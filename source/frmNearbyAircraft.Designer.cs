namespace tfm
{
    partial class frmNearbyAircraft
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tcTraffic = new System.Windows.Forms.TabControl();
            this.tabGround = new System.Windows.Forms.TabPage();
            this.lvGround = new System.Windows.Forms.ListView();
            this.colCallsign = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAircraft = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDistance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabAirborn = new System.Windows.Forms.TabPage();
            this.lvAirborn = new System.Windows.Forms.ListView();
            this.colAirCallsign = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAirDistance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAirAltitude = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOk = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.tcTraffic.SuspendLayout();
            this.tabGround.SuspendLayout();
            this.tabAirborn.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.tcTraffic);
            this.flowLayoutPanel1.Controls.Add(this.btnOk);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // tcTraffic
            // 
            this.tcTraffic.Controls.Add(this.tabGround);
            this.tcTraffic.Controls.Add(this.tabAirborn);
            this.tcTraffic.Location = new System.Drawing.Point(3, 3);
            this.tcTraffic.Name = "tcTraffic";
            this.tcTraffic.SelectedIndex = 0;
            this.tcTraffic.Size = new System.Drawing.Size(200, 100);
            this.tcTraffic.TabIndex = 0;
            // 
            // tabGround
            // 
            this.tabGround.Controls.Add(this.lvGround);
            this.tabGround.Location = new System.Drawing.Point(4, 22);
            this.tabGround.Name = "tabGround";
            this.tabGround.Padding = new System.Windows.Forms.Padding(3);
            this.tabGround.Size = new System.Drawing.Size(192, 74);
            this.tabGround.TabIndex = 0;
            this.tabGround.Text = "Ground";
            this.tabGround.UseVisualStyleBackColor = true;
            // 
            // lvGround
            // 
            this.lvGround.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCallsign,
            this.colStatus,
            this.colAircraft,
            this.colDistance,
            this.colFrom,
            this.colTo,
            this.colLocation});
            this.lvGround.HideSelection = false;
            this.lvGround.LabelWrap = false;
            this.lvGround.Location = new System.Drawing.Point(0, -1);
            this.lvGround.MultiSelect = false;
            this.lvGround.Name = "lvGround";
            this.lvGround.ShowGroups = false;
            this.lvGround.Size = new System.Drawing.Size(500, 200);
            this.lvGround.TabIndex = 0;
            this.lvGround.UseCompatibleStateImageBehavior = false;
            this.lvGround.View = System.Windows.Forms.View.Details;
            // 
            // colCallsign
            // 
            this.colCallsign.Text = "Callsign";
            // 
            // colStatus
            // 
            this.colStatus.Text = "status";
            // 
            // colAircraft
            // 
            this.colAircraft.Text = "Aircraft";
            // 
            // colDistance
            // 
            this.colDistance.Text = "Distance";
            // 
            // colFrom
            // 
            this.colFrom.Text = "From";
            // 
            // colTo
            // 
            this.colTo.Text = "To";
            // 
            // colLocation
            // 
            this.colLocation.Text = "Location";
            // 
            // tabAirborn
            // 
            this.tabAirborn.Controls.Add(this.lvAirborn);
            this.tabAirborn.Location = new System.Drawing.Point(4, 22);
            this.tabAirborn.Name = "tabAirborn";
            this.tabAirborn.Padding = new System.Windows.Forms.Padding(3);
            this.tabAirborn.Size = new System.Drawing.Size(192, 74);
            this.tabAirborn.TabIndex = 1;
            this.tabAirborn.Text = "Airborn";
            this.tabAirborn.UseVisualStyleBackColor = true;
            // 
            // lvAirborn
            // 
            this.lvAirborn.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAirCallsign,
            this.colState,
            this.colAirDistance,
            this.colAirAltitude});
            this.lvAirborn.HideSelection = false;
            this.lvAirborn.LabelWrap = false;
            this.lvAirborn.Location = new System.Drawing.Point(36, -12);
            this.lvAirborn.MultiSelect = false;
            this.lvAirborn.Name = "lvAirborn";
            this.lvAirborn.Size = new System.Drawing.Size(121, 97);
            this.lvAirborn.TabIndex = 1;
            this.lvAirborn.UseCompatibleStateImageBehavior = false;
            this.lvAirborn.View = System.Windows.Forms.View.Details;
            // 
            // colAirCallsign
            // 
            this.colAirCallsign.Text = "Callsign";
            // 
            // colState
            // 
            this.colState.Text = "State";
            // 
            // colAirDistance
            // 
            this.colAirDistance.Text = "Distance";
            // 
            // colAirAltitude
            // 
            this.colAirAltitude.Text = "Altitude";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(209, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // frmNearbyAircraft
            // 
            this.AcceptButton = this.btnOk;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOk;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmNearbyAircraft";
            this.Text = "Nearby aircraft";
            this.Load += new System.EventHandler(this.frmNearbyAircraft_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tcTraffic.ResumeLayout(false);
            this.tabGround.ResumeLayout(false);
            this.tabAirborn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TabControl tcTraffic;
        private System.Windows.Forms.TabPage tabGround;
        private System.Windows.Forms.ListView lvGround;
        private System.Windows.Forms.ColumnHeader colCallsign;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colFrom;
        private System.Windows.Forms.ColumnHeader colTo;
        private System.Windows.Forms.ColumnHeader colLocation;
        private System.Windows.Forms.TabPage tabAirborn;
        private System.Windows.Forms.ListView lvAirborn;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ColumnHeader colAircraft;
        private System.Windows.Forms.ColumnHeader colDistance;
        private System.Windows.Forms.ColumnHeader colAirCallsign;
        private System.Windows.Forms.ColumnHeader colState;
        private System.Windows.Forms.ColumnHeader colAirDistance;
        private System.Windows.Forms.ColumnHeader colAirAltitude;
    }
}