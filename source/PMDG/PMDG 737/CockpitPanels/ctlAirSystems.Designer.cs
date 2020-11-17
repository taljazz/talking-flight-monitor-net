namespace tfm
{
    partial class ctlAirSystems
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
            this.tmrAir = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtCabinTemp = new System.Windows.Forms.TextBox();
            this.btnTempSelector = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAPUBleed = new System.Windows.Forms.Button();
            this.btnBleed2 = new System.Windows.Forms.Button();
            this.btnBleed1 = new System.Windows.Forms.Button();
            this.btnIsolValve = new System.Windows.Forms.Button();
            this.btnPacRight = new System.Windows.Forms.Button();
            this.btnPacLeft = new System.Windows.Forms.Button();
            this.btnRecircRight = new System.Windows.Forms.Button();
            this.btnRecircLeft = new System.Windows.Forms.Button();
            this.btnTrimAir = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrAir
            // 
            this.tmrAir.Interval = 500;
            this.tmrAir.Tick += new System.EventHandler(this.tmrAir_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.txtCabinTemp);
            this.flowLayoutPanel1.Controls.Add(this.btnTempSelector);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // txtCabinTemp
            // 
            this.txtCabinTemp.AccessibleName = "zone temperature";
            this.txtCabinTemp.Location = new System.Drawing.Point(3, 3);
            this.txtCabinTemp.Name = "txtCabinTemp";
            this.txtCabinTemp.ReadOnly = true;
            this.txtCabinTemp.Size = new System.Drawing.Size(100, 26);
            this.txtCabinTemp.TabIndex = 0;
            // 
            // btnTempSelector
            // 
            this.btnTempSelector.Location = new System.Drawing.Point(109, 3);
            this.btnTempSelector.Name = "btnTempSelector";
            this.btnTempSelector.Size = new System.Drawing.Size(75, 23);
            this.btnTempSelector.TabIndex = 1;
            this.btnTempSelector.Text = "temperature selector";
            this.btnTempSelector.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnAPUBleed, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnBleed2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnBleed1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnIsolValve, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnPacRight, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnPacLeft, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnRecircRight, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnRecircLeft, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnTrimAir, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnAPUBleed
            // 
            this.btnAPUBleed.Location = new System.Drawing.Point(3, 83);
            this.btnAPUBleed.Name = "btnAPUBleed";
            this.btnAPUBleed.Size = new System.Drawing.Size(75, 14);
            this.btnAPUBleed.TabIndex = 8;
            this.btnAPUBleed.Text = "APU Bleed";
            this.btnAPUBleed.UseVisualStyleBackColor = true;
            this.btnAPUBleed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnAPUBleed_KeyDown);
            this.btnAPUBleed.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // btnBleed2
            // 
            this.btnBleed2.Location = new System.Drawing.Point(3, 63);
            this.btnBleed2.Name = "btnBleed2";
            this.btnBleed2.Size = new System.Drawing.Size(75, 14);
            this.btnBleed2.TabIndex = 7;
            this.btnBleed2.Text = "Right engine bleed";
            this.btnBleed2.UseVisualStyleBackColor = true;
            this.btnBleed2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnBleed2_KeyDown);
            this.btnBleed2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // btnBleed1
            // 
            this.btnBleed1.Location = new System.Drawing.Point(103, 63);
            this.btnBleed1.Name = "btnBleed1";
            this.btnBleed1.Size = new System.Drawing.Size(75, 14);
            this.btnBleed1.TabIndex = 6;
            this.btnBleed1.Text = "Left engine bleed";
            this.btnBleed1.UseVisualStyleBackColor = true;
            this.btnBleed1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnBleed1_KeyDown);
            this.btnBleed1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // btnIsolValve
            // 
            this.btnIsolValve.Location = new System.Drawing.Point(103, 43);
            this.btnIsolValve.Name = "btnIsolValve";
            this.btnIsolValve.Size = new System.Drawing.Size(75, 14);
            this.btnIsolValve.TabIndex = 5;
            this.btnIsolValve.Text = "Isolation valve";
            this.btnIsolValve.UseVisualStyleBackColor = true;
            this.btnIsolValve.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnIsolValve_KeyDown);
            this.btnIsolValve.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // btnPacRight
            // 
            this.btnPacRight.Location = new System.Drawing.Point(3, 43);
            this.btnPacRight.Name = "btnPacRight";
            this.btnPacRight.Size = new System.Drawing.Size(75, 14);
            this.btnPacRight.TabIndex = 4;
            this.btnPacRight.Text = "Right Pac";
            this.btnPacRight.UseVisualStyleBackColor = true;
            this.btnPacRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnPacRight_KeyDown);
            this.btnPacRight.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // btnPacLeft
            // 
            this.btnPacLeft.Location = new System.Drawing.Point(103, 23);
            this.btnPacLeft.Name = "btnPacLeft";
            this.btnPacLeft.Size = new System.Drawing.Size(75, 14);
            this.btnPacLeft.TabIndex = 3;
            this.btnPacLeft.Text = "Left PAC";
            this.btnPacLeft.UseVisualStyleBackColor = true;
            this.btnPacLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnPacLeft_KeyDown);
            this.btnPacLeft.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // btnRecircRight
            // 
            this.btnRecircRight.Location = new System.Drawing.Point(3, 23);
            this.btnRecircRight.Name = "btnRecircRight";
            this.btnRecircRight.Size = new System.Drawing.Size(75, 14);
            this.btnRecircRight.TabIndex = 2;
            this.btnRecircRight.Text = "Right recirculation fan";
            this.btnRecircRight.UseVisualStyleBackColor = true;
            this.btnRecircRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnRecircRight_KeyDown);
            this.btnRecircRight.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // btnRecircLeft
            // 
            this.btnRecircLeft.Location = new System.Drawing.Point(103, 3);
            this.btnRecircLeft.Name = "btnRecircLeft";
            this.btnRecircLeft.Size = new System.Drawing.Size(75, 14);
            this.btnRecircLeft.TabIndex = 1;
            this.btnRecircLeft.Text = "left Recirculation fan";
            this.btnRecircLeft.UseVisualStyleBackColor = true;
            this.btnRecircLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnRecircLeft_KeyDown);
            this.btnRecircLeft.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // btnTrimAir
            // 
            this.btnTrimAir.Location = new System.Drawing.Point(3, 3);
            this.btnTrimAir.Name = "btnTrimAir";
            this.btnTrimAir.Size = new System.Drawing.Size(75, 14);
            this.btnTrimAir.TabIndex = 0;
            this.btnTrimAir.Text = "Trim air";
            this.btnTrimAir.UseVisualStyleBackColor = true;
            this.btnTrimAir.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnTrimAir_KeyDown);
            this.btnTrimAir.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // ctlAirSystems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ctlAirSystems";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrAir;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtCabinTemp;
        private System.Windows.Forms.Button btnTempSelector;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnBleed2;
        private System.Windows.Forms.Button btnBleed1;
        private System.Windows.Forms.Button btnIsolValve;
        private System.Windows.Forms.Button btnPacRight;
        private System.Windows.Forms.Button btnPacLeft;
        private System.Windows.Forms.Button btnRecircRight;
        private System.Windows.Forms.Button btnRecircLeft;
        private System.Windows.Forms.Button btnTrimAir;
        private System.Windows.Forms.Button btnAPUBleed;
    }
}
