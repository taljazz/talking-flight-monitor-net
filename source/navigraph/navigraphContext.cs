using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace tfm
{
    public partial class navigraphContext : DbContext
    {
        public navigraphContext()
        {
        }

        public navigraphContext(DbContextOptions<navigraphContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAirportCommunication> TblAirportCommunication { get; set; }
        public virtual DbSet<TblAirportMsa> TblAirportMsa { get; set; }
        public virtual DbSet<TblAirports> TblAirports { get; set; }
        public virtual DbSet<TblControlledAirspace> TblControlledAirspace { get; set; }
        public virtual DbSet<TblCruisingTables> TblCruisingTables { get; set; }
        public virtual DbSet<TblEnrouteAirwayRestriction> TblEnrouteAirwayRestriction { get; set; }
        public virtual DbSet<TblEnrouteAirways> TblEnrouteAirways { get; set; }
        public virtual DbSet<TblEnrouteCommunication> TblEnrouteCommunication { get; set; }
        public virtual DbSet<TblEnrouteNdbnavaids> TblEnrouteNdbnavaids { get; set; }
        public virtual DbSet<TblEnrouteWaypoints> TblEnrouteWaypoints { get; set; }
        public virtual DbSet<TblFirUir> TblFirUir { get; set; }
        public virtual DbSet<TblGate> TblGate { get; set; }
        public virtual DbSet<TblGls> TblGls { get; set; }
        public virtual DbSet<TblGridMora> TblGridMora { get; set; }
        public virtual DbSet<TblHeader> TblHeader { get; set; }
        public virtual DbSet<TblHoldings> TblHoldings { get; set; }
        public virtual DbSet<TblIaps> TblIaps { get; set; }
        public virtual DbSet<TblLocalizerMarker> TblLocalizerMarker { get; set; }
        public virtual DbSet<TblLocalizersGlideslopes> TblLocalizersGlideslopes { get; set; }
        public virtual DbSet<TblRestrictiveAirspace> TblRestrictiveAirspace { get; set; }
        public virtual DbSet<TblRunways> TblRunways { get; set; }
        public virtual DbSet<TblSids> TblSids { get; set; }
        public virtual DbSet<TblStars> TblStars { get; set; }
        public virtual DbSet<TblTerminalNdbnavaids> TblTerminalNdbnavaids { get; set; }
        public virtual DbSet<TblTerminalWaypoints> TblTerminalWaypoints { get; set; }
        public virtual DbSet<TblVhfnavaids> TblVhfnavaids { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("DataSource=data/navigraph.s3db;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAirportCommunication>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_airport_communication");

                entity.Property(e => e.AirportIdentifier)
                    .HasColumnName("airport_identifier")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.AreaCode)
                    .HasColumnName("area_code")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Callsign)
                    .HasColumnName("callsign")
                    .HasColumnType("TEXT(25)");

                entity.Property(e => e.CommunicationFrequency)
                    .HasColumnName("communication_frequency")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.CommunicationType)
                    .HasColumnName("communication_type")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.FrequencyUnits)
                    .HasColumnName("frequency_units")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.IcaoCode)
                    .HasColumnName("icao_code")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.ServiceIndicator)
                    .HasColumnName("service_indicator")
                    .HasColumnType("TEXT(3)");
            });

            modelBuilder.Entity<TblAirportMsa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_airport_msa");

                entity.Property(e => e.AirportIdentifier)
                    .HasColumnName("airport_identifier")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.AreaCode)
                    .HasColumnName("area_code")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.IcaoCode)
                    .HasColumnName("icao_code")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.MagneticTrueIndicator)
                    .HasColumnName("magnetic_true_indicator")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.MsaCenter)
                    .HasColumnName("msa_center")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.MsaCenterLatitude)
                    .HasColumnName("msa_center_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.MsaCenterLongitude)
                    .HasColumnName("msa_center_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.MultipleCode)
                    .HasColumnName("multiple_code")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.RadiusLimit)
                    .HasColumnName("radius_limit")
                    .HasColumnType("INTEGER(2)");

                entity.Property(e => e.SectorAltitude1)
                    .HasColumnName("sector_altitude_1")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.SectorAltitude2)
                    .HasColumnName("sector_altitude_2")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.SectorAltitude3)
                    .HasColumnName("sector_altitude_3")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.SectorAltitude4)
                    .HasColumnName("sector_altitude_4")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.SectorAltitude5)
                    .HasColumnName("sector_altitude_5")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.SectorBearing1)
                    .HasColumnName("sector_bearing_1")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.SectorBearing2)
                    .HasColumnName("sector_bearing_2")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.SectorBearing3)
                    .HasColumnName("sector_bearing_3")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.SectorBearing4)
                    .HasColumnName("sector_bearing_4")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.SectorBearing5)
                    .HasColumnName("sector_bearing_5")
                    .HasColumnType("INTEGER(3)");
            });

            modelBuilder.Entity<TblAirports>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_airports");

                entity.Property(e => e.AirportIdentifier)
                    .IsRequired()
                    .HasColumnName("airport_identifier")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.AirportIdentifier3letter)
                    .HasColumnName("airport_identifier_3letter")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.AirportName)
                    .HasColumnName("airport_name")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.AirportRefLatitude)
                    .HasColumnName("airport_ref_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.AirportRefLongitude)
                    .HasColumnName("airport_ref_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.AreaCode)
                    .HasColumnName("area_code")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Elevation)
                    .HasColumnName("elevation")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.IcaoCode)
                    .IsRequired()
                    .HasColumnName("icao_code")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.IfrCapability)
                    .HasColumnName("ifr_capability")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.LongestRunwaySurfaceCode)
                    .HasColumnName("longest_runway_surface_code")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.SpeedLimit)
                    .HasColumnName("speed_limit")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.SpeedLimitAltitude)
                    .HasColumnName("speed_limit_altitude")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.TransitionAltitude)
                    .HasColumnName("transition_altitude")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.TransitionLevel)
                    .HasColumnName("transition_level")
                    .HasColumnType("INTEGER(5)");
            });

            modelBuilder.Entity<TblControlledAirspace>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_controlled_airspace");

                entity.Property(e => e.AirspaceCenter)
                    .HasColumnName("airspace_center")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.AirspaceClassification)
                    .HasColumnName("airspace_classification")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.AirspaceType)
                    .HasColumnName("airspace_type")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.ArcBearing)
                    .HasColumnName("arc_bearing")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.ArcDistance)
                    .HasColumnName("arc_distance")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.ArcOriginLatitude)
                    .HasColumnName("arc_origin_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.ArcOriginLongitude)
                    .HasColumnName("arc_origin_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.AreaCode)
                    .HasColumnName("area_code")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.BoundaryVia)
                    .HasColumnName("boundary_via")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.ControlledAirspaceName)
                    .HasColumnName("controlled_airspace_name")
                    .HasColumnType("TEXT(30)");

                entity.Property(e => e.Flightlevel)
                    .HasColumnName("flightlevel")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.IcaoCode)
                    .HasColumnName("icao_code")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.LowerLimit)
                    .HasColumnName("lower_limit")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.MultipleCode)
                    .HasColumnName("multiple_code")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.Seqno)
                    .HasColumnName("seqno")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.TimeCode)
                    .HasColumnName("time_code")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.UnitIndicatorLowerLimit)
                    .HasColumnName("unit_indicator_lower_limit")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.UnitIndicatorUpperLimit)
                    .HasColumnName("unit_indicator_upper_limit")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.UpperLimit)
                    .HasColumnName("upper_limit")
                    .HasColumnType("TEXT(5)");
            });

            modelBuilder.Entity<TblCruisingTables>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_cruising_tables");

                entity.Property(e => e.CourseFrom)
                    .HasColumnName("course_from")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.CourseTo)
                    .HasColumnName("course_to")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.CruiseLevelFrom1)
                    .HasColumnName("cruise_level_from1")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.CruiseLevelFrom2)
                    .HasColumnName("cruise_level_from2")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.CruiseLevelFrom3)
                    .HasColumnName("cruise_level_from3")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.CruiseLevelFrom4)
                    .HasColumnName("cruise_level_from4")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.CruiseLevelTo1)
                    .HasColumnName("cruise_level_to1")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.CruiseLevelTo2)
                    .HasColumnName("cruise_level_to2")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.CruiseLevelTo3)
                    .HasColumnName("cruise_level_to3")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.CruiseLevelTo4)
                    .HasColumnName("cruise_level_to4")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.CruiseTableIdentifier)
                    .HasColumnName("cruise_table_identifier")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.MagTrue)
                    .HasColumnName("mag_true")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.Seqno)
                    .HasColumnName("seqno")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.VerticalSeparation1)
                    .HasColumnName("vertical_separation1")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.VerticalSeparation2)
                    .HasColumnName("vertical_separation2")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.VerticalSeparation3)
                    .HasColumnName("vertical_separation3")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.VerticalSeparation4)
                    .HasColumnName("vertical_separation4")
                    .HasColumnType("INTEGER(5)");
            });

            modelBuilder.Entity<TblEnrouteAirwayRestriction>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_enroute_airway_restriction");

                entity.Property(e => e.AreaCode)
                    .HasColumnName("area_code")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.BlockIndicator1)
                    .HasColumnName("block_indicator1")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.BlockIndicator2)
                    .HasColumnName("block_indicator2")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.BlockIndicator3)
                    .HasColumnName("block_indicator3")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.BlockIndicator4)
                    .HasColumnName("block_indicator4")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.BlockIndicator5)
                    .HasColumnName("block_indicator5")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.BlockIndicator6)
                    .HasColumnName("block_indicator6")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.BlockIndicator7)
                    .HasColumnName("block_indicator7")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("TEXT(7)");

                entity.Property(e => e.EndWaypointIdentifier)
                    .HasColumnName("end_waypoint_identifier")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.EndWaypointLatitude)
                    .HasColumnName("end_waypoint_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.EndWaypointLongitude)
                    .HasColumnName("end_waypoint_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.RestrictionAltitude1)
                    .HasColumnName("restriction_altitude1")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.RestrictionAltitude2)
                    .HasColumnName("restriction_altitude2")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.RestrictionAltitude3)
                    .HasColumnName("restriction_altitude3")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.RestrictionAltitude4)
                    .HasColumnName("restriction_altitude4")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.RestrictionAltitude5)
                    .HasColumnName("restriction_altitude5")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.RestrictionAltitude6)
                    .HasColumnName("restriction_altitude6")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.RestrictionAltitude7)
                    .HasColumnName("restriction_altitude7")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.RestrictionIdentifier)
                    .HasColumnName("restriction_identifier")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.RestrictionNotes)
                    .HasColumnName("restriction_notes")
                    .HasColumnType("TEXT(69)");

                entity.Property(e => e.RestrictionType)
                    .HasColumnName("restriction_type")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.RouteIdentifier)
                    .HasColumnName("route_identifier")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("TEXT(7)");

                entity.Property(e => e.StartWaypointIdentifier)
                    .HasColumnName("start_waypoint_identifier")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.StartWaypointLatitude)
                    .HasColumnName("start_waypoint_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.StartWaypointLongitude)
                    .HasColumnName("start_waypoint_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.UnitsOfAltitude)
                    .HasColumnName("units_of_altitude")
                    .HasColumnType("TEXT(1)");
            });

            modelBuilder.Entity<TblEnrouteAirways>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_enroute_airways");

                entity.Property(e => e.AreaCode)
                    .HasColumnName("area_code")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.CrusingTableIdentifier)
                    .HasColumnName("crusing_table_identifier")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.DirectionRestriction)
                    .HasColumnName("direction_restriction")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.Flightlevel)
                    .HasColumnName("flightlevel")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.IcaoCode)
                    .HasColumnName("icao_code")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.InboundCourse)
                    .HasColumnName("inbound_course")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.InboundDistance)
                    .HasColumnName("inbound_distance")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.MaximumAltitude)
                    .HasColumnName("maximum_altitude")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.MinimumAltitude1)
                    .HasColumnName("minimum_altitude1")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.MinimumAltitude2)
                    .HasColumnName("minimum_altitude2")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.OutboundCourse)
                    .HasColumnName("outbound_course")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.RouteIdentifier)
                    .HasColumnName("route_identifier")
                    .HasColumnType("TEXT(6)");

                entity.Property(e => e.RouteType)
                    .HasColumnName("route_type")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.Seqno)
                    .HasColumnName("seqno")
                    .HasColumnType("INTEGER(4)");

                entity.Property(e => e.WaypointDescriptionCode)
                    .HasColumnName("waypoint_description_code")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.WaypointIdentifier)
                    .HasColumnName("waypoint_identifier")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.WaypointLatitude)
                    .HasColumnName("waypoint_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.WaypointLongitude)
                    .HasColumnName("waypoint_longitude")
                    .HasColumnType("DOUBLE(10)");
            });

            modelBuilder.Entity<TblEnrouteCommunication>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_enroute_communication");

                entity.Property(e => e.AreaCode)
                    .HasColumnName("area_code")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Callsign)
                    .HasColumnName("callsign")
                    .HasColumnType("TEXT(30)");

                entity.Property(e => e.CommunicationFrequency)
                    .HasColumnName("communication_frequency")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.CommunicationType)
                    .HasColumnName("communication_type")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.FirRdoIdent)
                    .HasColumnName("fir_rdo_ident")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.FirUirIndicator)
                    .HasColumnName("fir_uir_indicator")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.FrequencyUnits)
                    .HasColumnName("frequency_units")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.RemoteName)
                    .HasColumnName("remote_name")
                    .HasColumnType("TEXT(25)");

                entity.Property(e => e.ServiceIndicator)
                    .HasColumnName("service_indicator")
                    .HasColumnType("TEXT(3)");
            });

            modelBuilder.Entity<TblEnrouteNdbnavaids>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_enroute_ndbnavaids");

                entity.Property(e => e.AreaCode)
                    .HasColumnName("area_code")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.IcaoCode)
                    .IsRequired()
                    .HasColumnName("icao_code")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.NavaidClass)
                    .HasColumnName("navaid_class")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.NdbFrequency)
                    .HasColumnName("ndb_frequency")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.NdbIdentifier)
                    .IsRequired()
                    .HasColumnName("ndb_identifier")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.NdbLatitude)
                    .HasColumnName("ndb_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.NdbLongitude)
                    .HasColumnName("ndb_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.NdbName)
                    .HasColumnName("ndb_name")
                    .HasColumnType("TEXT(30)");
            });

            modelBuilder.Entity<TblEnrouteWaypoints>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_enroute_waypoints");

                entity.Property(e => e.AreaCode)
                    .HasColumnName("area_code")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.IcaoCode)
                    .IsRequired()
                    .HasColumnName("icao_code")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.WaypointIdentifier)
                    .IsRequired()
                    .HasColumnName("waypoint_identifier")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.WaypointLatitude)
                    .HasColumnName("waypoint_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.WaypointLongitude)
                    .HasColumnName("waypoint_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.WaypointName)
                    .HasColumnName("waypoint_name")
                    .HasColumnType("TEXT(25)");

                entity.Property(e => e.WaypointType)
                    .HasColumnName("waypoint_type")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.WaypointUsage)
                    .HasColumnName("waypoint_usage")
                    .HasColumnType("TEXT(2)");
            });

            modelBuilder.Entity<TblFirUir>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_fir_uir");

                entity.Property(e => e.AdjacentFirIdentifier)
                    .HasColumnName("adjacent_fir_identifier")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.AdjacentUirIdentifier)
                    .HasColumnName("adjacent_uir_identifier")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.ArcBearing)
                    .HasColumnName("arc_bearing")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.ArcDistance)
                    .HasColumnName("arc_distance")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.ArcOriginLatitude)
                    .HasColumnName("arc_origin_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.ArcOriginLongitude)
                    .HasColumnName("arc_origin_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.AreaCode)
                    .HasColumnName("area_code")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.BoundaryVia)
                    .HasColumnName("boundary_via")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.CruiseTableIdentifier)
                    .HasColumnName("cruise_table_identifier")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.FirUirAddress)
                    .HasColumnName("fir_uir_address")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.FirUirIdentifier)
                    .HasColumnName("fir_uir_identifier")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.FirUirIndicator)
                    .HasColumnName("fir_uir_indicator")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.FirUirLatitude)
                    .HasColumnName("fir_uir_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.FirUirLongitude)
                    .HasColumnName("fir_uir_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.FirUirName)
                    .HasColumnName("fir_uir_name")
                    .HasColumnType("TEXT(25)");

                entity.Property(e => e.FirUpperLimit)
                    .HasColumnName("fir_upper_limit")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.ReportingUnitsAltitude)
                    .HasColumnName("reporting_units_altitude")
                    .HasColumnType("INTEGER(1)");

                entity.Property(e => e.ReportingUnitsSpeed)
                    .HasColumnName("reporting_units_speed")
                    .HasColumnType("INTEGER(1)");

                entity.Property(e => e.Seqno)
                    .HasColumnName("seqno")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.UirLowerLimit)
                    .HasColumnName("uir_lower_limit")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.UirUpperLimit)
                    .HasColumnName("uir_upper_limit")
                    .HasColumnType("TEXT(5)");
            });

            modelBuilder.Entity<TblGate>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_gate");

                entity.Property(e => e.AirportIdentifier)
                    .HasColumnName("airport_identifier")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.AreaCode)
                    .HasColumnName("area_code")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.GateIdentifier)
                    .HasColumnName("gate_identifier")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.GateLatitude)
                    .HasColumnName("gate_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.GateLongitude)
                    .HasColumnName("gate_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.IcaoCode)
                    .HasColumnName("icao_code")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("TEXT(25)");
            });

            modelBuilder.Entity<TblGls>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_gls");

                entity.Property(e => e.AirportIdentifier)
                    .HasColumnName("airport_identifier")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.AreaCode)
                    .HasColumnName("area_code")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.GlsApproachBearing)
                    .HasColumnName("gls_approach_bearing")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.GlsApproachSlope)
                    .HasColumnName("gls_approach_slope")
                    .HasColumnType("DOUBLE(4)");

                entity.Property(e => e.GlsCategory)
                    .HasColumnName("gls_category")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.GlsChannel)
                    .HasColumnName("gls_channel")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.GlsRefPathIdentifier)
                    .HasColumnName("gls_ref_path_identifier")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.GlsStationIdent)
                    .HasColumnName("gls_station_ident")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.IcaoCode)
                    .HasColumnName("icao_code")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.MagenticVariation)
                    .HasColumnName("magentic_variation")
                    .HasColumnType("DOUBLE(6)");

                entity.Property(e => e.RunwayIdentifier)
                    .HasColumnName("runway_identifier")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.StationElevation)
                    .HasColumnName("station_elevation")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.StationLatitude)
                    .HasColumnName("station_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.StationLongitude)
                    .HasColumnName("station_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.StationType)
                    .HasColumnName("station_type")
                    .HasColumnType("TEXT(3)");
            });

            modelBuilder.Entity<TblGridMora>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_grid_mora");

                entity.Property(e => e.Mora01)
                    .HasColumnName("mora01")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora02)
                    .HasColumnName("mora02")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora03)
                    .HasColumnName("mora03")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora04)
                    .HasColumnName("mora04")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora05)
                    .HasColumnName("mora05")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora06)
                    .HasColumnName("mora06")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora07)
                    .HasColumnName("mora07")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora08)
                    .HasColumnName("mora08")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora09)
                    .HasColumnName("mora09")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora10)
                    .HasColumnName("mora10")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora11)
                    .HasColumnName("mora11")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora12)
                    .HasColumnName("mora12")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora13)
                    .HasColumnName("mora13")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora14)
                    .HasColumnName("mora14")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora15)
                    .HasColumnName("mora15")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora16)
                    .HasColumnName("mora16")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora17)
                    .HasColumnName("mora17")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora18)
                    .HasColumnName("mora18")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora19)
                    .HasColumnName("mora19")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora20)
                    .HasColumnName("mora20")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora21)
                    .HasColumnName("mora21")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora22)
                    .HasColumnName("mora22")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora23)
                    .HasColumnName("mora23")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora24)
                    .HasColumnName("mora24")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora25)
                    .HasColumnName("mora25")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora26)
                    .HasColumnName("mora26")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora27)
                    .HasColumnName("mora27")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora28)
                    .HasColumnName("mora28")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora29)
                    .HasColumnName("mora29")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Mora30)
                    .HasColumnName("mora30")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.StartingLatitude)
                    .HasColumnName("starting_latitude")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.StartingLongitude)
                    .HasColumnName("starting_longitude")
                    .HasColumnType("INTEGER(4)");
            });

            modelBuilder.Entity<TblHeader>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_header");

                entity.Property(e => e.Arincversion)
                    .IsRequired()
                    .HasColumnName("arincversion")
                    .HasColumnType("TEXT(6)");

                entity.Property(e => e.CurrentAirac)
                    .IsRequired()
                    .HasColumnName("current_airac")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.EffectiveFromto)
                    .IsRequired()
                    .HasColumnName("effective_fromto")
                    .HasColumnType("TEXT(10)");

                entity.Property(e => e.ParsedAt)
                    .IsRequired()
                    .HasColumnName("parsed_at")
                    .HasColumnType("TEXT(22)");

                entity.Property(e => e.PreviousAirac)
                    .IsRequired()
                    .HasColumnName("previous_airac")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.PreviousFromto)
                    .IsRequired()
                    .HasColumnName("previous_fromto")
                    .HasColumnType("TEXT(10)");

                entity.Property(e => e.RecordSet)
                    .IsRequired()
                    .HasColumnName("record_set")
                    .HasColumnType("TEXT(8)");

                entity.Property(e => e.Revision)
                    .IsRequired()
                    .HasColumnName("revision")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasColumnName("version")
                    .HasColumnType("TEXT(5)");
            });

            modelBuilder.Entity<TblHoldings>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_holdings");

                entity.Property(e => e.AreaCode)
                    .HasColumnName("area_code")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.DuplicateIdentifier)
                    .HasColumnName("duplicate_identifier")
                    .HasColumnType("INTEGER(2)");

                entity.Property(e => e.HoldingName)
                    .HasColumnName("holding_name")
                    .HasColumnType("TEXT(25)");

                entity.Property(e => e.HoldingSpeed)
                    .HasColumnName("holding_speed")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.IcaoCode)
                    .HasColumnName("icao_code")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.InboundHoldingCourse)
                    .HasColumnName("inbound_holding_course")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.LegLength)
                    .HasColumnName("leg_length")
                    .HasColumnType("DOUBLE(4)");

                entity.Property(e => e.LegTime)
                    .HasColumnName("leg_time")
                    .HasColumnType("DOUBLE(3)");

                entity.Property(e => e.MaximumAltitude)
                    .HasColumnName("maximum_altitude")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.MinimumAltitude)
                    .HasColumnName("minimum_altitude")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.RegionCode)
                    .HasColumnName("region_code")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.TurnDirection)
                    .HasColumnName("turn_direction")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.WaypointIdentifier)
                    .HasColumnName("waypoint_identifier")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.WaypointLatitude)
                    .HasColumnName("waypoint_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.WaypointLongitude)
                    .HasColumnName("waypoint_longitude")
                    .HasColumnType("DOUBLE(10)");
            });

            modelBuilder.Entity<TblIaps>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_iaps");

                entity.Property(e => e.AirportIdentifier)
                    .HasColumnName("airport_identifier")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.Altitude1)
                    .HasColumnName("altitude1")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.Altitude2)
                    .HasColumnName("altitude2")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.AltitudeDescription)
                    .HasColumnName("altitude_description")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.ArcRadius)
                    .HasColumnName("arc_radius")
                    .HasColumnType("DOUBLE(7)");

                entity.Property(e => e.AreaCode)
                    .HasColumnName("area_code")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.CenterWaypoint)
                    .HasColumnName("center_waypoint")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.CenterWaypointLatitude)
                    .HasColumnName("center_waypoint_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.CenterWaypointLongitude)
                    .HasColumnName("center_waypoint_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.DistanceTime)
                    .HasColumnName("distance_time")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.MagneticCourse)
                    .HasColumnName("magnetic_course")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.PathTermination)
                    .HasColumnName("path_termination")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.ProcedureIdentifier)
                    .HasColumnName("procedure_identifier")
                    .HasColumnType("TEXT(6)");

                entity.Property(e => e.RecommandedNavaid)
                    .HasColumnName("recommanded_navaid")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.RecommandedNavaidLatitude)
                    .HasColumnName("recommanded_navaid_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.RecommandedNavaidLongitude)
                    .HasColumnName("recommanded_navaid_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.Rho)
                    .HasColumnName("rho")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.Rnp)
                    .HasColumnName("rnp")
                    .HasColumnType("DOUBLE(4)");

                entity.Property(e => e.RouteDistanceHoldingDistanceTime)
                    .HasColumnName("route_distance_holding_distance_time")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.RouteType)
                    .HasColumnName("route_type")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.Seqno)
                    .HasColumnName("seqno")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.SpeedLimit)
                    .HasColumnName("speed_limit")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.SpeedLimitDescription)
                    .HasColumnName("speed_limit_description")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.Theta)
                    .HasColumnName("theta")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.TransitionAltitude)
                    .HasColumnName("transition_altitude")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.TransitionIdentifier)
                    .HasColumnName("transition_identifier")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.TurnDirection)
                    .HasColumnName("turn_direction")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.VerticalAngle)
                    .HasColumnName("vertical_angle")
                    .HasColumnType("DOUBLE(4)");

                entity.Property(e => e.WaypointDescriptionCode)
                    .HasColumnName("waypoint_description_code")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.WaypointIcaoCode)
                    .HasColumnName("waypoint_icao_code")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.WaypointIdentifier)
                    .HasColumnName("waypoint_identifier")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.WaypointLatitude)
                    .HasColumnName("waypoint_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.WaypointLongitude)
                    .HasColumnName("waypoint_longitude")
                    .HasColumnType("DOUBLE(10)");
            });

            modelBuilder.Entity<TblLocalizerMarker>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_localizer_marker");

                entity.Property(e => e.AirportIdentifier)
                    .IsRequired()
                    .HasColumnName("airport_identifier")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.AreaCode)
                    .IsRequired()
                    .HasColumnName("area_code")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.IcaoCode)
                    .IsRequired()
                    .HasColumnName("icao_code")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.LlzIdentifier)
                    .IsRequired()
                    .HasColumnName("llz_identifier")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.MarkerIdentifier)
                    .IsRequired()
                    .HasColumnName("marker_identifier")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.MarkerLatitude)
                    .HasColumnName("marker_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.MarkerLongitude)
                    .HasColumnName("marker_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.MarkerType)
                    .IsRequired()
                    .HasColumnName("marker_type")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.RunwayIdentifier)
                    .IsRequired()
                    .HasColumnName("runway_identifier")
                    .HasColumnType("TEXT(5)");
            });

            modelBuilder.Entity<TblLocalizersGlideslopes>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_localizers_glideslopes");

                entity.Property(e => e.AirportIdentifier)
                    .IsRequired()
                    .HasColumnName("airport_identifier")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.AreaCode)
                    .HasColumnName("area_code")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.GsAngle)
                    .HasColumnName("gs_angle")
                    .HasColumnType("DOUBLE(4)");

                entity.Property(e => e.GsElevation)
                    .HasColumnName("gs_elevation")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.GsLatitude)
                    .HasColumnName("gs_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.GsLongitude)
                    .HasColumnName("gs_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.IcaoCode)
                    .HasColumnName("icao_code")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.IlsMlsGlsCategory)
                    .HasColumnName("ils_mls_gls_category")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.LlzBearing)
                    .HasColumnName("llz_bearing")
                    .HasColumnType("DOUBLE(6)");

                entity.Property(e => e.LlzFrequency)
                    .HasColumnName("llz_frequency")
                    .HasColumnType("DOUBLE(6)");

                entity.Property(e => e.LlzIdentifier)
                    .IsRequired()
                    .HasColumnName("llz_identifier")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.LlzLatitude)
                    .HasColumnName("llz_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.LlzLongitude)
                    .HasColumnName("llz_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.LlzWidth)
                    .HasColumnName("llz_width")
                    .HasColumnType("DOUBLE(6)");

                entity.Property(e => e.RunwayIdentifier)
                    .HasColumnName("runway_identifier")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.StationDeclination)
                    .HasColumnName("station_declination")
                    .HasColumnType("DOUBLE(5)");
            });

            modelBuilder.Entity<TblRestrictiveAirspace>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_restrictive_airspace");

                entity.Property(e => e.ArcBearing)
                    .HasColumnName("arc_bearing")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.ArcDistance)
                    .HasColumnName("arc_distance")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.ArcOriginLatitude)
                    .HasColumnName("arc_origin_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.ArcOriginLongitude)
                    .HasColumnName("arc_origin_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.AreaCode)
                    .HasColumnName("area_code")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.BoundaryVia)
                    .HasColumnName("boundary_via")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.Flightlevel)
                    .HasColumnName("flightlevel")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.IcaoCode)
                    .HasColumnName("icao_code")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.LowerLimit)
                    .HasColumnName("lower_limit")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.MultipleCode)
                    .HasColumnName("multiple_code")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.RestrictiveAirspaceDesignation)
                    .HasColumnName("restrictive_airspace_designation")
                    .HasColumnType("TEXT(10)");

                entity.Property(e => e.RestrictiveAirspaceName)
                    .HasColumnName("restrictive_airspace_name")
                    .HasColumnType("TEXT(30)");

                entity.Property(e => e.RestrictiveType)
                    .HasColumnName("restrictive_type")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.Seqno)
                    .HasColumnName("seqno")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.UnitIndicatorLowerLimit)
                    .HasColumnName("unit_indicator_lower_limit")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.UnitIndicatorUpperLimit)
                    .HasColumnName("unit_indicator_upper_limit")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.UpperLimit)
                    .HasColumnName("upper_limit")
                    .HasColumnType("TEXT(5)");
            });

            modelBuilder.Entity<TblRunways>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_runways");

                entity.Property(e => e.AirportIdentifier)
                    .IsRequired()
                    .HasColumnName("airport_identifier")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.AreaCode)
                    .HasColumnName("area_code")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.DisplacedThresholdDistance)
                    .HasColumnName("displaced_threshold_distance")
                    .HasColumnType("INTEGER(4)");

                entity.Property(e => e.IcaoCode)
                    .HasColumnName("icao_code")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.LandingThresholdElevation)
                    .HasColumnName("landing_threshold_elevation")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.LlzIdentifier)
                    .HasColumnName("llz_identifier")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.LlzMlsGlsCategory)
                    .HasColumnName("llz_mls_gls_category")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.RunwayGradient)
                    .HasColumnName("runway_gradient")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.RunwayIdentifier)
                    .IsRequired()
                    .HasColumnName("runway_identifier")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.RunwayLatitude)
                    .HasColumnName("runway_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.RunwayLength)
                    .HasColumnName("runway_length")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.RunwayLongitude)
                    .HasColumnName("runway_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.RunwayMagneticBearing)
                    .HasColumnName("runway_magnetic_bearing")
                    .HasColumnType("DOUBLE(6)");

                entity.Property(e => e.RunwayTrueBearing)
                    .HasColumnName("runway_true_bearing")
                    .HasColumnType("DOUBLE(7)");

                entity.Property(e => e.RunwayWidth)
                    .HasColumnName("runway_width")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.ThresholdCrossingHeight)
                    .HasColumnName("threshold_crossing_height")
                    .HasColumnType("INTEGER(2)");
            });

            modelBuilder.Entity<TblSids>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_sids");

                entity.Property(e => e.AirportIdentifier)
                    .HasColumnName("airport_identifier")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.Altitude1)
                    .HasColumnName("altitude1")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.Altitude2)
                    .HasColumnName("altitude2")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.AltitudeDescription)
                    .HasColumnName("altitude_description")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.ArcRadius)
                    .HasColumnName("arc_radius")
                    .HasColumnType("DOUBLE(7)");

                entity.Property(e => e.AreaCode)
                    .HasColumnName("area_code")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.CenterWaypoint)
                    .HasColumnName("center_waypoint")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.CenterWaypointLatitude)
                    .HasColumnName("center_waypoint_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.CenterWaypointLongitude)
                    .HasColumnName("center_waypoint_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.DistanceTime)
                    .HasColumnName("distance_time")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.MagneticCourse)
                    .HasColumnName("magnetic_course")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.PathTermination)
                    .HasColumnName("path_termination")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.ProcedureIdentifier)
                    .HasColumnName("procedure_identifier")
                    .HasColumnType("TEXT(6)");

                entity.Property(e => e.RecommandedNavaid)
                    .HasColumnName("recommanded_navaid")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.RecommandedNavaidLatitude)
                    .HasColumnName("recommanded_navaid_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.RecommandedNavaidLongitude)
                    .HasColumnName("recommanded_navaid_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.Rho)
                    .HasColumnName("rho")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.Rnp)
                    .HasColumnName("rnp")
                    .HasColumnType("DOUBLE(4)");

                entity.Property(e => e.RouteDistanceHoldingDistanceTime)
                    .HasColumnName("route_distance_holding_distance_time")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.RouteType)
                    .HasColumnName("route_type")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.Seqno)
                    .HasColumnName("seqno")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.SpeedLimit)
                    .HasColumnName("speed_limit")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.SpeedLimitDescription)
                    .HasColumnName("speed_limit_description")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.Theta)
                    .HasColumnName("theta")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.TransitionAltitude)
                    .HasColumnName("transition_altitude")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.TransitionIdentifier)
                    .HasColumnName("transition_identifier")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.TurnDirection)
                    .HasColumnName("turn_direction")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.VerticalAngle)
                    .HasColumnName("vertical_angle")
                    .HasColumnType("DOUBLE(4)");

                entity.Property(e => e.WaypointDescriptionCode)
                    .HasColumnName("waypoint_description_code")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.WaypointIcaoCode)
                    .HasColumnName("waypoint_icao_code")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.WaypointIdentifier)
                    .HasColumnName("waypoint_identifier")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.WaypointLatitude)
                    .HasColumnName("waypoint_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.WaypointLongitude)
                    .HasColumnName("waypoint_longitude")
                    .HasColumnType("DOUBLE(10)");
            });

            modelBuilder.Entity<TblStars>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_stars");

                entity.Property(e => e.AirportIdentifier)
                    .HasColumnName("airport_identifier")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.Altitude1)
                    .HasColumnName("altitude1")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.Altitude2)
                    .HasColumnName("altitude2")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.AltitudeDescription)
                    .HasColumnName("altitude_description")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.ArcRadius)
                    .HasColumnName("arc_radius")
                    .HasColumnType("DOUBLE(7)");

                entity.Property(e => e.AreaCode)
                    .HasColumnName("area_code")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.CenterWaypoint)
                    .HasColumnName("center_waypoint")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.CenterWaypointLatitude)
                    .HasColumnName("center_waypoint_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.CenterWaypointLongitude)
                    .HasColumnName("center_waypoint_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.DistanceTime)
                    .HasColumnName("distance_time")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.MagneticCourse)
                    .HasColumnName("magnetic_course")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.PathTermination)
                    .HasColumnName("path_termination")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.ProcedureIdentifier)
                    .HasColumnName("procedure_identifier")
                    .HasColumnType("TEXT(6)");

                entity.Property(e => e.RecommandedNavaid)
                    .HasColumnName("recommanded_navaid")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.RecommandedNavaidLatitude)
                    .HasColumnName("recommanded_navaid_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.RecommandedNavaidLongitude)
                    .HasColumnName("recommanded_navaid_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.Rho)
                    .HasColumnName("rho")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.Rnp)
                    .HasColumnName("rnp")
                    .HasColumnType("DOUBLE(4)");

                entity.Property(e => e.RouteDistanceHoldingDistanceTime)
                    .HasColumnName("route_distance_holding_distance_time")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.RouteType)
                    .HasColumnName("route_type")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.Seqno)
                    .HasColumnName("seqno")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.SpeedLimit)
                    .HasColumnName("speed_limit")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.SpeedLimitDescription)
                    .HasColumnName("speed_limit_description")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.Theta)
                    .HasColumnName("theta")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.TransitionAltitude)
                    .HasColumnName("transition_altitude")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.TransitionIdentifier)
                    .HasColumnName("transition_identifier")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.TurnDirection)
                    .HasColumnName("turn_direction")
                    .HasColumnType("TEXT(1)");

                entity.Property(e => e.VerticalAngle)
                    .HasColumnName("vertical_angle")
                    .HasColumnType("DOUBLE(4)");

                entity.Property(e => e.WaypointDescriptionCode)
                    .HasColumnName("waypoint_description_code")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.WaypointIcaoCode)
                    .HasColumnName("waypoint_icao_code")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.WaypointIdentifier)
                    .HasColumnName("waypoint_identifier")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.WaypointLatitude)
                    .HasColumnName("waypoint_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.WaypointLongitude)
                    .HasColumnName("waypoint_longitude")
                    .HasColumnType("DOUBLE(10)");
            });

            modelBuilder.Entity<TblTerminalNdbnavaids>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_terminal_ndbnavaids");

                entity.Property(e => e.AirportIdentifier)
                    .IsRequired()
                    .HasColumnName("airport_identifier")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.AreaCode)
                    .HasColumnName("area_code")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.IcaoCode)
                    .IsRequired()
                    .HasColumnName("icao_code")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.NavaidClass)
                    .HasColumnName("navaid_class")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.NdbFrequency)
                    .HasColumnName("ndb_frequency")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.NdbIdentifier)
                    .IsRequired()
                    .HasColumnName("ndb_identifier")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.NdbLatitude)
                    .HasColumnName("ndb_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.NdbLongitude)
                    .HasColumnName("ndb_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.NdbName)
                    .HasColumnName("ndb_name")
                    .HasColumnType("TEXT(30)");
            });

            modelBuilder.Entity<TblTerminalWaypoints>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_terminal_waypoints");

                entity.Property(e => e.AreaCode)
                    .HasColumnName("area_code")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.IcaoCode)
                    .IsRequired()
                    .HasColumnName("icao_code")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.RegionCode)
                    .IsRequired()
                    .HasColumnName("region_code")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.WaypointIdentifier)
                    .IsRequired()
                    .HasColumnName("waypoint_identifier")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.WaypointLatitude)
                    .HasColumnName("waypoint_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.WaypointLongitude)
                    .HasColumnName("waypoint_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.WaypointName)
                    .HasColumnName("waypoint_name")
                    .HasColumnType("TEXT(25)");

                entity.Property(e => e.WaypointType)
                    .HasColumnName("waypoint_type")
                    .HasColumnType("TEXT(3)");
            });

            modelBuilder.Entity<TblVhfnavaids>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_vhfnavaids");

                entity.Property(e => e.AirportIdentifier)
                    .HasColumnName("airport_identifier")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.AreaCode)
                    .HasColumnName("area_code")
                    .HasColumnType("TEXT(3)");

                entity.Property(e => e.DmeElevation)
                    .HasColumnName("dme_elevation")
                    .HasColumnType("INTEGER(5)");

                entity.Property(e => e.DmeIdent)
                    .HasColumnName("dme_ident")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.DmeLatitude)
                    .HasColumnName("dme_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.DmeLongitude)
                    .HasColumnName("dme_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.IcaoCode)
                    .IsRequired()
                    .HasColumnName("icao_code")
                    .HasColumnType("TEXT(2)");

                entity.Property(e => e.IlsdmeBias)
                    .HasColumnName("ilsdme_bias")
                    .HasColumnType("DOUBLE(3)");

                entity.Property(e => e.NavaidClass)
                    .HasColumnName("navaid_class")
                    .HasColumnType("TEXT(5)");

                entity.Property(e => e.Range)
                    .HasColumnName("range")
                    .HasColumnType("INTEGER(3)");

                entity.Property(e => e.StationDeclination)
                    .HasColumnName("station_declination")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.VorFrequency)
                    .HasColumnName("vor_frequency")
                    .HasColumnType("DOUBLE(5)");

                entity.Property(e => e.VorIdentifier)
                    .IsRequired()
                    .HasColumnName("vor_identifier")
                    .HasColumnType("TEXT(4)");

                entity.Property(e => e.VorLatitude)
                    .HasColumnName("vor_latitude")
                    .HasColumnType("DOUBLE(9)");

                entity.Property(e => e.VorLongitude)
                    .HasColumnName("vor_longitude")
                    .HasColumnType("DOUBLE(10)");

                entity.Property(e => e.VorName)
                    .HasColumnName("vor_name")
                    .HasColumnType("TEXT(30)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
