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
    public partial class frmNavRadios : Form
    {
        // get instance of Autopilot class.
        InstrumentPanel ap = new InstrumentPanel();

        public frmNavRadios()
        {
            InitializeComponent();
        }

        private void frmNavRadios_Load(object sender, EventArgs e)
        {
            txtNav1Freq.Text = ap.Nav1Freq.ToString();
            txtNav1Course.Text = ap.Nav1Course.ToString();
            txtNav2Freq.Text = ap.Nav2Freq.ToString();
            txtNav2Course.Text = ap.Nav2Course.ToString();

        }

        private void frmNavRadios_Shown(object sender, EventArgs e)
        {
            txtNav1Freq.Focus();
            this.Activate();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtNav1Freq.Text != ap.Nav1Freq.ToString())
            {
                ap.Nav1Freq = decimal.Parse(txtNav1Freq.Text);
            }
            
            if (txtNav2Freq.Text != ap.Nav2Freq.ToString())
            {
                ap.Nav2Freq = decimal.Parse(txtNav2Freq.Text);
            }
            if (txtNav1Course.Text != ap.Nav1Course.ToString())
            {
                ap.Nav1Course = ushort.Parse(txtNav1Course.Text);
            }
            if (txtNav2Course.Text != ap.Nav2Course.ToString())
            {
                ap.Nav2Course = ushort.Parse(txtNav2Course.Text);
            }

        }
    }
}
