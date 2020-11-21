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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCtrRight = new System.Windows.Forms.Button();
            this.btnCtrLeft = new System.Windows.Forms.Button();
            this.btnAftRight = new System.Windows.Forms.Button();
            this.btnFwdRight = new System.Windows.Forms.Button();
            this.btnAftLeft = new System.Windows.Forms.Button();
            this.btnFwdLeft = new System.Windows.Forms.Button();
            this.tmrFuel = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnCtrRight, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCtrLeft, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnAftRight, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnFwdRight, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAftLeft, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFwdLeft, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnCtrRight
            // 
            this.btnCtrRight.Location = new System.Drawing.Point(84, 61);
            this.btnCtrRight.Name = "btnCtrRight";
            this.btnCtrRight.Size = new System.Drawing.Size(75, 23);
            this.btnCtrRight.TabIndex = 5;
            this.btnCtrRight.Text = "center right pump";
            this.btnCtrRight.UseVisualStyleBackColor = true;
            this.btnCtrRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCtrRight_KeyDown);
            this.btnCtrRight.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // btnCtrLeft
            // 
            this.btnCtrLeft.Location = new System.Drawing.Point(3, 61);
            this.btnCtrLeft.Name = "btnCtrLeft";
            this.btnCtrLeft.Size = new System.Drawing.Size(75, 23);
            this.btnCtrLeft.TabIndex = 4;
            this.btnCtrLeft.Text = "Center Left pump";
            this.btnCtrLeft.UseVisualStyleBackColor = true;
            this.btnCtrLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCtrLeft_KeyDown);
            this.btnCtrLeft.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // btnAftRight
            // 
            this.btnAftRight.Location = new System.Drawing.Point(84, 32);
            this.btnAftRight.Name = "btnAftRight";
            this.btnAftRight.Size = new System.Drawing.Size(75, 23);
            this.btnAftRight.TabIndex = 3;
            this.btnAftRight.Text = "Aft right pump";
            this.btnAftRight.UseVisualStyleBackColor = true;
            this.btnAftRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnAftRight_KeyDown);
            this.btnAftRight.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // btnFwdRight
            // 
            this.btnFwdRight.Location = new System.Drawing.Point(3, 32);
            this.btnFwdRight.Name = "btnFwdRight";
            this.btnFwdRight.Size = new System.Drawing.Size(75, 23);
            this.btnFwdRight.TabIndex = 2;
            this.btnFwdRight.Text = "Forward Right pump";
            this.btnFwdRight.UseVisualStyleBackColor = true;
            this.btnFwdRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnFwdRight_KeyDown);
            this.btnFwdRight.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // btnAftLeft
            // 
            this.btnAftLeft.Location = new System.Drawing.Point(84, 3);
            this.btnAftLeft.Name = "btnAftLeft";
            this.btnAftLeft.Size = new System.Drawing.Size(75, 23);
            this.btnAftLeft.TabIndex = 1;
            this.btnAftLeft.Text = "Aft left pump";
            this.btnAftLeft.UseVisualStyleBackColor = true;
            this.btnAftLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnAftLeft_KeyDown);
            this.btnAftLeft.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // btnFwdLeft
            // 
            this.btnFwdLeft.Location = new System.Drawing.Point(3, 3);
            this.btnFwdLeft.Name = "btnFwdLeft";
            this.btnFwdLeft.Size = new System.Drawing.Size(75, 23);
            this.btnFwdLeft.TabIndex = 0;
            this.btnFwdLeft.Text = "Forward left pump";
            this.btnFwdLeft.UseVisualStyleBackColor = true;
            this.btnFwdLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnFwdLeft_KeyDown);
            this.btnFwdLeft.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // tmrFuel
            // 
            this.tmrFuel.Interval = 500;
            this.tmrFuel.Tick += new System.EventHandler(this.tmrFuel_Tick);
            // 
            // ctlFuel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ctlFuel";
            this.Size = new System.Drawing.Size(203, 103);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCtrRight;
        private System.Windows.Forms.Button btnCtrLeft;
        private System.Windows.Forms.Button btnAftRight;
        private System.Windows.Forms.Button btnFwdRight;
        private System.Windows.Forms.Button btnAftLeft;
        private System.Windows.Forms.Button btnFwdLeft;
        private System.Windows.Forms.Timer tmrFuel;
    }
}
