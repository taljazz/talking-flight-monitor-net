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
    public partial class ctlAirSystems : UserControl, iPanelsPage
    {
        public ctlAirSystems()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void tmrAir_Tick(object sender, EventArgs e)
        {

        }

        private void btnTrimAir_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (Aircraft.AIR_TrimAirSwitch.Value != 1)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_AIRCOND_TRIM_AIR_SWITCH_800, Aircraft.ClkL);
                    }
                    break;
                case Keys.Down:
                    if (Aircraft.AIR_TrimAirSwitch.Value != 0)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_AIRCOND_TRIM_AIR_SWITCH_800, Aircraft.ClkR);
                    }
                    break;

            }


        }

        private void btnRecircLeft_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (Aircraft.AIR_RecircFanSwitchLeft.Value != 1)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_RECIRC_FAN_L_SWITCH, Aircraft.ClkL);
                    }
                    break;
                case Keys.Down:
                    if (Aircraft.AIR_RecircFanSwitchLeft.Value != 0)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_RECIRC_FAN_L_SWITCH, Aircraft.ClkR);
                    }
                    break;

            }


        }

        private void btnPacLeft_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Left:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_PACK_L_SWITCH, Aircraft.ClkL);
                    break;
                case Keys.Right:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_PACK_L_SWITCH, Aircraft.ClkR);
                    break;
            }
        }

        private void btnIsolValve_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Left:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_ISOLATION_VALVE_SWITCH, Aircraft.ClkL);
                    break;
                case Keys.Right:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_ISOLATION_VALVE_SWITCH, Aircraft.ClkR);
                    break;
            }
        }

        private void btnBleed1_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (Aircraft.AIR_BleedAirSwitchLeft.Value != 1)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_ENG_1_SWITCH, Aircraft.ClkL);
                    }
                    break;
                case Keys.Down:
                    if (Aircraft.AIR_BleedAirSwitchLeft.Value != 0)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_ENG_1_SWITCH, Aircraft.ClkR);
                    }
                    break;

            }


        }

        private void btnBleed2_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (Aircraft.AIR_BleedAirSwitchRight.Value != 1)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_ENG_2_SWITCH, Aircraft.ClkL);
                    }
                    break;
                case Keys.Down:
                    if (Aircraft.AIR_BleedAirSwitchRight.Value != 0)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_ENG_2_SWITCH, Aircraft.ClkR);
                    }
                    break;

            }


        }

        private void btnAPUBleed_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (Aircraft.AIR_APUBleedAirSwitch.Value != 1)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_APU_SWITCH, Aircraft.ClkL);
                    }
                    break;
                case Keys.Down:
                    if (Aircraft.AIR_APUBleedAirSwitch.Value != 0)
                    {
                                   FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_APU_SWITCH, Aircraft.ClkR);
                    }
                    break;

            }


        }

        private void btnRecircRight_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (Aircraft.AIR_RecircFanSwitchRight.Value != 1)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_RECIRC_FAN_R_SWITCH, Aircraft.ClkL);
                    }
                    break;
                case Keys.Down:
                    if (Aircraft.AIR_RecircFanSwitchRight.Value != 0)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_RECIRC_FAN_R_SWITCH, Aircraft.ClkR);
                    }
                    break;

            }


        }

        private void btnPacRight_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Left:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_PACK_R_SWITCH, Aircraft.ClkL);
                    break;
                case Keys.Right:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_BLEED_PACK_R_SWITCH, Aircraft.ClkR);
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

    }
}
