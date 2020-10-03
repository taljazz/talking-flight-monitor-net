using System;
using System.Collections.Generic;

namespace tfm
{
    public partial class TblAirportMsa
    {
        public string AreaCode { get; set; }
        public string IcaoCode { get; set; }
        public string AirportIdentifier { get; set; }
        public string MsaCenter { get; set; }
        public double? MsaCenterLatitude { get; set; }
        public double? MsaCenterLongitude { get; set; }
        public string MagneticTrueIndicator { get; set; }
        public string MultipleCode { get; set; }
        public long? RadiusLimit { get; set; }
        public long? SectorBearing1 { get; set; }
        public long? SectorAltitude1 { get; set; }
        public long? SectorBearing2 { get; set; }
        public long? SectorAltitude2 { get; set; }
        public long? SectorBearing3 { get; set; }
        public long? SectorAltitude3 { get; set; }
        public long? SectorBearing4 { get; set; }
        public long? SectorAltitude4 { get; set; }
        public long? SectorBearing5 { get; set; }
        public long? SectorAltitude5 { get; set; }
    }
}
