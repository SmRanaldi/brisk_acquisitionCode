using ShimmerAPI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using Newtonsoft.Json;
using System.Xml.Schema;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            _imus = new ShimmerNetwork(_enabledSensors,102.4f, chart1);

            fetch_config();
            
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
                Environment.Exit(0);

            }
            if (_isConnectionOK)
            {
                ConnectBtn.Text = "Exit";
                startBtn.Enabled = true;
                AddBtn.Enabled = false;
                RemoveBtn.Enabled = false;
                shimmerListBox.Enabled = false;
                triggerGB.Enabled = false;
                button_sf.Enabled = false;
                Plot_btn.Enabled = false;
            }
            else
            {
                ConnectBtn.Text = "Connect";
                startBtn.Enabled = false;
                AddBtn.Enabled = true;
                RemoveBtn.Enabled = true;
                shimmerListBox.Enabled = true;
                triggerGB.Enabled = true;
                button_sf.Enabled = true;
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
                        Debug.WriteLine("Creating directory " + _baseFilename);
                        Directory.CreateDirectory(_baseFilename);
                    }
                    string imuFilename = DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace(":","");
                    imuFilename = _baseFilename + "\\imus_" + imuFilename;
                    Debug.WriteLine("Saving to path: " + imuFilename);
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
                saveFolder_TB.Text = "Saving to " + _directoryName;
            }
            else
            {
                _baseFilename = _seedFilename;
                saveFolder_TB.Text = "Saving to root";
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

        private void fetch_config()
        {
            dynamic _init_imu = JsonConvert.DeserializeObject(File.ReadAllText(_baseExePath + "\\settings\\imu_configs.json")); //can recall the JSON object if we need it as ex: _init_imu.arm
            var files = JObject.Parse(File.ReadAllText(_baseExePath + "\\settings\\imu_configss.json"));
            var recList = files.SelectTokens("IMU").ToList(); //JSON file written with a headline
            foreach (JObject obj in recList.Children())
            {
                foreach (JProperty prop in obj.Children())
                {
                    var _key = prop.Name.ToString(); //extract all the keys of the JSON as a string
                    var _value = prop.Value.ToString(); //extract all the value of the JSON as a string
                    shimmerListBox.Items.Add(_value);
                    Console.WriteLine(_key);
                    this.config_TB.AppendText(Environment.NewLine + _key + ": \t" + _value);
                }

            }
        }

        private void triggerCB_CheckedChanged(object sender, EventArgs e)
        {
            niDeviceTB.Enabled = !triggerCB.Checked;
            niPortTB.Enabled = !triggerCB.Checked;
        }
        

        private void SaveCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sampling_frq form3 = new Sampling_frq(_imus);
            form3.Show();

        }
      
        private void button1_Click_2(object sender, EventArgs e)
        {
            PlotSelection form4 = new PlotSelection(_imus);
            form4.Show();
        }
    }
}

