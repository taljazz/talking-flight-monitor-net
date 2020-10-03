using System;
using System.Collections.Generic;

namespace tfm
{
    public partial class TblEnrouteAirways
    {
        public string AreaCode { get; set; }
        public string RouteIdentifier { get; set; }
        public long? Seqno { get; set; }
        public string IcaoCode { get; set; }
        public string WaypointIdentifier { get; set; }
        public double? WaypointLatitude { get; set; }
        public double? WaypointLongitude { get; set; }
        public string WaypointDescriptionCode { get; set; }
        public string RouteType { get; set; }
        public string Flightlevel { get; set; }
        public string DirectionRestriction { get; set; }
        public string CrusingTableIdentifier { get; set; }
        public long? MinimumAltitude1 { get; set; }
        public long? MinimumAltitude2 { get; set; }
        public long? MaximumAltitude { get; set; }
        public double? OutboundCourse { get; set; }
        public double? InboundCourse { get; set; }
        public double? InboundDistance { get; set; }
    }
}
