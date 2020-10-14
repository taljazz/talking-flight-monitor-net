using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm
{
    public partial class ctlUserInterface : UserControl, iSettingsPage
    {
        public ctlUserInterface()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void ctlUserInterface_Load(object sender, EventArgs e)
        {
            sendToTrayCheckBox.Checked = Properties.Settings.Default.sendToTray;
        }

        private void startInTrayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.sendToTray = sendToTrayCheckBox.Checked;
        }
    }
}
