namespace tfm
{
    partial class ctlEngines
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
            this.tmrEngines = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnEng2Fuel = new System.Windows.Forms.Button();
            this.btnEng2Start = new System.Windows.Forms.Button();
            this.btnEng1Start = new System.Windows.Forms.Button();
            this.btnEng1Fuel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrEngines
            // 
            this.tmrEngines.Interval = 500;
            this.tmrEngines.Tick += new System.EventHandler(this.tmrEngines_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnEng2Fuel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnEng2Start, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnEng1Start, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEng1Fuel, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnEng2Fuel
            // 
            this.btnEng2Fuel.Location = new System.Drawing.Point(103, 53);
            this.btnEng2Fuel.Name = "btnEng2Fuel";
            this.btnEng2Fuel.Size = new System.Drawing.Size(75, 23);
            this.btnEng2Fuel.TabIndex = 3;
            this.btnEng2Fuel.Text = "Engine 2 fuel";
            this.btnEng2Fuel.UseVisualStyleBackColor = true;
            this.btnEng2Fuel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEng2Fuel_KeyDown);
            this.btnEng2Fuel.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // btnEng2Start
            // 
            this.btnEng2Start.Location = new System.Drawing.Point(3, 53);
            this.btnEng2Start.Name = "btnEng2Start";
            this.btnEng2Start.Size = new System.Drawing.Size(75, 23);
            this.btnEng2Start.TabIndex = 2;
            this.btnEng2Start.Text = "Engine 2 Start";
            this.btnEng2Start.UseVisualStyleBackColor = true;
            this.btnEng2Start.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEng2Start_KeyDown);
            this.btnEng2Start.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // btnEng1Start
            // 
            this.btnEng1Start.Location = new System.Drawing.Point(3, 3);
            this.btnEng1Start.Name = "btnEng1Start";
            this.btnEng1Start.Size = new System.Drawing.Size(75, 23);
            this.btnEng1Start.TabIndex = 0;
            this.btnEng1Start.Text = "Engine 1 start";
            this.btnEng1Start.UseVisualStyleBackColor = true;
            this.btnEng1Start.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEng1Start_KeyDown);
            this.btnEng1Start.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // btnEng1Fuel
            // 
            this.btnEng1Fuel.Location = new System.Drawing.Point(103, 3);
            this.btnEng1Fuel.Name = "btnEng1Fuel";
            this.btnEng1Fuel.Size = new System.Drawing.Size(75, 23);
            this.btnEng1Fuel.TabIndex = 1;
            this.btnEng1Fuel.Text = "Engine 1 fuel";
            this.btnEng1Fuel.UseVisualStyleBackColor = true;
            this.btnEng1Fuel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEng1Fuel_KeyDown);
            this.btnEng1Fuel.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // ctlEngines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ctlEngines";
            this.Size = new System.Drawing.Size(203, 103);
            this.Load += new System.EventHandler(this.ctlEngines_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrEngines;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnEng2Fuel;
        private System.Windows.Forms.Button btnEng2Start;
        private System.Windows.Forms.Button btnEng1Start;
        private System.Windows.Forms.Button btnEng1Fuel;
    }
}
