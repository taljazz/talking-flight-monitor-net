using System;
using System.Collections.Generic;

namespace tfm
{
    public partial class TblControlledAirspace
    {
        public string AreaCode { get; set; }
        public string IcaoCode { get; set; }
        public string AirspaceCenter { get; set; }
        public string ControlledAirspaceName { get; set; }
        public string AirspaceType { get; set; }
        public string AirspaceClassification { get; set; }
        public string MultipleCode { get; set; }
        public string TimeCode { get; set; }
        public long? Seqno { get; set; }
        public string Flightlevel { get; set; }
        public string BoundaryVia { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? ArcOriginLatitude { get; set; }
        public double? ArcOriginLongitude { get; set; }
        public double? ArcDistance { get; set; }
        public double? ArcBearing { get; set; }
        public string UnitIndicatorLowerLimit { get; set; }
        public string LowerLimit { get; set; }
        public string UnitIndicatorUpperLimit { get; set; }
        public string UpperLimit { get; set; }
    }
}
