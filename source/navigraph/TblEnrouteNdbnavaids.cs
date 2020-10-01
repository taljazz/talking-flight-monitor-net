using System;
using System.Collections.Generic;

namespace tfm
{
    public partial class TblEnrouteNdbnavaids
    {
        public string AreaCode { get; set; }
        public string IcaoCode { get; set; }
        public string NdbIdentifier { get; set; }
        public string NdbName { get; set; }
        public double? NdbFrequency { get; set; }
        public string NavaidClass { get; set; }
        public double? NdbLatitude { get; set; }
        public double? NdbLongitude { get; set; }
    }
}
