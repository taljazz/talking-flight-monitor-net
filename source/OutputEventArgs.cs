using System;

namespace tfm
{
    public class OutputEventArgs : EventArgs
    {
        public string msg { get; set; }
        public bool OutputText { get; set; }
    }
}