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
        KeysConverter kc = new KeysConverter();
        ListView.SelectedListViewItemCollection selectedKey;
        public frmKeyboardManager()
        {
            InitializeComponent();

            lvKeys.BeginUpdate();
            foreach (SettingsProperty s in Properties.Hotkeys.Default.Properties)
            {
                lvKeys.Items.Add(s.Name).SubItems.Add(kc.ConvertToString(s.DefaultValue));
            }
            lvKeys.EndUpdate();
        }

        void lvKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mods;
            string key;
            selectedKey = this.lvKeys.SelectedItems;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            string name = null;
            string key = null;
            foreach (ListViewItem item in selectedKey)
            {
                name = item.SubItems[0].Text;
                key = item.SubItems[1].Text;

            }
            frmModifyKey frm = new frmModifyKey(name: name, value: key);
            frm.ShowDialog();
            Properties.Hotkeys.Default[name] = (Keys)kc.ConvertFromString("Ctrl+Q");

        }
    }

}

