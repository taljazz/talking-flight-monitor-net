using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DavyKager;

namespace tfm
{
    public partial class ctlGeneral : UserControl, iSettingsPage
    {
        public ctlGeneral()
        {
            InitializeComponent();
            if (Properties.Settings.Default.avionics_tab == "simplified")
            {
                radSimplified.Checked = true;
            }
            else
            {
                radPropertyGrid.Checked = true;
            }

        }

        public void SetDocking()
        {

        }

        private void radPropertyGrid_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                Properties.Settings.Default.avionics_tab = "properties";
                Properties.Settings.Default.AvionicsTabChangeFlag = true;
            }
        } // End properties grid check.

        private void radSimplified_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if(rb.Checked)
            {
                Properties.Settings.Default.avionics_tab = "simplified";
                Properties.Settings.Default.AvionicsTabChangeFlag = true;
            }
        } // End simplified change.

    }
}