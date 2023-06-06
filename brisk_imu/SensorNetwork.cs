using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace brisk_imu
{
    interface ISensorNetwork
    {

        // Methods
        void Initialize();
        void Disconnect();
        void Start();
        void Stop();
        void DumpData(string ID);
        void AddSensor(string ID);
    }

    public abstract class SensorNetworkClass : ISensorNetwork
    {
        public int NChannels { get; set; }
        public int NSensors { get; set; }
        public int BufferLength { get; set; }

        public float SamplingFrequency { get; set; }
        public int _sensorsToEnable { get; set; }

        public Thread UpdateThread { get; set; }
        public Chart BaseChart { get; set; }

        protected bool _isRunning = false;

        // The constructor
        public SensorNetworkClass() { }

        // Interface Methods
        public virtual void Initialize()
        {
            throw new NotImplementedException();
        }
        public virtual void Disconnect()
        {
            throw new NotImplementedException();
        }
        public virtual void Start()
        {
            throw new NotImplementedException();
        }
        public virtual void Stop()
        {
            throw new NotImplementedException();
        }
        public virtual void DumpData(string ID)
        {
            throw new NotImplementedException();
        }
        public virtual void AddSensor(string ID)
        {
            throw new NotImplementedException();
        }

    }
}
