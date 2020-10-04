using System;
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
    public partial class frmAutopilot : Form
    {
        Autopilot ap = new Autopilot();
        string instrument;
        public frmAutopilot(string instrument)
        {
            InitializeComponent();
            this.instrument = instrument;

        }

        private void frmAutopilot_Load(object sender, EventArgs e)
        {
            this.Activate();
            if (instrument == "Transponder")
            {
                this.Text = "set transponder";
            }
            else
            {
                this.Text = $"set autopilot {instrument}";
            }
            
            lblSetting.Text = $"Enter {this.instrument}: ";
            switch (this.instrument)
            {
                case "Altitude":
                    txtSetting.Text = ap.ApAltitude.ToString();
                    chkLock.AccessibleName = "Altitude lock";
                    chkLock.Checked = ap.ApAltitudeLock;
                    break;
                case "Heading":
                    txtSetting.Text = ap.ApHeading.ToString();
                    chkLock.AccessibleName = "heading lock";
                    chkLock.Checked = ap.ApHeadingLock;
                    break;
                case "Airspeed":
                    txtSetting.Text = ap.ApAirspeed.ToString();
                    chkLock.AccessibleName = "airspeed hold";
                    chkLock.Checked = ap.ApAirspeedHold;
                    break;
                case "Mach":
                    txtSetting.Text = ap.ApMachSpeed.ToString();
                    chkLock.AccessibleName = "mach hold";
                    chkLock.Checked = ap.ApMachHold;
                    break;
                case "Vertical speed":
                    txtSetting.Text = ap.ApVerticalSpeed.ToString();
                    chkLock.AccessibleName = "vertical speed hold";
                    chkLock.Checked = ap.ApVerticalSpeedHold;
                    break;
                case "Transponder":
                    txtSetting.Text = ap.Transponder.ToString();
                    chkLock.Visible = false;
                    break;

            }
            txtSetting.SelectionStart = 0;
            txtSetting.SelectionLength = txtSetting.Text.Length;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            try
            {
                switch (this.instrument)
                {
                    case "Altitude":
                        if (double.TryParse(txtSetting.Text, out double altitude))
                        {
                            ap.ApAltitude = altitude;
                        }
                        ap.ApAltitudeLock = chkLock.Checked;
                        break;

                    case "Heading":
                        if (double.TryParse(txtSetting.Text, out double heading))
                        {
                            ap.ApHeading = heading;
                        }
                        ap.ApHeadingLock = chkLock.Checked;
                        break;

                    case "Airspeed":
                        if (double.TryParse(txtSetting.Text, out double airspeed))
                        {
                            ap.ApAirspeed = airspeed;
                        }
                        ap.ApAirspeedHold = chkLock.Checked;
                        break;

                    case "Mach":
                        if (double.TryParse(txtSetting.Text, out double mach))
                        {
                            ap.ApMachSpeed = mach;
                        }
                        ap.ApMachHold = chkLock.Checked;
                        break;

                    case "Vertical speed":
                        if (double.TryParse(txtSetting.Text, out double verticalSpeed))
                        {
                            ap.ApVerticalSpeed = verticalSpeed;
                        }
                        ap.ApVerticalSpeedHold = chkLock.Checked;
                        break;
                    case "Transponder":
                        if (int.TryParse(txtSetting.Text, out int transponder))
                        {
                            ap.Transponder = transponder;
                        }
                        break;


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK);

                
            }        }
    }
}
