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
        public ctlElectrical()
        {
            InitializeComponent();
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

            
        
        private void btnGroundPower_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_GRD_PWR_SWITCH, Aircraft.ClkL);
                    break;
                case Keys.Down:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_GRD_PWR_SWITCH, Aircraft.ClkR);
                    break;

            }
            
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

        private void btnStandbyPower_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_STBY_PWR_SWITCH, Aircraft.ClkL);
                    break;
                case Keys.Right:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_STBY_PWR_SWITCH, Aircraft.ClkR);
                    break;

            }
        }

        private void btnApuGen1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_APU_GEN1_SWITCH, Aircraft.ClkL);
                    break;
                case Keys.Down:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_APU_GEN1_SWITCH, Aircraft.ClkR);
                    break;

            }

        }

        private void btnApuGen2_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_APU_GEN2_SWITCH, Aircraft.ClkL);
                    break;
                case Keys.Down:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_APU_GEN2_SWITCH, Aircraft.ClkR);
                    break;

            }

        }

        private void btnBattery_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (Aircraft.ELEC_BatSelector.Value != 1)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_BATTERY_SWITCH, Aircraft.ClkL);
                    }

                    break;
                case Keys.Down:
                    if (Aircraft.ELEC_BatSelector.Value != 0)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_BATTERY_SWITCH, Aircraft.ClkL);
                    }

                    break;

            }
        }

        private void btnGen1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_GEN1_SWITCH, Aircraft.ClkL);
                    break;
                case Keys.Down:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_GEN1_SWITCH, Aircraft.ClkR);
                    break;

            }

        }

        private void btnGen2_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_GEN2_SWITCH, Aircraft.ClkL);
                    break;
                case Keys.Down:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_GEN2_SWITCH, Aircraft.ClkR);
                    break;

            }

        }

        private void btnDCSource_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_DC_METER, Aircraft.ClkL);
                    break;
                case Keys.Right:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_DC_METER, Aircraft.ClkR);
                    break;

            }
        }

        private void tmrElectrical_Tick(object sender, EventArgs e)
        {
            
            if (Aircraft.ELEC_BatSelector.Value == 1)
            {
                btnBattery.AccessibleDescription = "on";
            }
            else
            {
                btnBattery.AccessibleDescription = "off";
            }
            if (Aircraft.ELEC_CabUtilSw.Value == 1)
            {
                btnCabUtil.AccessibleDescription = "on";
            }
            else
            {
                btnCabUtil.AccessibleDescription = "off";
            }
            if (Aircraft.ELEC_IFEPassSeatSw.Value == 1)
            {
                btnIFE.AccessibleDescription = "on";
            }
            else
            {
                btnIFE.AccessibleDescription = "off";
            }
            switch (Aircraft.ELEC_StandbyPowerSelector.Value)
            {
                case 0:
                    btnStandbyPower.AccessibleDescription = "battery";
                    break;
                case 1:
                    btnStandbyPower.AccessibleDescription = "off";
                    break;
                case 2:
                    btnStandbyPower.AccessibleDescription = "auto";
                    break;

            }
        }

        private void btnACSource_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_AC_METER, Aircraft.ClkL);
                    break;
                case Keys.Right:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_AC_METER, Aircraft.ClkR);
                    break;

            }       

        }

        private void btnCabUtil_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (Aircraft.ELEC_CabUtilSw.Value != 1)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_CAB_UTIL, Aircraft.ClkL);
                    }

                    break;
                case Keys.Down:
                    if (Aircraft.ELEC_CabUtilSw.Value != 0)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_CAB_UTIL, Aircraft.ClkR);
                    }
                    break;

            }

        }

        private void btnIFE_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (Aircraft.ELEC_IFEPassSeatSw.Value != 1)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_IFE, Aircraft.ClkL);
                    }
                    break;
                case Keys.Down:
                    if (Aircraft.ELEC_IFEPassSeatSw.Value != 0)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_IFE, Aircraft.ClkR);
                    }

                    break;
            }
        }

        private void btnBusTransfer_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Up:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_BUS_TRANSFER_SWITCH, Aircraft.ClkL);
                    break;
                case Keys.Down:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_BUS_TRANSFER_SWITCH, Aircraft.ClkR);
                    break;
            }
        }
    }
}
                    