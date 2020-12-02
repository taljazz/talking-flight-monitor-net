using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FSUIPC;
using DavyKager;
namespace tfm
{
    public partial class ctlElectrical : UserControl, iPanelsPage
    {
        pmdg pmdg = new pmdg();        

        public ctlElectrical()
        {
            InitializeComponent();
            PMDGPanelUpdateEvent.PMDGPanelUpdate += onPMDGPanelUpdate;
        }

        private void onPMDGPanelUpdate(object sender, PMDGPanelUpdateEventArgs e)
        {
            
        }

        private void ctlElectrical_Load(object sender, EventArgs e)
        {
            tmrElectrical.Start();
        }

        
        public void SetDocking()
        {
            
        }

        

        
        private void btnIFE_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_IFE, Aircraft.ClkL);
        }

        
        private void btnDisconnectGen1_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_DISCONNECT_1_SWITCH, Aircraft.ClkL);
        }

        private void btnDisconnectGen2_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_DISCONNECT_2_SWITCH, Aircraft.ClkL);
        }

        
            
        
        
        private void btnBusTransfer_Click(object sender, EventArgs e)
        {
                
        }

            
        
        
        private void tmrElectrical_Tick(object sender, EventArgs e)
        {
            chkBattery.CheckedChanged -= chkBattery_CheckedChanged;
            if (Aircraft.ELEC_BatSelector.Value == 0 && chkBattery.Checked == true)
            {
            chkBattery.Checked = false;
            }
            if (Aircraft.ELEC_BatSelector.Value == 1 && chkBattery.Checked == false)
            {
            chkBattery.Checked = true;
            }
            chkBattery.CheckedChanged += chkBattery_CheckedChanged;
            if (Aircraft.ELEC_CabUtilSw.Value == 1)
            {
                chkCabUtil.Checked = true;
            }
            else
            {
                chkCabUtil.Checked = false;
            }
            if (Aircraft.ELEC_IFEPassSeatSw.Value == 1)
            {
                            chkPassSeat.Checked = true;
            }
            else
            {
                chkPassSeat.Checked = false;
            }
            switch (Aircraft.ELEC_StandbyPowerSelector.Value)
            {
                case 0:
                    radStandbyBat.Checked = true;
                    break;
                case 1:
                    radStandbyOff.Checked = true;
                    break;
                case 2:
                    radStandbyAuto.Checked = true;
                    break;

            }
        }

        
        private void chkBattery_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBattery.Checked)
            {
pmdg.ElecBatteryOn();

            }
            else
            {
                pmdg.ElecBatteryOff();
            }
        }

        private void chkCabUtil_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCabUtil.Checked)
            {

            }
        }

        private void RadStandby_CheckChanged(object sender, EventArgs e)
        {
                    RadioButton rb = sender as RadioButton;
if (rb.Checked)
            {
                switch (rb.Name)
                {
                    case "radStandbyBat":
                        pmdg.ElecStandbyBattery();
                        break;
                    case "radStandbyOff":
                        pmdg.ElecStandbyOff();
                        break;
                    case "radStandbyAuto":
                        pmdg.ElecStandbyAuto();
                        break;

                }
            }
        }
    }
}
                    