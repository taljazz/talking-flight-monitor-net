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
        private void event_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                case Keys.Down:
                    e.IsInputKey = true;
                    break;

            }

        }

        private void btnFwdLeft_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Up:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_1_FORWARD, Aircraft.ClkL);
                    break;
                case Keys.Down:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_1_FORWARD, Aircraft.ClkR);
                    break;

            }




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
            UpdateToggleControl(Aircraft.pmdg737.FUEL_PumpCtrSw[0].Value > 0, chkCtrLeft);
            UpdateToggleControl(Aircraft.pmdg737.FUEL_PumpCtrSw[1].Value > 0, chkCtrRight);
        }
    }
}
