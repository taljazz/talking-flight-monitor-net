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
    public partial class FlightPlanForm : Form
    {
        public FlightPlanForm()
        {
            InitializeComponent();
        }

        private void FlightPlanForm_Load(object sender, EventArgs e)
        {
            this.Activate();
        }
    }
}
