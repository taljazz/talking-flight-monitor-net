namespace tfm
{
    partial class ctlElectrical
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
            this.components = new System.ComponentModel.Container();
            this.tmrElectrical = new System.Windows.Forms.Timer(this.components);
            this.chkBattery = new System.Windows.Forms.CheckBox();
            this.chkCabUtil = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radStandbyBat = new System.Windows.Forms.RadioButton();
            this.radStandbyOff = new System.Windows.Forms.RadioButton();
            this.radStandbyAuto = new System.Windows.Forms.RadioButton();
            this.chkPassSeat = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrElectrical
            // 
            this.tmrElectrical.Interval = 500;
            this.tmrElectrical.Tick += new System.EventHandler(this.tmrElectrical_Tick);
            // 
            // chkBattery
            // 
            this.chkBattery.AutoSize = true;
            this.chkBattery.Location = new System.Drawing.Point(5, 5);
            this.chkBattery.Name = "chkBattery";
            this.chkBattery.Size = new System.Drawing.Size(86, 24);
            this.chkBattery.TabIndex = 0;
            this.chkBattery.Text = "Battery";
            this.chkBattery.UseVisualStyleBackColor = true;
            this.chkBattery.CheckedChanged += new System.EventHandler(this.chkBattery_CheckedChanged);
            // 
            // chkCabUtil
            // 
            this.chkCabUtil.AutoSize = true;
            this.chkCabUtil.Location = new System.Drawing.Point(335, 5);
            this.chkCabUtil.Name = "chkCabUtil";
            this.chkCabUtil.Size = new System.Drawing.Size(118, 24);
            this.chkCabUtil.TabIndex = 2;
            this.chkCabUtil.Text = "Cabin Utility";
            this.chkCabUtil.UseVisualStyleBackColor = true;
            this.chkCabUtil.CheckedChanged += new System.EventHandler(this.chkCabUtil_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(97, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 58);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Standby Power";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.radStandbyBat);
            this.flowLayoutPanel1.Controls.Add(this.radStandbyOff);
            this.flowLayoutPanel1.Controls.Add(this.radStandbyAuto);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(225, 30);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // radStandbyBat
            // 
            this.radStandbyBat.AutoSize = true;
            this.radStandbyBat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radStandbyBat.Location = new System.Drawing.Point(3, 3);
            this.radStandbyBat.Name = "radStandbyBat";
            this.radStandbyBat.Size = new System.Drawing.Size(83, 24);
            this.radStandbyBat.TabIndex = 0;
            this.radStandbyBat.TabStop = true;
            this.radStandbyBat.Text = "Battery";
            this.radStandbyBat.UseVisualStyleBackColor = true;
            this.radStandbyBat.CheckedChanged += new System.EventHandler(this.RadStandby_CheckChanged);
            // 
            // radStandbyOff
            // 
            this.radStandbyOff.AutoSize = true;
            this.radStandbyOff.Location = new System.Drawing.Point(92, 3);
            this.radStandbyOff.Name = "radStandbyOff";
            this.radStandbyOff.Size = new System.Drawing.Size(56, 24);
            this.radStandbyOff.TabIndex = 1;
            this.radStandbyOff.TabStop = true;
            this.radStandbyOff.Text = "Off";
            this.radStandbyOff.UseVisualStyleBackColor = true;
            this.radStandbyOff.CheckedChanged += new System.EventHandler(this.RadStandby_CheckChanged);
            // 
            // radStandbyAuto
            // 
            this.radStandbyAuto.AutoSize = true;
            this.radStandbyAuto.Location = new System.Drawing.Point(154, 3);
            this.radStandbyAuto.Name = "radStandbyAuto";
            this.radStandbyAuto.Size = new System.Drawing.Size(68, 24);
            this.radStandbyAuto.TabIndex = 2;
            this.radStandbyAuto.TabStop = true;
            this.radStandbyAuto.Text = "Auto";
            this.radStandbyAuto.UseVisualStyleBackColor = true;
            this.radStandbyAuto.CheckedChanged += new System.EventHandler(this.RadStandby_CheckChanged);
            // 
            // chkPassSeat
            // 
            this.chkPassSeat.AutoSize = true;
            this.chkPassSeat.Location = new System.Drawing.Point(460, 5);
            this.chkPassSeat.Name = "chkPassSeat";
            this.chkPassSeat.Size = new System.Drawing.Size(197, 24);
            this.chkPassSeat.TabIndex = 3;
            this.chkPassSeat.Text = "Passenger Seat Power";
            this.chkPassSeat.UseVisualStyleBackColor = true;
            // 
            // ctlElectrical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.chkPassSeat);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkCabUtil);
            this.Controls.Add(this.chkBattery);
            this.Name = "ctlElectrical";
            this.Size = new System.Drawing.Size(660, 66);
            this.Load += new System.EventHandler(this.ctlElectrical_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer tmrElectrical;
        private System.Windows.Forms.CheckBox chkBattery;
        private System.Windows.Forms.CheckBox chkCabUtil;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radStandbyBat;
        private System.Windows.Forms.RadioButton radStandbyOff;
        private System.Windows.Forms.RadioButton radStandbyAuto;
        private System.Windows.Forms.CheckBox chkPassSeat;
    }
}
