using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.Autopilot
{
    public partial class FrmThrottleValue : Form
    {
        public FrmThrottleValue()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            // Close the dialog, setting the throttle percentage to the value in the spinbox.
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Not yet implemented.
        }
    }
}
