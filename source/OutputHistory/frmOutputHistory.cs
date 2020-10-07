using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tfm
{
    public partial class frmOutputHistory : Form
    {
        OutputHistory history = new OutputHistory();
        public frmOutputHistory()
        {
            InitializeComponent();
        }
        private void frmOutputHistory_Load(object sender, EventArgs e)
        {
            this.Activate();
            List<string> items = history.GetItems();
            if (items.Count > 0)
            {
                lbHistory.BeginUpdate();
                foreach (string item in items)
                {
                    lbHistory.Items.Add(item);

                }
                lbHistory.EndUpdate();
                lbHistory.SelectedIndex = 0;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lbHistory.SelectedItem.ToString(), TextDataFormat.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbHistory.Items.Clear();
            history.Clear();
        }

        
        private void lbHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMessage.Text = lbHistory.SelectedItem.ToString();
        }
    }
}
