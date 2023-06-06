using ShimmerAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ShimmerAPI.ShimmerBluetooth;

namespace brisk_imu
{
    public partial class Sampling_frq : Form
    {
        private ShimmerNetwork _newIMUS;


        public Sampling_frq(ShimmerNetwork _imus)
        {
            _newIMUS = _imus;
            InitializeComponent();
            
            comboBox1.SelectedItem = Properties.Settings.Default.SelectedFrequency;
           /* checkBox1.Checked = Properties.Settings.Default.CheckboxStatus1;
            checkBox2.Checked = Properties.Settings.Default.CheckboxStatus2;
            checkBox3.Checked = Properties.Settings.Default.CheckboxStatus3;*/
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboBox1.SelectedItem.ToString();
           
            float returnValue = float.Parse(selectedValue); 
            _newIMUS.SetSamplingRate(returnValue);
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked & !checkBox2.Checked & !checkBox3.Checked)
            {
                 int _SetSensor = ((int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_A_ACCEL);
                _newIMUS.SetSensors(_SetSensor);

            }
            else if (checkBox1.Checked & checkBox2.Checked & !checkBox3.Checked)
            {
                int _SetSensor = ((int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_A_ACCEL |
           (int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_MPU9150_GYRO);
                _newIMUS.SetSensors(_SetSensor);

            }
            else if (checkBox1.Checked & !checkBox2.Checked & checkBox3.Checked)
            {
                int _SetSensor = ((int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_A_ACCEL |
            (int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_LSM303DLHC_MAG);
                _newIMUS.SetSensors(_SetSensor);
            }
            else if (checkBox1.Checked & checkBox2.Checked & checkBox3.Checked)
            {
               int _SetSensor = ((int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_A_ACCEL |
             (int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_MPU9150_GYRO |
             (int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_LSM303DLHC_MAG);
                _newIMUS.SetSensors(_SetSensor);
            }
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked & checkBox2.Checked & !checkBox3.Checked)
            {
                int _SetSensor = ((int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_MPU9150_GYRO);
                _newIMUS.SetSensors(_SetSensor);
            }
            else if (checkBox1.Checked & checkBox2.Checked & !checkBox3.Checked)
            {
                int _SetSensor = ((int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_A_ACCEL |
           (int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_MPU9150_GYRO);
                _newIMUS.SetSensors(_SetSensor);
            }
            else if (!checkBox1.Checked & checkBox2.Checked & checkBox3.Checked)
            {
                int _SetSensor = ((int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_MPU9150_GYRO |
            (int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_LSM303DLHC_MAG);
                _newIMUS.SetSensors(_SetSensor);
            }
            else if (checkBox1.Checked & checkBox2.Checked & checkBox3.Checked)
            {
                int _SetSensor = ((int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_A_ACCEL |
              (int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_MPU9150_GYRO |
              (int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_LSM303DLHC_MAG);
                _newIMUS.SetSensors(_SetSensor);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked & !checkBox2.Checked & checkBox3.Checked)
            {
                int _SetSensor = ((int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_LSM303DLHC_MAG);
                _newIMUS.SetSensors(_SetSensor);
            }
            else if (checkBox1.Checked & !checkBox2.Checked & checkBox3.Checked)
            {
                int _SetSensor = ((int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_A_ACCEL |
           (int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_LSM303DLHC_MAG);
                _newIMUS.SetSensors(_SetSensor);
            }
            else if (!checkBox1.Checked & checkBox2.Checked & checkBox3.Checked)
            {
                int _SetSensor = ((int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_MPU9150_GYRO |
            (int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_LSM303DLHC_MAG);
                _newIMUS.SetSensors(_SetSensor);
            }
            else if (checkBox1.Checked & checkBox2.Checked & checkBox3.Checked)
            {
                int _SetSensor = ((int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_A_ACCEL |
             (int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_MPU9150_GYRO |
             (int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_LSM303DLHC_MAG);
                _newIMUS.SetSensors(_SetSensor);
            }
            
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            /*Properties.Settings.Default.CheckboxStatus1 = checkBox1.Checked;
            Properties.Settings.Default.CheckboxStatus2 = checkBox2.Checked;
            Properties.Settings.Default.CheckboxStatus3 = checkBox3.Checked;*/
           
            Properties.Settings.Default.SelectedFrequency = comboBox1.SelectedItem.ToString();
            Properties.Settings.Default.Save();
            
            this.Close();
        }
    }
}
