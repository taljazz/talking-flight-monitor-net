namespace tfm
{
    partial class TFMMainForm
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
            this.components = new System.ComponentModel.Container();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.timerConnection = new System.Windows.Forms.Timer(this.components);
            this.TFMMainMenu = new System.Windows.Forms.MenuStrip();
            this.PlanMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenPlanMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SavePlanMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SavePlanAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.QuitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.A2AManagerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AircraftMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.WebsiteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportIssueMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TFMTabControl = new System.Windows.Forms.TabControl();
            this.AvionicsTabPage = new System.Windows.Forms.TabPage();
            this.FlyModeComboBox = new System.Windows.Forms.ComboBox();
            this.OutputLogTextBox = new System.Windows.Forms.TextBox();
            this.AutopilotCheckBox = new System.Windows.Forms.CheckBox();
            this.LockGageCheckBox = new System.Windows.Forms.CheckBox();
            this.GageValueTextBox = new System.Windows.Forms.TextBox();
            this.GageComboBox = new System.Windows.Forms.ComboBox();
            this.AvionicsExplorationTabPage = new System.Windows.Forms.TabPage();
            this.AutopilotPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.FlightPlanTabPage = new System.Windows.Forms.TabPage();
            this.ProceduresTabPage = new System.Windows.Forms.TabPage();
            this.FindTabPage = new System.Windows.Forms.TabPage();
            this.TFMMainMenu.SuspendLayout();
            this.TFMTabControl.SuspendLayout();
            this.AvionicsTabPage.SuspendLayout();
            this.AvionicsExplorationTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerMain
            // 
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // timerConnection
            // 
            this.timerConnection.Interval = 1000;
            this.timerConnection.Tick += new System.EventHandler(this.timerConnection_Tick);
            // 
            // TFMMainMenu
            // 
            this.TFMMainMenu.AccessibleDescription = "Talking flight moniter main menu";
            this.TFMMainMenu.AccessibleName = "TFM Main menu";
            this.TFMMainMenu.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TFMMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlanMenu,
            this.ToolsMenu,
            this.HelpMenu});
            this.TFMMainMenu.Location = new System.Drawing.Point(0, 0);
            this.TFMMainMenu.Name = "TFMMainMenu";
            this.TFMMainMenu.Size = new System.Drawing.Size(484, 33);
            this.TFMMainMenu.TabIndex = 0;
            this.TFMMainMenu.Text = "Main menu";
            // 
            // PlanMenu
            // 
            this.PlanMenu.AccessibleDescription = "";
            this.PlanMenu.AccessibleName = "Plan";
            this.PlanMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenPlanMenuItem,
            this.toolStripSeparator1,
            this.SavePlanMenuItem,
            this.SavePlanAsMenuItem,
            this.toolStripSeparator2,
            this.QuitMenuItem});
            this.PlanMenu.Name = "PlanMenu";
            this.PlanMenu.ShortcutKeyDisplayString = "ALT+P";
            this.PlanMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.PlanMenu.Size = new System.Drawing.Size(61, 29);
            this.PlanMenu.Text = "&Plan";
            this.PlanMenu.ToolTipText = "Load and save flight plans.";
            // 
            // OpenPlanMenuItem
            // 
            this.OpenPlanMenuItem.AccessibleDescription = "";
            this.OpenPlanMenuItem.AccessibleName = "Open...";
            this.OpenPlanMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenPlanMenuItem.Name = "OpenPlanMenuItem";
            this.OpenPlanMenuItem.ShortcutKeyDisplayString = "CONTROL+O";
            this.OpenPlanMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenPlanMenuItem.Size = new System.Drawing.Size(296, 26);
            this.OpenPlanMenuItem.Text = "&Open...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(293, 6);
            // 
            // SavePlanMenuItem
            // 
            this.SavePlanMenuItem.AccessibleDescription = "";
            this.SavePlanMenuItem.AccessibleName = "Save...";
            this.SavePlanMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SavePlanMenuItem.Name = "SavePlanMenuItem";
            this.SavePlanMenuItem.ShortcutKeyDisplayString = "CONTROL+S";
            this.SavePlanMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SavePlanMenuItem.Size = new System.Drawing.Size(296, 26);
            this.SavePlanMenuItem.Text = "&Save...";
            // 
            // SavePlanAsMenuItem
            // 
            this.SavePlanAsMenuItem.AccessibleDescription = "";
            this.SavePlanAsMenuItem.AccessibleName = "Save as...";
            this.SavePlanAsMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SavePlanAsMenuItem.Name = "SavePlanAsMenuItem";
            this.SavePlanAsMenuItem.ShortcutKeyDisplayString = "CONTROL+SHIFT+S";
            this.SavePlanAsMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SavePlanAsMenuItem.Size = new System.Drawing.Size(296, 26);
            this.SavePlanAsMenuItem.Text = "&Save as...";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(293, 6);
            // 
            // QuitMenuItem
            // 
            this.QuitMenuItem.AccessibleDescription = "";
            this.QuitMenuItem.AccessibleName = "Quit";
            this.QuitMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitMenuItem.Name = "QuitMenuItem";
            this.QuitMenuItem.ShortcutKeyDisplayString = "ALT+F4";
            this.QuitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.QuitMenuItem.Size = new System.Drawing.Size(296, 26);
            this.QuitMenuItem.Text = "&Quit";
            this.QuitMenuItem.Click += new System.EventHandler(this.QuitMenuItem_Click);
            // 
            // ToolsMenu
            // 
            this.ToolsMenu.AccessibleDescription = "";
            this.ToolsMenu.AccessibleName = "Tools";
            this.ToolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.A2AManagerMenuItem,
            this.AircraftMenuItem,
            this.SettingsMenuItem});
            this.ToolsMenu.Name = "ToolsMenu";
            this.ToolsMenu.ShortcutKeyDisplayString = "ALT+T";
            this.ToolsMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.ToolsMenu.Size = new System.Drawing.Size(67, 29);
            this.ToolsMenu.Text = "&Tools";
            // 
            // A2AManagerMenuItem
            // 
            this.A2AManagerMenuItem.AccessibleDescription = "";
            this.A2AManagerMenuItem.AccessibleName = "A2A aircraft manager";
            this.A2AManagerMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A2AManagerMenuItem.Name = "A2AManagerMenuItem";
            this.A2AManagerMenuItem.ShortcutKeyDisplayString = "CONTROL+M";
            this.A2AManagerMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.A2AManagerMenuItem.Size = new System.Drawing.Size(337, 26);
            this.A2AManagerMenuItem.Text = "A2A aircraft &manager";
            // 
            // AircraftMenuItem
            // 
            this.AircraftMenuItem.AccessibleDescription = "";
            this.AircraftMenuItem.AccessibleName = "Aircraft profiles...";
            this.AircraftMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AircraftMenuItem.Name = "AircraftMenuItem";
            this.AircraftMenuItem.ShortcutKeyDisplayString = "CONTROL+I";
            this.AircraftMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.AircraftMenuItem.Size = new System.Drawing.Size(337, 26);
            this.AircraftMenuItem.Text = "A&ircraft...";
            // 
            // SettingsMenuItem
            // 
            this.SettingsMenuItem.AccessibleDescription = "";
            this.SettingsMenuItem.AccessibleName = "Settings...";
            this.SettingsMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsMenuItem.Name = "SettingsMenuItem";
            this.SettingsMenuItem.ShortcutKeyDisplayString = "CONTROL+,";
            this.SettingsMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemcomma)));
            this.SettingsMenuItem.Size = new System.Drawing.Size(337, 26);
            this.SettingsMenuItem.Text = "&Settings...";
            this.SettingsMenuItem.Click += new System.EventHandler(this.SettingsMenuItem_Click);
            // 
            // HelpMenu
            // 
            this.HelpMenu.AccessibleDescription = "";
            this.HelpMenu.AccessibleName = "Help";
            this.HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WebsiteMenuItem,
            this.ReportIssueMenuItem,
            this.AboutMenuItem});
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.ShortcutKeyDisplayString = "ALT+H";
            this.HelpMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.HelpMenu.Size = new System.Drawing.Size(63, 29);
            this.HelpMenu.Text = "Help";
            // 
            // WebsiteMenuItem
            // 
            this.WebsiteMenuItem.AccessibleDescription = "";
            this.WebsiteMenuItem.AccessibleName = "Visit website";
            this.WebsiteMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WebsiteMenuItem.Name = "WebsiteMenuItem";
            this.WebsiteMenuItem.ShortcutKeyDisplayString = "CONTROL+W";
            this.WebsiteMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.WebsiteMenuItem.Size = new System.Drawing.Size(337, 26);
            this.WebsiteMenuItem.Text = "Visit &website";
            this.WebsiteMenuItem.Click += new System.EventHandler(this.WebsiteMenuItem_Click);
            // 
            // ReportIssueMenuItem
            // 
            this.ReportIssueMenuItem.AccessibleDescription = "";
            this.ReportIssueMenuItem.AccessibleName = "Report an issue";
            this.ReportIssueMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportIssueMenuItem.Name = "ReportIssueMenuItem";
            this.ReportIssueMenuItem.ShortcutKeyDisplayString = "CONTROL+SHIFT+I";
            this.ReportIssueMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.I)));
            this.ReportIssueMenuItem.Size = new System.Drawing.Size(337, 26);
            this.ReportIssueMenuItem.Text = "Report an &issue";
            this.ReportIssueMenuItem.Click += new System.EventHandler(this.ReportIssueMenuItem_Click);
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.AccessibleDescription = "";
            this.AboutMenuItem.AccessibleName = "About...";
            this.AboutMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(337, 26);
            this.AboutMenuItem.Text = "&About...";
            this.AboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // TFMTabControl
            // 
            this.TFMTabControl.AccessibleName = "Primary tabs";
            this.TFMTabControl.Controls.Add(this.AvionicsTabPage);
            this.TFMTabControl.Controls.Add(this.AvionicsExplorationTabPage);
            this.TFMTabControl.Controls.Add(this.FlightPlanTabPage);
            this.TFMTabControl.Controls.Add(this.ProceduresTabPage);
            this.TFMTabControl.Controls.Add(this.FindTabPage);
            this.TFMTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TFMTabControl.Location = new System.Drawing.Point(0, 33);
            this.TFMTabControl.Name = "TFMTabControl";
            this.TFMTabControl.SelectedIndex = 0;
            this.TFMTabControl.Size = new System.Drawing.Size(484, 228);
            this.TFMTabControl.TabIndex = 1;
            // 
            // AvionicsTabPage
            // 
            this.AvionicsTabPage.AccessibleName = "Avionics";
            this.AvionicsTabPage.Controls.Add(this.FlyModeComboBox);
            this.AvionicsTabPage.Controls.Add(this.OutputLogTextBox);
            this.AvionicsTabPage.Controls.Add(this.AutopilotCheckBox);
            this.AvionicsTabPage.Controls.Add(this.LockGageCheckBox);
            this.AvionicsTabPage.Controls.Add(this.GageValueTextBox);
            this.AvionicsTabPage.Controls.Add(this.GageComboBox);
            this.AvionicsTabPage.Location = new System.Drawing.Point(4, 30);
            this.AvionicsTabPage.Name = "AvionicsTabPage";
            this.AvionicsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AvionicsTabPage.Size = new System.Drawing.Size(476, 194);
            this.AvionicsTabPage.TabIndex = 0;
            this.AvionicsTabPage.Text = "Avionics";
            this.AvionicsTabPage.UseVisualStyleBackColor = true;
            // 
            // FlyModeComboBox
            // 
            this.FlyModeComboBox.AccessibleName = "Fly mode";
            this.FlyModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FlyModeComboBox.FormattingEnabled = true;
            this.FlyModeComboBox.Items.AddRange(new object[] {
            "Plan",
            "Approach"});
            this.FlyModeComboBox.Location = new System.Drawing.Point(381, 149);
            this.FlyModeComboBox.Name = "FlyModeComboBox";
            this.FlyModeComboBox.Size = new System.Drawing.Size(100, 29);
            this.FlyModeComboBox.TabIndex = 3;
            this.FlyModeComboBox.SelectedIndexChanged += new System.EventHandler(this.FlyModeComboBox_SelectedIndexChanged);
            // 
            // OutputLogTextBox
            // 
            this.OutputLogTextBox.AccessibleName = "Speech log";
            this.OutputLogTextBox.Location = new System.Drawing.Point(110, 132);
            this.OutputLogTextBox.Multiline = true;
            this.OutputLogTextBox.Name = "OutputLogTextBox";
            this.OutputLogTextBox.ReadOnly = true;
            this.OutputLogTextBox.Size = new System.Drawing.Size(160, 80);
            this.OutputLogTextBox.TabIndex = 5;
            // 
            // AutopilotCheckBox
            // 
            this.AutopilotCheckBox.AccessibleName = "Autopilot";
            this.AutopilotCheckBox.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.AutopilotCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.AutopilotCheckBox.AutoSize = true;
            this.AutopilotCheckBox.Location = new System.Drawing.Point(381, 180);
            this.AutopilotCheckBox.Name = "AutopilotCheckBox";
            this.AutopilotCheckBox.Size = new System.Drawing.Size(90, 31);
            this.AutopilotCheckBox.TabIndex = 4;
            this.AutopilotCheckBox.Text = "Autopilot";
            this.AutopilotCheckBox.UseVisualStyleBackColor = true;
            this.AutopilotCheckBox.CheckedChanged += new System.EventHandler(this.AutopilotCheckBox_CheckedChanged);
            // 
            // LockGageCheckBox
            // 
            this.LockGageCheckBox.AccessibleName = "";
            this.LockGageCheckBox.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.LockGageCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.LockGageCheckBox.AutoSize = true;
            this.LockGageCheckBox.Location = new System.Drawing.Point(381, 85);
            this.LockGageCheckBox.Name = "LockGageCheckBox";
            this.LockGageCheckBox.Size = new System.Drawing.Size(59, 31);
            this.LockGageCheckBox.TabIndex = 2;
            this.LockGageCheckBox.Text = "Lock";
            this.LockGageCheckBox.UseVisualStyleBackColor = true;
            this.LockGageCheckBox.CheckedChanged += new System.EventHandler(this.AutoGageCheckBox_CheckedChanged);
            // 
            // GageValueTextBox
            // 
            this.GageValueTextBox.Location = new System.Drawing.Point(249, 83);
            this.GageValueTextBox.Name = "GageValueTextBox";
            this.GageValueTextBox.Size = new System.Drawing.Size(100, 29);
            this.GageValueTextBox.TabIndex = 1;
            this.GageValueTextBox.WordWrap = false;
            // 
            // GageComboBox
            // 
            this.GageComboBox.AccessibleName = "Gages";
            this.GageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GageComboBox.FormattingEnabled = true;
            this.GageComboBox.Items.AddRange(new object[] {
            "Air speed",
            "Vertical speed",
            "Mach",
            "Altitude",
            "Heading",
            "Com 1",
            "Com 2",
            "Transponder",
            "Altimeter [inches]",
            "Altimeter [QNH]",
            "Nav 1",
            "Nav 2",
            "ADF"});
            this.GageComboBox.Location = new System.Drawing.Point(10, 82);
            this.GageComboBox.Name = "GageComboBox";
            this.GageComboBox.Size = new System.Drawing.Size(121, 29);
            this.GageComboBox.TabIndex = 0;
            this.GageComboBox.SelectedIndexChanged += new System.EventHandler(this.GageComboBox_SelectedIndexChanged);
            // 
            // AvionicsExplorationTabPage
            // 
            this.AvionicsExplorationTabPage.AccessibleName = "Avionics (exploration)";
            this.AvionicsExplorationTabPage.Controls.Add(this.AutopilotPropertyGrid);
            this.AvionicsExplorationTabPage.Location = new System.Drawing.Point(4, 30);
            this.AvionicsExplorationTabPage.Name = "AvionicsExplorationTabPage";
            this.AvionicsExplorationTabPage.Size = new System.Drawing.Size(476, 194);
            this.AvionicsExplorationTabPage.TabIndex = 4;
            this.AvionicsExplorationTabPage.Text = "Autopilot instrument panel";
            this.AvionicsExplorationTabPage.UseVisualStyleBackColor = true;
            // 
            // AutopilotPropertyGrid
            // 
            this.AutopilotPropertyGrid.AccessibleName = "Autopilot instrument panel";
            this.AutopilotPropertyGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.AutopilotPropertyGrid.LargeButtons = true;
            this.AutopilotPropertyGrid.LineColor = System.Drawing.SystemColors.ControlDarkDark;
            this.AutopilotPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.AutopilotPropertyGrid.Name = "AutopilotPropertyGrid";
            this.AutopilotPropertyGrid.Size = new System.Drawing.Size(130, 194);
            this.AutopilotPropertyGrid.TabIndex = 2;
            // 
            // FlightPlanTabPage
            // 
            this.FlightPlanTabPage.AccessibleName = "Flight plan";
            this.FlightPlanTabPage.Location = new System.Drawing.Point(4, 30);
            this.FlightPlanTabPage.Name = "FlightPlanTabPage";
            this.FlightPlanTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.FlightPlanTabPage.Size = new System.Drawing.Size(476, 194);
            this.FlightPlanTabPage.TabIndex = 1;
            this.FlightPlanTabPage.Text = "Flight plan";
            this.FlightPlanTabPage.UseVisualStyleBackColor = true;
            // 
            // ProceduresTabPage
            // 
            this.ProceduresTabPage.AccessibleName = "Procedures";
            this.ProceduresTabPage.Location = new System.Drawing.Point(4, 30);
            this.ProceduresTabPage.Name = "ProceduresTabPage";
            this.ProceduresTabPage.Size = new System.Drawing.Size(476, 194);
            this.ProceduresTabPage.TabIndex = 2;
            this.ProceduresTabPage.Text = "Procedures";
            this.ProceduresTabPage.UseVisualStyleBackColor = true;
            // 
            // FindTabPage
            // 
            this.FindTabPage.AccessibleName = "Find";
            this.FindTabPage.Location = new System.Drawing.Point(4, 30);
            this.FindTabPage.Name = "FindTabPage";
            this.FindTabPage.Size = new System.Drawing.Size(476, 194);
            this.FindTabPage.TabIndex = 3;
            this.FindTabPage.Text = "Find";
            this.FindTabPage.UseVisualStyleBackColor = true;
            // 
            // TFMMainForm
            // 
            this.AccessibleDescription = "";
            this.AccessibleName = "Talking flight moniter";
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.TFMTabControl);
            this.Controls.Add(this.TFMMainMenu);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MainMenuStrip = this.TFMMainMenu;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "TFMMainForm";
            this.Text = "Talking flight moniter";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.TFMMainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFMMainForm_KeyDown);
            this.TFMMainMenu.ResumeLayout(false);
            this.TFMMainMenu.PerformLayout();
            this.TFMTabControl.ResumeLayout(false);
            this.AvionicsTabPage.ResumeLayout(false);
            this.AvionicsTabPage.PerformLayout();
            this.AvionicsExplorationTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.Timer timerConnection;
        private System.Windows.Forms.MenuStrip TFMMainMenu;
        private System.Windows.Forms.ToolStripMenuItem PlanMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenPlanMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem SavePlanMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SavePlanAsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem QuitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsMenu;
        private System.Windows.Forms.ToolStripMenuItem A2AManagerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AircraftMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpMenu;
        private System.Windows.Forms.ToolStripMenuItem WebsiteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReportIssueMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.TabControl TFMTabControl;
        private System.Windows.Forms.TabPage AvionicsTabPage;
        private System.Windows.Forms.TabPage FlightPlanTabPage;
        private System.Windows.Forms.TabPage ProceduresTabPage;
        private System.Windows.Forms.TabPage FindTabPage;
        private System.Windows.Forms.ComboBox GageComboBox;
        private System.Windows.Forms.CheckBox LockGageCheckBox;
        private System.Windows.Forms.TextBox GageValueTextBox;
        private System.Windows.Forms.CheckBox AutopilotCheckBox;
        private System.Windows.Forms.TextBox OutputLogTextBox;
        private System.Windows.Forms.ComboBox FlyModeComboBox;
        private System.Windows.Forms.TabPage AvionicsExplorationTabPage;
        private System.Windows.Forms.PropertyGrid AutopilotPropertyGrid;
    }
}

