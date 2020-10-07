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
            this.trkSpeechRate = new System.Windows.Forms.TrackBar();
            this.grpAttitude = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radTones = new System.Windows.Forms.RadioButton();
            this.radSpeech = new System.Windows.Forms.RadioButton();
            this.radBoth = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.chkReadInstrumentation = new System.Windows.Forms.CheckBox();
            this.chkAltitude = new System.Windows.Forms.CheckBox();
            this.chkReadGroundSpeed = new System.Windows.Forms.CheckBox();
            this.chkReadILS = new System.Windows.Forms.CheckBox();
            this.chkReadGPWS = new System.Windows.Forms.CheckBox();
            this.chkFlightFollowing = new System.Windows.Forms.CheckBox();
            this.chkReadSimconnectMessages = new System.Windows.Forms.CheckBox();
            this.chkUseSAPI = new System.Windows.Forms.CheckBox();
            this.chkAutopilot = new System.Windows.Forms.CheckBox();
            this.chkBraille = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkSpeechRate)).BeginInit();
            this.grpAttitude.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chkReadInstrumentation, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.trkSpeechRate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkAltitude, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkReadGroundSpeed, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkReadILS, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkReadGPWS, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkFlightFollowing, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkReadSimconnectMessages, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkUseSAPI, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkAutopilot, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkBraille, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.grpAttitude, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown1, 1, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // trkSpeechRate
            // 
            this.trkSpeechRate.AccessibleName = "SAPI speech rate";
            this.trkSpeechRate.Location = new System.Drawing.Point(3, 3);
            this.trkSpeechRate.Maximum = 20;
            this.trkSpeechRate.Name = "trkSpeechRate";
            this.trkSpeechRate.Size = new System.Drawing.Size(94, 1);
            this.trkSpeechRate.TabIndex = 1;
            this.trkSpeechRate.Value = 10;
            this.trkSpeechRate.Scroll += new System.EventHandler(this.trkSpeechRate_Scroll);
            // 
            // grpAttitude
            // 
            this.grpAttitude.Controls.Add(this.flowLayoutPanel1);
            this.grpAttitude.Location = new System.Drawing.Point(103, 63);
            this.grpAttitude.Name = "grpAttitude";
            this.grpAttitude.Size = new System.Drawing.Size(94, 14);
            this.grpAttitude.TabIndex = 15;
            this.grpAttitude.TabStop = false;
            this.grpAttitude.Text = "Attitude output mode";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.radTones);
            this.flowLayoutPanel1.Controls.Add(this.radSpeech);
            this.flowLayoutPanel1.Controls.Add(this.radBoth);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // radTones
            // 
            this.radTones.AutoSize = true;
            this.radTones.Location = new System.Drawing.Point(3, 3);
            this.radTones.Name = "radTones";
            this.radTones.Size = new System.Drawing.Size(55, 17);
            this.radTones.TabIndex = 0;
            this.radTones.TabStop = true;
            this.radTones.Text = "Tones";
            this.radTones.UseVisualStyleBackColor = true;
            this.radTones.CheckedChanged += new System.EventHandler(this.radTones_CheckedChanged);
            // 
            // radSpeech
            // 
            this.radSpeech.AutoSize = true;
            this.radSpeech.Location = new System.Drawing.Point(64, 3);
            this.radSpeech.Name = "radSpeech";
            this.radSpeech.Size = new System.Drawing.Size(62, 17);
            this.radSpeech.TabIndex = 1;
            this.radSpeech.TabStop = true;
            this.radSpeech.Text = "Speech";
            this.radSpeech.UseVisualStyleBackColor = true;
            this.radSpeech.CheckedChanged += new System.EventHandler(this.radSpeech_CheckedChanged);
            // 
            // radBoth
            // 
            this.radBoth.AutoSize = true;
            this.radBoth.Location = new System.Drawing.Point(3, 26);
            this.radBoth.Name = "radBoth";
            this.radBoth.Size = new System.Drawing.Size(116, 17);
            this.radBoth.TabIndex = 2;
            this.radBoth.TabStop = true;
            this.radBoth.Text = "Speech and Tones";
            this.radBoth.UseVisualStyleBackColor = true;
            this.radBoth.CheckedChanged += new System.EventHandler(this.radBoth_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Output History Size: ";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.AccessibleName = "output history size";
            this.numericUpDown1.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::tfm.Properties.Settings.Default, "OutputHistoryLength", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown1.Location = new System.Drawing.Point(103, 83);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(94, 20);
            this.numericUpDown1.TabIndex = 17;
            this.numericUpDown1.Value = global::tfm.Properties.Settings.Default.OutputHistoryLength;
            // 
            // chkReadInstrumentation
            // 
            this.chkReadInstrumentation.AutoSize = true;
            this.chkReadInstrumentation.Checked = global::tfm.Properties.Settings.Default.ReadInstrumentation;
            this.chkReadInstrumentation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReadInstrumentation.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::tfm.Properties.Settings.Default, "ReadInstrumentation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkReadInstrumentation.Location = new System.Drawing.Point(103, 3);
            this.chkReadInstrumentation.Name = "chkReadInstrumentation";
            this.chkReadInstrumentation.Size = new System.Drawing.Size(94, 1);
            this.chkReadInstrumentation.TabIndex = 2;
            this.chkReadInstrumentation.Text = "Read instrumentation";
            this.chkReadInstrumentation.UseVisualStyleBackColor = true;
            // 
            // chkAltitude
            // 
            this.chkAltitude.AutoSize = true;
            this.chkAltitude.Checked = global::tfm.Properties.Settings.Default.AltitudeAnnouncements;
            this.chkAltitude.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAltitude.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::tfm.Properties.Settings.Default, "AltitudeAnnouncements", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkAltitude.Location = new System.Drawing.Point(3, 23);
            this.chkAltitude.Name = "chkAltitude";
            this.chkAltitude.Size = new System.Drawing.Size(94, 14);
            this.chkAltitude.TabIndex = 9;
            this.chkAltitude.Text = "Read altitude every 1000 feet";
            this.chkAltitude.UseVisualStyleBackColor = true;
            // 
            // chkReadGroundSpeed
            // 
            this.chkReadGroundSpeed.AutoSize = true;
            this.chkReadGroundSpeed.Checked = global::tfm.Properties.Settings.Default.ReadGroundSpeed;
            this.chkReadGroundSpeed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReadGroundSpeed.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::tfm.Properties.Settings.Default, "ReadGroundSpeed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkReadGroundSpeed.Location = new System.Drawing.Point(103, 43);
            this.chkReadGroundSpeed.Name = "chkReadGroundSpeed";
            this.chkReadGroundSpeed.Size = new System.Drawing.Size(94, 14);
            this.chkReadGroundSpeed.TabIndex = 12;
            this.chkReadGroundSpeed.Text = "Read ground speed periodically while on ground";
            this.chkReadGroundSpeed.UseVisualStyleBackColor = true;
            // 
            // chkReadILS
            // 
            this.chkReadILS.AutoSize = true;
            this.chkReadILS.Checked = global::tfm.Properties.Settings.Default.ReadILS;
            this.chkReadILS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReadILS.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::tfm.Properties.Settings.Default, "ReadILS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkReadILS.Location = new System.Drawing.Point(103, 23);
            this.chkReadILS.Name = "chkReadILS";
            this.chkReadILS.Size = new System.Drawing.Size(94, 14);
            this.chkReadILS.TabIndex = 10;
            this.chkReadILS.Text = "Read ILS information on approach";
            this.chkReadILS.UseVisualStyleBackColor = true;
            // 
            // chkReadGPWS
            // 
            this.chkReadGPWS.AutoSize = true;
            this.chkReadGPWS.Checked = global::tfm.Properties.Settings.Default.ReadGPWS;
            this.chkReadGPWS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReadGPWS.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::tfm.Properties.Settings.Default, "ReadGPWS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkReadGPWS.Location = new System.Drawing.Point(103, 3);
            this.chkReadGPWS.Name = "chkReadGPWS";
            this.chkReadGPWS.Size = new System.Drawing.Size(94, 14);
            this.chkReadGPWS.TabIndex = 8;
            this.chkReadGPWS.Text = "Ground proximity warning system (GPWS) announcements";
            this.chkReadGPWS.UseVisualStyleBackColor = true;
            // 
            // chkFlightFollowing
            // 
            this.chkFlightFollowing.AutoSize = true;
            this.chkFlightFollowing.Checked = global::tfm.Properties.Settings.Default.FlightFollowing;
            this.chkFlightFollowing.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::tfm.Properties.Settings.Default, "FlightFollowing", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkFlightFollowing.Location = new System.Drawing.Point(103, 3);
            this.chkFlightFollowing.Name = "chkFlightFollowing";
            this.chkFlightFollowing.Size = new System.Drawing.Size(94, 1);
            this.chkFlightFollowing.TabIndex = 6;
            this.chkFlightFollowing.Text = "Read flight following information";
            this.chkFlightFollowing.UseVisualStyleBackColor = true;
            // 
            // chkReadSimconnectMessages
            // 
            this.chkReadSimconnectMessages.AutoSize = true;
            this.chkReadSimconnectMessages.Checked = global::tfm.Properties.Settings.Default.ReadSimconnectMessages;
            this.chkReadSimconnectMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReadSimconnectMessages.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::tfm.Properties.Settings.Default, "ReadSimconnectMessages", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkReadSimconnectMessages.Location = new System.Drawing.Point(3, 3);
            this.chkReadSimconnectMessages.Name = "chkReadSimconnectMessages";
            this.chkReadSimconnectMessages.Size = new System.Drawing.Size(94, 14);
            this.chkReadSimconnectMessages.TabIndex = 4;
            this.chkReadSimconnectMessages.Text = "Read SimConnect messages";
            this.chkReadSimconnectMessages.UseVisualStyleBackColor = true;
            // 
            // chkUseSAPI
            // 
            this.chkUseSAPI.AutoSize = true;
            this.chkUseSAPI.Checked = global::tfm.Properties.Settings.Default.UseSAPIOutput;
            this.chkUseSAPI.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::tfm.Properties.Settings.Default, "UseSAPIOutput", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkUseSAPI.Location = new System.Drawing.Point(3, 3);
            this.chkUseSAPI.Name = "chkUseSAPI";
            this.chkUseSAPI.Size = new System.Drawing.Size(94, 1);
            this.chkUseSAPI.TabIndex = 0;
            this.chkUseSAPI.Text = "Use SAPI for speech output";
            this.chkUseSAPI.UseVisualStyleBackColor = true;
            // 
            // chkAutopilot
            // 
            this.chkAutopilot.AutoSize = true;
            this.chkAutopilot.Checked = global::tfm.Properties.Settings.Default.ReadAutopilot;
            this.chkAutopilot.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::tfm.Properties.Settings.Default, "ReadAutopilot", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkAutopilot.Location = new System.Drawing.Point(3, 43);
            this.chkAutopilot.Name = "chkAutopilot";
            this.chkAutopilot.Size = new System.Drawing.Size(94, 14);
            this.chkAutopilot.TabIndex = 13;
            this.chkAutopilot.Text = "Read autopilot instrument changes";
            this.chkAutopilot.UseVisualStyleBackColor = true;
            // 
            // chkBraille
            // 
            this.chkBraille.AutoSize = true;
            this.chkBraille.Checked = global::tfm.Properties.Settings.Default.OutputBraille;
            this.chkBraille.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBraille.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::tfm.Properties.Settings.Default, "OutputBraille", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkBraille.Location = new System.Drawing.Point(3, 63);
            this.chkBraille.Name = "chkBraille";
            this.chkBraille.Size = new System.Drawing.Size(94, 14);
            this.chkBraille.TabIndex = 14;
            this.chkBraille.Text = "Output tfm messages to Braile display";
            this.chkBraille.UseVisualStyleBackColor = true;
            // 
            // ctlSpeechOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ctlSpeechOutput";
            this.Load += new System.EventHandler(this.ctlSpeechOutput_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkSpeechRate)).EndInit();
            this.grpAttitude.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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
        private System.Windows.Forms.CheckBox chkAltitude;
        private System.Windows.Forms.CheckBox chkAutopilot;
        private System.Windows.Forms.TrackBar trkSpeechRate;
        private System.Windows.Forms.CheckBox chkBraille;
        private System.Windows.Forms.GroupBox grpAttitude;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radTones;
        private System.Windows.Forms.RadioButton radSpeech;
        private System.Windows.Forms.RadioButton radBoth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}
