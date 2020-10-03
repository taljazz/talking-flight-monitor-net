using System;
using System.Collections.Generic;

namespace tfm
{
    public partial class TblAirports
    {
        public string AreaCode { get; set; }
        public string IcaoCode { get; set; }
        public string AirportIdentifier { get; set; }
        public string AirportIdentifier3letter { get; set; }
        public string AirportName { get; set; }
        public double? AirportRefLatitude { get; set; }
        public double? AirportRefLongitude { get; set; }
        public string IfrCapability { get; set; }
        public string LongestRunwaySurfaceCode { get; set; }
        public long? Elevation { get; set; }
        public long? TransitionAltitude { get; set; }
        public long? TransitionLevel { get; set; }
        public long? SpeedLimit { get; set; }
        public long? SpeedLimitAltitude { get; set; }
    }
}
