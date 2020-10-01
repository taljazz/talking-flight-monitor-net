using System;
using System.Collections.Generic;

namespace tfm
{
    public partial class TblIaps
    {
        public string AreaCode { get; set; }
        public string AirportIdentifier { get; set; }
        public string ProcedureIdentifier { get; set; }
        public string RouteType { get; set; }
        public string TransitionIdentifier { get; set; }
        public long? Seqno { get; set; }
        public string WaypointIcaoCode { get; set; }
        public string WaypointIdentifier { get; set; }
        public double? WaypointLatitude { get; set; }
        public double? WaypointLongitude { get; set; }
        public string WaypointDescriptionCode { get; set; }
        public string TurnDirection { get; set; }
        public double? Rnp { get; set; }
        public string PathTermination { get; set; }
        public string RecommandedNavaid { get; set; }
        public double? RecommandedNavaidLatitude { get; set; }
        public double? RecommandedNavaidLongitude { get; set; }
        public double? ArcRadius { get; set; }
        public double? Theta { get; set; }
        public double? Rho { get; set; }
        public double? MagneticCourse { get; set; }
        public double? RouteDistanceHoldingDistanceTime { get; set; }
        public string DistanceTime { get; set; }
        public string AltitudeDescription { get; set; }
        public long? Altitude1 { get; set; }
        public long? Altitude2 { get; set; }
        public long? TransitionAltitude { get; set; }
        public string SpeedLimitDescription { get; set; }
        public long? SpeedLimit { get; set; }
        public double? VerticalAngle { get; set; }
        public string CenterWaypoint { get; set; }
        public double? CenterWaypointLatitude { get; set; }
        public double? CenterWaypointLongitude { get; set; }
    }
}
