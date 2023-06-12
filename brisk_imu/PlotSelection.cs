using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace brisk_imu
{
    public partial class PlotSelection : Form
    {
        private ShimmerNetwork _newIMUS;


        public PlotSelection(ShimmerNetwork _imus)
        {
            _newIMUS = _imus;
            InitializeComponent();
            comboBox1.SelectedItem = Properties.Settings.Default.SelectedPlot;

            checkBox1.Checked = Properties.Settings.Default.CheckboxStatusx;
            checkBox2.Checked = Properties.Settings.Default.CheckboxStatusy;
            checkBox3.Checked = Properties.Settings.Default.CheckboxStatusz;

        }
        private void PlotSelection_Load(object sender, EventArgs e)
        {

        }

        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           string selectedValue = comboBox1.SelectedItem.ToString();
        
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
            Properties.Settings.Default.CheckboxStatusx = checkBox1.Checked;
            Properties.Settings.Default.CheckboxStatusy = checkBox2.Checked;
            Properties.Settings.Default.CheckboxStatusz = checkBox3.Checked;
            bool X = checkBox1.Checked;
            int x = Convert.ToInt32(X);
            bool Y = checkBox2.Checked;
            int y = Convert.ToInt32(Y);
            bool Z = checkBox3.Checked;
            int z = Convert.ToInt32(Z);
            int selectedIndex = comboBox1.SelectedIndex;
            _newIMUS.Plotcomponent(selectedIndex,x,y,z);

            Properties.Settings.Default.SelectedPlot = comboBox1.SelectedItem.ToString();
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
