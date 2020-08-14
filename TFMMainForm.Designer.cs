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
            this.TFMMainMenu.SuspendLayout();
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
            this.TFMMainMenu.Size = new System.Drawing.Size(717, 33);
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
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.AccessibleDescription = "";
            this.AboutMenuItem.AccessibleName = "About...";
            this.AboutMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(337, 26);
            this.AboutMenuItem.Text = "&About...";
            // 
            // TFMMainForm
            // 
            this.AccessibleDescription = "";
            this.AccessibleName = "Talking flight moniter";
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(717, 512);
            this.Controls.Add(this.TFMMainMenu);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.TFMMainMenu;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "TFMMainForm";
            this.Text = "Talking flight moniter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.TFMMainMenu.ResumeLayout(false);
            this.TFMMainMenu.PerformLayout();
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
    }
}

