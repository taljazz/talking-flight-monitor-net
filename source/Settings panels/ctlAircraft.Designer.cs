namespace tfm
{
    partial class ctlAircraft
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
            this.aircraftFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.takeoffAssistDropDown = new System.Windows.Forms.ComboBox();
            this.aircraftFlowLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // aircraftFlowLayout
            // 
            this.aircraftFlowLayout.AccessibleName = "Aircraft layout";
            this.aircraftFlowLayout.AutoSize = true;
            this.aircraftFlowLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.aircraftFlowLayout.Controls.Add(this.takeoffAssistDropDown);
            this.aircraftFlowLayout.Location = new System.Drawing.Point(0, 0);
            this.aircraftFlowLayout.Name = "aircraftFlowLayout";
            this.aircraftFlowLayout.Size = new System.Drawing.Size(127, 30);
            this.aircraftFlowLayout.TabIndex = 0;
            // 
            // takeoffAssistDropDown
            // 
            this.takeoffAssistDropDown.AccessibleName = "Takeoff assist mode";
            this.takeoffAssistDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.takeoffAssistDropDown.FormattingEnabled = true;
            this.takeoffAssistDropDown.Items.AddRange(new object[] {
            "off",
            "partial",
            "full"});
            this.takeoffAssistDropDown.Location = new System.Drawing.Point(3, 3);
            this.takeoffAssistDropDown.Name = "takeoffAssistDropDown";
            this.takeoffAssistDropDown.Size = new System.Drawing.Size(121, 24);
            this.takeoffAssistDropDown.TabIndex = 0;
            this.takeoffAssistDropDown.SelectedIndexChanged += new System.EventHandler(this.takeoffAssistDropDown_SelectedIndexChanged);
            // 
            // ctlAircraft
            // 
            this.AccessibleName = "Aircraft settings";
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.aircraftFlowLayout);
            this.Name = "ctlAircraft";
            this.Size = new System.Drawing.Size(130, 33);
            this.Load += new System.EventHandler(this.ctlAircraft_Load);
            this.aircraftFlowLayout.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel aircraftFlowLayout;
        private System.Windows.Forms.ComboBox takeoffAssistDropDown;
    }
}
