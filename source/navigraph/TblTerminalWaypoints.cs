using System;
using System.Collections.Generic;

namespace tfm
{
    public partial class TblTerminalWaypoints
    {
        public string AreaCode { get; set; }
        public string RegionCode { get; set; }
        public string IcaoCode { get; set; }
        public string WaypointIdentifier { get; set; }
        public string WaypointName { get; set; }
        public string WaypointType { get; set; }
        public double? WaypointLatitude { get; set; }
        public double? WaypointLongitude { get; set; }
    }
}
