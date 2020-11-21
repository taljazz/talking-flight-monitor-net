namespace tfm
{
    partial class ctlHydraulics
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
            this.btnEngine2 = new System.Windows.Forms.Button();
            this.btnElec1 = new System.Windows.Forms.Button();
            this.btnElec2 = new System.Windows.Forms.Button();
            this.btnEngine1 = new System.Windows.Forms.Button();
            this.tmrHydraulics = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnEngine2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnElec1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnElec2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEngine1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnEngine2
            // 
            this.btnEngine2.Location = new System.Drawing.Point(103, 43);
            this.btnEngine2.Name = "btnEngine2";
            this.btnEngine2.Size = new System.Drawing.Size(75, 23);
            this.btnEngine2.TabIndex = 3;
            this.btnEngine2.Text = "Engine 2";
            this.btnEngine2.UseVisualStyleBackColor = true;
            this.btnEngine2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEngine2_KeyDown);
            this.btnEngine2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // btnElec1
            // 
            this.btnElec1.Location = new System.Drawing.Point(3, 3);
            this.btnElec1.Name = "btnElec1";
            this.btnElec1.Size = new System.Drawing.Size(75, 23);
            this.btnElec1.TabIndex = 0;
            this.btnElec1.Text = "Electric1";
            this.btnElec1.UseVisualStyleBackColor = true;
            this.btnElec1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnElec1_KeyDown);
            this.btnElec1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // btnElec2
            // 
            this.btnElec2.Location = new System.Drawing.Point(103, 3);
            this.btnElec2.Name = "btnElec2";
            this.btnElec2.Size = new System.Drawing.Size(75, 23);
            this.btnElec2.TabIndex = 1;
            this.btnElec2.Text = "Electric 2";
            this.btnElec2.UseVisualStyleBackColor = true;
            this.btnElec2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnElec2_KeyDown);
            this.btnElec2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // btnEngine1
            // 
            this.btnEngine1.Location = new System.Drawing.Point(3, 43);
            this.btnEngine1.Name = "btnEngine1";
            this.btnEngine1.Size = new System.Drawing.Size(75, 23);
            this.btnEngine1.TabIndex = 2;
            this.btnEngine1.Text = "Engine 1";
            this.btnEngine1.UseVisualStyleBackColor = true;
            this.btnEngine1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEngine1_KeyDown);
            this.btnEngine1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.event_PreviewKeyDown);
            // 
            // tmrHydraulics
            // 
            this.tmrHydraulics.Interval = 500;
            this.tmrHydraulics.Tick += new System.EventHandler(this.tmrHydraulics_Tick);
            // 
            // ctlHydraulics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ctlHydraulics";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnEngine2;
        private System.Windows.Forms.Button btnElec1;
        private System.Windows.Forms.Button btnElec2;
        private System.Windows.Forms.Button btnEngine1;
        private System.Windows.Forms.Timer tmrHydraulics;
    }
}
