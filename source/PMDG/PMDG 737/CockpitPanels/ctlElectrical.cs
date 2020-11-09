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
            if (Aircraft.ELEC_BatSelector.Value == 1)
            {
                btnBattery.AccessibleDescription = "on";
            }
            else
            {
                btnBattery.AccessibleDescription = "off";
            }
            

        }

        private void btnBattery_Click(object sender, EventArgs e)
        {
            if (Aircraft.ELEC_BatSelector.Value > 0)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_BATTERY_SWITCH, Aircraft.ClkR);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_BATTERY_SWITCH, Aircraft.ClkL);
            }
        }

        public void SetDocking()
        {
            
        }

        private void btnDCSource_Click(object sender, EventArgs e)
        {

        }

        private void btnACSource_Click(object sender, EventArgs e)
        {

        }

        private void btnGalley_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_GALLEY, Aircraft.ClkL);

        }

        private void btnCabUtil_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_CAB_UTIL, Aircraft.ClkL);
        }

        private void btnIFE_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_IFE, Aircraft.ClkL);
        }

        private void btnStandbyPower_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_STBY_PWR_SWITCH, Aircraft.ClkL);
        }

        private void btnDisconnectGen1_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_DISCONNECT_1_SWITCH, Aircraft.ClkL);
        }

        private void btnDisconnectGen2_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_DISCONNECT_2_SWITCH, Aircraft.ClkL);
        }

        private void btnGroundPower_Click(object sender, EventArgs e)
        {
            double grdPwr = FSUIPCConnection.ReadLVar("switch_17_73X");
            Tolk.Output(grdPwr.ToString());
            if (grdPwr == 100)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_GRD_PWR_SWITCH, Aircraft.ClkR);
            }
            if (grdPwr == 0 || grdPwr == 50)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_GRD_PWR_SWITCH, Aircraft.ClkL);
            }

        }

            private void btnApuGen1_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_APU_GEN1_SWITCH, Aircraft.ClkL);
        }

        private void btnApuGen2_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_APU_GEN2_SWITCH, Aircraft.ClkL);
        }

        private void btnGen1_Click(object sender, EventArgs e)
        {

        }

        private void btnGen2_Click(object sender, EventArgs e)
        {

        }

        private void btnBusTransfer_Click(object sender, EventArgs e)
        {
                
        }

            
        
        private void btnGroundPower_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_GRD_PWR_SWITCH, Aircraft.ClkL);
                    break;
                case Keys.Right:
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
                case Keys.Left:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_APU_GEN1_SWITCH, Aircraft.ClkL);
                    break;
                case Keys.Right:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_APU_GEN1_SWITCH, Aircraft.ClkR);
                    break;

            }

        }

        private void btnApuGen2_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_APU_GEN2_SWITCH, Aircraft.ClkL);
                    break;
                case Keys.Right:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_APU_GEN2_SWITCH, Aircraft.ClkR);
                    break;

            }

        }
    }
}
                