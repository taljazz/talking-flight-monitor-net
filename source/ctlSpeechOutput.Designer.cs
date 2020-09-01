namespace tfm
{
    partial class ctlSpeechOutput
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chkUseSAPI = new System.Windows.Forms.CheckBox();
            this.chkReadInstrumentation = new System.Windows.Forms.CheckBox();
            this.chkReadSimconnectMessages = new System.Windows.Forms.CheckBox();
            this.chkFlightFollowing = new System.Windows.Forms.CheckBox();
            this.chkReadGPWS = new System.Windows.Forms.CheckBox();
            this.chkReadILS = new System.Windows.Forms.CheckBox();
            this.chkReadGroundSpeed = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chkReadGroundSpeed, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkReadILS, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkReadGPWS, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkFlightFollowing, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkReadSimconnectMessages, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkReadInstrumentation, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkUseSAPI, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chkUseSAPI
            // 
            this.chkUseSAPI.AutoSize = true;
            this.chkUseSAPI.Checked = global::tfm.Properties.Settings.Default.UseSAPIOutput;
            this.chkUseSAPI.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::tfm.Properties.Settings.Default, "UseSAPIOutput", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkUseSAPI.Location = new System.Drawing.Point(3, 3);
            this.chkUseSAPI.Name = "chkUseSAPI";
            this.chkUseSAPI.Size = new System.Drawing.Size(94, 17);
            this.chkUseSAPI.TabIndex = 0;
            this.chkUseSAPI.Text = "Use SAPI for speech output";
            this.chkUseSAPI.UseVisualStyleBackColor = true;
            // 
            // chkReadInstrumentation
            // 
            this.chkReadInstrumentation.AutoSize = true;
            this.chkReadInstrumentation.Checked = global::tfm.Properties.Settings.Default.ReadInstrumentation;
            this.chkReadInstrumentation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReadInstrumentation.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::tfm.Properties.Settings.Default, "ReadInstrumentation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkReadInstrumentation.Location = new System.Drawing.Point(103, 3);
            this.chkReadInstrumentation.Name = "chkReadInstrumentation";
            this.chkReadInstrumentation.Size = new System.Drawing.Size(94, 17);
            this.chkReadInstrumentation.TabIndex = 2;
            this.chkReadInstrumentation.Text = "Read instrumentation";
            this.chkReadInstrumentation.UseVisualStyleBackColor = true;
            // 
            // chkReadSimconnectMessages
            // 
            this.chkReadSimconnectMessages.AutoSize = true;
            this.chkReadSimconnectMessages.Checked = global::tfm.Properties.Settings.Default.ReadSimconnectMessages;
            this.chkReadSimconnectMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReadSimconnectMessages.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::tfm.Properties.Settings.Default, "ReadSimconnectMessages", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkReadSimconnectMessages.Location = new System.Drawing.Point(3, 33);
            this.chkReadSimconnectMessages.Name = "chkReadSimconnectMessages";
            this.chkReadSimconnectMessages.Size = new System.Drawing.Size(94, 17);
            this.chkReadSimconnectMessages.TabIndex = 4;
            this.chkReadSimconnectMessages.Text = "Read SimConnect messages";
            this.chkReadSimconnectMessages.UseVisualStyleBackColor = true;
            // 
            // chkFlightFollowing
            // 
            this.chkFlightFollowing.AutoSize = true;
            this.chkFlightFollowing.Checked = global::tfm.Properties.Settings.Default.FlightFollowing;
            this.chkFlightFollowing.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::tfm.Properties.Settings.Default, "FlightFollowing", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkFlightFollowing.Location = new System.Drawing.Point(103, 33);
            this.chkFlightFollowing.Name = "chkFlightFollowing";
            this.chkFlightFollowing.Size = new System.Drawing.Size(94, 17);
            this.chkFlightFollowing.TabIndex = 6;
            this.chkFlightFollowing.Text = "Read flight following information";
            this.chkFlightFollowing.UseVisualStyleBackColor = true;
            // 
            // chkReadGPWS
            // 
            this.chkReadGPWS.AutoSize = true;
            this.chkReadGPWS.Checked = global::tfm.Properties.Settings.Default.ReadGPWS;
            this.chkReadGPWS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReadGPWS.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::tfm.Properties.Settings.Default, "ReadGPWS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkReadGPWS.Location = new System.Drawing.Point(3, 63);
            this.chkReadGPWS.Name = "chkReadGPWS";
            this.chkReadGPWS.Size = new System.Drawing.Size(94, 14);
            this.chkReadGPWS.TabIndex = 8;
            this.chkReadGPWS.Text = "Ground proximity warning system (GPWS) announcements";
            this.chkReadGPWS.UseVisualStyleBackColor = true;
            // 
            // chkReadILS
            // 
            this.chkReadILS.AutoSize = true;
            this.chkReadILS.Checked = global::tfm.Properties.Settings.Default.ReadILS;
            this.chkReadILS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReadILS.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::tfm.Properties.Settings.Default, "ReadILS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkReadILS.Location = new System.Drawing.Point(103, 63);
            this.chkReadILS.Name = "chkReadILS";
            this.chkReadILS.Size = new System.Drawing.Size(94, 14);
            this.chkReadILS.TabIndex = 10;
            this.chkReadILS.Text = "Read ILS information on approach";
            this.chkReadILS.UseVisualStyleBackColor = true;
            // 
            // chkReadGroundSpeed
            // 
            this.chkReadGroundSpeed.AutoSize = true;
            this.chkReadGroundSpeed.Checked = global::tfm.Properties.Settings.Default.ReadGroundSpeed;
            this.chkReadGroundSpeed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReadGroundSpeed.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::tfm.Properties.Settings.Default, "ReadGroundSpeed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkReadGroundSpeed.Location = new System.Drawing.Point(3, 83);
            this.chkReadGroundSpeed.Name = "chkReadGroundSpeed";
            this.chkReadGroundSpeed.Size = new System.Drawing.Size(94, 14);
            this.chkReadGroundSpeed.TabIndex = 12;
            this.chkReadGroundSpeed.Text = "Read ground speed periodically while on ground";
            this.chkReadGroundSpeed.UseVisualStyleBackColor = true;
            // 
            // ctlSpeechOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ctlSpeechOutput";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chkFlightFollowing;
        private System.Windows.Forms.CheckBox chkReadSimconnectMessages;
        private System.Windows.Forms.CheckBox chkReadInstrumentation;
        private System.Windows.Forms.CheckBox chkUseSAPI;
        private System.Windows.Forms.CheckBox chkReadGroundSpeed;
        private System.Windows.Forms.CheckBox chkReadILS;
        private System.Windows.Forms.CheckBox chkReadGPWS;
    }
}
