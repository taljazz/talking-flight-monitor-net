using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm
{
    public class Output
    {
        public Output()
        {
        }

        public void Speak(string msg, bool text = true)
        {
            OutputEventArgs args = new OutputEventArgs();
            args.msg = msg;
            args.OutputText = text;
            OnOutputEvent(args);
        }
        protected virtual void OnOutputEvent(OutputEventArgs e)
        {
            EventHandler<OutputEventArgs> handler = OutputEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<OutputEventArgs> OutputEvent;
    }
}
