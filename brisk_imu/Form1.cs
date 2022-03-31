using ShimmerAPI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using Newtonsoft.Json;

namespace brisk_imu
{
    public partial class Form1 : Form
    {
        // Aux
        private bool _isConnectionOK = false;
        private bool _isStarted = false;
        //private string _baseFilename = "C:\\Users\\smran\\Desktop\\Test_SynAcq\\imus_";
        private string _baseExePath = Path.GetDirectoryName(Application.ExecutablePath);
        private string _baseFilename = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\briskAcquisitionData";
        private string _seedFilename = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\briskAcquisitionData";
        private string _directoryName;

        // Sensors info
        private int _enabledSensors = ((int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_A_ACCEL |
            (int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_MPU9150_GYRO |
            (int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_LSM303DLHC_MAG);

        // Sensors
        private ShimmerNetwork _imus;
        private NiDAQTrigger _niTrigger;

        public Form1()
        {
            InitializeComponent();

            startBtn.BackColor = Color.Lime;
            startBtn.Enabled = false;

            _imus = new ShimmerNetwork(_enabledSensors, 102.4f, chart1);

            dynamic _init_imu = JsonConvert.DeserializeObject(File.ReadAllText(_baseExePath+"\\settings\\imu_configs.json"));

        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            if (!_isConnectionOK)
            {
                foreach (string ID in shimmerListBox.Items)
                {
                    _imus.AddSensor(ID);
                }
                _imus.Initialize();
                if (triggerCB.Checked)
                {
                    _niTrigger = new NiDAQTrigger(niDeviceTB.Text, niPortTB.Text);
                    triggerCB.Enabled = false;
                    _niTrigger.Initialize();
                }
                _isConnectionOK = true;
            }
            else
            {
                _imus.Disconnect();
                if (triggerCB.Checked)
                {
                    triggerCB.Enabled = true;
                }
                _isConnectionOK = false;

            }
            if (_isConnectionOK)
            {
                ConnectBtn.Text = "Disconnect";
                startBtn.Enabled = true;
                AddBtn.Enabled = false;
                RemoveBtn.Enabled = false;
                shimmerListBox.Enabled = false;
                triggerGB.Enabled = false;
            }
            else
            {
                ConnectBtn.Text = "Connect";
                startBtn.Enabled = false;
                AddBtn.Enabled = true;
                RemoveBtn.Enabled = true;
                shimmerListBox.Enabled = true;
                triggerGB.Enabled = true;
            }
        }

        private void startBtn_Click_1(object sender, EventArgs e)
        {
            if (!_isStarted)
            {
                if (SaveCheckBox.Checked)
                {
                    if (!Directory.Exists(_baseFilename))
                    {
                        Console.WriteLine("Creating directory " + _baseFilename);
                        Directory.CreateDirectory(_baseFilename);
                    }
                    string imuFilename = DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace(":","");
                    imuFilename = _baseFilename + "\\imus_" + imuFilename;
                    Console.WriteLine("Saving to path: " + imuFilename);
                    _imus.SetFilename(imuFilename);
                }
                _imus.Start();
                if (triggerCB.Checked)
                {
                    _niTrigger.Start();
                }
                _isStarted = true;
                startBtn.BackColor = Color.Crimson;
                startBtn.Text = "Stop";
                ConnectBtn.Enabled = false;
                updateFilenameButton.Enabled = false;
                filenameTB.Text = _directoryName;
                filenameTB.Enabled = false;
                SaveCheckBox.Enabled = false;
            }
            else
            {
                if (triggerCB.Checked)
                {
                    _niTrigger.Stop();
                }
                _imus.Stop();
                _isStarted = false;
                syncFcn();
                startBtn.BackColor = Color.Lime;
                startBtn.Text = "Start";
                ConnectBtn.Enabled = true;
                updateFilenameButton.Enabled = true;
                filenameTB.Enabled = true;
                SaveCheckBox.Enabled = true;
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            _imus.ClearAllSensors();
            AddSensorForm frm = new AddSensorForm(shimmerListBox);
            frm.Show();
        }

        private void shimmerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (shimmerListBox.Items.Count > 0)
            {
                RemoveBtn.Enabled = true;
            }
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            shimmerListBox.Items.RemoveAt(shimmerListBox.SelectedIndex);
            if(shimmerListBox.Items.Count == 0)
            {
                RemoveBtn.Enabled = false;
            }
        }

        private void updateFilenameButton_Click(object sender, EventArgs e)
        {
            if (filenameTB.Text.Length > 0)
            {
                _directoryName = filenameTB.Text;
                _baseFilename = _seedFilename + "\\" + _directoryName;
            }
        }

        private void syncBtn_Click(object sender, EventArgs e)
        {
            syncFcn();
        }

        private void syncFcn()
        {
            ProcessStartInfo strt = new ProcessStartInfo();
            Process prc = new Process();

            if (filenameTB.Text.Length > 0)
            {
                _directoryName = filenameTB.Text;
                _baseFilename = _seedFilename + "\\" + _directoryName;
            }

            string mainDir = new FileInfo(Assembly.GetEntryAssembly().Location).Directory.ToString();
            string pyFile = mainDir + "\\utils\\sync_acquisition.py";
            pyFile = "\"" + pyFile + "\"";
            string cmdText = "\"" + _baseFilename + "\"";

            strt.FileName = "cmd.exe";
            strt.UseShellExecute = false;
            strt.RedirectStandardInput = true;
            strt.RedirectStandardOutput = false;
            strt.CreateNoWindow = true;
            prc.StartInfo = strt;
            prc.Start();
            using (var sw = prc.StandardInput)
            {
                sw.WriteLine("conda activate base");
                sw.WriteLine("python " + pyFile + " " + cmdText);
            }
        }

        private void triggerCB_CheckedChanged(object sender, EventArgs e)
        {
            niDeviceTB.Enabled = !triggerCB.Checked;
            niPortTB.Enabled = !triggerCB.Checked;
        }
    }
}
