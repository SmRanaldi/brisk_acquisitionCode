
namespace brisk_imu
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.startBtn = new System.Windows.Forms.Button();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.shimmerListBox = new System.Windows.Forms.ListBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.RemoveBtn = new System.Windows.Forms.Button();
            this.SaveCheckBox = new System.Windows.Forms.CheckBox();
            this.filenameTB = new System.Windows.Forms.TextBox();
            this.updateFilenameButton = new System.Windows.Forms.Button();
            this.syncBtn = new System.Windows.Forms.Button();
            this.imuBox = new System.Windows.Forms.GroupBox();
            this.triggerCB = new System.Windows.Forms.CheckBox();
            this.niDeviceTB = new System.Windows.Forms.TextBox();
            this.triggerGB = new System.Windows.Forms.GroupBox();
            this.niPortTB = new System.Windows.Forms.TextBox();
            this.config_TB = new System.Windows.Forms.TextBox();
            this.saveFolder_TB = new System.Windows.Forms.TextBox();
            this.button_sf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.imuBox.SuspendLayout();
            this.triggerGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(16, 15);
            this.chart1.Margin = new System.Windows.Forms.Padding(4);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(535, 311);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // startBtn
            // 
            this.startBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(255)))), ((int)(((byte)(64)))));
            this.startBtn.Enabled = false;
            this.startBtn.Location = new System.Drawing.Point(812, 401);
            this.startBtn.Margin = new System.Windows.Forms.Padding(4);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(143, 46);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = false;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click_1);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(705, 401);
            this.ConnectBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(99, 46);
            this.ConnectBtn.TabIndex = 2;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // shimmerListBox
            // 
            this.shimmerListBox.FormattingEnabled = true;
            this.shimmerListBox.ItemHeight = 16;
            this.shimmerListBox.Location = new System.Drawing.Point(35, 91);
            this.shimmerListBox.Margin = new System.Windows.Forms.Padding(4);
            this.shimmerListBox.Name = "shimmerListBox";
            this.shimmerListBox.Size = new System.Drawing.Size(127, 196);
            this.shimmerListBox.TabIndex = 3;
            this.shimmerListBox.SelectedIndexChanged += new System.EventHandler(this.shimmerListBox_SelectedIndexChanged);
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(71, 18);
            this.AddBtn.Margin = new System.Windows.Forms.Padding(4);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(92, 28);
            this.AddBtn.TabIndex = 4;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.Enabled = false;
            this.RemoveBtn.Location = new System.Drawing.Point(71, 54);
            this.RemoveBtn.Margin = new System.Windows.Forms.Padding(4);
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(92, 30);
            this.RemoveBtn.TabIndex = 5;
            this.RemoveBtn.Text = "Remove";
            this.RemoveBtn.UseVisualStyleBackColor = true;
            this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
            // 
            // SaveCheckBox
            // 
            this.SaveCheckBox.AutoSize = true;
            this.SaveCheckBox.Checked = true;
            this.SaveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SaveCheckBox.Location = new System.Drawing.Point(363, 392);
            this.SaveCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.SaveCheckBox.Name = "SaveCheckBox";
            this.SaveCheckBox.Size = new System.Drawing.Size(61, 20);
            this.SaveCheckBox.TabIndex = 6;
            this.SaveCheckBox.Text = "Save";
            this.SaveCheckBox.UseVisualStyleBackColor = true;
            // 
            // filenameTB
            // 
            this.filenameTB.Location = new System.Drawing.Point(16, 422);
            this.filenameTB.Margin = new System.Windows.Forms.Padding(4);
            this.filenameTB.Name = "filenameTB";
            this.filenameTB.Size = new System.Drawing.Size(149, 22);
            this.filenameTB.TabIndex = 7;
            // 
            // updateFilenameButton
            // 
            this.updateFilenameButton.Location = new System.Drawing.Point(175, 421);
            this.updateFilenameButton.Margin = new System.Windows.Forms.Padding(4);
            this.updateFilenameButton.Name = "updateFilenameButton";
            this.updateFilenameButton.Size = new System.Drawing.Size(71, 26);
            this.updateFilenameButton.TabIndex = 8;
            this.updateFilenameButton.Text = "Update";
            this.updateFilenameButton.UseVisualStyleBackColor = true;
            this.updateFilenameButton.Click += new System.EventHandler(this.updateFilenameButton_Click);
            // 
            // syncBtn
            // 
            this.syncBtn.Location = new System.Drawing.Point(253, 421);
            this.syncBtn.Margin = new System.Windows.Forms.Padding(4);
            this.syncBtn.Name = "syncBtn";
            this.syncBtn.Size = new System.Drawing.Size(71, 26);
            this.syncBtn.TabIndex = 9;
            this.syncBtn.Text = "Sync";
            this.syncBtn.UseVisualStyleBackColor = true;
            this.syncBtn.Click += new System.EventHandler(this.syncBtn_Click);
            // 
            // imuBox
            // 
            this.imuBox.Controls.Add(this.RemoveBtn);
            this.imuBox.Controls.Add(this.AddBtn);
            this.imuBox.Controls.Add(this.shimmerListBox);
            this.imuBox.Location = new System.Drawing.Point(773, 23);
            this.imuBox.Margin = new System.Windows.Forms.Padding(4);
            this.imuBox.Name = "imuBox";
            this.imuBox.Padding = new System.Windows.Forms.Padding(4);
            this.imuBox.Size = new System.Drawing.Size(181, 303);
            this.imuBox.TabIndex = 10;
            this.imuBox.TabStop = false;
            this.imuBox.Text = "IMU";
            // 
            // triggerCB
            // 
            this.triggerCB.AutoSize = true;
            this.triggerCB.Location = new System.Drawing.Point(47, 110);
            this.triggerCB.Margin = new System.Windows.Forms.Padding(4);
            this.triggerCB.Name = "triggerCB";
            this.triggerCB.Size = new System.Drawing.Size(80, 20);
            this.triggerCB.TabIndex = 11;
            this.triggerCB.Text = "Enabled";
            this.triggerCB.UseVisualStyleBackColor = true;
            this.triggerCB.CheckedChanged += new System.EventHandler(this.triggerCB_CheckedChanged);
            // 
            // niDeviceTB
            // 
            this.niDeviceTB.Location = new System.Drawing.Point(47, 42);
            this.niDeviceTB.Margin = new System.Windows.Forms.Padding(4);
            this.niDeviceTB.Name = "niDeviceTB";
            this.niDeviceTB.Size = new System.Drawing.Size(85, 22);
            this.niDeviceTB.TabIndex = 12;
            this.niDeviceTB.Text = "Dev1";
            // 
            // triggerGB
            // 
            this.triggerGB.Controls.Add(this.niPortTB);
            this.triggerGB.Controls.Add(this.niDeviceTB);
            this.triggerGB.Controls.Add(this.triggerCB);
            this.triggerGB.Location = new System.Drawing.Point(612, 23);
            this.triggerGB.Margin = new System.Windows.Forms.Padding(4);
            this.triggerGB.Name = "triggerGB";
            this.triggerGB.Padding = new System.Windows.Forms.Padding(4);
            this.triggerGB.Size = new System.Drawing.Size(141, 138);
            this.triggerGB.TabIndex = 13;
            this.triggerGB.TabStop = false;
            this.triggerGB.Text = "Trigger";
            // 
            // niPortTB
            // 
            this.niPortTB.Location = new System.Drawing.Point(47, 74);
            this.niPortTB.Margin = new System.Windows.Forms.Padding(4);
            this.niPortTB.Name = "niPortTB";
            this.niPortTB.Size = new System.Drawing.Size(85, 22);
            this.niPortTB.TabIndex = 13;
            this.niPortTB.Text = "1";
            // 
            // config_TB
            // 
            this.config_TB.AcceptsReturn = true;
            this.config_TB.BackColor = System.Drawing.SystemColors.Menu;
            this.config_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.config_TB.Location = new System.Drawing.Point(612, 169);
            this.config_TB.Margin = new System.Windows.Forms.Padding(4);
            this.config_TB.Multiline = true;
            this.config_TB.Name = "config_TB";
            this.config_TB.ReadOnly = true;
            this.config_TB.Size = new System.Drawing.Size(140, 155);
            this.config_TB.TabIndex = 14;
            this.config_TB.Text = "IMU Config:";
            // 
            // saveFolder_TB
            // 
            this.saveFolder_TB.BackColor = System.Drawing.SystemColors.Control;
            this.saveFolder_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveFolder_TB.Location = new System.Drawing.Point(17, 390);
            this.saveFolder_TB.Margin = new System.Windows.Forms.Padding(4);
            this.saveFolder_TB.Name = "saveFolder_TB";
            this.saveFolder_TB.ReadOnly = true;
            this.saveFolder_TB.Size = new System.Drawing.Size(305, 22);
            this.saveFolder_TB.TabIndex = 15;
            this.saveFolder_TB.Text = "Saving to root";
            // 
            // button_sf
            // 
            this.button_sf.Location = new System.Drawing.Point(617, 328);
            this.button_sf.Name = "button_sf";
            this.button_sf.Size = new System.Drawing.Size(127, 34);
            this.button_sf.TabIndex = 17;
            this.button_sf.Text = "Configuration";
            this.button_sf.UseVisualStyleBackColor = true;
            this.button_sf.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 462);
            this.Controls.Add(this.button_sf);
            this.Controls.Add(this.saveFolder_TB);
            this.Controls.Add(this.config_TB);
            this.Controls.Add(this.triggerGB);
            this.Controls.Add(this.imuBox);
            this.Controls.Add(this.syncBtn);
            this.Controls.Add(this.updateFilenameButton);
            this.Controls.Add(this.filenameTB);
            this.Controls.Add(this.SaveCheckBox);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.chart1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "BRISK Data Acquisition";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.imuBox.ResumeLayout(false);
            this.triggerGB.ResumeLayout(false);
            this.triggerGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.ListBox shimmerListBox;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button RemoveBtn;
        private System.Windows.Forms.CheckBox SaveCheckBox;
        private System.Windows.Forms.TextBox filenameTB;
        private System.Windows.Forms.Button updateFilenameButton;
        private System.Windows.Forms.Button syncBtn;
        private System.Windows.Forms.GroupBox imuBox;
        private System.Windows.Forms.CheckBox triggerCB;
        private System.Windows.Forms.TextBox niDeviceTB;
        private System.Windows.Forms.GroupBox triggerGB;
        private System.Windows.Forms.TextBox niPortTB;
        private System.Windows.Forms.TextBox config_TB;
        private System.Windows.Forms.TextBox saveFolder_TB;
        private System.Windows.Forms.Button button_sf;
    }
}

