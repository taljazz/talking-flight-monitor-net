using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm
{
        // Class that publishes an event
        class Publisher
        {
            // Declare the event using EventHandler<T>
            public event EventHandler<OutputEventArgs> RaiseOutputEvent;

            public void Output(string msg, bool txt = true)
            {
                // Write some code that does something useful here
                // then raise the event. You can also raise an event
                // before you execute a block of code.
                OnRaiseOutputEvent(new OutputEventArgs(msg, txt));
            }

            // Wrap event invocations inside a protected virtual method
            // to allow derived classes to override the event invocation behavior
            protected virtual void OnRaiseOutputEvent(OutputEventArgs e)
            {
                // Make a temporary copy of the event to avoid possibility of
                // a race condition if the last subscriber unsubscribes
                // immediately after the null check and before the event is raised.
                EventHandler<OutputEventArgs> raiseEvent = RaiseOutputEvent;

                // Event will be null if there are no subscribers
                if (raiseEvent != null)
                {
                    // Call to raise the event.
                    raiseEvent(this, e);
                }
            }
        }
    }           
