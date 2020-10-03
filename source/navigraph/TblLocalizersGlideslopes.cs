using System;
using System.Collections.Generic;

namespace tfm
{
    public partial class TblLocalizersGlideslopes
    {
        public string AreaCode { get; set; }
        public string IcaoCode { get; set; }
        public string AirportIdentifier { get; set; }
        public string RunwayIdentifier { get; set; }
        public string LlzIdentifier { get; set; }
        public double? LlzLatitude { get; set; }
        public double? LlzLongitude { get; set; }
        public double? LlzFrequency { get; set; }
        public double? LlzBearing { get; set; }
        public double? LlzWidth { get; set; }
        public string IlsMlsGlsCategory { get; set; }
        public double? GsLatitude { get; set; }
        public double? GsLongitude { get; set; }
        public double? GsAngle { get; set; }
        public long? GsElevation { get; set; }
        public double? StationDeclination { get; set; }
    }
}
