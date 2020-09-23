namespace tfm
{
    partial class ctlGeneral
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
            this.lblGeonames = new System.Windows.Forms.Label();
            this.txtGeonames = new System.Windows.Forms.TextBox();
            this.chkMetric = new System.Windows.Forms.CheckBox();
            this.grpUserInterfaceMode = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radPropertyGrid = new System.Windows.Forms.RadioButton();
            this.radSimplified = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpUserInterfaceMode.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblGeonames, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtGeonames, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkMetric, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grpUserInterfaceMode, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(267, 123);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblGeonames
            // 
            this.lblGeonames.AutoSize = true;
            this.lblGeonames.Location = new System.Drawing.Point(4, 0);
            this.lblGeonames.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGeonames.Name = "lblGeonames";
            this.lblGeonames.Size = new System.Drawing.Size(81, 34);
            this.lblGeonames.TabIndex = 0;
            this.lblGeonames.Text = "Geonames username: ";
            // 
            // txtGeonames
            // 
            this.txtGeonames.AccessibleName = "Geonames username";
            this.txtGeonames.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::tfm.Properties.Settings.Default, "GeonamesUsername", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtGeonames.Location = new System.Drawing.Point(137, 4);
            this.txtGeonames.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGeonames.Name = "txtGeonames";
            this.txtGeonames.Size = new System.Drawing.Size(124, 22);
            this.txtGeonames.TabIndex = 1;
            this.txtGeonames.Text = global::tfm.Properties.Settings.Default.GeonamesUsername;
            // 
            // chkMetric
            // 
            this.chkMetric.AutoSize = true;
            this.chkMetric.Checked = global::tfm.Properties.Settings.Default.UseMetric;
            this.chkMetric.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::tfm.Properties.Settings.Default, "UseMetric", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkMetric.Location = new System.Drawing.Point(4, 53);
            this.chkMetric.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkMetric.Name = "chkMetric";
            this.chkMetric.Size = new System.Drawing.Size(125, 21);
            this.chkMetric.TabIndex = 2;
            this.chkMetric.Text = "Use metric measurements";
            this.chkMetric.UseVisualStyleBackColor = true;
            // 
            // grpUserInterfaceMode
            // 
            this.grpUserInterfaceMode.Controls.Add(this.flowLayoutPanel1);
            this.grpUserInterfaceMode.Location = new System.Drawing.Point(137, 53);
            this.grpUserInterfaceMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpUserInterfaceMode.Name = "grpUserInterfaceMode";
            this.grpUserInterfaceMode.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpUserInterfaceMode.Size = new System.Drawing.Size(125, 41);
            this.grpUserInterfaceMode.TabIndex = 3;
            this.grpUserInterfaceMode.TabStop = false;
            this.grpUserInterfaceMode.Text = "avionics panel mode";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.radPropertyGrid);
            this.flowLayoutPanel1.Controls.Add(this.radSimplified);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(-71, -41);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(267, 123);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // radPropertyGrid
            // 
            this.radPropertyGrid.AutoSize = true;
            this.radPropertyGrid.Location = new System.Drawing.Point(4, 4);
            this.radPropertyGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radPropertyGrid.Name = "radPropertyGrid";
            this.radPropertyGrid.Size = new System.Drawing.Size(110, 21);
            this.radPropertyGrid.TabIndex = 2;
            this.radPropertyGrid.TabStop = true;
            this.radPropertyGrid.Text = "property grid";
            this.radPropertyGrid.UseVisualStyleBackColor = true;
            this.radPropertyGrid.CheckedChanged += new System.EventHandler(this.radPropertyGrid_CheckedChanged);
            // 
            // radSimplified
            // 
            this.radSimplified.AutoSize = true;
            this.radSimplified.Location = new System.Drawing.Point(122, 4);
            this.radSimplified.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radSimplified.Name = "radSimplified";
            this.radSimplified.Size = new System.Drawing.Size(87, 21);
            this.radSimplified.TabIndex = 3;
            this.radSimplified.TabStop = true;
            this.radSimplified.Text = "simplified";
            this.radSimplified.UseVisualStyleBackColor = true;
            this.radSimplified.CheckedChanged += new System.EventHandler(this.radSimplified_CheckedChanged);
            // 
            // ctlGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ctlGeneral";
            this.Size = new System.Drawing.Size(200, 185);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.grpUserInterfaceMode.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblGeonames;
        private System.Windows.Forms.TextBox txtGeonames;
        private System.Windows.Forms.CheckBox chkMetric;
        private System.Windows.Forms.GroupBox grpUserInterfaceMode;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radPropertyGrid;
        private System.Windows.Forms.RadioButton radSimplified;
    }
}
