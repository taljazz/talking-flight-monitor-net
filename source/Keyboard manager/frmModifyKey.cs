using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm.Keyboard_manager
{
    public partial class frmModifyKey : Form
    {
        public frmModifyKey(string name, string value)
        {
            InitializeComponent();
            string[] temp = value.Split('+');
            if (temp.Length == 1)
            {
                txtKey.Text = value;
            }
            if (temp.Length == 2)
            {
                if (temp[0] == "Alt")
                {
                    chkAlt.Checked = true;
                }
                if (temp[0] == "Control")
                {
                    chkControl.Checked = true;
                }
                if (temp[0] == "Shift")
                {
                    chkShift.Checked = true;
                }
                txtKey.Text = temp[1];

            }
        }
    }
}
