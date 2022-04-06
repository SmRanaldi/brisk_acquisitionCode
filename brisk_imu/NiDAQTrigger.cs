using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NationalInstruments.DAQmx;

namespace brisk_imu
{
    class NiDAQTrigger
    {

        private string _devName;
        private string _portNumber;
        private string _portPath;

        public NiDAQTrigger(string devName, string portNumber)
        {
            _devName = devName;
            _portNumber = portNumber;
        }

        public void Initialize()
        {
            _portPath = _devName + "/Port" + _portNumber + "/line0:7";
            Stop();
        }

        public void Start()
        {
            using (Task digitalWriteTask = new Task())
            {
                digitalWriteTask.DOChannels.CreateChannel(_portPath, "",
                    ChannelLineGrouping.OneChannelForAllLines);
                bool[] dataArray = new bool[8];
                for(int i = 0; i < 8; i++)
                {
                    dataArray[i] = true;
                }
                DigitalSingleChannelWriter writer = new DigitalSingleChannelWriter(digitalWriteTask.Stream);
                writer.WriteSingleSampleMultiLine(true, dataArray);
            }
        }

        public void Stop()
        {
            using (Task digitalWriteTask = new Task())
            {
                digitalWriteTask.DOChannels.CreateChannel(_portPath, "",
                    ChannelLineGrouping.OneChannelForAllLines);
                bool[] dataArray = new bool[8];
                for (int i = 0; i < 8; i++)
                {
                    dataArray[i] = false;
                }
                DigitalSingleChannelWriter writer = new DigitalSingleChannelWriter(digitalWriteTask.Stream);
                writer.WriteSingleSampleMultiLine(true, dataArray);
            }
        }
    }
}
