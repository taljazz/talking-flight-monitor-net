namespace tfm.Keyboard_manager
{
    partial class frmKeyboardManager
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
            this.lvKeys = new System.Windows.Forms.ListView();
            this.hdrFunction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnModify = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lvKeys, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnModify, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOk, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lvKeys
            // 
            this.lvKeys.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hdrFunction,
            this.hdrKey});
            this.lvKeys.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvKeys.HideSelection = false;
            this.lvKeys.Location = new System.Drawing.Point(3, 3);
            this.lvKeys.MultiSelect = false;
            this.lvKeys.Name = "lvKeys";
            this.lvKeys.ShowGroups = false;
            this.lvKeys.Size = new System.Drawing.Size(94, 44);
            this.lvKeys.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvKeys.TabIndex = 0;
            this.lvKeys.UseCompatibleStateImageBehavior = false;
            this.lvKeys.View = System.Windows.Forms.View.Details;
            this.lvKeys.SelectedIndexChanged += new System.EventHandler(this.lvKeys_SelectedIndexChanged);
            // 
            // hdrFunction
            // 
            this.hdrFunction.Text = "Function";
            // 
            // hdrKey
            // 
            this.hdrKey.Text = "Key";
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(103, 3);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 1;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(3, 53);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // frmKeyboardManager
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmKeyboardManager";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keyboard Manager";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView lvKeys;
        private System.Windows.Forms.ColumnHeader hdrFunction;
        private System.Windows.Forms.ColumnHeader hdrKey;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnOk;
    }
}