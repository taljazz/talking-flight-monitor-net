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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tcKeys = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.lvKeys = new System.Windows.Forms.ListView();
            this.hdrName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabAutopilot = new System.Windows.Forms.TabPage();
            this.lvAutopilotKeys = new System.Windows.Forms.ListView();
            this.hdrApName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrApKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabA2A = new System.Windows.Forms.TabPage();
            this.lvA2AKeys = new System.Windows.Forms.ListView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.tcKeys.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabAutopilot.SuspendLayout();
            this.tabA2A.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.tcKeys);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // tcKeys
            // 
            this.tcKeys.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab;
            this.tcKeys.Controls.Add(this.tabGeneral);
            this.tcKeys.Controls.Add(this.tabAutopilot);
            this.tcKeys.Controls.Add(this.tabA2A);
            this.tcKeys.Location = new System.Drawing.Point(3, 3);
            this.tcKeys.Name = "tcKeys";
            this.tcKeys.SelectedIndex = 0;
            this.tcKeys.Size = new System.Drawing.Size(200, 100);
            this.tcKeys.TabIndex = 0;
            this.tcKeys.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tcKeys.Selected += new System.Windows.Forms.TabControlEventHandler(this.tcKeys_Selected);
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.lvKeys);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(192, 74);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            this.tabGeneral.Click += new System.EventHandler(this.tabGeneral_Click);
            // 
            // lvKeys
            // 
            this.lvKeys.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hdrName,
            this.hdrKey});
            this.lvKeys.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvKeys.HideSelection = false;
            this.lvKeys.Location = new System.Drawing.Point(3, 3);
            this.lvKeys.MultiSelect = false;
            this.lvKeys.Name = "lvKeys";
            this.lvKeys.ShowGroups = false;
            this.lvKeys.Size = new System.Drawing.Size(186, 97);
            this.lvKeys.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvKeys.TabIndex = 0;
            this.lvKeys.UseCompatibleStateImageBehavior = false;
            this.lvKeys.View = System.Windows.Forms.View.Details;
            this.lvKeys.SelectedIndexChanged += new System.EventHandler(this.lvKeys_SelectedIndexChanged);
            // 
            // hdrName
            // 
            this.hdrName.Text = "Name";
            // 
            // hdrKey
            // 
            this.hdrKey.Text = "Key";
            // 
            // tabAutopilot
            // 
            this.tabAutopilot.Controls.Add(this.lvAutopilotKeys);
            this.tabAutopilot.Location = new System.Drawing.Point(4, 22);
            this.tabAutopilot.Name = "tabAutopilot";
            this.tabAutopilot.Padding = new System.Windows.Forms.Padding(3);
            this.tabAutopilot.Size = new System.Drawing.Size(192, 74);
            this.tabAutopilot.TabIndex = 1;
            this.tabAutopilot.Text = "Autopilot";
            this.tabAutopilot.UseVisualStyleBackColor = true;
            // 
            // lvAutopilotKeys
            // 
            this.lvAutopilotKeys.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hdrApName,
            this.hdrApKey});
            this.lvAutopilotKeys.HideSelection = false;
            this.lvAutopilotKeys.Location = new System.Drawing.Point(36, -11);
            this.lvAutopilotKeys.Name = "lvAutopilotKeys";
            this.lvAutopilotKeys.Size = new System.Drawing.Size(121, 97);
            this.lvAutopilotKeys.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvAutopilotKeys.TabIndex = 1;
            this.lvAutopilotKeys.UseCompatibleStateImageBehavior = false;
            this.lvAutopilotKeys.View = System.Windows.Forms.View.Details;
            this.lvAutopilotKeys.SelectedIndexChanged += new System.EventHandler(this.lvAutopilotKeys_SelectedIndexChanged);
            // 
            // hdrApName
            // 
            this.hdrApName.Text = "Name";
            // 
            // hdrApKey
            // 
            this.hdrApKey.Text = "Key";
            // 
            // tabA2A
            // 
            this.tabA2A.Controls.Add(this.lvA2AKeys);
            this.tabA2A.Location = new System.Drawing.Point(4, 22);
            this.tabA2A.Name = "tabA2A";
            this.tabA2A.Padding = new System.Windows.Forms.Padding(3);
            this.tabA2A.Size = new System.Drawing.Size(192, 74);
            this.tabA2A.TabIndex = 2;
            this.tabA2A.Text = "A2A";
            this.tabA2A.UseVisualStyleBackColor = true;
            // 
            // lvA2AKeys
            // 
            this.lvA2AKeys.HideSelection = false;
            this.lvA2AKeys.Location = new System.Drawing.Point(36, -11);
            this.lvA2AKeys.Name = "lvA2AKeys";
            this.lvA2AKeys.Size = new System.Drawing.Size(121, 97);
            this.lvA2AKeys.TabIndex = 1;
            this.lvA2AKeys.UseCompatibleStateImageBehavior = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnModify);
            this.flowLayoutPanel2.Controls.Add(this.btnOk);
            this.flowLayoutPanel2.Controls.Add(this.btnCancel);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 109);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(3, 3);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 0;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(84, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(3, 32);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmKeyboardManager
            // 
            this.AcceptButton = this.btnOk;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmKeyboardManager";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keyboard Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmKeyboardManager_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tcKeys.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabAutopilot.ResumeLayout(false);
            this.tabA2A.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TabControl tcKeys;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.ListView lvKeys;
        private System.Windows.Forms.TabPage tabAutopilot;
        private System.Windows.Forms.ListView lvAutopilotKeys;
        private System.Windows.Forms.TabPage tabA2A;
        private System.Windows.Forms.ListView lvA2AKeys;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColumnHeader hdrName;
        private System.Windows.Forms.ColumnHeader hdrKey;
        private System.Windows.Forms.ColumnHeader hdrApName;
        private System.Windows.Forms.ColumnHeader hdrApKey;
    }
}