namespace tfm.Autopilot
{
    partial class FrmThrottleValue
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
            this.SpnThrValue = new System.Windows.Forms.NumericUpDown();
            this.LblThrPct = new System.Windows.Forms.Label();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SpnThrValue)).BeginInit();
            this.SuspendLayout();
            // 
            // SpnThrValue
            // 
            this.SpnThrValue.AccessibleName = "Engine Throttle Value (percent)";
            this.SpnThrValue.Location = new System.Drawing.Point(0, 40);
            this.SpnThrValue.Name = "SpnThrValue";
            this.SpnThrValue.Size = new System.Drawing.Size(121, 22);
            this.SpnThrValue.TabIndex = 0;
            // 
            // LblThrPct
            // 
            this.LblThrPct.AutoSize = true;
            this.LblThrPct.Location = new System.Drawing.Point(0, 0);
            this.LblThrPct.Name = "LblThrPct";
            this.LblThrPct.Size = new System.Drawing.Size(159, 17);
            this.LblThrPct.TabIndex = 1;
            this.LblThrPct.Text = "&Throttle Value (percent)";
            this.LblThrPct.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BtnOK
            // 
            this.BtnOK.AccessibleName = "OK";
            this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOK.Location = new System.Drawing.Point(8, 48);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 2;
            this.BtnOK.Text = "&OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.AccessibleName = "Cancel";
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(16, 56);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmThrottleValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.LblThrPct);
            this.Controls.Add(this.SpnThrValue);
            this.Name = "FrmThrottleValue";
            this.Text = "FrmThrottleValue";
            ((System.ComponentModel.ISupportInitialize)(this.SpnThrValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown SpnThrValue;
        private System.Windows.Forms.Label LblThrPct;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
    }
}