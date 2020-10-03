using System;
using System.Collections.Generic;

namespace tfm
{
    public partial class TblHoldings
    {
        public string AreaCode { get; set; }
        public string RegionCode { get; set; }
        public string IcaoCode { get; set; }
        public string WaypointIdentifier { get; set; }
        public string HoldingName { get; set; }
        public double? WaypointLatitude { get; set; }
        public double? WaypointLongitude { get; set; }
        public long? DuplicateIdentifier { get; set; }
        public double? InboundHoldingCourse { get; set; }
        public string TurnDirection { get; set; }
        public double? LegLength { get; set; }
        public double? LegTime { get; set; }
        public long? MinimumAltitude { get; set; }
        public long? MaximumAltitude { get; set; }
        public long? HoldingSpeed { get; set; }
    }
}
