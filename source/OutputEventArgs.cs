using System;
using System.Windows.Forms;

namespace tfm
{
    public class OutputEventArgs : EventArgs
    {
        public OutputEventArgs(string message, bool textOut)
        {
            Message = message;
            TextOut = textOut;
        }

        public string Message { get; set; }
        public bool TextOut { get; set; }
    }
}

