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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGround = new System.Windows.Forms.TabPage();
            this.tabAirborn = new System.Windows.Forms.TabPage();
            this.lvGround = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.btnOk = new System.Windows.Forms.Button();
            this.colCallsign = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTaxiing = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabGround.SuspendLayout();
            this.tabAirborn.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.tabControl1);
            this.flowLayoutPanel1.Controls.Add(this.btnOk);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGround);
            this.tabControl1.Controls.Add(this.tabAirborn);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 100);
            this.tabControl1.TabIndex = 0;
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
            // tabAirborn
            // 
            this.tabAirborn.Controls.Add(this.listView2);
            this.tabAirborn.Location = new System.Drawing.Point(4, 22);
            this.tabAirborn.Name = "tabAirborn";
            this.tabAirborn.Padding = new System.Windows.Forms.Padding(3);
            this.tabAirborn.Size = new System.Drawing.Size(192, 74);
            this.tabAirborn.TabIndex = 1;
            this.tabAirborn.Text = "Airborn";
            this.tabAirborn.UseVisualStyleBackColor = true;
            // 
            // lvGround
            // 
            this.lvGround.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCallsign,
            this.colStatus,
            this.colFrom,
            this.colTo,
            this.colTaxiing});
            this.lvGround.HideSelection = false;
            this.lvGround.Location = new System.Drawing.Point(0, -1);
            this.lvGround.Name = "lvGround";
            this.lvGround.Size = new System.Drawing.Size(500, 200);
            this.lvGround.TabIndex = 0;
            this.lvGround.UseCompatibleStateImageBehavior = false;
            this.lvGround.View = System.Windows.Forms.View.Details;
            // 
            // listView2
            // 
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(36, -11);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(121, 97);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
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
            // colCallsign
            // 
            this.colCallsign.Text = "Callsign";
            // 
            // colStatus
            // 
            this.colStatus.Text = "status";
            // 
            // colFrom
            // 
            this.colFrom.Text = "From";
            // 
            // colTo
            // 
            this.colTo.Text = "To";
            // 
            // colTaxiing
            // 
            this.colTaxiing.Text = "taxiing to";
            // 
            // frmNearbyAircraft
            // 
            this.AcceptButton = this.btnOk;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmNearbyAircraft";
            this.Text = "Nearby aircraft";
            this.Load += new System.EventHandler(this.frmNearbyAircraft_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabGround.ResumeLayout(false);
            this.tabAirborn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGround;
        private System.Windows.Forms.ListView lvGround;
        private System.Windows.Forms.ColumnHeader colCallsign;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colFrom;
        private System.Windows.Forms.ColumnHeader colTo;
        private System.Windows.Forms.ColumnHeader colTaxiing;
        private System.Windows.Forms.TabPage tabAirborn;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button btnOk;
    }
}