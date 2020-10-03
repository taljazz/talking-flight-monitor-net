using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm
{
    public partial class frmKeyboardHelp : Form
    {
        public frmKeyboardHelp()
        {
            List<string> lstHotkeys = new List<string>();
            InitializeComponent();
            
            foreach (SettingsProperty p in Properties.Hotkeys.Default.Properties)
            {
                lstHotkeys.Add($"{p.Name} : {p.DefaultValue}\r\n");


            }
            lstHotkeys.Sort();
            foreach (string i in lstHotkeys)
            {
                txtHotkeys.Text += i;
            }
        }
    }
}
