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
using tfm.Properties;

namespace tfm
{
    public partial class TFMMainForm : Form
    {
        public Instrumentation inst = new Instrumentation();
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
                // Keeps track of the autopilot master switch in the simplified avionics tab.
                if (Properties.Settings.Default.avionics_tab == "simplified") { 
                AutopilotCheckBox.Checked = inst.ApMaster;

                // Keep track of the locks/holds on each autopilot gage.
                var apGage = GageComboBox.SelectedItem.ToString();
                switch (apGage)
                {
                    case "Heading":
                        LockGageCheckBox.Checked = inst.ApHeadingLock;
                        break;
                    case "Air speed":
                        LockGageCheckBox.Checked = inst.ApAirspeedHold;
                        break;
                    case "Altitude":
                        LockGageCheckBox.Checked = inst.ApAltitudeLock;
                        break;
                    case "Mach":
                        LockGageCheckBox.Checked = inst.ApMachHold;
                        break;
                    case "Vertical speed":
                        LockGageCheckBox.Checked = inst.ApVerticalSpeedHold;
                        break;
                    case "Nav 1":
                        LockGageCheckBox.Checked = inst.ApNavLock;
                        break;
                    case "default":
                        break;
                }
            }
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

        // This runs when the master avionics tick has been changed

        // Form is closing so stop all the timers and close FSUIPC Connection
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.timerConnection.Stop();
            this.timerMain.Stop();
            FSUIPCConnection.Close();
        }

        private void QuitMenuItem_Click     (object sender, EventArgs e)
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
            if ((e.Control && e.KeyCode == Keys.D1))
            {
                if (TFMTabControl.TabPages.Contains(AvionicsTabPage)) { 
                TFMTabControl.SelectedTab = AvionicsTabPage;
            } else
            {
                TFMTabControl.SelectedTab = AvionicsExplorationTabPage;
            }
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
            // Assign the airplane auto pilot gages to the gage value field.
            // See related checked changed events for locks and apMaster switch.

                switch(item)
                {
                    case "ADF":
                    GageValueTextBox.Text = inst.Adf1Freq.ToString();
                        LockGageCheckBox.Visible = false;
                        break;
                case "Air speed":
                    GageValueTextBox.Text = inst.ApAirspeed.ToString();
                    LockGageCheckBox.Visible = true;
                    LockGageCheckBox.Checked = inst.ApAirspeedHold;
                    break;
                case "Vertical speed":
                    GageValueTextBox.Text = inst.ApVerticalSpeed.ToString();
                    LockGageCheckBox.Visible = true;
                    LockGageCheckBox.Checked = inst.ApVerticalSpeedHold;
                    break;
                case "Mach":
                    GageValueTextBox.Text = inst.ApMachSpeed.ToString();
                    LockGageCheckBox.Visible = true;
                    LockGageCheckBox.Checked = inst.ApMachHold;
                    break;
                case "Altitude":
                    GageValueTextBox.Text = inst.ApAltitude.ToString();
                    LockGageCheckBox.Visible = true;
                    LockGageCheckBox.Checked = inst.ApAltitudeLock;
                    break;
                case "Heading":
                    GageValueTextBox.Text = inst.ApHeading.ToString();
                    LockGageCheckBox.Visible = true;
                    LockGageCheckBox.Checked = inst.ApHeadingLock;
                    break;
                case "Com 1":
                    GageValueTextBox.Text = inst.Com1Freq.ToString();
                    LockGageCheckBox.Visible = false;
                    break;
                case "Com 2":
                    GageValueTextBox.Text = inst.Com2Freq.ToString();
                    LockGageCheckBox.Checked = false;
                    break;
                case "Transponder":
                    GageValueTextBox.Text = inst.Transponder.ToString();
                    LockGageCheckBox.Visible = false;
                    break;
                case "Altimeter [inches]":
                    GageValueTextBox.Text = inst.AltimeterInches.ToString();
                    LockGageCheckBox.Visible = false;
                    break;
                case "Altimeter [QNH]":
                    GageValueTextBox.Text = inst.AltimeterQNH.ToString();
                    LockGageCheckBox.Visible = false;
                    break;
                case "Nav 1":
                    GageValueTextBox.Text = inst.Nav1Freq.ToString();
                    LockGageCheckBox.Visible = true;
                    LockGageCheckBox.Checked = inst.ApNavLock;
                    break;
                case "Nav 2":
                    GageValueTextBox.Text = inst.Nav2Freq.ToString();
                    LockGageCheckBox.Visible = false;
                    break;
                case "default":
                    GageValueTextBox.Text = "That gage is not supported at this time.";
                    break;
                }
                                       
                        var screenReader = Tolk.DetectScreenReader();
            if(screenReader == "NVDA" && GagesList.DroppedDown == false)
            {
                Tolk.Output(GageValueTextBox.Text + ", " + GagesList.SelectedItem.ToString());
            } else
            {
                Tolk.Output(GageValueTextBox.Text);
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
            inst.ApMaster = AutopilotCheckBox.Checked;
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
            //Move to a configure function when implementing settings.
            if (Properties.Settings.Default.avionics_tab == "simplified")
            {
                TFMTabControl.TabPages.Remove(AvionicsExplorationTabPage);
                GageComboBox.SelectedIndex = 0;
                FlyModeComboBox.SelectedIndex = 0;
                GageComboBox.Focus();
                AutopilotCheckBox.Checked = inst.ApMaster;
            }
            else
            {
                                //Following code is expiremental.

                TFMTabControl.TabPages.Remove(AvionicsTabPage);
                                AutopilotPropertyGrid.SelectedObject = inst;
            }
                    }

                        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        } //End About menu item.

        private void WebsiteMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/jfayre/talking-flight-monitor-net");                       
        }

        private void ReportIssueMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/jfayre/talking-flight-monitor-net/issues");
        }

        private void GageValueTextBox_KeyDown(object sender, KeyEventArgs e)
        {
                        if (e.KeyCode == Keys.Enter)
            {
                                
                var apGage = GageComboBox.SelectedItem.ToString();
                switch (apGage)
                {
                    case "Air speed":
                        if (Double.TryParse(GageValueTextBox.Text, out double airSpeed) && airSpeed > 0)
                        {
                            inst.ApAirspeed = airSpeed;
                            GageValueTextBox.Text = inst.ApAirspeed.ToString();
                        } else
                        {
                            GageValueTextBox.Text = string.Empty;
                            Tolk.Output("Invalid air speed");
                        }
                        break;
                    case "Vertical speed":
                        if (Double.TryParse(GageValueTextBox.Text, out double verticalSpeed))
                        {
                            inst.ApVerticalSpeed = verticalSpeed;
                            GageValueTextBox.Text = inst.ApVerticalSpeed.ToString();
                        } else
                        {
                            GageValueTextBox.Text = string.Empty;
                            Tolk.Output("Invalid vertical speed");
                        }
                        break;
                    case "Mach":
                        if(Double.TryParse(GageValueTextBox.Text, out double machSpeed))
                        {
                            inst.ApMachSpeed = machSpeed;
                            GageValueTextBox.Text = inst.ApMachSpeed.ToString();
                        } else
                        {
                            GageValueTextBox.Text = string.Empty;
                            Tolk.Output("Invalid mach speed");
                        }
                        break;
                    case "Altitude":
                        if(Double.TryParse(GageValueTextBox.Text, out double altitude))
                        {
                            inst.ApAltitude = altitude;
                            GageValueTextBox.Text = inst.ApAltitude.ToString();
                        } else
                        {
                            GageValueTextBox.Text = string.Empty;
                            Tolk.Output("Invalid altitude.");
                        }
                        break;
                    case "Heading":
                        if(Double.TryParse(GageValueTextBox.Text, out Double heading) && heading <= 359)
                        {
                            inst.ApHeading = heading;
                            GageValueTextBox.Text = inst.ApHeading.ToString();
                        } else
                        {
                            GageValueTextBox.Text = string.Empty;
                            Tolk.Output("Invalid heading.");
                        }
                        break;
                    case "Com 1":
                        if(Decimal.TryParse(GageValueTextBox.Text, out decimal com1))
                        {
                            inst.Com1Freq = com1;
                            GageValueTextBox.Text = inst.Com1Freq.ToString();
                        } else
                        {
                            GageValueTextBox.Text = string.Empty;
                            Tolk.Output("Invalid frequency.");
                        }
                        break;
                    case "Com 2":
                        if(Decimal.TryParse(GageValueTextBox.Text, out decimal com2))
                        {
                            inst.Com2Freq = com2;
                            GageValueTextBox.Text = inst.Com2Freq.ToString();
                        } else
                        {
                            GageValueTextBox.Text = string.Empty;
                            Tolk.Output("Invalid frequency.");
                        }
                        break;
                    case "Transponder":
                        if(int.TryParse(GageValueTextBox.Text, out int transponder) && transponder < 9999)
                        {
                            inst.Transponder = transponder;
                            GageValueTextBox.Text = inst.Transponder.ToString();
                        } else
                        {
                            GageValueTextBox.Text = string.Empty;
                            Tolk.Output("Invalid transponder number.");
                        }
                        break;
                    case "Altimeter[inches]":
                        if(Double.TryParse(GageValueTextBox.Text, out double altimeterInches))
                        {
                            inst.AltimeterInches = altimeterInches;
                            GageValueTextBox.Text = inst.AltimeterInches.ToString();
                        } else
                        {
                            GageValueTextBox.Text = string.Empty;
                            Tolk.Output("Invalid altimeter value.");
                        }
                        break;
                    case "Altimeter[QNH]":
                        if(double.TryParse(GageValueTextBox.Text, out double altimeterQNH))
                        {
                            inst.AltimeterQNH = altimeterQNH;
                            GageValueTextBox.Text = inst.AltimeterQNH.ToString();
                        } else
                        {
                            GageValueTextBox.Text = string.Empty;
                            Tolk.Output("Invalid altimeter value.");
                        }
                        break;
                    case "Nav 1":
                        if(Decimal.TryParse(GageValueTextBox.Text, out decimal nav1))
                        {
                            inst.Nav1Freq = nav1;
                            GageValueTextBox.Text = inst.Nav1Freq.ToString();
                        } else
                        {
                            GageValueTextBox.Text = string.Empty;
                            GageValueTextBox.Text = inst.Nav1Freq.ToString();
                        }
                        break;
                    case "Nav 2":
                        if(Decimal.TryParse(GageValueTextBox.Text, out decimal nav2))
                        {
                            inst.Nav2Freq = nav2;
                            GageValueTextBox.Text = inst.Nav2Freq.ToString();
                        } else
                        {
                            GageValueTextBox.Text = string.Empty;
                            Tolk.Output("Invalid frequency.");
                        }
                        break;
                    case "ADF":
                        if(Decimal.TryParse(GageValueTextBox.Text, out decimal adf))
                        {
                            inst.Adf1Freq = adf;
                            GageValueTextBox.Text = inst.Adf1Freq.ToString();
                        } else
                        {
                            GageValueTextBox.Text = string.Empty;
                            Tolk.Output("Invalid frequency.");
                        }
                        break;
                    case "default":
                        break;
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            } //End apGage input.
                                       } //End sending data to the simulator.
        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings settings = new frmSettings();
            settings.ShowDialog();
            if (settings.DialogResult == DialogResult.OK)
            {
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Reload();
                
            }
            

        }
    }//End TFMMainForm class.
} //End TFM namespace.
