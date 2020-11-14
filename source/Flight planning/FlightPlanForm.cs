﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm
{
    public partial class FlightPlanForm : Form
    {
        public FlightPlanForm()
        {
            InitializeComponent();
        }

        private void FlightPlanForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{FlightPlan.Title} - Flight planner";
            this.Activate();
            LoadAiracCycle();
        } // End flightPlannerForm load event.

        // Load the current Airac cycle.
        private void LoadAiracCycle()
        {
            // Get the navigraph database header. No checks against the array index because we already know
            // That there is only 1 header returned.
            var airacCycle = new navigraphContext().TblHeader.ToArray()[0];

            // Display the current version in the airac cycle textbox.
            airacCycleTextBox.Text = $"Airac cycle {airacCycle.CurrentAirac}, version {airacCycle.Version}, revision {airacCycle.Revision}";
        } // End LoadAiracCycle method.
        private void ConfigureKeyboardShortcuts(KeyEventArgs e)
        {
            // Airac cycle text field found in menu bar.
            if ((e.Alt) && (e.KeyCode == Keys.A)) {
                airacCycleTextBox.Focus();
            } // End Airac cycle shortcut.

            // Waypoints listview.
            if ((e.Control) && (e.KeyCode == Keys.W))
            {
                waypointsListView.Focus();
            } // End waypoints list shortcut.
        } // End ConfigureKeyboardShortcuts method.

        private void FlightPlanForm_KeyDown(object sender, KeyEventArgs e)
        {
            ConfigureKeyboardShortcuts(e);
        } // End KeyDown event.
    } // End FlightPlannerForm class.
} // End TFM namespace.
