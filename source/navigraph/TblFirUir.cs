using System;
using System.Collections.Generic;

namespace tfm
{
    public partial class TblFirUir
    {
        public string AreaCode { get; set; }
        public string FirUirIdentifier { get; set; }
        public string FirUirAddress { get; set; }
        public string FirUirName { get; set; }
        public string FirUirIndicator { get; set; }
        public long? Seqno { get; set; }
        public string BoundaryVia { get; set; }
        public string AdjacentFirIdentifier { get; set; }
        public string AdjacentUirIdentifier { get; set; }
        public long? ReportingUnitsSpeed { get; set; }
        public long? ReportingUnitsAltitude { get; set; }
        public double? FirUirLatitude { get; set; }
        public double? FirUirLongitude { get; set; }
        public double? ArcOriginLatitude { get; set; }
        public double? ArcOriginLongitude { get; set; }
        public double? ArcDistance { get; set; }
        public double? ArcBearing { get; set; }
        public string FirUpperLimit { get; set; }
        public string UirLowerLimit { get; set; }
        public string UirUpperLimit { get; set; }
        public string CruiseTableIdentifier { get; set; }
    }
}
