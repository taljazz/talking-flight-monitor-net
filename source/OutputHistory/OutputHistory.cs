using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace tfm
{
    class OutputHistory
    {
        static List<string> History = new List<string>();

        public void AddItem(string item)
        {
            int maxHistory = (int)Properties.Settings.Default.OutputHistoryLength;
            if (History.Count >= maxHistory)
            {
                int removeItems = History.Count - maxHistory+ 1;
                History.RemoveRange(0, removeItems);
                History.Add(item);

            }
            else
            {
                History.Add(item);
            }

        }
        public List<string> GetItems()
        {
            return History;
        }
        public void Clear()
        {
            History.Clear();
        }
    }
}
