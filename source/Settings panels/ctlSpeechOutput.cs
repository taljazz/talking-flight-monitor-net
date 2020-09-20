using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
namespace tfm
{
    public partial class ctlSpeechOutput : UserControl, iSettingsPage
    {
        SpeechSynthesizer synth = new SpeechSynthesizer();

        public ctlSpeechOutput()
        {
            InitializeComponent();

        }

        public void SetDocking()
        {
            
        }

        private void trkSpeechRate_Scroll(object sender, EventArgs e)
        {
            synth.SpeakAsyncCancelAll();
            int val = trkSpeechRate.Value;
            synth.SpeakAsync("rate " + val);
            val = val - 10;
            Properties.Settings.Default.SAPISpeechRate = val;
            synth.Rate = val;
            
        }
    }
}
