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
    public partial class ctlEngines : UserControl, iPanelsPage
    {
        public ctlEngines()
        {
            InitializeComponent();
        }

        public void SetDocking()
        {
            
        }

        private void ctlEngines_Load(object sender, EventArgs e)
        {

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

        private void tmrEngines_Tick(object sender, EventArgs e)
        {

        }

        private void btnEng1Start_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Left:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_R_ENGINE_START, Aircraft.ClkL);
                    break;
                case Keys.Right:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_LIGHTS_R_ENGINE_START, Aircraft.ClkR);
                    break;
            }
        }
    }
}
