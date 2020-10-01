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
        private bool apTabSelected;
        private bool generalTabSelected;

        public frmKeyboardManager()
        {
            InitializeComponent();

        }

        void lvKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mods;
            string key;
            selectedKey = this.lvKeys.SelectedItems;
            apTabSelected = false;
            generalTabSelected = true;
            btnModify.Enabled = true;
        }
        void lvAutopilotKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mods;
            string key;
            selectedKey = this.lvAutopilotKeys.SelectedItems;
            apTabSelected = true;
            generalTabSelected = false;
            btnModify.Enabled = true;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            string name = null;
            string key = null;
            foreach (ListViewItem item in selectedKey)
            {
                name = item.SubItems[0].Text.Replace(" ", "_");
                key = item.SubItems[1].Text;

            }
            string tab = tcKeys.SelectedTab.Name;
            frmModifyKey frm = new frmModifyKey(name: name, tab: tab);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                if (tcKeys.SelectedTab == tabGeneral)
                {
                    lvKeys.Items.Clear();
                    lvKeys.BeginUpdate();
                    foreach (SettingsPropertyValue s in Properties.Hotkeys.Default.PropertyValues)
                    {
                        if (s.Name.StartsWith("ap_")) continue;
                        lvKeys.Items.Add(s.Name).SubItems.Add(kc.ConvertToString(s.PropertyValue));
                    }
                    lvKeys.EndUpdate();

                }
                if (tcKeys.SelectedTab == tabAutopilot)
                {
                    lvAutopilotKeys.Items.Clear();
                    lvAutopilotKeys.BeginUpdate();
                    foreach (SettingsPropertyValue s in Properties.Hotkeys.Default.PropertyValues)
                    {
                        if (s.Name.StartsWith("ap_"))
                        {
                            lvAutopilotKeys.Items.Add(s.Name).SubItems.Add(kc.ConvertToString(s.PropertyValue));
                        }

                    }
                    lvAutopilotKeys.EndUpdate();

                }

            }
        }

        private void btnDefaults_Click(object sender, EventArgs e)
        {
            Properties.Hotkeys.Default.Reset();
            Properties.Hotkeys.Default.Reload();
            lvKeys.Items.Clear();
            lvKeys.BeginUpdate();
            foreach (SettingsProperty s in Properties.Hotkeys.Default.Properties)
            {
                lvKeys.Items.Add(s.Name).SubItems.Add(kc.ConvertToString(s.DefaultValue));
            }
            lvKeys.EndUpdate();

        }

        private void tabGeneral_Click(object sender, EventArgs e)
        {
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tcKeys_Selected(object sender, TabControlEventArgs e)
        {
        }

        private void frmKeyboardManager_Load(object sender, EventArgs e)
        {
            string keyName = null;
            lvKeys.BeginUpdate();
            foreach (SettingsProperty s in Properties.Hotkeys.Default.Properties)
            {
                keyName = s.Name.Replace("_", " ");
                if (s.Name.StartsWith("ap_")) continue;
                lvKeys.Items.Add(keyName).SubItems.Add(kc.ConvertToString(s.DefaultValue));
            }
            lvKeys.EndUpdate();
            lvAutopilotKeys.BeginUpdate();
            foreach (SettingsProperty s in Properties.Hotkeys.Default.Properties)
            {
                keyName = s.Name.Replace("_", " ");
                if (s.Name.StartsWith("ap_"))
                { 
                    lvAutopilotKeys.Items.Add(keyName).SubItems.Add(kc.ConvertToString(s.DefaultValue)); 
                }
            }
            lvAutopilotKeys.EndUpdate();

        }
    }

}

