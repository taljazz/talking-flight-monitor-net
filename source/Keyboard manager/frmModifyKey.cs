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
    public partial class frmModifyKey : Form
    {
        KeysConverter kc = new KeysConverter();
        private Keys newKey;
        private string name;
        private string tab;
        public frmModifyKey(string name, string tab)
        {
            InitializeComponent();
            txtKey.Text = kc.ConvertToString(Properties.Hotkeys.Default[name]);
            this.name = name;
            this.tab = tab;
        }


        private void txtKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey) return;

            foreach (SettingsPropertyValue s in Properties.Hotkeys.Default.PropertyValues)
            {
                string k = s.PropertyValue.ToString();
                if (e.KeyData.ToString() == k && tab == "tabAutopilot")
                {
                    if (!s.Name.StartsWith("ap_")) continue;
                    MessageBox.Show($"This key is already assigned to {s.Name}");
                    return;
                }
                if (e.KeyData.ToString() == k && tab == "tabGeneral")
                {
                    if (s.Name.StartsWith("ap_")) continue;
                    MessageBox.Show($"This key is already assigned to {s.Name}");
                    return;
                }

            }
            txtKey.Text = kc.ConvertToString(e.KeyData);
            newKey = e.KeyData;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Properties.Hotkeys.Default[name] = newKey;
        }
    }
}
