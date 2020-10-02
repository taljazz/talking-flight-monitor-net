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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Sid waypoints", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("In route waypoints", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Star waypoints", System.Windows.Forms.HorizontalAlignment.Left);
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
            this.KeyManagerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CommandKeyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConnectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.WebsiteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportIssueMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotkeyHelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TFMTabControl = new System.Windows.Forms.TabControl();
            this.AvionicsTabPage = new System.Windows.Forms.TabPage();
            this.OutputLogTextBox = new System.Windows.Forms.TextBox();
            this.AutopilotCheckBox = new System.Windows.Forms.CheckBox();
            this.LockGageCheckBox = new System.Windows.Forms.CheckBox();
            this.GageValueTextBox = new System.Windows.Forms.TextBox();
            this.GageComboBox = new System.Windows.Forms.ComboBox();
            this.AvionicsExplorationTabPage = new System.Windows.Forms.TabPage();
            this.AutopilotPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.FlightPlanTabPage = new System.Windows.Forms.TabPage();
            this.waypointRestrictionsTextBox = new System.Windows.Forms.TextBox();
            this.FlyModeComboBox = new System.Windows.Forms.ComboBox();
            this.waypointsListView = new System.Windows.Forms.ListView();
            this.icaoColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.routeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.altitudeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fuelColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.frequencyColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProceduresTabPage = new System.Windows.Forms.TabPage();
            this.FindTabPage = new System.Windows.Forms.TabPage();
            this.dbLoadWorker = new System.ComponentModel.BackgroundWorker();
            this.timerLowPriority = new System.Windows.Forms.Timer(this.components);
            this.waypointsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addWaypointContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeWaypointContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.directToHereContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.holdContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeAltitudeContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeSpeedContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeVerticalSpeedContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TFMMainMenu.SuspendLayout();
            this.TFMTabControl.SuspendLayout();
            this.AvionicsTabPage.SuspendLayout();
            this.AvionicsExplorationTabPage.SuspendLayout();
            this.FlightPlanTabPage.SuspendLayout();
            this.waypointsContextMenu.SuspendLayout();
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
            this.TFMMainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TFMMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlanMenu,
            this.ToolsMenu,
            this.HelpMenu});
            this.TFMMainMenu.Location = new System.Drawing.Point(0, 0);
            this.TFMMainMenu.Name = "TFMMainMenu";
            this.TFMMainMenu.Size = new System.Drawing.Size(484, 40);
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
            this.PlanMenu.Size = new System.Drawing.Size(74, 36);
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
            this.OpenPlanMenuItem.Size = new System.Drawing.Size(365, 32);
            this.OpenPlanMenuItem.Text = "&Open...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(362, 6);
            // 
            // SavePlanMenuItem
            // 
            this.SavePlanMenuItem.AccessibleDescription = "";
            this.SavePlanMenuItem.AccessibleName = "Save...";
            this.SavePlanMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SavePlanMenuItem.Name = "SavePlanMenuItem";
            this.SavePlanMenuItem.ShortcutKeyDisplayString = "CONTROL+S";
            this.SavePlanMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SavePlanMenuItem.Size = new System.Drawing.Size(365, 32);
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
            this.SavePlanAsMenuItem.Size = new System.Drawing.Size(365, 32);
            this.SavePlanAsMenuItem.Text = "&Save as...";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(362, 6);
            // 
            // QuitMenuItem
            // 
            this.QuitMenuItem.AccessibleDescription = "";
            this.QuitMenuItem.AccessibleName = "Quit";
            this.QuitMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitMenuItem.Name = "QuitMenuItem";
            this.QuitMenuItem.ShortcutKeyDisplayString = "ALT+F4";
            this.QuitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.QuitMenuItem.Size = new System.Drawing.Size(365, 32);
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
            this.SettingsMenuItem,
            this.KeyManagerMenuItem,
            this.CommandKeyMenuItem,
            this.ConnectMenuItem});
            this.ToolsMenu.Name = "ToolsMenu";
            this.ToolsMenu.ShortcutKeyDisplayString = "ALT+T";
            this.ToolsMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.ToolsMenu.Size = new System.Drawing.Size(84, 36);
            this.ToolsMenu.Text = "&Tools";
            this.ToolsMenu.Click += new System.EventHandler(this.ToolsMenu_Click);
            // 
            // A2AManagerMenuItem
            // 
            this.A2AManagerMenuItem.AccessibleDescription = "";
            this.A2AManagerMenuItem.AccessibleName = "A2A aircraft manager";
            this.A2AManagerMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A2AManagerMenuItem.Name = "A2AManagerMenuItem";
            this.A2AManagerMenuItem.ShortcutKeyDisplayString = "CONTROL+M";
            this.A2AManagerMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.A2AManagerMenuItem.Size = new System.Drawing.Size(568, 36);
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
            this.AircraftMenuItem.Size = new System.Drawing.Size(568, 36);
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
            this.SettingsMenuItem.Size = new System.Drawing.Size(568, 36);
            this.SettingsMenuItem.Text = "&Settings...";
            this.SettingsMenuItem.Click += new System.EventHandler(this.SettingsMenuItem_Click);
            // 
            // KeyManagerMenuItem
            // 
            this.KeyManagerMenuItem.Name = "KeyManagerMenuItem";
            this.KeyManagerMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.KeyManagerMenuItem.Size = new System.Drawing.Size(568, 36);
            this.KeyManagerMenuItem.Text = "&Keyboard Manager";
            this.KeyManagerMenuItem.Click += new System.EventHandler(this.KeyManagerMenuItem_Click);
            // 
            // CommandKeyMenuItem
            // 
            this.CommandKeyMenuItem.CheckOnClick = true;
            this.CommandKeyMenuItem.Name = "CommandKeyMenuItem";
            this.CommandKeyMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.CommandKeyMenuItem.Size = new System.Drawing.Size(568, 36);
            this.CommandKeyMenuItem.Text = "Enable/Disable command key";
            this.CommandKeyMenuItem.Click += new System.EventHandler(this.CommandKeyMenuItem_Click);
            // 
            // ConnectMenuItem
            // 
            this.ConnectMenuItem.AccessibleName = "Connect to simulator";
            this.ConnectMenuItem.Name = "ConnectMenuItem";
            this.ConnectMenuItem.ShortcutKeyDisplayString = "CTRL+SHIFT+R";
            this.ConnectMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.ConnectMenuItem.Size = new System.Drawing.Size(568, 36);
            this.ConnectMenuItem.Text = "&Connect to simulator";
            this.ConnectMenuItem.Click += new System.EventHandler(this.ConnectMenuItem_Click);
            // 
            // HelpMenu
            // 
            this.HelpMenu.AccessibleDescription = "";
            this.HelpMenu.AccessibleName = "Help";
            this.HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WebsiteMenuItem,
            this.ReportIssueMenuItem,
            this.AboutMenuItem,
            this.hotkeyHelpMenuItem});
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.ShortcutKeyDisplayString = "ALT+H";
            this.HelpMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.HelpMenu.Size = new System.Drawing.Size(79, 36);
            this.HelpMenu.Text = "Help";
            // 
            // WebsiteMenuItem
            // 
            this.WebsiteMenuItem.AccessibleDescription = "";
            this.WebsiteMenuItem.AccessibleName = "Visit website";
            this.WebsiteMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WebsiteMenuItem.Name = "WebsiteMenuItem";
            this.WebsiteMenuItem.ShortcutKeyDisplayString = "CONTROL+SHIFT+W";
            this.WebsiteMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.W)));
            this.WebsiteMenuItem.Size = new System.Drawing.Size(415, 36);
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
            this.ReportIssueMenuItem.Size = new System.Drawing.Size(415, 36);
            this.ReportIssueMenuItem.Text = "Report an &issue";
            this.ReportIssueMenuItem.Click += new System.EventHandler(this.ReportIssueMenuItem_Click);
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.AccessibleDescription = "";
            this.AboutMenuItem.AccessibleName = "About...";
            this.AboutMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(415, 36);
            this.AboutMenuItem.Text = "&About...";
            this.AboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // hotkeyHelpMenuItem
            // 
            this.hotkeyHelpMenuItem.Name = "hotkeyHelpMenuItem";
            this.hotkeyHelpMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.hotkeyHelpMenuItem.Size = new System.Drawing.Size(415, 36);
            this.hotkeyHelpMenuItem.Text = "Hotkey help";
            this.hotkeyHelpMenuItem.Click += new System.EventHandler(this.hotkeyHelpMenuItem_Click);
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
            this.TFMTabControl.Location = new System.Drawing.Point(0, 40);
            this.TFMTabControl.Name = "TFMTabControl";
            this.TFMTabControl.SelectedIndex = 0;
            this.TFMTabControl.Size = new System.Drawing.Size(484, 221);
            this.TFMTabControl.TabIndex = 1;
            // 
            // AvionicsTabPage
            // 
            this.AvionicsTabPage.AccessibleName = "Avionics";
            this.AvionicsTabPage.Controls.Add(this.OutputLogTextBox);
            this.AvionicsTabPage.Controls.Add(this.AutopilotCheckBox);
            this.AvionicsTabPage.Controls.Add(this.LockGageCheckBox);
            this.AvionicsTabPage.Controls.Add(this.GageValueTextBox);
            this.AvionicsTabPage.Controls.Add(this.GageComboBox);
            this.AvionicsTabPage.Location = new System.Drawing.Point(4, 36);
            this.AvionicsTabPage.Name = "AvionicsTabPage";
            this.AvionicsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AvionicsTabPage.Size = new System.Drawing.Size(476, 181);
            this.AvionicsTabPage.TabIndex = 0;
            this.AvionicsTabPage.Text = "Avionics";
            this.AvionicsTabPage.UseVisualStyleBackColor = true;
            // 
            // OutputLogTextBox
            // 
            this.OutputLogTextBox.AccessibleName = "Speech log";
            this.OutputLogTextBox.Location = new System.Drawing.Point(109, 131);
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
            this.AutopilotCheckBox.Location = new System.Drawing.Point(381, 163);
            this.AutopilotCheckBox.Name = "AutopilotCheckBox";
            this.AutopilotCheckBox.Size = new System.Drawing.Size(113, 37);
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
            this.LockGageCheckBox.Location = new System.Drawing.Point(381, 86);
            this.LockGageCheckBox.Name = "LockGageCheckBox";
            this.LockGageCheckBox.Size = new System.Drawing.Size(72, 37);
            this.LockGageCheckBox.TabIndex = 2;
            this.LockGageCheckBox.Text = "Lock";
            this.LockGageCheckBox.UseVisualStyleBackColor = true;
            this.LockGageCheckBox.CheckedChanged += new System.EventHandler(this.AutoGageCheckBox_CheckedChanged);
            // 
            // GageValueTextBox
            // 
            this.GageValueTextBox.AcceptsReturn = true;
            this.GageValueTextBox.Location = new System.Drawing.Point(249, 83);
            this.GageValueTextBox.Name = "GageValueTextBox";
            this.GageValueTextBox.Size = new System.Drawing.Size(100, 35);
            this.GageValueTextBox.TabIndex = 1;
            this.GageValueTextBox.WordWrap = false;
            this.GageValueTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GageValueTextBox_KeyDown);
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
            this.GageComboBox.Size = new System.Drawing.Size(121, 35);
            this.GageComboBox.TabIndex = 0;
            this.GageComboBox.SelectedIndexChanged += new System.EventHandler(this.GageComboBox_SelectedIndexChanged);
            // 
            // AvionicsExplorationTabPage
            // 
            this.AvionicsExplorationTabPage.AccessibleName = "Avionics (exploration)";
            this.AvionicsExplorationTabPage.Controls.Add(this.AutopilotPropertyGrid);
            this.AvionicsExplorationTabPage.Location = new System.Drawing.Point(4, 36);
            this.AvionicsExplorationTabPage.Name = "AvionicsExplorationTabPage";
            this.AvionicsExplorationTabPage.Size = new System.Drawing.Size(476, 181);
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
            this.AutopilotPropertyGrid.Size = new System.Drawing.Size(130, 181);
            this.AutopilotPropertyGrid.TabIndex = 2;
            // 
            // FlightPlanTabPage
            // 
            this.FlightPlanTabPage.AccessibleName = "Flight plan";
            this.FlightPlanTabPage.Controls.Add(this.waypointRestrictionsTextBox);
            this.FlightPlanTabPage.Controls.Add(this.FlyModeComboBox);
            this.FlightPlanTabPage.Controls.Add(this.waypointsListView);
            this.FlightPlanTabPage.Location = new System.Drawing.Point(4, 36);
            this.FlightPlanTabPage.Name = "FlightPlanTabPage";
            this.FlightPlanTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.FlightPlanTabPage.Size = new System.Drawing.Size(476, 181);
            this.FlightPlanTabPage.TabIndex = 1;
            this.FlightPlanTabPage.Text = "Flight plan";
            this.FlightPlanTabPage.UseVisualStyleBackColor = true;
            // 
            // waypointRestrictionsTextBox
            // 
            this.waypointRestrictionsTextBox.AccessibleName = "Waypoint restrictions";
            this.waypointRestrictionsTextBox.Location = new System.Drawing.Point(6, 112);
            this.waypointRestrictionsTextBox.Multiline = true;
            this.waypointRestrictionsTextBox.Name = "waypointRestrictionsTextBox";
            this.waypointRestrictionsTextBox.ReadOnly = true;
            this.waypointRestrictionsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.waypointRestrictionsTextBox.Size = new System.Drawing.Size(300, 88);
            this.waypointRestrictionsTextBox.TabIndex = 1;
            // 
            // FlyModeComboBox
            // 
            this.FlyModeComboBox.AccessibleName = "Fly mode";
            this.FlyModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FlyModeComboBox.FormattingEnabled = true;
            this.FlyModeComboBox.Items.AddRange(new object[] {
            "Plan",
            "Approach"});
            this.FlyModeComboBox.Location = new System.Drawing.Point(375, 150);
            this.FlyModeComboBox.Name = "FlyModeComboBox";
            this.FlyModeComboBox.Size = new System.Drawing.Size(100, 35);
            this.FlyModeComboBox.TabIndex = 4;
            // 
            // waypointsListView
            // 
            this.waypointsListView.AccessibleName = "Waypoints";
            this.waypointsListView.AllowColumnReorder = true;
            this.waypointsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.icaoColumnHeader,
            this.nameColumnHeader,
            this.routeColumnHeader,
            this.altitudeColumnHeader,
            this.timeColumnHeader,
            this.fuelColumnHeader,
            this.frequencyColumnHeader});
            this.waypointsListView.ContextMenuStrip = this.waypointsContextMenu;
            listViewGroup1.Header = "Sid waypoints";
            listViewGroup1.Name = "sidWaypointsListViewGroup";
            listViewGroup2.Header = "In route waypoints";
            listViewGroup2.Name = "inRouteWaypointsListViewGroup";
            listViewGroup3.Header = "Star waypoints";
            listViewGroup3.Name = "starWaypointsListViewGroup";
            this.waypointsListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.waypointsListView.HideSelection = false;
            this.waypointsListView.Location = new System.Drawing.Point(6, 6);
            this.waypointsListView.Name = "waypointsListView";
            this.waypointsListView.Size = new System.Drawing.Size(469, 100);
            this.waypointsListView.TabIndex = 0;
            this.waypointsListView.UseCompatibleStateImageBehavior = false;
            this.waypointsListView.View = System.Windows.Forms.View.Details;
            // 
            // icaoColumnHeader
            // 
            this.icaoColumnHeader.Text = "ICAO";
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            // 
            // routeColumnHeader
            // 
            this.routeColumnHeader.Text = "Route";
            // 
            // altitudeColumnHeader
            // 
            this.altitudeColumnHeader.Text = "Altitude";
            // 
            // timeColumnHeader
            // 
            this.timeColumnHeader.Text = "Time";
            // 
            // fuelColumnHeader
            // 
            this.fuelColumnHeader.Text = "Fuel";
            // 
            // frequencyColumnHeader
            // 
            this.frequencyColumnHeader.Text = "Frequency";
            // 
            // ProceduresTabPage
            // 
            this.ProceduresTabPage.AccessibleName = "Procedures";
            this.ProceduresTabPage.Location = new System.Drawing.Point(4, 36);
            this.ProceduresTabPage.Name = "ProceduresTabPage";
            this.ProceduresTabPage.Size = new System.Drawing.Size(476, 181);
            this.ProceduresTabPage.TabIndex = 2;
            this.ProceduresTabPage.Text = "Procedures";
            this.ProceduresTabPage.UseVisualStyleBackColor = true;
            // 
            // FindTabPage
            // 
            this.FindTabPage.AccessibleName = "Find";
            this.FindTabPage.Location = new System.Drawing.Point(4, 36);
            this.FindTabPage.Name = "FindTabPage";
            this.FindTabPage.Size = new System.Drawing.Size(476, 181);
            this.FindTabPage.TabIndex = 3;
            this.FindTabPage.Text = "Find";
            this.FindTabPage.UseVisualStyleBackColor = true;
            // 
            // dbLoadWorker
            // 
            this.dbLoadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.dbLoadWorker_DoWork);
            // 
            // timerLowPriority
            // 
            this.timerLowPriority.Interval = 1000;
            this.timerLowPriority.Tick += new System.EventHandler(this.timerLowPriority_Tick);
            // 
            // waypointsContextMenu
            // 
            this.waypointsContextMenu.AccessibleName = "Waypoint menu";
            this.waypointsContextMenu.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waypointsContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.waypointsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addWaypointContextMenuItem,
            this.removeWaypointContextMenu,
            this.directToHereContextMenuItem,
            this.holdContextMenuItem,
            this.changeAltitudeContextMenuItem,
            this.changeSpeedContextMenuItem,
            this.changeVerticalSpeedContextMenuItem});
            this.waypointsContextMenu.Name = "waypointsContextMenu";
            this.waypointsContextMenu.Size = new System.Drawing.Size(297, 228);
            // 
            // addWaypointContextMenuItem
            // 
            this.addWaypointContextMenuItem.AccessibleName = "Add waypoint";
            this.addWaypointContextMenuItem.Name = "addWaypointContextMenuItem";
            this.addWaypointContextMenuItem.Size = new System.Drawing.Size(296, 32);
            this.addWaypointContextMenuItem.Text = "&Add waypoint";
            // 
            // removeWaypointContextMenu
            // 
            this.removeWaypointContextMenu.Name = "removeWaypointContextMenu";
            this.removeWaypointContextMenu.Size = new System.Drawing.Size(296, 32);
            this.removeWaypointContextMenu.Text = "&Remove waypoint";
            // 
            // directToHereContextMenuItem
            // 
            this.directToHereContextMenuItem.AccessibleName = "Direct to here";
            this.directToHereContextMenuItem.Name = "directToHereContextMenuItem";
            this.directToHereContextMenuItem.Size = new System.Drawing.Size(296, 32);
            this.directToHereContextMenuItem.Text = "&Direct to here";
            // 
            // holdContextMenuItem
            // 
            this.holdContextMenuItem.AccessibleName = "Hold";
            this.holdContextMenuItem.Name = "holdContextMenuItem";
            this.holdContextMenuItem.Size = new System.Drawing.Size(296, 32);
            this.holdContextMenuItem.Text = "&hold";
            // 
            // changeAltitudeContextMenuItem
            // 
            this.changeAltitudeContextMenuItem.AccessibleName = "Change altitude";
            this.changeAltitudeContextMenuItem.Name = "changeAltitudeContextMenuItem";
            this.changeAltitudeContextMenuItem.Size = new System.Drawing.Size(296, 32);
            this.changeAltitudeContextMenuItem.Text = "Change &altitude";
            // 
            // changeSpeedContextMenuItem
            // 
            this.changeSpeedContextMenuItem.AccessibleName = "Change speed";
            this.changeSpeedContextMenuItem.Name = "changeSpeedContextMenuItem";
            this.changeSpeedContextMenuItem.Size = new System.Drawing.Size(296, 32);
            this.changeSpeedContextMenuItem.Text = "Change &speed";
            // 
            // changeVerticalSpeedContextMenuItem
            // 
            this.changeVerticalSpeedContextMenuItem.AccessibleName = "Change vertical speed";
            this.changeVerticalSpeedContextMenuItem.Name = "changeVerticalSpeedContextMenuItem";
            this.changeVerticalSpeedContextMenuItem.Size = new System.Drawing.Size(296, 32);
            this.changeVerticalSpeedContextMenuItem.Text = "Change &vertical speed";
            // 
            // TFMMainForm
            // 
            this.AccessibleDescription = "";
            this.AccessibleName = "Talking flight moniter";
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 27F);
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
            this.FlightPlanTabPage.ResumeLayout(false);
            this.FlightPlanTabPage.PerformLayout();
            this.waypointsContextMenu.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage AvionicsExplorationTabPage;
        private System.Windows.Forms.PropertyGrid AutopilotPropertyGrid;
        private System.ComponentModel.BackgroundWorker dbLoadWorker;
        private System.Windows.Forms.ToolStripMenuItem KeyManagerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CommandKeyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hotkeyHelpMenuItem;
        private System.Windows.Forms.Timer timerLowPriority;
        private System.Windows.Forms.ToolStripMenuItem ConnectMenuItem;
        private System.Windows.Forms.ListView waypointsListView;
        private System.Windows.Forms.ColumnHeader icaoColumnHeader;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader routeColumnHeader;
        private System.Windows.Forms.ColumnHeader altitudeColumnHeader;
        private System.Windows.Forms.ColumnHeader timeColumnHeader;
        private System.Windows.Forms.ColumnHeader fuelColumnHeader;
        private System.Windows.Forms.ColumnHeader frequencyColumnHeader;
        private System.Windows.Forms.TextBox waypointRestrictionsTextBox;
        private System.Windows.Forms.ComboBox FlyModeComboBox;
        private System.Windows.Forms.ContextMenuStrip waypointsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem addWaypointContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeWaypointContextMenu;
        private System.Windows.Forms.ToolStripMenuItem directToHereContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem holdContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeAltitudeContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeSpeedContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeVerticalSpeedContextMenuItem;
    }
}

