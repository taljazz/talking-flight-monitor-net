using FSUIPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm
{
    public partial class CDUForm : Form
    {
        uint ClkL = 0x20000000;
        uint ClkR = 0x80000000;

        PMDG_NGX_CDU_Screen cdu;

        public CDUForm()
        {
            InitializeComponent();
            cdu = new PMDG_NGX_CDU_Screen(0x5400);
            RefreshCDU();
            
        }

        private void RefreshCDU()
        {
            txtCDU.Clear();
            Thread.Sleep(200);
            cdu.RefreshData();
            int counter = 1;
            foreach (PMDG_NGX_CDU_Row row in cdu.Rows)
            {
                txtCDU.Text += $"{counter}: {row.ToString()}\r\n";          
                counter++;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshCDU();
        }

        private void btnLSK1L_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_L1, 0x20000000);
            RefreshCDU();
        }

        private void btnLSK1R_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_R1, 0x20000000);
            RefreshCDU();

        }

        private void btnLSK2L_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_L2, 0x20000000);
            RefreshCDU();

        }

        private void btnLSK2R_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_R2, 0x20000000);
            RefreshCDU();

        }

        private void btnLSK3L_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_L3, 0x20000000);
            RefreshCDU();

        }

        private void btnLSK3R_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_R3, 0x20000000);
            RefreshCDU();

        }

        private void btnLSK4L_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_L4, 0x20000000);
            RefreshCDU();

        }

        private void btnLSK4R_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_R4, 0x20000000);
            RefreshCDU();
        }

        private void btnLSK5L_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_L5, 0x20000000);
            RefreshCDU();

        }

        private void btnLSK5R_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_R5, 0x20000000);
            RefreshCDU();

        }

        private void btnLSK6L_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_L6, 0x20000000);
            RefreshCDU();

        }

        private void btnLSK6R_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_R6, 0x20000000);
            RefreshCDU();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_BATTERY_SWITCH, 0x20000000);

            // FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_GRD_PWR_SWITCH, Aircraft.ClkL);
            // FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_APU_GEN1_SWITCH, -2147483648);
            // FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_APU_GEN2_SWITCH, -2147483648);

            RefreshCDU();

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_MENU, 0x00800000);
            Thread.Sleep(3000);
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_MENU, 0x00200000);
            RefreshCDU();
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_EXEC, Aircraft.ClkL);
            RefreshCDU();
        }

        private void CDUForm_KeyDown(object sender, KeyEventArgs e)
        {
            // keys for CDU buttons
            
            if ((e.Alt && e.KeyCode == Keys.D1))
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_R1, 0x20000000);
                RefreshCDU();
                e.SuppressKeyPress = true;
            }
            if ((e.Alt && e.KeyCode == Keys.D2))
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_R2, Aircraft.ClkL);
                RefreshCDU();
                e.SuppressKeyPress = true;
            }
            if ((e.Alt && e.KeyCode == Keys.D3))
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_R3, 0x20000000);
                RefreshCDU();
                e.SuppressKeyPress = true;
            }
            if ((e.Alt && e.KeyCode == Keys.D4))
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_R4, 0x20000000);
                RefreshCDU();
                e.SuppressKeyPress = true;
            }
            if ((e.Alt && e.KeyCode == Keys.D5))
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_R5, 0x20000000);
                RefreshCDU();
                e.SuppressKeyPress = true;
            }
            if ((e.Alt && e.KeyCode == Keys.D6))
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_R6, 0x20000000);
                RefreshCDU();
                e.SuppressKeyPress = true;
            }
            if ((e.Control && e.KeyCode == Keys.D1))
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_L1, 0x20000000);
                RefreshCDU();
                e.SuppressKeyPress = true;
            }
            if ((e.Control && e.KeyCode == Keys.D2))
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_L2, 0x20000000);
                RefreshCDU();
                e.SuppressKeyPress = true;
            }
            if ((e.Control && e.KeyCode == Keys.D3))
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_L3, 0x20000000);
                RefreshCDU();
                e.SuppressKeyPress = true;
            }
            if ((e.Control && e.KeyCode == Keys.D4))
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_L4, 0x20000000);
                RefreshCDU();
                e.SuppressKeyPress = true;
            }
            if ((e.Control && e.KeyCode == Keys.D5))
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_L5, 0x20000000);
                RefreshCDU();
                e.SuppressKeyPress = true;
            }
            if ((e.Control && e.KeyCode == Keys.D6))
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_L6, 0x20000000);
                RefreshCDU();
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.PageDown)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_NEXT_PAGE, 0x20000000);
                RefreshCDU();
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.PageUp)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_CDU_L_PREV_PAGE, 0x20000000);
                RefreshCDU();
                e.SuppressKeyPress = true;
            }

        }
    }
}
