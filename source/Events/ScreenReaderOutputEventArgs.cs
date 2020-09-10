using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm
{
    public class ScreenReaderOutputEventArgs
    {
        public string output { get; set; }
        public string gageName { get; set; }
        public string gageValue { get; set; }
        public bool isGage { get; set; }
    } // end ScreenReaderOutputEventArgs
} // End TFM namespace.
