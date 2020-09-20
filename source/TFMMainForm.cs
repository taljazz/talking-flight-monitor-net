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
using tfm.Keyboard_manager;
using NLog;
using NLog.Config;
using System.Speech.Synthesis;
namespace tfm
{
    public partial class TFMMainForm : Form
    {
        // get a logger object for this class
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        // get a speech synthesis object for SAPI output
        public static SpeechSynthesizer synth = new SpeechSynthesizer();
        
        
        public Instrumentation inst = new Instrumentation();
        
        public TFMMainForm()
        {
            InitializeComponent();
            Aircraft.InitOffsets();
            // upgrade settings
            Properties.Settings.Default.Upgrade();
            synth.Rate = Properties.Settings.Default.SAPISpeechRate;
            if (Properties.Settings.Default.GeonamesUsername == "")
            {
                MessageBox.Show("Geonames username has not been configured. Flight following features will not function.\nGo to the General section in settings to add your Geonames user name\n", "error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            inst.ScreenReaderOutput += onScreenReaderOutput;
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
                this.timerLowPriority.Start();
                // load airport database
                speak("loading airport database");
                dbLoadWorker.RunWorkerAsync();
                // write version info to the debug log
                logger.Debug($"simulator version: {FSUIPCConnection.FlightSimVersionConnected.ToString()}");
                logger.Debug($"FSUIPC version: {FSUIPCConnection.FSUIPCVersion.ToString()}");
                logger.Debug($"FSUIPC .net DLL version: {FSUIPCConnection.DLLVersion.ToString()}");
                

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
        // second 200 MS timer for lower priority instruments, or instruments that don't work well on 100 MS
        private void timerLowPriority_Tick(object sender, EventArgs e)
        {
            FSUIPCConnection.Process("LowPriority");
            inst.ReadLowPriorityInstruments();
        }


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
            if (Properties.Settings.Default.AvionicsTabChangeFlag)
            {
                Properties.Settings.Default.avionics_tab = Properties.Settings.Default.NewAvionicsTab;
                Properties.Settings.Default.AvionicsTabChangeFlag = false;
                Properties.Settings.Default.Save();
            }
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
                if (Properties.Settings.Default.AvionicsTabChangeFlag)
                {
                    MessageBox.Show("You must restart TFM for the avionics tab changes to take affect", "restart required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Reload();
                
            }
            

        }

        protected void onScreenReaderOutput(object sender, ScreenReaderOutputEventArgs e)
        {
            // We can do anything we want since the gage/value are broken up into different variables now.
            // The event should take care of anything the screen reader needs to output to the user.

                        // when e.isGage is true, e.output is empty.
            // Otherwise, e.output should contain a string to send to the screen reader.
        // EX: the next waypoint feature is inappropriate for e.gageName and e.gageValue, so e.isGage will be false, and e.output will have the output for the next waypoint.
            
            if(e.isGauge)
            {
                switch(e.gaugeName)
                {
                    case "Vertical speed":
                        // We can implement different settings here. One of them is braille support.
                        // After including a braille only, speech only, or both setting,
                        // All we need to do is check for the setting and respond to it.
                        // Braile, speech, and output can have different output without toying with the backend code.
                        // This also makes way for message type: short or long. A pilot might not want
                        // to hear "feet per minute" every time he/she presses ]v, so, give them a choice.
                        // That setting would be checked here because it influences screen reader/braille output.
                        // The log may also contain different formatting options. For now, stick with
                        // reasonable defaults.
                        
                        speak($"{e.gaugeValue} feet per minute.");
                        Tolk.Braille($"{e.gaugeName}: {e.gaugeValue}\n");
                        OutputLogTextBox.Text += $"{e.gaugeName}: {e.gaugeValue}\n";
                        break;
                    case "Outside temperature":
                        speak($"{e.gaugeValue} degrees");
                        Tolk.Braille($"{e.gaugeName}: {e.gaugeValue}\n");
                        OutputLogTextBox.Text += $"{e.gaugeName}: {e.gaugeValue}\n";
                        break;
                    case "ASL altitude":
                        speak($"{e.gaugeValue} feet ASL.");
                        Tolk.Braille($"{e.gaugeName}: {e.gaugeValue}\n");
                        OutputLogTextBox.Text += $"{e.gaugeName}: {e.gaugeValue}\n";
                        break;
                        
                    case "AGL altitude":
                        speak($"{e.gaugeValue} feet AGL.");
                        Tolk.Braille($"{e.gaugeName}: {e.gaugeValue}\n");
                        OutputLogTextBox.Text += $"{e.gaugeName}: {e.gaugeValue}\n";
                        break;
                        
                    case "Airspeed true":
                        speak($"{e.gaugeValue} knotts true");
                        Tolk.Braille($"{e.gaugeName}: {e.gaugeValue}\n");
                        OutputLogTextBox.Text += $"{e.gaugeName}: {e.gaugeValue}\n";
                        break;
                        
                    case "Airspeed indicated":
                        speak($"{e.gaugeValue} knotts indicated");
                        Tolk.Braille($"{e.gaugeName}: {e.gaugeValue}\n");
                        OutputLogTextBox.Text += $"{e.gaugeName}: {e.gaugeValue}\n";
                        break;
                    
                    case "Ground speed":
                        speak($"{e.gaugeValue} knotts ground speed");
                        Tolk.Braille($"{e.gaugeName}: {e.gaugeValue}\n");
                        OutputLogTextBox.Text += $"{e.gaugeName}: {e.gaugeValue}\n";
                        break;
                        
                    case "Mach":
                        speak($"Mach {e.gaugeValue}. ");
                        Tolk.Braille($"{e.gaugeName}: {e.gaugeValue}\n");
                        OutputLogTextBox.Text += $"{e.gaugeName}: {e.gaugeValue}\n";
                        break;

                    case "Localiser":
                        speak($"{e.gaugeValue}. ", useSAPI: true);
                        Tolk.Braille($"{e.gaugeName}: {e.gaugeValue}\n");
                        break;

                    case "Glide slope":
                        speak($"{e.gaugeValue}. ", useSAPI: true);
                        Tolk.Braille($"{e.gaugeName}: {e.gaugeValue}\n");
                        break;

                    case "Altimeter":
                        speak($"{e.gaugeName}: {e.gaugeValue}. ");
                        Tolk.Braille($"{e.gaugeName}: {e.gaugeValue}\n");
                        OutputLogTextBox.Text += $"{e.gaugeName}: {e.gaugeValue}\n";
                        break;
                    
                    case "Flaps":
                        speak($"{e.gaugeName}: {e.gaugeValue}. ");
                        Tolk.Braille($"{e.gaugeName}: {e.gaugeValue}\n");
                        OutputLogTextBox.Text += $"{e.gaugeName}: {e.gaugeValue}\n";
                        break;
                    
                    case "Gear":
                        speak($"{e.gaugeName}: {e.gaugeValue}. ");
                        Tolk.Braille($"{e.gaugeName}: {e.gaugeValue}\n");
                        OutputLogTextBox.Text += $"{e.gaugeName}: {e.gaugeValue}\n";
                        break;

                    case "AP heading":
                        speak($"heading: {e.gaugeValue}. ");
                        Tolk.Braille($"hdg: {e.gaugeValue}\n");
                        OutputLogTextBox.Text += $"{e.gaugeName}: {e.gaugeValue}\n";
                        break;

                    case "AP airspeed":
                        speak($"{e.gaugeValue} knotts. ");
                        Tolk.Braille($"{e.gaugeName}: {e.gaugeValue}\n");
                        OutputLogTextBox.Text += $"{e.gaugeName}: {e.gaugeValue}\n";
                        break;

                    case "AP vertical speed":
                        speak($"{e.gaugeValue} feet per minute. ");
                        Tolk.Braille($"{e.gaugeValue} FPM\n");
                        OutputLogTextBox.Text += $"{e.gaugeName}: {e.gaugeValue}\n";
                        break;

                    case "AP altitude":
                        speak($"{e.gaugeName}: {e.gaugeValue} feet. ");
                        Tolk.Braille($"{e.gaugeName}: {e.gaugeValue}\n");
                        OutputLogTextBox.Text += $"{e.gaugeName}: {e.gaugeValue}\n";
                        break;


                    case "Com1":
                        speak($"{e.gaugeName}: {e.gaugeValue}. ");
                        Tolk.Braille($"{e.gaugeName}: {e.gaugeValue}\n");
                        OutputLogTextBox.Text += $"{e.gaugeName}: {e.gaugeValue}\n";
                        break;

                    case "Com2":
                        speak($"{e.gaugeName}: {e.gaugeValue}. ");
                        Tolk.Braille($"{e.gaugeName}: {e.gaugeValue}\n");
                        OutputLogTextBox.Text += $"{e.gaugeName}: {e.gaugeValue}\n";
                        break;

                    case "Nav1":
                        speak($"{e.gaugeName}: {e.gaugeValue}. ");
                        Tolk.Braille($"{e.gaugeName}: {e.gaugeValue}\n");
                        OutputLogTextBox.Text += $"{e.gaugeName}: {e.gaugeValue}\n";
                        break;

                    case "Nav2":
                        speak($"{e.gaugeName}: {e.gaugeValue}. ");
                        Tolk.Braille($"{e.gaugeName}: {e.gaugeValue}\n");
                        OutputLogTextBox.Text += $"{e.gaugeName}: {e.gaugeValue}\n";
                        break;

                    case "Transponder":
                        speak($"squawk: {e.gaugeValue}. ");
                        Tolk.Braille($"Squawk: {e.gaugeValue}\n");
                        OutputLogTextBox.Text += $"{e.gaugeName}: {e.gaugeValue}\n";
                        break;





                    default:
                        Tolk.Output("Gage or instrument not supported.\n");
                        break;
                }
            } // End gage output.
            else
            {
                if (e.useSAPI == true)
                {
                    speak(useSAPI: true, interruptSpeech:  e.interruptSpeech, output: e.output);
                }
                else
                {
                    speak(e.output, interruptSpeech: e.interruptSpeech);
                }
                if (e.textOutput == true)
                {
                    OutputLogTextBox.Text += $"{e.output}\n";
                }

            } // end generic output
        } // End screenreader output event.
        private void speak(string output, bool useSAPI = false, bool interruptSpeech = false)
        {
            if (Properties.Settings.Default.UseSAPIOutput == true || useSAPI == true)
            {
                if (interruptSpeech == true) synth.SpeakAsyncCancelAll();
                synth.Rate = Properties.Settings.Default.SAPISpeechRate;
                synth.SpeakAsync(output);
            }
            else
            {
                Tolk.Speak(output, interruptSpeech);

            }
        }
        private void dbLoadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                FSUIPCConnection.AirportsDatabase.LoadTaxiways = true;
                FSUIPCConnection.AirportsDatabase.Load();
                if (FSUIPCConnection.AirportsDatabase.IsLoaded)
                {
                    Tolk.Output("Airport database loaded.");
                }
            }
            catch (Exception ex)
            {
                Tolk.Output("could not load airport database.");
                
            }

        }

        private void KeyManagerMenuItem_Click(object sender, EventArgs e)
        {
            frmKeyboardManager keyboardManager = new frmKeyboardManager();
            keyboardManager.Show();

        }

        private void ToolsMenu_Click(object sender, EventArgs e)
        {

        }

        private void CommandKeyMenuItem_Click(object sender, EventArgs e)
        {
            if (inst.CommandKeyEnabled)
            {
                inst.CommandKeyEnabled = false;
                inst.ResetHotkeys();
                Tolk.Output("command key disabled");
            }
            else
            {
                inst.CommandKeyEnabled = true;
                inst.ResetHotkeys();
                Tolk.Output("command key enabled");

            }
        }

        private void hotkeyHelpMenuItem_Click(object sender, EventArgs e)
        {
            frmKeyboardHelp keyboardHelp = new frmKeyboardHelp();
            keyboardHelp.ShowDialog();

        }


    }//End TFMMainForm class.
} //End TFM namespace.
