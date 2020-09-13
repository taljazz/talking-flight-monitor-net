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

namespace tfm.Keyboard_manager
{
    public partial class frmKeyboardManager : Form
    {
        public frmKeyboardManager()
        {
            InitializeComponent();
            KeysConverter kc = new KeysConverter();
            lvKeys.Items.Add("command key").SubItems.Add(kc.ConvertToInvariantString(Properties.Hotkeys.Default.command));
        }

        private void lvKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
