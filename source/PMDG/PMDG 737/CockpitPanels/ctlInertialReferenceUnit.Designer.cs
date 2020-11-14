namespace tfm
{
    partial class ctlInertialReferenceUnit
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
            this.btnIRURightMode = new System.Windows.Forms.Button();
            this.txtIRURight = new System.Windows.Forms.TextBox();
            this.txtIRULeft = new System.Windows.Forms.TextBox();
            this.btnIRULeftMode = new System.Windows.Forms.Button();
            this.tmrIRU = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnIRURightMode, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtIRURight, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtIRULeft, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnIRULeftMode, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnIRURightMode
            // 
            this.btnIRURightMode.AutoSize = true;
            this.btnIRURightMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnIRURightMode.Location = new System.Drawing.Point(103, 53);
            this.btnIRURightMode.Name = "btnIRURightMode";
            this.btnIRURightMode.Size = new System.Drawing.Size(94, 30);
            this.btnIRURightMode.TabIndex = 3;
            this.btnIRURightMode.Text = "Right IRU mode";
            this.btnIRURightMode.UseVisualStyleBackColor = true;
            this.btnIRURightMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnIRURightMode_KeyDown);
            this.btnIRURightMode.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // txtIRURight
            // 
            this.txtIRURight.Location = new System.Drawing.Point(103, 3);
            this.txtIRURight.Name = "txtIRURight";
            this.txtIRURight.ReadOnly = true;
            this.txtIRURight.Size = new System.Drawing.Size(94, 26);
            this.txtIRURight.TabIndex = 1;
            // 
            // txtIRULeft
            // 
            this.txtIRULeft.Location = new System.Drawing.Point(3, 3);
            this.txtIRULeft.Name = "txtIRULeft";
            this.txtIRULeft.ReadOnly = true;
            this.txtIRULeft.Size = new System.Drawing.Size(94, 26);
            this.txtIRULeft.TabIndex = 0;
            // 
            // btnIRULeftMode
            // 
            this.btnIRULeftMode.AutoSize = true;
            this.btnIRULeftMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnIRULeftMode.Location = new System.Drawing.Point(3, 53);
            this.btnIRULeftMode.Name = "btnIRULeftMode";
            this.btnIRULeftMode.Size = new System.Drawing.Size(94, 30);
            this.btnIRULeftMode.TabIndex = 2;
            this.btnIRULeftMode.Text = "Left IRU mode";
            this.btnIRULeftMode.UseVisualStyleBackColor = true;
            this.btnIRULeftMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnIRULeftMode_KeyDown);
            this.btnIRULeftMode.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // tmrIRU
            // 
            this.tmrIRU.Interval = 500;
            this.tmrIRU.Tick += new System.EventHandler(this.tmrIRU_Tick);
            // 
            // ctlInertialReferenceUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ctlInertialReferenceUnit";
            this.Size = new System.Drawing.Size(203, 103);
            this.Load += new System.EventHandler(this.ctlInertialReferenceUnit_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnIRURightMode;
        private System.Windows.Forms.TextBox txtIRURight;
        private System.Windows.Forms.TextBox txtIRULeft;
        private System.Windows.Forms.Button btnIRULeftMode;
        private System.Windows.Forms.Timer tmrIRU;
    }
}
