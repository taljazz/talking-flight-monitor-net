namespace tfm       
{
    partial class ctlFuel
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
            this.tmrFuel = new System.Windows.Forms.Timer(this.components);
            this.grpLeft = new System.Windows.Forms.GroupBox();
            this.chkFwdLeft = new System.Windows.Forms.CheckBox();
            this.chkAftLeft = new System.Windows.Forms.CheckBox();
            this.grpRight = new System.Windows.Forms.GroupBox();
            this.chkFwdRight = new System.Windows.Forms.CheckBox();
            this.chkAftRight = new System.Windows.Forms.CheckBox();
            this.grpCenter = new System.Windows.Forms.GroupBox();
            this.chkCenterRight = new System.Windows.Forms.CheckBox();
            this.chkCenterLeft = new System.Windows.Forms.CheckBox();
            this.grpLeft.SuspendLayout();
            this.grpRight.SuspendLayout();
            this.grpCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrFuel
            // 
            this.tmrFuel.Interval = 500;
            this.tmrFuel.Tick += new System.EventHandler(this.tmrFuel_Tick);
            // 
            // grpLeft
            // 
            this.grpLeft.AutoSize = true;
            this.grpLeft.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpLeft.Controls.Add(this.chkAftLeft);
            this.grpLeft.Controls.Add(this.chkFwdLeft);
            this.grpLeft.Location = new System.Drawing.Point(5, 5);
            this.grpLeft.Name = "grpLeft";
            this.grpLeft.Size = new System.Drawing.Size(223, 52);
            this.grpLeft.TabIndex = 0;
            this.grpLeft.TabStop = false;
            // 
            // chkFwdLeft
            // 
            this.chkFwdLeft.AutoSize = true;
            this.chkFwdLeft.Location = new System.Drawing.Point(3, 3);
            this.chkFwdLeft.Name = "chkFwdLeft";
            this.chkFwdLeft.Size = new System.Drawing.Size(120, 24);
            this.chkFwdLeft.TabIndex = 0;
            this.chkFwdLeft.Text = "Left forward";
            this.chkFwdLeft.UseVisualStyleBackColor = true;
            this.chkFwdLeft.CheckedChanged += new System.EventHandler(this.chkFwdLeft_CheckedChanged);
            // 
            // chkAftLeft
            // 
            this.chkAftLeft.AutoSize = true;
            this.chkAftLeft.Location = new System.Drawing.Point(129, 3);
            this.chkAftLeft.Name = "chkAftLeft";
            this.chkAftLeft.Size = new System.Drawing.Size(88, 24);
            this.chkAftLeft.TabIndex = 1;
            this.chkAftLeft.Text = "Left Aft";
            this.chkAftLeft.UseVisualStyleBackColor = true;
            this.chkAftLeft.CheckedChanged += new System.EventHandler(this.chkAftLeft_CheckedChanged);
            // 
            // grpRight
            // 
            this.grpRight.AutoSize = true;
            this.grpRight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpRight.Controls.Add(this.chkAftRight);
            this.grpRight.Controls.Add(this.chkFwdRight);
            this.grpRight.Location = new System.Drawing.Point(233, 5);
            this.grpRight.Name = "grpRight";
            this.grpRight.Size = new System.Drawing.Size(245, 52);
            this.grpRight.TabIndex = 1;
            this.grpRight.TabStop = false;
            // 
            // chkFwdRight
            // 
            this.chkFwdRight.AutoSize = true;
            this.chkFwdRight.Location = new System.Drawing.Point(3, 3);
            this.chkFwdRight.Name = "chkFwdRight";
            this.chkFwdRight.Size = new System.Drawing.Size(135, 24);
            this.chkFwdRight.TabIndex = 1;
            this.chkFwdRight.Text = "Right Forward";
            this.chkFwdRight.UseVisualStyleBackColor = true;
            this.chkFwdRight.CheckedChanged += new System.EventHandler(this.chkFwdRight_CheckedChanged);
            // 
            // chkAftRight
            // 
            this.chkAftRight.AutoSize = true;
            this.chkAftRight.Location = new System.Drawing.Point(141, 3);
            this.chkAftRight.Name = "chkAftRight";
            this.chkAftRight.Size = new System.Drawing.Size(98, 24);
            this.chkAftRight.TabIndex = 2;
            this.chkAftRight.Text = "Right Aft";
            this.chkAftRight.UseVisualStyleBackColor = true;
            this.chkAftRight.CheckedChanged += new System.EventHandler(this.chkAftRight_CheckedChanged);
            // 
            // grpCenter
            // 
            this.grpCenter.AutoSize = true;
            this.grpCenter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpCenter.Controls.Add(this.chkCenterRight);
            this.grpCenter.Controls.Add(this.chkCenterLeft);
            this.grpCenter.Location = new System.Drawing.Point(118, 5);
            this.grpCenter.Name = "grpCenter";
            this.grpCenter.Size = new System.Drawing.Size(272, 52);
            this.grpCenter.TabIndex = 2;
            this.grpCenter.TabStop = false;
            // 
            // chkCenterRight
            // 
            this.chkCenterRight.AutoSize = true;
            this.chkCenterRight.Location = new System.Drawing.Point(141, 3);
            this.chkCenterRight.Name = "chkCenterRight";
            this.chkCenterRight.Size = new System.Drawing.Size(125, 24);
            this.chkCenterRight.TabIndex = 2;
            this.chkCenterRight.Text = "Center Right";
            this.chkCenterRight.UseVisualStyleBackColor = true;
            this.chkCenterRight.CheckedChanged += new System.EventHandler(this.chkCenterRight_CheckedChanged);
            // 
            // chkCenterLeft
            // 
            this.chkCenterLeft.AutoSize = true;
            this.chkCenterLeft.Location = new System.Drawing.Point(3, 3);
            this.chkCenterLeft.Name = "chkCenterLeft";
            this.chkCenterLeft.Size = new System.Drawing.Size(115, 24);
            this.chkCenterLeft.TabIndex = 1;
            this.chkCenterLeft.Text = "Center Left";
            this.chkCenterLeft.UseVisualStyleBackColor = true;
            this.chkCenterLeft.CheckedChanged += new System.EventHandler(this.chkCenterLeft_CheckedChanged);
            // 
            // ctlFuel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.grpCenter);
            this.Controls.Add(this.grpRight);
            this.Controls.Add(this.grpLeft);
            this.Name = "ctlFuel";
            this.Size = new System.Drawing.Size(481, 60);
            this.grpLeft.ResumeLayout(false);
            this.grpLeft.PerformLayout();
            this.grpRight.ResumeLayout(false);
            this.grpRight.PerformLayout();
            this.grpCenter.ResumeLayout(false);
            this.grpCenter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer tmrFuel;
        private System.Windows.Forms.GroupBox grpLeft;
        private System.Windows.Forms.CheckBox chkAftLeft;
        private System.Windows.Forms.CheckBox chkFwdLeft;
        private System.Windows.Forms.GroupBox grpRight;
        private System.Windows.Forms.CheckBox chkAftRight;
        private System.Windows.Forms.CheckBox chkFwdRight;
        private System.Windows.Forms.GroupBox grpCenter;
        private System.Windows.Forms.CheckBox chkCenterRight;
        private System.Windows.Forms.CheckBox chkCenterLeft;
    }
}
