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
    public partial class ctlInertialReferenceUnit : UserControl, iPanelsPage
    {
        public ctlInertialReferenceUnit()
        {
            InitializeComponent();
        }

        private void tmrIRU_Tick(object sender, EventArgs e)
        {
            txtIRULeft.Text = Aircraft.IRS_DisplayLeft.Value;
            txtIRURight.Text = Aircraft.IRS_DisplayRight.Value;
            switch (Aircraft.IRS_ModeSelectorLeft.Value)
            {
                case 0:
                    btnIRULeftMode.AccessibleName = "Left IRS off";
                    break;
                case 1:
                    btnIRULeftMode.AccessibleName = "Left IRS align";
                    break;
                case 2:
                    btnIRULeftMode.AccessibleName = "Left IRS nav";
                    break;
                case 3:
                    btnIRULeftMode.AccessibleName = "Left IRS ATT";
                    break;

            }
            switch (Aircraft.IRS_ModeSelectorRight.Value)
            {
                case 0:
                    btnIRURightMode.AccessibleName = "Right IRS off";
                    break;
                case 1:
                    btnIRURightMode.AccessibleName = "Right IRS align";
                    break;
                case 2:
                    btnIRURightMode.AccessibleName = "Right IRS nav";
                    break;
                case 3:
                    btnIRURightMode.AccessibleName = "Right IRS ATT";
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

        private void ctlInertialReferenceUnit_Load(object sender, EventArgs e)
        {
            tmrIRU.Start();
        }

        public void SetDocking()
        {
            
        }

        private void btnIRULeftMode_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_IRU_MSU_LEFT, Aircraft.ClkL);
                    break;
                case Keys.Right:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_IRU_MSU_LEFT, Aircraft.ClkR);
                    break;
            }


            }

        private void btnIRURightMode_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_IRU_MSU_RIGHT, Aircraft.ClkL);
                    break;
                case Keys.Right:
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_IRU_MSU_RIGHT, Aircraft.ClkR);
                    break;
            }


        }
    }
}
