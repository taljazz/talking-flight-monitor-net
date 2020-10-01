using System;
using System.Collections.Generic;

namespace tfm
{
    public partial class TblLocalizerMarker
    {
        public string AreaCode { get; set; }
        public string IcaoCode { get; set; }
        public string AirportIdentifier { get; set; }
        public string RunwayIdentifier { get; set; }
        public string LlzIdentifier { get; set; }
        public string MarkerIdentifier { get; set; }
        public string MarkerType { get; set; }
        public double MarkerLatitude { get; set; }
        public double MarkerLongitude { get; set; }
    }
}
