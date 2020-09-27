namespace tfm.Settings_panels
{
    partial class ctlTiming
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
            this.lblFlightFollowing = new System.Windows.Forms.Label();
            this.txtFlightFollowingInterval = new System.Windows.Forms.TextBox();
            this.lblILSInterval = new System.Windows.Forms.Label();
            this.txtILSInterval = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblFlightFollowing, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtFlightFollowingInterval, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblILSInterval, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtILSInterval, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblFlightFollowing
            // 
            this.lblFlightFollowing.AutoSize = true;
            this.lblFlightFollowing.Location = new System.Drawing.Point(3, 0);
            this.lblFlightFollowing.Name = "lblFlightFollowing";
            this.lblFlightFollowing.Size = new System.Drawing.Size(82, 50);
            this.lblFlightFollowing.TabIndex = 0;
            this.lblFlightFollowing.Text = "Flight Following announcement interval (in minutes): ";
            // 
            // txtFlightFollowingInterval
            // 
            this.txtFlightFollowingInterval.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::tfm.Properties.Settings.Default, "FlightFollowingTimeInterval", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtFlightFollowingInterval.Location = new System.Drawing.Point(103, 3);
            this.txtFlightFollowingInterval.Name = "txtFlightFollowingInterval";
            this.txtFlightFollowingInterval.Size = new System.Drawing.Size(94, 20);
            this.txtFlightFollowingInterval.TabIndex = 1;
            this.txtFlightFollowingInterval.Text = global::tfm.Properties.Settings.Default.FlightFollowingTimeInterval;
            // 
            // lblILSInterval
            // 
            this.lblILSInterval.AutoSize = true;
            this.lblILSInterval.Location = new System.Drawing.Point(3, 50);
            this.lblILSInterval.Name = "lblILSInterval";
            this.lblILSInterval.Size = new System.Drawing.Size(89, 50);
            this.lblILSInterval.TabIndex = 2;
            this.lblILSInterval.Text = "Interval between ILS announcements (in seconds): ";
            // 
            // txtILSInterval
            // 
            this.txtILSInterval.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::tfm.Properties.Settings.Default, "ILSAnnouncementTimeInterval", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtILSInterval.Location = new System.Drawing.Point(103, 53);
            this.txtILSInterval.Name = "txtILSInterval";
            this.txtILSInterval.Size = new System.Drawing.Size(94, 20);
            this.txtILSInterval.TabIndex = 3;
            this.txtILSInterval.Text = global::tfm.Properties.Settings.Default.ILSAnnouncementTimeInterval;
            // 
            // ctlTiming
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ctlTiming";
            this.Load += new System.EventHandler(this.ctlTiming_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblFlightFollowing;
        private System.Windows.Forms.TextBox txtFlightFollowingInterval;
        private System.Windows.Forms.Label lblILSInterval;
        private System.Windows.Forms.TextBox txtILSInterval;
    }
}
