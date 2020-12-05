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
    public partial class ctlHydraulics : UserControl, iPanelsPage
    {
        public ctlHydraulics()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void btnElec1_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (Aircraft.pmdg737.HYD_PumpSw_elec1.Value != 1)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_HYD_ELEC1, Aircraft.pmdg737.ClkL);
                    }
                    break;
                case Keys.Down:
                    if (Aircraft.pmdg737.HYD_PumpSw_elec1.Value != 0)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_HYD_ELEC1, Aircraft.pmdg737.ClkR);
                    }
                    break;

            }


        }

        private void btnElec2_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (Aircraft.pmdg737.HYD_PumpSw_elec2.Value != 1)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_HYD_ELEC2, Aircraft.pmdg737.ClkL);
                    }
                    break;
                case Keys.Down:
                    if (Aircraft.pmdg737.HYD_PumpSw_elec2.Value != 0)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_HYD_ELEC2, Aircraft.pmdg737.ClkR);
                    }
                    break;

            }

        }

        private void btnEngine1_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (Aircraft.pmdg737.HYD_PumpSw_eng1.Value != 1)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_HYD_ENG1, Aircraft.pmdg737.ClkL);
                    }
                    break;
                case Keys.Down:
                    if (Aircraft.pmdg737.HYD_PumpSw_eng1.Value != 0)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_HYD_ENG1, Aircraft.pmdg737.ClkR);
                    }
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

        private void btnEngine2_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (Aircraft.pmdg737.HYD_PumpSw_eng2.Value != 1)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_HYD_ENG2, Aircraft.pmdg737.ClkL);
                    }
                    break;
                case Keys.Down:
                    if (Aircraft.pmdg737.HYD_PumpSw_eng2.Value != 0)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_HYD_ENG2, Aircraft.pmdg737.ClkR);
                    }
                    break;

            }

        }

        private void tmrHydraulics_Tick(object sender, EventArgs e)
        {
            if (Aircraft.pmdg737.HYD_PumpSw_elec1.Value == 0)
            {
                btnElec1.AccessibleDescription = "off";
            }
            else
            {
                btnElec1.AccessibleDescription = "on";
            }
            if (Aircraft.pmdg737.HYD_PumpSw_elec2.Value == 0)
            {
                btnElec2.AccessibleDescription = "off";
            }
            else
            {
                btnElec2.AccessibleDescription = "on";
            }
            if (Aircraft.pmdg737.HYD_PumpSw_eng1.Value == 0)
            {
                btnEngine1.AccessibleDescription = "off";
            }
            else
            {
                btnEngine1.AccessibleDescription = "on";
            }
            if (Aircraft.pmdg737.HYD_PumpSw_eng2.Value == 0)
            {
                btnEngine2.AccessibleDescription = "off";
            }
            else
            {
                btnEngine2.AccessibleDescription = "on";
            }

        }
    }
}
