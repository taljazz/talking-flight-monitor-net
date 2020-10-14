namespace tfm
{
    partial class ctlUserInterface
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
            this.ctlFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.sendToTrayCheckBox = new System.Windows.Forms.CheckBox();
            this.ctlFlowLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctlFlowLayout
            // 
            this.ctlFlowLayout.AutoSize = true;
            this.ctlFlowLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlFlowLayout.Controls.Add(this.sendToTrayCheckBox);
            this.ctlFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlFlowLayout.Location = new System.Drawing.Point(0, 0);
            this.ctlFlowLayout.Name = "ctlFlowLayout";
            this.ctlFlowLayout.Size = new System.Drawing.Size(275, 37);
            this.ctlFlowLayout.TabIndex = 0;
            // 
            // sendToTrayCheckBox
            // 
            this.sendToTrayCheckBox.AccessibleName = "Minimize to system tray";
            this.sendToTrayCheckBox.AutoSize = true;
            this.sendToTrayCheckBox.Location = new System.Drawing.Point(3, 3);
            this.sendToTrayCheckBox.Name = "sendToTrayCheckBox";
            this.sendToTrayCheckBox.Size = new System.Drawing.Size(269, 31);
            this.sendToTrayCheckBox.TabIndex = 0;
            this.sendToTrayCheckBox.Text = "Minimize to system tray.";
            this.sendToTrayCheckBox.UseVisualStyleBackColor = true;
            this.sendToTrayCheckBox.CheckedChanged += new System.EventHandler(this.startInTrayCheckBox_CheckedChanged);
            // 
            // ctlUserInterface
            // 
            this.AccessibleName = "User interface settings";
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.ctlFlowLayout);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ctlUserInterface";
            this.Size = new System.Drawing.Size(275, 37);
            this.Load += new System.EventHandler(this.ctlUserInterface_Load);
            this.ctlFlowLayout.ResumeLayout(false);
            this.ctlFlowLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel ctlFlowLayout;
        private System.Windows.Forms.CheckBox sendToTrayCheckBox;
    }
}
