using FSUIPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using NHotkey;
using NHotkey.WindowsForms;
using DavyKager;
using System.Reflection;
using System.Net.Configuration;

namespace tfm
{
    public partial class TFMMainForm : Form
    {
        public Instrumentation inst = new Instrumentation();
        private Output msg = new Output();
        msg.OutputEvent += onOutput;
        
        
        
        public TFMMainForm()
        {
            InitializeComponent();
            Aircraft.InitOffsets();
            // Start the connection timer to look for a flight sim
            this.timerConnection.Start();
        }
        // This method is called every 1 second by the connection timer.
        private void timerConnection_Tick(object sender, EventArgs e)
        {
            // Try to open the connection
            try
            {
                FSUIPCConnection.Open();
                // If there was no problem, stop this timer and start the main timer
                this.timerConnection.Stop();
                this.timerMain.Start();
                // Update the connection status

            }
            catch
            {
                // No connection found. Don't need to do anything, just keep trying
            }
        }

        // This method runs 10 times per second (every 100ms). This is set on the timerMain properties.
        private void timerMain_Tick(object sender, EventArgs e)
        {
            // Call process() to read/write data to/from FSUIPC
            // We do this in a Try/Catch block incase something goes wrong
            try
            {
                FSUIPCConnection.Process();
                inst.ReadAircraftState();
            }


            catch (Exception ex)
            {
                // An error occured. Tell the user and stop this timer.
                this.timerMain.Stop();
                MessageBox.Show("Communication with FSUIPC Failed\n\n" + ex.Message, "FSUIPC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // Update the connection status
                // start the connection timer
                this.timerConnection.Start();
            }
        }

        // Form is closing so stop all the timers and close FSUIPC Connection
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.timerConnection.Stop();
            this.timerMain.Stop();
            FSUIPCConnection.Close();
        }

        private void QuitMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void TFMMainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Manually define keyboard shortcuts for the Gages list and the gage value textbox.
            if ((e.Control && e.KeyCode == Keys.E))
            {
                GageValueTextBox.Focus();
            }// End Gage textfield assignment.
            if ((e.Control && e.KeyCode == Keys.G))
            {
                GageComboBox.Focus();
            } //End Gage list assignment.
            if ((e.Control && e.KeyCode == Keys.U))
            {
                LockGageCheckBox.Focus();
            } // End Auto gage assignment.
            if ((e.Control && e.KeyCode == Keys.F))
            {
                FlyModeComboBox.Focus();
            } //End FlyMode assignment.
            if ((e.Control && e.KeyCode == Keys.P))
            {
                AutopilotCheckBox.Focus();
            } //End autopilot assignment.

            if ((e.Control && e.KeyCode == Keys.L))
            {
                OutputLogTextBox.Focus();
            } //End output log assignment.
            if((e.Control && e.KeyCode == Keys.D1))
            {
                TFMTabControl.SelectedTab = AvionicsTabPage;
            } //End Avionics assignment.

            if((e.Control && e.KeyCode == Keys.D2)) {
                TFMTabControl.SelectedTab = FlightPlanTabPage;
            } //End FlightPlan assignment.

            if((e.Control && e.KeyCode == Keys.D3))
            {
                TFMTabControl.SelectedTab = ProceduresTabPage;
            } //End Procedures assignment.

            if((e.Control && e.KeyCode == Keys.D4))
            {
                TFMTabControl.SelectedTab = FindTabPage;
            } //End Find assignment.
                    } //End KeyDown event.

        private void GageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox GagesList = (ComboBox)sender;
            var item = GagesList.SelectedItem.ToString();
                        GageValueTextBox.AccessibleName = "Enter " + item;
            LockGageCheckBox.AccessibleName = item + " lock";
            Tolk.Output(GageValueTextBox.Text);
            var screenReader = Tolk.DetectScreenReader();
            if(screenReader == "NVDA" && GagesList.DroppedDown == false)
            {
                Tolk.Output(item + ", " + GageValueTextBox.Text);
            }
        } //End gages list selected index change event.
        private void AutoGageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (LockGageCheckBox.Checked == true)
            {
                LockGageCheckBox.ForeColor = Color.Green;
            }
            else
            {
                LockGageCheckBox.ForeColor = Color.Red;
            }//End color change.
        } //End auto gage checked changed event.
                
        private void AutopilotCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AutopilotCheckBox.Checked == true)
            {
                AutopilotCheckBox.ForeColor = Color.Green;
            }
            else
            {
                AutopilotCheckBox.ForeColor = Color.Red;
            } //End color change.
        } //End Autopilot checked changed event.

        private void FlyModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox FlyModes = (ComboBox)sender;
            var ScreenReader = Tolk.DetectScreenReader();            

            // Make sure NVDA can read the items without opening the dropDown.
if(ScreenReader == "NVDA" && FlyModes.DroppedDown == false)
            {
                Tolk.Output(FlyModes.SelectedItem.ToString());
            } //End NVDA fix.
        } //End FlyModes selected index change event.

        private void TFMMainForm_Load(object sender, EventArgs e)
        {
            GageComboBox.SelectedIndex = 0;
            FlyModeComboBox.SelectedIndex = 0;
            GageComboBox.Focus();
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        } //End About menu item.
        private void onOutput(object sender, OutputEventArgs e)
        {
            if (e.OutputText)
            {
                OutputLogTextBox.AppendText(e.msg);
            }
        }
    }//End TFMMainForm class.
} //End TFM namespace.
