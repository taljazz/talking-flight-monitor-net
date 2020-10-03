using System;
using System.Collections.Generic;

namespace tfm
{
    public partial class TblHeader
    {
        public string Version { get; set; }
        public string Arincversion { get; set; }
        public string RecordSet { get; set; }
        public string CurrentAirac { get; set; }
        public string Revision { get; set; }
        public string EffectiveFromto { get; set; }
        public string PreviousAirac { get; set; }
        public string PreviousFromto { get; set; }
        public string ParsedAt { get; set; }
    }
}
