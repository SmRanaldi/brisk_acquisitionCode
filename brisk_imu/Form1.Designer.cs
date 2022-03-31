
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
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
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.imuBox.SuspendLayout();
            this.triggerGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea5.AxisX.MajorGrid.Enabled = false;
            chartArea5.AxisY.MajorGrid.Enabled = false;
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(401, 253);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // startBtn
            // 
            this.startBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(255)))), ((int)(((byte)(64)))));
            this.startBtn.Enabled = false;
            this.startBtn.Location = new System.Drawing.Point(609, 326);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(107, 37);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = false;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click_1);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(529, 326);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(74, 37);
            this.ConnectBtn.TabIndex = 2;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // shimmerListBox
            // 
            this.shimmerListBox.FormattingEnabled = true;
            this.shimmerListBox.Location = new System.Drawing.Point(26, 74);
            this.shimmerListBox.Name = "shimmerListBox";
            this.shimmerListBox.Size = new System.Drawing.Size(96, 160);
            this.shimmerListBox.TabIndex = 3;
            this.shimmerListBox.SelectedIndexChanged += new System.EventHandler(this.shimmerListBox_SelectedIndexChanged);
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(53, 15);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(69, 23);
            this.AddBtn.TabIndex = 4;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.Enabled = false;
            this.RemoveBtn.Location = new System.Drawing.Point(53, 44);
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(69, 24);
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
            this.SaveCheckBox.Location = new System.Drawing.Point(472, 346);
            this.SaveCheckBox.Name = "SaveCheckBox";
            this.SaveCheckBox.Size = new System.Drawing.Size(51, 17);
            this.SaveCheckBox.TabIndex = 6;
            this.SaveCheckBox.Text = "Save";
            this.SaveCheckBox.UseVisualStyleBackColor = true;
            // 
            // filenameTB
            // 
            this.filenameTB.Location = new System.Drawing.Point(12, 343);
            this.filenameTB.Name = "filenameTB";
            this.filenameTB.Size = new System.Drawing.Size(113, 20);
            this.filenameTB.TabIndex = 7;
            // 
            // updateFilenameButton
            // 
            this.updateFilenameButton.Location = new System.Drawing.Point(131, 342);
            this.updateFilenameButton.Name = "updateFilenameButton";
            this.updateFilenameButton.Size = new System.Drawing.Size(53, 21);
            this.updateFilenameButton.TabIndex = 8;
            this.updateFilenameButton.Text = "Update";
            this.updateFilenameButton.UseVisualStyleBackColor = true;
            this.updateFilenameButton.Click += new System.EventHandler(this.updateFilenameButton_Click);
            // 
            // syncBtn
            // 
            this.syncBtn.Location = new System.Drawing.Point(190, 342);
            this.syncBtn.Name = "syncBtn";
            this.syncBtn.Size = new System.Drawing.Size(53, 21);
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
            this.imuBox.Location = new System.Drawing.Point(580, 19);
            this.imuBox.Name = "imuBox";
            this.imuBox.Size = new System.Drawing.Size(136, 246);
            this.imuBox.TabIndex = 10;
            this.imuBox.TabStop = false;
            this.imuBox.Text = "IMU";
            // 
            // triggerCB
            // 
            this.triggerCB.AutoSize = true;
            this.triggerCB.Checked = true;
            this.triggerCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.triggerCB.Location = new System.Drawing.Point(35, 89);
            this.triggerCB.Name = "triggerCB";
            this.triggerCB.Size = new System.Drawing.Size(65, 17);
            this.triggerCB.TabIndex = 11;
            this.triggerCB.Text = "Enabled";
            this.triggerCB.UseVisualStyleBackColor = true;
            this.triggerCB.CheckedChanged += new System.EventHandler(this.triggerCB_CheckedChanged);
            // 
            // niDeviceTB
            // 
            this.niDeviceTB.Location = new System.Drawing.Point(35, 34);
            this.niDeviceTB.Name = "niDeviceTB";
            this.niDeviceTB.Size = new System.Drawing.Size(65, 20);
            this.niDeviceTB.TabIndex = 12;
            this.niDeviceTB.Text = "Dev1";
            // 
            // triggerGB
            // 
            this.triggerGB.Controls.Add(this.niPortTB);
            this.triggerGB.Controls.Add(this.niDeviceTB);
            this.triggerGB.Controls.Add(this.triggerCB);
            this.triggerGB.Location = new System.Drawing.Point(459, 19);
            this.triggerGB.Name = "triggerGB";
            this.triggerGB.Size = new System.Drawing.Size(106, 112);
            this.triggerGB.TabIndex = 13;
            this.triggerGB.TabStop = false;
            this.triggerGB.Text = "Trigger";
            // 
            // niPortTB
            // 
            this.niPortTB.Location = new System.Drawing.Point(35, 60);
            this.niPortTB.Name = "niPortTB";
            this.niPortTB.Size = new System.Drawing.Size(65, 20);
            this.niPortTB.TabIndex = 13;
            this.niPortTB.Text = "1";
            // 
            // config_TB
            // 
            this.config_TB.AcceptsReturn = true;
            this.config_TB.BackColor = System.Drawing.SystemColors.Menu;
            this.config_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.config_TB.Location = new System.Drawing.Point(459, 167);
            this.config_TB.Multiline = true;
            this.config_TB.Name = "config_TB";
            this.config_TB.ReadOnly = true;
            this.config_TB.Size = new System.Drawing.Size(106, 97);
            this.config_TB.TabIndex = 14;
            this.config_TB.Text = "IMU Config:";
            // 
            // saveFolder_TB
            // 
            this.saveFolder_TB.BackColor = System.Drawing.SystemColors.Control;
            this.saveFolder_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveFolder_TB.Location = new System.Drawing.Point(13, 317);
            this.saveFolder_TB.Name = "saveFolder_TB";
            this.saveFolder_TB.ReadOnly = true;
            this.saveFolder_TB.Size = new System.Drawing.Size(230, 19);
            this.saveFolder_TB.TabIndex = 15;
            this.saveFolder_TB.Text = "Saving to root";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 375);
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
    }
}

