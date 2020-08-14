using FSUIPC;
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
using System.Diagnostics;
using NHotkey;
using NHotkey.WindowsForms;
using DavyKager;

namespace tfm
{
    public partial class TFMMainForm : Form
    {
        public Instrumentation inst = new Instrumentation();
        public TFMMainForm()
        {
            InitializeComponent();
            Aircraft.InitOffsets();
            // Start the connection timer to look for a flight sim
            this.timerConnection.Start();
        }
        // This method is called every 1 second by the connection timer.
        private void timerConnection_Tick(object sender, EventArgs e)
        {
            // Try to open the connection
            try
            {
                FSUIPCConnection.Open();
                // If there was no problem, stop this timer and start the main timer
                this.timerConnection.Stop();
                this.timerMain.Start();
                // Update the connection status
                
            }
            catch
            {
                // No connection found. Don't need to do anything, just keep trying
            }
        }

        // This method runs 10 times per second (every 100ms). This is set on the timerMain properties.
        private void timerMain_Tick(object sender, EventArgs e)
        {
            // Call process() to read/write data to/from FSUIPC
            // We do this in a Try/Catch block incase something goes wrong
            try
            {
                FSUIPCConnection.Process();
                inst.ReadAircraftState();
            }


            catch (Exception ex)
            {
                // An error occured. Tell the user and stop this timer.
                this.timerMain.Stop();
                MessageBox.Show("Communication with FSUIPC Failed\n\n" + ex.Message, "FSUIPC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // Update the connection status
                // start the connection timer
                this.timerConnection.Start();
            }
        }

        // This runs when the master avionics tick has been changed
        
        // Form is closing so stop all the timers and close FSUIPC Connection
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.timerConnection.Stop();
            this.timerMain.Stop();
            FSUIPCConnection.Close();
        }

        private void QuitMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
