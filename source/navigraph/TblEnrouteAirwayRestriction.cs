using System;
using System.Collections.Generic;

namespace tfm
{
    public partial class TblEnrouteAirwayRestriction
    {
        public string AreaCode { get; set; }
        public string RouteIdentifier { get; set; }
        public long? RestrictionIdentifier { get; set; }
        public string RestrictionType { get; set; }
        public string StartWaypointIdentifier { get; set; }
        public double? StartWaypointLatitude { get; set; }
        public double? StartWaypointLongitude { get; set; }
        public string EndWaypointIdentifier { get; set; }
        public double? EndWaypointLatitude { get; set; }
        public double? EndWaypointLongitude { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string UnitsOfAltitude { get; set; }
        public long? RestrictionAltitude1 { get; set; }
        public string BlockIndicator1 { get; set; }
        public long? RestrictionAltitude2 { get; set; }
        public string BlockIndicator2 { get; set; }
        public long? RestrictionAltitude3 { get; set; }
        public string BlockIndicator3 { get; set; }
        public long? RestrictionAltitude4 { get; set; }
        public string BlockIndicator4 { get; set; }
        public long? RestrictionAltitude5 { get; set; }
        public string BlockIndicator5 { get; set; }
        public long? RestrictionAltitude6 { get; set; }
        public string BlockIndicator6 { get; set; }
        public long? RestrictionAltitude7 { get; set; }
        public string BlockIndicator7 { get; set; }
        public string RestrictionNotes { get; set; }
    }
}
