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

        void avionicsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                if (rb.Name == "radSimplified")
                {
                    if (Properties.Settings.Default.avionics_tab != "simplified")
                    {
                        Properties.Settings.Default.NewAvionicsTab = "simplified";
                        Properties.Settings.Default.AvionicsTabChangeFlag = true;
                    }
                }
                if (rb.Name == "radPropertyGrid")
                {
                    if (Properties.Settings.Default.avionics_tab != "PropertyGrid")
                    {
                        Properties.Settings.Default.NewAvionicsTab = "PropertyGrid";
                        Properties.Settings.Default.AvionicsTabChangeFlag = true;
                    }
                }
            }
        }
    }
}