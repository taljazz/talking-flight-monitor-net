using FSUIPC;
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
    public partial class ctlFuel : UserControl, iPanelsPage
    {
        public ctlFuel()
        {
            InitializeComponent();
            tmrFuel.Start();
        }
        
        
        public void SetDocking()
        {
        }

        private void UpdateToggleControl (bool toggleStateOn, CheckBox ctrl)
        {
            if (toggleStateOn)
            {
                if (ctrl.Checked != true)
                {
                    ctrl.Checked = true;
                }
                
            }
            else
            {
                if (ctrl.Checked != false)
                {
                    ctrl.Checked = false;
                }
                    
            }
        }

        private void tmrFuel_Tick(object sender, EventArgs e)
        {
            UpdateToggleControl(Aircraft.pmdg737.FUEL_PumpAftSw[0].Value > 0, chkAftLeft);
            UpdateToggleControl(Aircraft.pmdg737.FUEL_PumpFwdSw[0].Value > 0, chkFwdLeft);
            UpdateToggleControl(Aircraft.pmdg737.FUEL_PumpFwdSw[1].Value > 0, chkFwdRight);
            UpdateToggleControl(Aircraft.pmdg737.FUEL_PumpAftSw[1].Value > 0, chkAftRight);
            UpdateToggleControl(Aircraft.pmdg737.FUEL_PumpCtrSw[0].Value > 0, chkCenterLeft);
            UpdateToggleControl(Aircraft.pmdg737.FUEL_PumpCtrSw[1].Value > 0, chkCenterRight);
        }

        private void chkFwdLeft_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkAftLeft_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkFwdRight_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkAftRight_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkCenterLeft_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkCenterRight_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
