using System;
using System.Collections.Generic;

namespace tfm
{
    public partial class TblRunways
    {
        public string AreaCode { get; set; }
        public string IcaoCode { get; set; }
        public string AirportIdentifier { get; set; }
        public string RunwayIdentifier { get; set; }
        public double? RunwayLatitude { get; set; }
        public double? RunwayLongitude { get; set; }
        public double? RunwayGradient { get; set; }
        public double? RunwayMagneticBearing { get; set; }
        public double? RunwayTrueBearing { get; set; }
        public long? LandingThresholdElevation { get; set; }
        public long? DisplacedThresholdDistance { get; set; }
        public long? ThresholdCrossingHeight { get; set; }
        public long? RunwayLength { get; set; }
        public long? RunwayWidth { get; set; }
        public string LlzIdentifier { get; set; }
        public string LlzMlsGlsCategory { get; set; }
    }
}
