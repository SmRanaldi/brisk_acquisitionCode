using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

using ShimmerAPI;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using System.IO;

namespace brisk_imu
{
    public class ShimmerNetwork : SensorNetworkClass
    {

        // Buffers
        private Dictionary<string, Matrix<double>> _buffer = new Dictionary<string, Matrix<double>>();
        private Dictionary<string, Queue<double>> _bufferTimestamp = new Dictionary<string, Queue<double>>();
        private Dictionary<string, Queue<double>> _plotQueue = new Dictionary<string, Queue<double>>();

        // Utils
        private Dictionary<string, int> _samplesInBuffer = new Dictionary<string, int>();
        private int _pointsInPlot = 0;
        private int _basePlotBuffer = 200;
        private int _plotBuffer = 0;

        // Sensors to enable
        private List<string> _shimmerToEnable = new List<string>();
        private int _sensorsToEnable;
        private List<ShimmerLogAndStream32Feet> _shimmerList = new List<ShimmerLogAndStream32Feet>();

        // Output filename
        private string _outputFilename;

        // Base string for MAC address
        private readonly string _MACBase = "00:06:66:79";

        // Constructors

        public ShimmerNetwork(int enabledSensors, float frequency, Chart plotChart)
        {
            _sensorsToEnable = enabledSensors;
            NChannels = 3 * NSensors;
            SamplingFrequency = frequency;
            BufferLength = 200;
            BaseChart = plotChart;
            UpdateThread = new Thread(UpdatePlotFunction);
            UpdateThread.IsBackground = true;
            UpdateThread.Start();
            BaseChart.ChartAreas[0].AxisY.Maximum = 30;
            BaseChart.ChartAreas[0].AxisY.Minimum = -30;
        }

        public ShimmerNetwork(int enabledSensors, float frequency, Chart plotChart, string filename) : 
            this(enabledSensors, frequency, plotChart)
        {
            _outputFilename = filename;
        }

        // Interface methods
        public override void Initialize()
        {
            foreach (var sh in _shimmerToEnable)
            {
                string MAC = _MACBase + ":" + sh.Remove(2) + ":" + sh.Substring(2);
                _shimmerList.Add(new ShimmerLogAndStream32Feet(sh, MAC));
                if (!_samplesInBuffer.ContainsKey(sh))
                {
                    _samplesInBuffer.Add(sh, 0);
                    _plotQueue.Add(sh, new Queue<double>());
                    _bufferTimestamp.Add(sh, new Queue<double>());
                }
                else
                {
                    _samplesInBuffer[sh] = 0;
                    _plotQueue[sh].Clear();
                    _bufferTimestamp[sh].Clear();
                }
            }

            foreach (ShimmerLogAndStream32Feet sh in _shimmerList)
            {
                int c = 0;
                while (c < 10) {
                    sh.Connect();
                    if (sh.IsConnected())
                    {
                        sh.UICallback += HandleShimmerDataPoints;
                        sh.WriteSamplingRate(SamplingFrequency);
                        sh.WriteSensors(_sensorsToEnable);
                        sh.Set3DOrientation(true);
                        sh.writeRealWorldClock(); // Explicitely sets the real world clock
                        Console.WriteLine("Shimmer " + sh.GetDeviceName() + " connected.");
                        c = 10;
                        sh.StartStreaming();
                    }
                    else
                    {
                        // new Exception("Shimmer " + sh.GetDeviceName() + " failed to connect.");
                        Console.WriteLine("Shimmer " + sh.GetDeviceName() + " failed to connect.");
                        c++;
                    }
                }
            }
        }

        public override void Start()
        {
            Console.WriteLine("Acquisition started.");
            _isRunning = true;
        }

        public override void Stop()
        {
            _isRunning = false;
            foreach (ShimmerLogAndStream32Feet sh in _shimmerList)
            {
                string id = sh.GetDeviceName();
                
                if (_outputFilename != null)
                {
                    DumpData(id);
                }
                BaseChart.Series[id].Points.Clear();
                _samplesInBuffer[id] = 0;
                _buffer.Remove(id);
                _plotQueue[id].Clear();
            }
            _pointsInPlot = 0;
            Console.WriteLine("Acquisition stopped.");
        }

        public override void Disconnect()
        {
            if (_isRunning)
            {
                Stop();
            }
            foreach (ShimmerLogAndStream32Feet sh in _shimmerList)
            {
                sh.StopStreaming();
                sh.Disconnect();
            }
            _shimmerList.Clear();
            _plotQueue.Clear();
            BaseChart.Series.Clear();
            Console.WriteLine("All shimmers disconnected");
        }

        public override void DumpData(string ID)
        {
            string filename = _outputFilename + "_" + ID + ".csv";
            string outputString = "";

            using (StreamWriter writetext = new StreamWriter(filename, append: true))
            {
                for (int i = 0; i < _buffer[ID].ColumnCount; i++)
                {
                    outputString = _bufferTimestamp[ID].Dequeue().ToString() + ", ";
                    for (int j = 0; j < _buffer[ID].RowCount; j++)
                    {
                        outputString += _buffer[ID][j, i].ToString() + ", ";
                    }
                    //Console.WriteLine("!" + outputString);
                    writetext.WriteLine(outputString.Remove(outputString.Length - 2));
                }
            }
        }

        public override void AddSensor(string ID)
        {
            if (ID.Length != 4)
            {
                Console.WriteLine("Invalid name for shimmer " + ID);
                throw new Exception("Invalid name for shimmer " + ID);
            }
            else
            {
                _shimmerToEnable.Add(ID);
                NSensors = _shimmerToEnable.Count();

                BaseChart.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series(ID));
                BaseChart.Series[ID].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                BaseChart.Series[ID].IsValueShownAsLabel = false;
                BaseChart.Series[ID].SmartLabelStyle.Enabled = false;
                _plotBuffer = _basePlotBuffer * NSensors;
                BaseChart.ChartAreas[0].AxisX.Maximum = _plotBuffer / NSensors;

                Console.WriteLine("Shimmer " + ID + " added.");
            }
        }

        // AuxiliaryMethods
        public void ClearAllSensors()
        {
            _shimmerToEnable.Clear();
        }

        public void SetFilename(string filenameIn)
        {
            _outputFilename = filenameIn;
        }

        public void SetSamplingRate(float frequency)
        {
            SamplingFrequency = frequency;
            foreach(ShimmerLogAndStream32Feet sh in _shimmerList)
            {
                sh.WriteSamplingRate(SamplingFrequency);
            }
        }

        public bool IsEnabled(string ID)
        {
            bool isIDEnabled = false;

            foreach(string enabledID in _shimmerToEnable)
            {
                isIDEnabled = isIDEnabled | String.Equals(enabledID, ID);
            }

            return isIDEnabled;
        }

        void HandleShimmerDataPoints(object sender, EventArgs e)
        {
            List<double> tmpBuff = new List<double>();
            int lenCurrentData;
            double tmpTimeStamp;

            CustomEventArgs eventArgs = (CustomEventArgs)e;
            int indicator = eventArgs.getIndicator();
            if (indicator == (int)ShimmerBluetooth.ShimmerIdentifier.MSG_IDENTIFIER_DATA_PACKET)
            {
                ObjectCluster oC = (ObjectCluster)eventArgs.getObject();
                List<double> currentData = oC.GetData();
                //tmpTimeStamp = (long)(DateTime.Now.Ticks / 10000); // From ticks to milliseconds
                if (_isRunning)
                {
                    if (currentData != null)
                    {
                        string ID = oC.GetShimmerID();
                        lenCurrentData = currentData.Count();
                        tmpTimeStamp = oC.GetData(ShimmerConfiguration.SignalNames.SYSTEM_TIMESTAMP, "CAL").Data; // Get the timestamp from shimmer
                        int i = 4;
                        while (i < lenCurrentData)
                        {
                            tmpBuff.Add(currentData[i]);
                            i += 2;
                        }
                        if (_samplesInBuffer[ID] == 0)
                        {
                            _buffer.Add(ID, Matrix<double>.Build.DenseOfColumnArrays(tmpBuff.ToArray()));
                            _bufferTimestamp[ID].Enqueue(tmpTimeStamp);
                            _plotQueue[ID].Enqueue(tmpBuff[0]);
                            _samplesInBuffer[ID]++;
                        }
                        else
                        {
                            _buffer[ID] = _buffer[ID].Append(Matrix<double>.Build.DenseOfColumnArrays(tmpBuff.ToArray()));
                            _bufferTimestamp[ID].Enqueue(tmpTimeStamp);
                            _plotQueue[ID].Enqueue(tmpBuff[0]);
                            _samplesInBuffer[ID]++;
                            Console.WriteLine(_buffer[ID].RowCount.ToString());
                        }
                        if (_samplesInBuffer[ID] == BufferLength)
                        {
                            if (_outputFilename != null)
                            {
                                DumpData(ID);
                            }
                            _buffer.Remove(ID);
                            if (_bufferTimestamp.Count() > 0)
                            {
                                _bufferTimestamp[ID].Clear();
                            }
                            _samplesInBuffer[ID] = 0;
                        }
                    }
                }
            }

        }

        void UpdatePlotFunction()
        {
            double pointToPlot;
            string ID;
            while (true)
            {
                if (_isRunning)
                {
                    foreach (var sh in _shimmerToEnable)
                    {
                        ID = sh;
                        if (_plotQueue[ID].Count > 0)
                        {
                            pointToPlot = _plotQueue[ID].Dequeue();
                            BaseChart.Invoke(new Action(delegate
                            {
                                if (_pointsInPlot < _plotBuffer)
                                {
                                    BaseChart.Series[sh].Points.Add(pointToPlot);
                                    _pointsInPlot++;
                                }
                                else
                                {
                                    BaseChart.Series[sh].Points.RemoveAt(0);
                                    BaseChart.Series[sh].Points.Add(pointToPlot);
                                }
                            }));
                        }
                    }
                }
            }
        }

    }
}