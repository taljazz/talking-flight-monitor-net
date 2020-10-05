namespace tfm
{
    partial class FlightPlanForm
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.planMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.NewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.simBriefMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPlanMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aircraftMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proceduresMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.airportsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taxiwaysMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gatesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runwaysMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sidsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.starsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.approachesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navigraphCycleTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.AccessibleName = "Main menu";
            this.mainMenu.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.planMenu,
            this.proceduresMenu,
            this.navigraphCycleTextBox});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(13, 3, 0, 3);
            this.mainMenu.Size = new System.Drawing.Size(1300, 40);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "Main menu";
            // 
            // planMenu
            // 
            this.planMenu.AccessibleName = "Plan";
            this.planMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewMenu,
            this.openPlanMenuItem,
            this.toolStripSeparator1,
            this.saveMenuItem,
            this.saveAsMenuItem,
            this.toolStripSeparator2,
            this.aircraftMenuItem,
            this.toolStripSeparator3,
            this.closeMenuItem});
            this.planMenu.Name = "planMenu";
            this.planMenu.Size = new System.Drawing.Size(69, 34);
            this.planMenu.Text = "&Plan";
            // 
            // NewMenu
            // 
            this.NewMenu.AccessibleName = "New";
            this.NewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simBriefMenuItem,
            this.openMenuItem});
            this.NewMenu.Name = "NewMenu";
            this.NewMenu.Size = new System.Drawing.Size(192, 32);
            this.NewMenu.Text = "&New";
            // 
            // simBriefMenuItem
            // 
            this.simBriefMenuItem.AccessibleName = "From Simbrief...";
            this.simBriefMenuItem.Name = "simBriefMenuItem";
            this.simBriefMenuItem.Size = new System.Drawing.Size(254, 32);
            this.simBriefMenuItem.Text = "From &Simbrief...";
            // 
            // openMenuItem
            // 
            this.openMenuItem.AccessibleName = "Open...";
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(254, 32);
            this.openMenuItem.Text = "&Open...";
            // 
            // openPlanMenuItem
            // 
            this.openPlanMenuItem.AccessibleName = "Open...";
            this.openPlanMenuItem.Name = "openPlanMenuItem";
            this.openPlanMenuItem.Size = new System.Drawing.Size(192, 32);
            this.openPlanMenuItem.Text = "&Open...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.Equation;
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.Size = new System.Drawing.Size(192, 32);
            this.saveMenuItem.Text = "&Save";
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.AccessibleName = "Save as...";
            this.saveAsMenuItem.Name = "saveAsMenuItem";
            this.saveAsMenuItem.Size = new System.Drawing.Size(192, 32);
            this.saveAsMenuItem.Text = "Save &as...";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(189, 6);
            // 
            // aircraftMenuItem
            // 
            this.aircraftMenuItem.AccessibleName = "Aircraft...";
            this.aircraftMenuItem.Name = "aircraftMenuItem";
            this.aircraftMenuItem.Size = new System.Drawing.Size(192, 32);
            this.aircraftMenuItem.Text = "&Aircraft...";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(189, 6);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.Size = new System.Drawing.Size(192, 32);
            this.closeMenuItem.Text = "&Close";
            // 
            // proceduresMenu
            // 
            this.proceduresMenu.AccessibleName = "Procedures";
            this.proceduresMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.airportsMenuItem,
            this.taxiwaysMenuItem,
            this.gatesMenuItem,
            this.runwaysMenuItem,
            this.sidsMenuItem,
            this.starsMenuItem,
            this.approachesMenuItem});
            this.proceduresMenu.Name = "proceduresMenu";
            this.proceduresMenu.Size = new System.Drawing.Size(134, 34);
            this.proceduresMenu.Text = "P&rocedures";
            // 
            // airportsMenuItem
            // 
            this.airportsMenuItem.AccessibleName = "Airports...";
            this.airportsMenuItem.Name = "airportsMenuItem";
            this.airportsMenuItem.Size = new System.Drawing.Size(231, 32);
            this.airportsMenuItem.Text = "&Airports...";
            // 
            // taxiwaysMenuItem
            // 
            this.taxiwaysMenuItem.AccessibleName = "Taxiways...";
            this.taxiwaysMenuItem.Name = "taxiwaysMenuItem";
            this.taxiwaysMenuItem.Size = new System.Drawing.Size(231, 32);
            this.taxiwaysMenuItem.Text = "&Taxiways...";
            // 
            // gatesMenuItem
            // 
            this.gatesMenuItem.AccessibleName = "Gates...";
            this.gatesMenuItem.Name = "gatesMenuItem";
            this.gatesMenuItem.Size = new System.Drawing.Size(231, 32);
            this.gatesMenuItem.Text = "&Gates...";
            // 
            // runwaysMenuItem
            // 
            this.runwaysMenuItem.AccessibleName = "Runways...";
            this.runwaysMenuItem.Name = "runwaysMenuItem";
            this.runwaysMenuItem.Size = new System.Drawing.Size(231, 32);
            this.runwaysMenuItem.Text = "&Runways...";
            // 
            // sidsMenuItem
            // 
            this.sidsMenuItem.AccessibleName = "Sids...";
            this.sidsMenuItem.Name = "sidsMenuItem";
            this.sidsMenuItem.Size = new System.Drawing.Size(231, 32);
            this.sidsMenuItem.Text = "&Sids...";
            // 
            // starsMenuItem
            // 
            this.starsMenuItem.AccessibleName = "Stars...";
            this.starsMenuItem.Name = "starsMenuItem";
            this.starsMenuItem.Size = new System.Drawing.Size(231, 32);
            this.starsMenuItem.Text = "&Stars...";
            // 
            // approachesMenuItem
            // 
            this.approachesMenuItem.AccessibleName = "Approaches...";
            this.approachesMenuItem.Name = "approachesMenuItem";
            this.approachesMenuItem.Size = new System.Drawing.Size(231, 32);
            this.approachesMenuItem.Text = "&Approaches...";
            // 
            // navigraphCycleTextBox
            // 
            this.navigraphCycleTextBox.AccessibleName = "Aeric cycle";
            this.navigraphCycleTextBox.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navigraphCycleTextBox.Name = "navigraphCycleTextBox";
            this.navigraphCycleTextBox.ReadOnly = true;
            this.navigraphCycleTextBox.Size = new System.Drawing.Size(160, 34);
            // 
            // FlightPlanForm
            // 
            this.AccessibleName = "Flight planner";
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1300, 731);
            this.Controls.Add(this.mainMenu);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FlightPlanForm";
            this.Text = "Flight planning";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FlightPlanForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem planMenu;
        private System.Windows.Forms.ToolStripMenuItem proceduresMenu;
        private System.Windows.Forms.ToolStripTextBox navigraphCycleTextBox;
        private System.Windows.Forms.ToolStripMenuItem NewMenu;
        private System.Windows.Forms.ToolStripMenuItem simBriefMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPlanMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem aircraftMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem closeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem airportsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taxiwaysMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gatesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runwaysMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sidsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem starsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem approachesMenuItem;
    }
}