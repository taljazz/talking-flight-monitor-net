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
            lblSetting.Text = $"Enter {this.instrument}: ";
            switch (this.instrument)
            {
                case "Altitude":
                    txtSetting.Text = ap.ApAltitude.ToString();
                    break;
                case "Heading":
                    txtSetting.Text = ap.ApHeading.ToString();
                    break;
                case "Airspeed":
                    txtSetting.Text = ap.ApAirspeed.ToString();
                    break;
                case "Mach":
                    txtSetting.Text = ap.ApMachSpeed.ToString();
                    break;
                case "Vertical speed":
                    txtSetting.Text = ap.ApVerticalSpeed.ToString();
                    break;

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            switch (this.instrument)
            {
                case "Altitude":
                    if (double.TryParse(txtSetting.Text, out double altitude))
                    {
                        ap.ApAltitude = altitude;
                    }
                    break;

                case "Heading":
                    if (double.TryParse(txtSetting.Text, out double heading))
                    {
                        ap.ApHeading = heading;
                    }
                    break;

                case "Airspeed":
                    if (double.TryParse(txtSetting.Text, out double airspeed))
                    {
                        ap.ApAirspeed = airspeed;
                    }
                    break;


            }
        }
    }
}
