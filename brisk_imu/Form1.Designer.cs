﻿
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
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.imuBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
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
            this.startBtn.Location = new System.Drawing.Point(555, 326);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(107, 37);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = false;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click_1);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(475, 326);
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
            this.SaveCheckBox.Location = new System.Drawing.Point(418, 346);
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
            this.imuBox.Location = new System.Drawing.Point(526, 19);
            this.imuBox.Name = "imuBox";
            this.imuBox.Size = new System.Drawing.Size(136, 246);
            this.imuBox.TabIndex = 10;
            this.imuBox.TabStop = false;
            this.imuBox.Text = "IMU";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 375);
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
    }
}

