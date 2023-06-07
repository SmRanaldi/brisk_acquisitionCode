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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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

            checkBox1.Checked = Properties.Settings.Default.CheckboxStatus1;
            checkBox2.Checked = Properties.Settings.Default.CheckboxStatus2;
            checkBox3.Checked = Properties.Settings.Default.CheckboxStatus3;
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
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
        Properties.Settings.Default.CheckboxStatus1 = checkBox1.Checked;
        Properties.Settings.Default.CheckboxStatus2 = checkBox2.Checked;
        Properties.Settings.Default.CheckboxStatus3 = checkBox3.Checked;
            bool A = checkBox1.Checked;
            int a = Convert.ToInt32(A);
            bool G = checkBox2.Checked;
            int g = Convert.ToInt32(G);
            bool M = checkBox3.Checked;
            int m = Convert.ToInt32(M);
            _newIMUS.SetSensors(a, g, m);

            Properties.Settings.Default.SelectedFrequency = comboBox1.SelectedItem.ToString();
            Properties.Settings.Default.Save();
            
            this.Close();
        }
    }
}
