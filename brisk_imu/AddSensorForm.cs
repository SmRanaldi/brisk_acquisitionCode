using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace brisk_imu
{
    public partial class AddSensorForm : Form
    {
        private ListBox _listBox;

        public AddSensorForm(ListBox listBox)
        {
            _listBox = listBox;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputID = ShimmerIDTB.Text.ToUpper();
            if(inputID.Length == 4)
            {
                if (!_listBox.Items.Contains(inputID))
                {
                    _listBox.Items.Add(inputID);
                }
            }
            this.Close();
        }
    }
}
