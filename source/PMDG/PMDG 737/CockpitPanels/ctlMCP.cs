using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FSUIPC;

namespace tfm
{
    public partial class ctlMCP : UserControl, iPanelsPage
    {
        
            
        public ctlMCP()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }
        private void ctlMCP_Load(object sender, EventArgs e)
        {
            tmrMCP.Start();
        }

        private void txtAltitude_KeyDown(object sender, KeyEventArgs e)
        {
            // increment altitude by 100 feet
            if (e.KeyCode == Keys.Oemplus)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_ALTITUDE_SELECTOR, Aircraft.pmdg737.Inc);
            }
            // increment altitude by 500 feet
            if ((e.Shift && e.KeyCode == Keys.Oemplus))
            {
                for (int i = 0; i <5; i++)
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_ALTITUDE_SELECTOR, Aircraft.pmdg737.Inc);
                }
            }
            // decrement altitude by 100 feet
            if (e.KeyCode == Keys.OemMinus)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_ALTITUDE_SELECTOR, Aircraft.pmdg737.Dec);
            }
            // decrement altitude by 500 feet
            if ((e.Shift && e.KeyCode == Keys.OemMinus))
            {
                for (int i = 0; i < 5; i++)
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_ALTITUDE_SELECTOR, Aircraft.pmdg737.Dec);
                }
            }

        }

        private void chkFlightDirectorL_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFlightDirectorL.Checked)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_FD_SWITCH_L, Aircraft.pmdg737.ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_FD_SWITCH_L, Aircraft.pmdg737.ClkR);
            }
        }

        private void chkATArm_CheckedChanged(object sender, EventArgs e)
        {
        if (chkATArm.Checked)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_AT_ARM_SWITCH, Aircraft.pmdg737.ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_AT_ARM_SWITCH, Aircraft.pmdg737.ClkR);
            }
        }

        private void btnN1_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_N1_SWITCH, Aircraft.pmdg737.ClkL);
        }

        
        private void txtSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            // increment speed
            if (e.KeyCode == Keys.Oemplus)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_SPEED_SELECTOR, Aircraft.pmdg737.Inc);
            }
            // increment altitude fast
            if ((e.Shift && e.KeyCode == Keys.Oemplus))
            {
                for (int i = 0; i < 5; i++)
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_SPEED_SELECTOR, Aircraft.pmdg737.Inc);
                }
            }
            // decrement altitude slowly
            if (e.KeyCode == Keys.OemMinus)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_SPEED_SELECTOR, Aircraft.pmdg737.Dec);
            }
            // decrement altitude fast
            if ((e.Shift && e.KeyCode == Keys.OemMinus))
            {
                for (int i = 0; i < 5; i++)
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_SPEED_SELECTOR, Aircraft.pmdg737.Dec);
                }
            }

        }

        private void btnSpeed_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_SPEED_SWITCH, Aircraft.pmdg737.ClkL);
        }

        private void btnSpeedINTV_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_SPD_INTV_SWITCH, Aircraft.pmdg737.ClkL);
        }

        private void btnAltIntv_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_ALT_INTV_SWITCH, Aircraft.pmdg737.ClkL);
        }

        private void btnLvlChg_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_LVL_CHG_SWITCH, Aircraft.pmdg737.ClkL);
        }

        private void btnAltHold_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_ALT_HOLD_SWITCH, Aircraft.pmdg737.ClkL);
        }

        private void txtVSpd_KeyDown(object sender, KeyEventArgs e)
        {
            // increment v-speed
            if (e.KeyCode == Keys.Oemplus)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_VS_SELECTOR, Aircraft.pmdg737.Inc);
            }
            // increment altitude fast
            if ((e.Shift && e.KeyCode == Keys.Oemplus))
            {
                for (int i = 0; i < 5; i++)
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_VS_SELECTOR, Aircraft.pmdg737.Inc);
                }
            }
            // decrement altitude slowly
            if (e.KeyCode == Keys.OemMinus)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_VS_SELECTOR, Aircraft.pmdg737.Dec);
            }
            // decrement altitude fast
            if ((e.Shift && e.KeyCode == Keys.OemMinus))
            {
                for (int i = 0; i < 5; i++)
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_VS_SELECTOR, Aircraft.pmdg737.Dec);
                }
            }

        }

        private void btnVNav_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_VNAV_SWITCH, Aircraft.pmdg737.ClkL);
        }

        private void txtHeading_KeyDown(object sender, KeyEventArgs e)
        {
            // increment heading
            if (e.KeyCode == Keys.Oemplus)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_HEADING_SELECTOR, Aircraft.pmdg737.Inc);
            }
            // increment heading fast
            if ((e.Shift && e.KeyCode == Keys.Oemplus))
            {
                for (int i = 0; i < 5; i++)
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_HEADING_SELECTOR, Aircraft.pmdg737.Inc);
                }
            }
            // decrement heading slowly
            if (e.KeyCode == Keys.OemMinus)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_HEADING_SELECTOR, Aircraft.pmdg737.Dec);
            }
            // decrement heading fast
            if ((e.Shift && e.KeyCode == Keys.OemMinus))
            {
                for (int i = 0; i < 5; i++)
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_HEADING_SELECTOR, Aircraft.pmdg737.Dec);
                }
            }


        }

        private void btnHdgSel_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_HDG_SEL_SWITCH, Aircraft.pmdg737.ClkL);
        }

        private void btnLNav_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_LNAV_SWITCH, Aircraft.pmdg737.ClkL);
        }

        private void btnVorLock_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_VOR_LOC_SWITCH, Aircraft.pmdg737.ClkL);
        }

        private void btnApproach_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_APP_SWITCH, Aircraft.pmdg737.ClkL);
        }

        private void btnCmdA_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_CMD_A_SWITCH, Aircraft.pmdg737.ClkL);
        }

        private void btnCmdB_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_CMD_B_SWITCH, Aircraft.pmdg737.ClkL);
        }

        private void btnCWSA_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_CWS_A_SWITCH, Aircraft.pmdg737.ClkL);
        }

        private void btnCWSB_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_CWS_B_SWITCH, Aircraft.pmdg737.ClkL);
        }

        private void chkFlightDirectorRight_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFlightDirectorRight.Checked)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_FD_SWITCH_R, Aircraft.pmdg737.ClkL);
            }
            else
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_FD_SWITCH_R, Aircraft.pmdg737.ClkR);
            }

        }

        private void btnVs_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_VS_SWITCH, Aircraft.pmdg737.ClkL);
        }

        private void tmrMCP_Tick(object sender, EventArgs e)
        {
            // update the form when instruments change
            if (Aircraft.pmdg737.MCP_Altitude.Value.ToString() != txtAltitude.Text.ToString())
            {
                txtAltitude.Text = Aircraft.pmdg737.MCP_Altitude.Value.ToString();
            }
            if (Aircraft.pmdg737.MCP_VertSpeed.Value.ToString() != txtHeading.Text.ToString())
            {
                txtVSpd.Text = Aircraft.pmdg737.MCP_VertSpeed.Value.ToString();
            }

            if (Aircraft.pmdg737.MCP_Heading.Value.ToString() != txtHeading.Text.ToString())
            {
                txtHeading.Text = Aircraft.pmdg737.MCP_Heading.Value.ToString();
            }
            if (Aircraft.pmdg737.MCP_IASMach.Value.ToString() != txtSpeed.Text.ToString())
            {
                txtSpeed.Text = Aircraft.pmdg737.MCP_IASMach.Value.ToString();
            }
            if (Aircraft.pmdg737.MCP_annunLNAV.Value == 1)
            {
                btnLNav.AccessibleName = "L Nav on";
            }
            else
            {
                btnLNav.AccessibleName = "L Nav off";
            }
            if (Aircraft.pmdg737.MCP_annunVNAV.Value == 1)
            {
                btnVNav.AccessibleName = "V Nav on";
            }
            else
            {
                btnVNav.AccessibleName = "V Nav off";
            }
            if (Aircraft.pmdg737.MCP_annunSPEED.Value == 1)
            {
                btnSpeed.AccessibleName = "speed on";
            }
            else
            {
                btnSpeed.AccessibleName = "speed off";
            }
            if (Aircraft.pmdg737.MCP_annunHDG_SEL.Value == 1)
            {
                btnHdgSel.AccessibleName = "heading select on";
            }
            else
            {
                btnHdgSel.AccessibleName = "heading select off";
            }
            if (Aircraft.pmdg737.MCP_annunN1.Value == 1)
            {
                btnN1.AccessibleName = "N1 on";
            }
            else
            {
                btnN1.AccessibleName = "N1 off";
            }
            if (Aircraft.pmdg737.MCP_annunLVL_CHG.Value == 1)
            {
                btnLvlChg.AccessibleName = "level change on";
            }
            else
            {
                btnLvlChg.AccessibleName = "Level change off";
            }
            if (Aircraft.pmdg737.MCP_annunCMD_A.Value == 1)
            {
                btnCmdA.AccessibleName = "CMD A on";
            }
            else
            {
                btnCmdA.AccessibleName = "CMD A off";
            }
            if (Aircraft.pmdg737.MCP_annunCMD_B.Value == 1)
            {
                btnCmdB.AccessibleName = "CMD B on";
            }
            else
            {
                btnCmdB.AccessibleName = "CMD B off";
            }
            if (Aircraft.pmdg737.MCP_annunVOR_LOC.Value == 1)
            {
                btnVorLock.AccessibleName = "VOR LOC on";
            }
            else
            {
                btnVorLock.AccessibleName = "VOR LOC off";
            }
            if (Aircraft.pmdg737.MCP_annunAPP.Value == 1)
            {
                btnApproach.AccessibleName = "Approach on";
            }
            else
            {
                btnApproach.AccessibleName = "Approach off";
            }
            if (Aircraft.pmdg737.MCP_annunALT_HOLD.Value == 1)
            {
                btnAltHold.AccessibleName = "Alt hold on";
            }
            else
            {
                btnAltHold.AccessibleName = "Alt hold off";
            }
            if (Aircraft.pmdg737.MCP_annunCWS_A.Value == 1)
            {
                btnCWSA.AccessibleName = "CWS A on";
            }
            else
            {
                btnCWSB.AccessibleName = "CWS B off";
            }

        }

        private void txtCourseL_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                int crs = int.Parse(txtCourseL.Text);
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_CRS_L_SET, crs);
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_MCP_CRS_R_SET, crs);
            }

        }
    }
}
