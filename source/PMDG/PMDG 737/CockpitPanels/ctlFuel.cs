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

        private void btnAftLeft_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (Aircraft.FUEL_PumpAftLeftSw.Value != 1)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_1_AFT, Aircraft.ClkL);
                    }
                    break;
                case Keys.Down:
                    if (Aircraft.FUEL_PumpAftLeftSw.Value != 0)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_1_AFT, Aircraft.ClkR);
                    }
                    break;

            }

        }

        private void btnFwdRight_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (Aircraft.FUEL_PumpFwdRightSw.Value != 1)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_2_FORWARD, Aircraft.ClkL);
                    }
                    break;
                case Keys.Down:
                    if (Aircraft.FUEL_PumpFwdRightSw.Value != 0)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_2_FORWARD, Aircraft.ClkR);
                    }
                    break;

            }

        }

        private void btnAftRight_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (Aircraft.FUEL_PumpAftRightSw.Value != 1)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_2_AFT, Aircraft.ClkL);
                    }
                    break;
                case Keys.Down:
                    if (Aircraft.FUEL_PumpAftRightSw.Value != 0)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_2_AFT, Aircraft.ClkR);
                    }
                    break;

            }

        }

        private void btnCtrLeft_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (Aircraft.FUEL_PumpCtrLeftSw.Value != 1)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_L_CENTER, Aircraft.ClkL);
                    }
                    break;
                case Keys.Down:
                    if (Aircraft.FUEL_PumpCtrLeftSw.Value != 0)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_L_CENTER, Aircraft.ClkR);
                    }
                    break;

            }

        }

        private void btnCtrRight_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (Aircraft.FUEL_PumpCtrRightSw.Value != 1)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_R_CENTER, Aircraft.ClkL);
                    }
                    break;
                case Keys.Down:
                    if (Aircraft.FUEL_PumpCtrRightSw.Value != 0)
                    {
                        FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_FUEL_PUMP_R_CENTER, Aircraft.ClkR);
                    }
                    break;

            }

        }
    }
}
