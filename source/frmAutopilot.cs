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

            }
        }
    }
}
