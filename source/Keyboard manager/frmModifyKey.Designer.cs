namespace tfm.Keyboard_manager
{
    partial class frmModifyKey
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chkAlt = new System.Windows.Forms.CheckBox();
            this.chkControl = new System.Windows.Forms.CheckBox();
            this.chkShift = new System.Windows.Forms.CheckBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chkAlt, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkControl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkShift, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtKey, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnOk, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chkAlt
            // 
            this.chkAlt.AutoSize = true;
            this.chkAlt.Location = new System.Drawing.Point(3, 3);
            this.chkAlt.Name = "chkAlt";
            this.chkAlt.Size = new System.Drawing.Size(38, 17);
            this.chkAlt.TabIndex = 0;
            this.chkAlt.Text = "Alt";
            this.chkAlt.UseVisualStyleBackColor = true;
            // 
            // chkControl
            // 
            this.chkControl.AutoSize = true;
            this.chkControl.Location = new System.Drawing.Point(3, 33);
            this.chkControl.Name = "chkControl";
            this.chkControl.Size = new System.Drawing.Size(59, 17);
            this.chkControl.TabIndex = 1;
            this.chkControl.Text = "Control";
            this.chkControl.UseVisualStyleBackColor = true;
            // 
            // chkShift
            // 
            this.chkShift.AutoSize = true;
            this.chkShift.Location = new System.Drawing.Point(3, 63);
            this.chkShift.Name = "chkShift";
            this.chkShift.Size = new System.Drawing.Size(47, 14);
            this.chkShift.TabIndex = 2;
            this.chkShift.Text = "Shift";
            this.chkShift.UseVisualStyleBackColor = true;
            // 
            // txtKey
            // 
            this.txtKey.AccessibleName = "Key";
            this.txtKey.Location = new System.Drawing.Point(3, 83);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(94, 20);
            this.txtKey.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(103, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(103, 33);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmModifyKey
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModifyKey";
            this.Text = "Modify key";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chkAlt;
        private System.Windows.Forms.CheckBox chkControl;
        private System.Windows.Forms.CheckBox chkShift;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}