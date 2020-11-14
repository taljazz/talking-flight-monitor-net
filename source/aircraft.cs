using DavyKager;
using FSUIPC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace tfm
{
    public static class Aircraft
    {
        // =====================================
        // DECLARE OFFSETS YOU WANT TO USE HERE
        // =====================================
        public static Offset<short> SimPauseControl = new Offset<short>(0x0262);
        public static Offset<short> SimPauseIndicator = new Offset<short>(0x0264);
        public static Offset<short> SimSoundFlag = new Offset<short>(0x0b24);
        public static  Offset<ushort> Com1Freq = new Offset<ushort>(0x034e);
        public static  Offset<ushort> Com1StandbyFreq = new Offset<ushort>(0x311a);
        public static  Offset<ushort> Com2Freq = new Offset<ushort>(0x3118);
        public static  Offset<ushort> Com2StandbyFreq = new Offset<ushort>(0x311c);
        public static  Offset<FsBitArray> RadioAudio = new Offset<FsBitArray>(0x3122, 1);
        public static Offset<ushort> Nav1Freq = new Offset<ushort>(0x0350);
        public static Offset<ushort> Nav2Freq = new Offset<ushort>(0x0352);
        // ADF frequencies are split over 2 offsets, the 'main' and 'extended'.
        public static Offset<ushort> adf1Main = new Offset<ushort>(0x034C);
        public static Offset<ushort> adf1Extended = new Offset<ushort>(0x0356);

        public static  Offset<FsLatitude> aircraftLat = new Offset<FsLatitude>(0x0560, 8);
        public static  Offset<FsLongitude> aircraftLon = new Offset<FsLongitude>(0x0568, 8);
        public static  Offset<short> Flaps = new Offset<short>(0x30f0);
        public static  Offset<short> OnGround = new Offset<short>(0x0366);
        public static  Offset<short> ParkingBrake = new Offset<short>(0x0bc8);
        public static  Offset<uint> LandingGear = new Offset<uint>(0x0bec);
        public static Offset<uint> LandingGearControl = new Offset<uint>(0x0BE8);
        public static  Offset<int> Altitude = new Offset<int>(0x3324);
        public static  Offset<int> GroundAltitude = new Offset<int>(0x0020);
        public static  Offset<uint> SpoilersArm = new Offset<uint>(0x0bcc);
        public static  Offset<uint> Spoilers = new Offset<uint>(0x0bd0);
        public static Offset<byte> SeatbeltSign = new Offset<byte>(0x341d);
        public static Offset<byte> NoSmokingSign = new Offset<byte>(0x341c);

        public static  Offset<uint> AvionicsMaster = new Offset<uint>(0x2e80);
        public static  Offset<uint> ApMaster = new Offset<uint>(0x07bc);
        public static  Offset<uint> ApNavLock = new Offset<uint>(0x07c4);
        public static  Offset<uint> ApHeadingLock = new Offset<uint>(0x07c8);
        public static  Offset<ushort> ApHeading = new Offset<ushort>(0x07cc);
        public static  Offset<uint> ApAltitudeLock = new Offset<uint>(0x07d0);
        public static  Offset<uint> ApAltitude = new Offset<uint>(0x07d4);
        public static  Offset<uint> ApSpeedHold = new Offset<uint>(0x07dc);
        public static  Offset<uint> ApMachHold = new Offset<uint>(0x07e4);
        public static  Offset<short> ApAirspeed = new Offset<short>(0x07e2);
        public static  Offset<uint> ApMach = new Offset<uint>(0x07e8);
        public static  Offset<uint> ApVerticalSpeedHold = new Offset<uint>(0x07ec);
        public static  Offset<short> ApVerticalSpeed = new Offset<short>(0x07f2);
        public static  Offset<uint> ApNavGPS = new Offset<uint>(0x132c);
        public static  Offset<uint> ApApproachHold = new Offset<uint>(0x0800);
        public static  Offset<uint> ApGlideSlopeHold = new Offset<uint>(0x07fc);
        public static  Offset<uint> ApFlightDirector = new Offset<uint>(0x2ee0);
        public static  Offset<double> ApFlightDirectorPitch = new Offset<double>(0x2ee8);
        public static  Offset<double> ApFlightDirectorBank = new Offset<double>(0x2ef0);
        public static  Offset<uint> ApAttitudeHold = new Offset<uint>(0x07d8);
        public static  Offset<uint> ApWingLeveler = new Offset<uint>(0x07c0);
        public static  Offset<uint> PropSync = new Offset<uint>(0x243c);
        public static  Offset<short> ApAutoRudder = new Offset<short>(0x0278);
        public static  Offset<uint> BatteryMaster = new Offset<uint>(0x281c);
        public static  Offset<byte> Alternator = new Offset<byte>(0x3101);
        public static  Offset<uint> Heading = new Offset<uint>(0x0580);
        public static  Offset<short> MagneticVariation = new Offset<short>(0x02a0);
        public static  Offset<ushort> Transponder = new Offset<ushort>(0x0354);
        public static  Offset<double> CompassHeading = new Offset<double>(0x2b00);
        public static  Offset<double> NextWPDistance = new Offset<double>(0x6048);
        public static Offset<string> NextWPName = new Offset<string>(0x60a4, 6);
        public static  Offset<uint> NextWPETE = new Offset<uint>(0x60e4);
        public static  Offset<byte> AutoBrake = new Offset<byte>(0x2f80);
        public static  Offset<uint> AirspeedTrue = new Offset<uint>(0x02b8);
        public static  Offset<uint> AirspeedIndicated = new Offset<uint>(0x02bc);
        public static  Offset<uint> GroundSpeed = new Offset<uint>(0x02b4);
        public static  Offset<uint> ApYawDamper = new Offset<uint>(0x0808);
        public static  Offset<uint> Toga = new Offset<uint>(0x080c);
        public static  Offset<uint> AutoThrottleArm = new Offset<uint>(0x0810);
        public static  Offset<uint> AutoFeather = new Offset<uint>(0x2438);
        public static  Offset<short> AirspeedMach = new Offset<short>(0x11c6);
        public static  Offset<uint> NextWPETA = new Offset<uint>(0x60e8);
        public static  Offset<double> NextWPBaring = new Offset<double>(0x6050);
        public static Offset<string> DestinationAirportID = new Offset<string>(0x6137, 5);
        public static  Offset<uint> DestinationTimeEnroute = new Offset<uint>(0x6198);
        public static  Offset<double> RouteDistance = new Offset<double>(0x61a0);
        public static  Offset<double> FuelBurn = new Offset<double>(0x61a8);
        public static  Offset<uint> FuelQuantity = new Offset<uint>(0x126c);
        public static  Offset<double> ElevatorTrim = new Offset<double>(0x2ea0);
        public static  Offset<double> AileronTrim = new Offset<double>(0x2eb0);
        public static  Offset<double> RudderTrim = new Offset<double>(0x2ec0);
        public static  Offset<short> VerticalSpeed = new Offset<short>(0x0842);
        public static  Offset<short> AirTemp = new Offset<short>(0x0e8c);
        public static  Offset<byte> Nav1GS = new Offset<byte>(0x0c4c);
        public static  Offset<short> Nav1LocaliserInverseRunwayHeading = new Offset<short>(0x0870);

        public static Offset<sbyte> Nav1GSNeedle = new Offset<sbyte>(0x0c49);
        public static Offset<sbyte> Nav1LocNeedle = new Offset<sbyte>(0x0c48);
        public static Offset<string> Vor1ID = new Offset<string>(0x3000, 6);
        public static Offset<string> Vor1Name = new Offset<string>(0x3006, 25);
        public static Offset<ushort> Nav1GSInclination = new Offset<ushort>(0x0872);

        public static  Offset<FsBitArray> Nav1Flags = new Offset<FsBitArray>(0x0c4d, 1);
        public enum NavFlag
        {
            DMEAvailable,
            TACAN,
            VoiceAvailable,
            NoSignal,
            DMEGSCoLocated,
            NoBackCourse,
            GSAvailable,
            NavType
        }

        public static  Offset<uint> Nav1Signal = new Offset<uint>(0x0c52);

        /* Additional radio and autopilot status indicators (read only access). Allocation by bits which are set when true. Bit 0 = least significant (value 1):
0  = reserved
1  = good NAV1
2  = good NAV2
3  = good ADF1
4  = NAV1 has DME
5  = NAV2 has DME
6  = NAV1 is ILS
7  = AP NAV1 radial acquired
8  = AP ILS LOC acquired (incl BC—see 10)
9  = AP ILS GS acquired
10=AP ILS LOC is BC
11=good ADF2
12=NAV2 is ILS
13–15 reserved */
        public static Offset<FsBitArray> AutopilotRadioStatus = new Offset<FsBitArray>(0x3300, 2);
        public static  Offset<ushort> Altimeter = new Offset<ushort>(0x0330);
        public static  Offset<FsBitArray> Doors = new Offset<FsBitArray>(0x3367, 1);
        public static  Offset<byte> APUGenerator = new Offset<byte>("LowPriority", 0x0b51);
        public static  Offset<byte> APUGeneratorActive = new Offset<byte>(0x0b52);
        public static  Offset<float> APUPercentage = new Offset<float>(0x0b54);
        public static  Offset<float> APUVoltage = new Offset<float>(0x0b5c);
        public static  Offset<double> Eng1RPM = new Offset<double>(0x2400);
        public static  Offset<uint> Eng1Starter = new Offset<uint>("LowPriority", 0x3b00);
        public static  Offset<uint> Eng2Starter = new Offset<uint>("LowPriority", 0x3a40);
        public static  Offset<uint> Eng3Starter = new Offset<uint>("LowPriority", 0x3980);
        public static  Offset<uint> Eng4Starter = new Offset<uint>("LowPriority", 0x38c0);
        public static  Offset<double> Eng1FuelFlow = new Offset<double>(0x2060);
        public static  Offset<double> Eng2FuelFlow = new Offset<double>(0x2160);
        public static  Offset<double> Eng3FuelFlow = new Offset<double>(0x2260);
        public static  Offset<double> Eng4FuelFlow = new Offset<double>(0x2360);
        public static  Offset<double> Eng1N1 = new Offset<double>(0x2010);
        public static  Offset<uint> Eng4Generator = new Offset<uint>("LowPriority", 0x393c);
        public static  Offset<uint> Eng3Generator = new Offset<uint>("LowPriority", 0x39fc);
        public static  Offset<uint> Eng2Generator = new Offset<uint>("LowPriority", 0x3abc);
        public static  Offset<uint> Eng1Generator = new Offset<uint>("LowPriority", 0x3b7c);
        public static Offset<short> Engine1ThrottleLever = new Offset<short>(0x088c);
        public static Offset<short> Engine2ThrottleLever = new Offset<short>(0x0924);
        public static Offset<short> Engine3ThrottleLever = new Offset<short>(0x09bc);
        public static Offset<short> Engine4ThrottleLever = new Offset<short>(0x0a54);
        public static Offset<double> Engine1JetThrust = new Offset<double>(0x204c);
        public static Offset<double> Engine2JetThrust = new Offset<double>(0x214c);
        public static Offset<double> Engine3JetThrust = new Offset<double>(0x224c);
        public static Offset<double> Engine4JetThrust = new Offset<double>(0x234c);

        public static  Offset<double> Eng1N2 = new Offset<double>(0x2018);
        public static  Offset<double> Eng2N1 = new Offset<double>(0x2110);
        public static  Offset<double> Eng2N2 = new Offset<double>(0x2118);
        public static  Offset<double> Eng3N1 = new Offset<double>(0x2210);
        public static  Offset<double> Eng3N2 = new Offset<double>(0x2218);
        public static  Offset<double> Eng4N1 = new Offset<double>(0x2310);
        public static  Offset<double> Eng4N2 = new Offset<double>(0x2318);
        public static  Offset<ushort> Eng1Combustion = new Offset<ushort>("LowPriority", 0x0894);
        public static  Offset<ushort> Eng2Combustion = new Offset<ushort>("LowPriority", 0x092c);
        public static  Offset<ushort> Eng3Combustion = new Offset<ushort>("LowPriority", 0x09c4);
        public static  Offset<ushort> Eng4Combustion = new Offset<ushort>("LowPriority", 0x0a5c);
        public static  Offset<uint> Eng1ITT = new Offset<uint>(0x08f0);
        public static  Offset<uint> Eng2ITT = new Offset<uint>(0x0988);
        public static  Offset<uint> Eng3ITT = new Offset<uint>(0x0a20);
        public static  Offset<uint> Eng4ITT = new Offset<uint>(0x0ab8);
        public static  Offset<uint> Eng1FuelValve = new Offset<uint>("LowPriority", 0x3590);
        public static  Offset<uint> Eng2FuelValve = new Offset<uint>("LowPriority", 0x3594);
        public static  Offset<uint> Eng3FuelValve = new Offset<uint>("LowPriority", 0x3598);
        public static  Offset<uint> Eng4FuelValve = new Offset<uint>("LowPriority", 0x359c);
        public static  Offset<byte> PitotHeat = new Offset<byte>(0x029c);
        public static Offset<FsBitArray> Lights = new Offset<FsBitArray>(0x0d0c, 2);
        public enum light
        {
            Navigation,
            Beacon,
            Landing,
            Taxi,
            Strobe,
            Instruments,
            Recognition,
            Wing,
            Logo,
            Cabin
        }

        public static  Offset<ushort> WindSpeed = new Offset<ushort>(0x0e90);
        public static  Offset<ushort> WindDirection = new Offset<ushort>(0x0e92);
        public static  Offset<ushort> WindGust = new Offset<ushort>(0x0e94);
        public static  Offset<uint> RadioAltimeter = new Offset<uint>(0x31e4);
        public static  Offset<byte> FuelPump = new Offset<byte>(0x3104);
        public static  Offset<ushort> num_engines = new Offset<ushort>(0x0aec);
        public static  Offset<double> eng1_fuel_flow = new Offset<double>(0x0918);
        public static  Offset<double> eng2_fuel_flow = new Offset<double>(0x09b0);
        public static  Offset<double> eng3_fuel_flow = new Offset<double>(0x0a48);
        public static  Offset<double> eng4_fuel_flow = new Offset<double>(0x0ae0);
        public static Offset<BitArray> EngineSelectFlags = new Offset<BitArray>(0x0888, 1);
        public enum EngSelect
        {
            Eng1,
            Eng2,
            Eng3,
            Eng4
        }

        public static  Offset<double> GyroSuction = new Offset<double>(0x0b18);
        public static  Offset<byte> OilQuantity = new Offset<byte>(0x66c9);
        public static  Offset<string> AircraftName = new Offset<string>(0x3d00, 255);
        public static Offset<byte> EngineType = new Offset<byte>(0x0609);
        public static Offset<double> Engine1RPM = new Offset<double>(0x2400);
        public static Offset<double> Engine2RPM = new Offset<double>(0x2500);
        public static Offset<double> Engine3RPM = new Offset<double>(0x2600);
        public static Offset<double> Engine4RPM = new Offset<double>(0x2700);
        public static Offset<short> Engine1ManifoldPressure = new Offset<short>(0x08c0);
        public static Offset<short> Engine2ManifoldPressure = new Offset<short>(0x0958);
        public static Offset<short> Engine3ManifoldPressure = new Offset<short>(0x09f0);
        public static Offset<short> Engine4ManifoldPressure = new Offset<short>(0x0a88);
        public static Offset<double> Engine1CHT = new Offset<double>(0x08e8);
        public static Offset<double> Engine2CHT = new Offset<double>(0x0980);
        public static Offset<double> Engine3CHT = new Offset<double>(0x0a18);
        public static Offset<double> Engine4CHT = new Offset<double>(0x0ab0);
        public static Offset<double> Engine1EGT = new Offset<double>(0x3b70);
        public static Offset<double> Engine2EGT = new Offset<double>(0x3ab0);
        public static Offset<double> Engine3EGT = new Offset<double>(0x39f0);
        public static Offset<double> Engine4EGT = new Offset<double>(0x3930);
        public static Offset<double> CenterOfGravity = new Offset<double>("Payload", 0x2ef8);
        // atitude mode offsets
        public static Offset<int> AttitudePitch = new Offset<int>("attitude", 0x0578);
        public static Offset<int> AttitudeBank = new Offset<int>("attitude", 0x057c);
        public static  TextMenu textMenu = new TextMenu();
        public static Offset<ushort> SimulationRate = new Offset<ushort>(0x0c1a);
        // PMDG offsets. These are all read-only. Writing is done via the PMDG control codes.
        // ﻿Aft overhead
        // ADIRU
        public static Offset<string> IRS_DisplayLeft = new Offset<string>(0x6C5A, 7);
        public static Offset<string> IRS_DisplayRight = new Offset<string>(0x6c61, 8);
        public static Offset<byte> IRS_DisplaySelector = new Offset<byte>("pmdg", 0x6420);
        public static Offset<byte> IRS_SysDisplay_R = new Offset<byte>("pmdg", 0x6421);
        public static Offset<byte> IRS_annunGPS = new Offset<byte>("pmdg", 0x6422);
        public static Offset<byte> IRS_annunALIGN = new Offset<byte>("pmdg", 0x6423);
        public static Offset<byte> IRS_annunON_DC = new Offset<byte>("pmdg", 0x6425);
        public static Offset<byte> IRS_annunFAULT = new Offset<byte>("pmdg", 0x6427);
        public static Offset<byte> IRS_annunDC_FAIL = new Offset<byte>("pmdg", 0x6429);
        public static Offset<byte> IRS_ModeSelectorLeft = new Offset<byte>("pmdg", 0x642B);
        public static Offset<byte> IRS_ModeSelectorRight = new Offset<byte>("pmdg", 0x642C);
        // PSEU
        public static Offset<byte> WARN_annunPSEU = new Offset<byte>("pmdg", 0x642D);
        // SERVICE INTERPHONE
        public static Offset<byte> COMM_ServiceInterphoneSw = new Offset<byte>("pmdg", 0x642E);
        // LIGHTS
        public static Offset<byte> LTS_DomeWhiteSw = new Offset<byte>("pmdg", 0x642F);
        // ENGINE
        public static Offset<byte> ENG_EECSwitch = new Offset<byte>("pmdg", 0x6430);
        public static Offset<byte> ENG_annunREVERSER = new Offset<byte>("pmdg", 0x6432);
        public static Offset<byte> ENG_annunENGINE_CONTROL = new Offset<byte>("pmdg", 0x6434);
public static Offset<byte> ENG_annunALTN = new Offset<byte>("pmdg", 0x6436);
        // OXYGEN
        public static Offset<byte> OXY_Needle = new Offset<byte>("pmdg", 0x6438);
        public static Offset<byte> OXY_SwNormal = new Offset<byte>("pmdg", 0x6439);
        public static Offset<byte> OXY_annunPASS_OXY_ON = new Offset<byte>("pmdg", 0x643A);
        // GEAR
        public static Offset<byte> GEAR_annunOvhdLEFT = new Offset<byte>("pmdg", 0x643B);
        public static Offset<byte> GEAR_annunOvhdNOSE = new Offset<byte>("pmdg", 0x643C);
        public static Offset<byte> GEAR_annunOvhdRIGHT = new Offset<byte>("pmdg", 0x643D);
        // FLIGHT RECORDER
        public static Offset<byte> FLTREC_SwNormal = new Offset<byte>("pmdg", 0x643E);
        public static Offset<byte> FLTREC_annunOFF = new Offset<byte>("pmdg", 0x643F);
        // Forward overhead
        // FLIGHT CONTROLS
        public static Offset<byte> FCTL_FltControl_Sw = new Offset<byte>("pmdg", 0x6440);
        public static Offset<byte> FCTL_Spoiler_Sw = new Offset<byte>("pmdg", 0x6442);
        public static Offset<byte> FCTL_YawDamper_Sw = new Offset<byte>("pmdg", 0x6444);
        public static Offset<byte> FCTL_AltnFlaps_Sw_ARM = new Offset<byte>("pmdg", 0x6445);
        public static Offset<byte> FCTL_AltnFlaps_Control_Sw = new Offset<byte>("pmdg", 0x6446);
        public static Offset<byte> FCTL_annunFC_LOW_PRESSURE = new Offset<byte>("pmdg", 0x6447);
        public static Offset<byte> FCTL_annunYAW_DAMPER = new Offset<byte>("pmdg", 0x6449);
        public static Offset<byte> FCTL_annunLOW_QUANTITY = new Offset<byte>("pmdg", 0x644A);
        public static Offset<byte> FCTL_annunLOW_PRESSURE = new Offset<byte>("pmdg", 0x644B);
        public static Offset<byte> FCTL_annunLOW_STBY_RUD_ON = new Offset<byte>("pmdg", 0x644C);
        public static Offset<byte> FCTL_annunFEEL_DIFF_PRESS = new Offset<byte>("pmdg", 0x644D);
        public static Offset<byte> FCTL_annunSPEED_TRIM_FAIL = new Offset<byte>("pmdg", 0x644E);
        public static Offset<byte> FCTL_annunMACH_TRIM_FAIL = new Offset<byte>("pmdg", 0x644F);
        public static Offset<byte> FCTL_annunAUTO_SLAT_FAIL = new Offset<byte>("pmdg", 0x6450);
        // NAVIGATION/DISPLAYS
        public static Offset<byte> NAVDIS_VHFNavSelector = new Offset<byte>("pmdg", 0x6451);
        public static Offset<byte> NAVDIS_IRSSelector = new Offset<byte>("pmdg", 0x6452);
        public static Offset<byte> NAVDIS_FMCSelector = new Offset<byte>("pmdg", 0x6453);
        public static Offset<byte> NAVDIS_SourceSelector = new Offset<byte>("pmdg", 0x6454);
        public static Offset<byte> NAVDIS_ControlPaneSelector = new Offset<byte>("pmdg", 0x6455);
        // FUEL
        public static Offset<byte> FUEL_CrossFeedSw = new Offset<byte>("pmdg", 0x645C);
        public static Offset<byte> FUEL_PumpFwdSw = new Offset<byte>("pmdg", 0x645D);
        public static Offset<byte> FUEL_PumpAftSw = new Offset<byte>("pmdg", 0x645F);
        public static Offset<byte> FUEL_PumpCtrSw = new Offset<byte>("pmdg", 0x6461);
        public static Offset<byte> FUEL_annunENG_VALVE_CLOSED = new Offset<byte>("pmdg", 0x6463);
        public static Offset<byte> FUEL_annunSPAR_VALVE_CLOSED = new Offset<byte>("pmdg", 0x6465);
        public static Offset<byte> FUEL_annunFILTER_BYPASS = new Offset<byte>("pmdg", 0x6467);
        public static Offset<byte> FUEL_annunXFEED_VALVE_OPEN = new Offset<byte>("pmdg", 0x6469);
        public static Offset<byte> FUEL_annunLOWPRESS_Fwd = new Offset<byte>("pmdg", 0x646A);
        public static Offset<byte> FUEL_annunLOWPRESS_Aft = new Offset<byte>("pmdg", 0x646C);
        public static Offset<byte> FUEL_annunLOWPRESS_Ctr = new Offset<byte>("pmdg", 0x646E);
        // ELECTRICAL
        public static Offset<byte> ELEC_annunBAT_DISCHARGE = new Offset<byte>("pmdg", 0x6470);
        public static Offset<byte> ELEC_annunTR_UNIT = new Offset<byte>("pmdg", 0x6471);
        public static Offset<byte> ELEC_annunELEC = new Offset<byte>("pmdg", 0x6472);
        public static Offset<byte> ELEC_DCMeterSelector = new Offset<byte>("pmdg", 0x6473);
        public static Offset<byte> ELEC_ACMeterSelector = new Offset<byte>("pmdg", 0x6474);
        public static Offset<byte> ELEC_BatSelector = new Offset<byte>("pmdg", 0x6475);
        public static Offset<byte> ELEC_CabUtilSw = new Offset<byte>("pmdg", 0x6476);
        public static Offset<byte> ELEC_IFEPassSeatSw = new Offset<byte>("pmdg", 0x6477);
        public static Offset<byte> ELEC_annunDRIVE = new Offset<byte>("pmdg", 0x6478);
        public static Offset<byte> ELEC_annunSTANDBY_POWER_OFF = new Offset<byte>("pmdg", 0x647A);
        public static Offset<byte> ELEC_IDGDisconnectSw = new Offset<byte>("pmdg", 0x647B);
        public static Offset<byte> ELEC_StandbyPowerSelector = new Offset<byte>("pmdg", 0x647D);
        public static Offset<byte> ELEC_annunGRD_POWER_AVAILABLE = new Offset<byte>("pmdg", 0x647E);
        public static Offset<byte> ELEC_GrdPwrSw = new Offset<byte>("pmdg", 0x647F);
        public static Offset<byte> ELEC_BusTransSw_AUTO = new Offset<byte>("pmdg", 0x6480);
        public static Offset<byte> ELEC_GenSw = new Offset<byte>("pmdg", 0x6481);
        public static Offset<byte> ELEC_APUGenSw = new Offset<byte>("pmdg", 0x6483);
        public static Offset<byte> ELEC_annunTRANSFER_BUS_OFF = new Offset<byte>("pmdg", 0x6485);
        public static Offset<byte> ELEC_annunSOURCE_OFF = new Offset<byte>("pmdg", 0x6487);
        public static Offset<byte> ELEC_annunGEN_BUS_OFF = new Offset<byte>("pmdg", 0x6489);
        public static Offset<byte> ELEC_annunAPU_GEN_OFF_BUS = new Offset<byte>("pmdg", 0x648B);
        // APU
        public static Offset<byte> APU_annunMAINT = new Offset<byte>("pmdg", 0x6490);
        public static Offset<byte> APU_annunLOW_OIL_PRESSURE = new Offset<byte>("pmdg", 0x6491);
        public static Offset<byte> APU_annunFAULT = new Offset<byte>("pmdg", 0x6492);
        public static Offset<byte> APU_annunOVERSPEED = new Offset<byte>("pmdg", 0x6493);
        // WIPERS
        public static Offset<byte> OH_WiperLSelector = new Offset<byte>("pmdg", 0x6494);
        public static Offset<byte> OH_WiperRSelector = new Offset<byte>("pmdg", 0x6495);
        // CENTRE OVERHEAD CONTROLS & INDICATORS
        public static Offset<byte> LTS_CircuitBreakerKnob = new Offset<byte>("pmdg", 0x6496);
        public static Offset<byte> LTS_OvereadPanelKnob = new Offset<byte>("pmdg", 0x6497);
        public static Offset<byte> AIR_EquipCoolingSupplyNORM = new Offset<byte>("pmdg", 0x6498);
        public static Offset<byte> AIR_EquipCoolingExhaustNORM = new Offset<byte>("pmdg", 0x6499);
        public static Offset<byte> AIR_annunEquipCoolingSupplyOFF = new Offset<byte>("pmdg", 0x649A);
        public static Offset<byte> AIR_annunEquipCoolingExhaustOFF = new Offset<byte>("pmdg", 0x649B);
        public static Offset<byte> LTS_annunEmerNOT_ARMED = new Offset<byte>("pmdg", 0x649C);
        public static Offset<byte> LTS_EmerExitSelector = new Offset<byte>("pmdg", 0x649D);
        public static Offset<byte> COMM_NoSmokingSelector = new Offset<byte>("pmdg", 0x649E);
        public static Offset<byte> COMM_FastenBeltsSelector = new Offset<byte>("pmdg", 0x649F);
        public static Offset<byte> COMM_annunCALL = new Offset<byte>("pmdg", 0x64A0);
        public static Offset<byte> COMM_annunPA_IN_USE = new Offset<byte>("pmdg", 0x64A1);
        // ANTI-ICE
        public static Offset<byte> ICE_annunCAPT_PITOT = new Offset<byte>("pmdg", 0x64AE);
        public static Offset<byte> ICE_annunL_ELEV_PITOT = new Offset<byte>("pmdg", 0x64AF);
        public static Offset<byte> ICE_annunL_ALPHA_VANE = new Offset<byte>("pmdg", 0x64B0);
        public static Offset<byte> ICE_annunL_TEMP_PROBE = new Offset<byte>("pmdg", 0x64B1);
        public static Offset<byte> ICE_annunFO_PITOT = new Offset<byte>("pmdg", 0x64B2);
        public static Offset<byte> ICE_annunR_ELEV_PITOT = new Offset<byte>("pmdg", 0x64B3);
        public static Offset<byte> ICE_annunR_ALPHA_VANE = new Offset<byte>("pmdg", 0x64B4);
        public static Offset<byte> ICE_annunAUX_PITOT = new Offset<byte>("pmdg", 0x64B5);
        public static Offset<byte> ICE_TestProbeHeatSw = new Offset<byte>("pmdg", 0x64B6);
        public static Offset<byte> ICE_annunVALVE_OPEN = new Offset<byte>("pmdg", 0x64B8);
        public static Offset<byte> ICE_annunCOWL_ANTI_ICE = new Offset<byte>("pmdg", 0x64BA);
        public static Offset<byte> ICE_annunCOWL_VALVE_OPEN = new Offset<byte>("pmdg", 0x64BC);
        public static Offset<byte> ICE_WingAntiIceSw = new Offset<byte>("pmdg", 0x64BE);
        public static Offset<byte> ICE_EngAntiIceSw = new Offset<byte>("pmdg", 0x64BF);
        // HYDRAULICS
        public static Offset<byte> HYD_annunLOW_PRESS_eng = new Offset<byte>("pmdg", 0x64C1);
        public static Offset<byte> HYD_annunLOW_PRESS_elec = new Offset<byte>("pmdg", 0x64C3);
        public static Offset<byte> HYD_annunOVERHEAT_elec = new Offset<byte>("pmdg", 0x64C5);
        public static Offset<byte> HYD_PumpSw_eng = new Offset<byte>("pmdg", 0x64C7);
        public static Offset<byte> HYD_PumpSw_elec = new Offset<byte>("pmdg", 0x64C9);
        // AIR SYSTEMS
        public static Offset<byte> AIR_TempSourceSelector = new Offset<byte>("pmdg", 0x64CB);
        public static Offset<byte> AIR_TrimAirSwitch = new Offset<byte>("pmdg", 0x64CC);
        public static Offset<byte> AIR_annunDualBleed = new Offset<byte>("pmdg", 0x64D0);
        public static Offset<byte> AIR_annunRamDoorL = new Offset<byte>("pmdg", 0x64D1);
        public static Offset<byte> AIR_annunRamDoorR = new Offset<byte>("pmdg", 0x64D2);
        public static Offset<byte> AIR_RecircFanSwitch = new Offset<byte>("pmdg", 0x64D3);
        public static Offset<byte> AIR_PackSwitch = new Offset<byte>("pmdg", 0x64D5);
        public static Offset<byte> AIR_BleedAirSwitch = new Offset<byte>("pmdg", 0x64D7);
        public static Offset<byte> AIR_APUBleedAirSwitch = new Offset<byte>("pmdg", 0x64D9);
        public static Offset<byte> AIR_IsolationValveSwitch = new Offset<byte>("pmdg", 0x64DA);
        public static Offset<byte> AIR_annunPackTripOff = new Offset<byte>("pmdg", 0x64DB);
        public static Offset<byte> AIR_annunWingBodyOverheat = new Offset<byte>("pmdg", 0x64DD);
        public static Offset<byte> AIR_annunBleedTripOff = new Offset<byte>("pmdg", 0x64DF);
        // BOTTOM OVERHEAD
        public static Offset<byte> LTS_LandingLtRetractableSw = new Offset<byte>("pmdg", 0x64F4);
        public static Offset<byte> LTS_LandingLtFixedSw = new Offset<byte>("pmdg", 0x64F6);
        public static Offset<byte> LTS_RunwayTurnoffSw = new Offset<byte>("pmdg", 0x64F8);
        public static Offset<byte> LTS_TaxiSw = new Offset<byte>("pmdg", 0x64FA);
        public static Offset<byte> APU_Selector = new Offset<byte>("pmdg", 0x64FB);
        public static Offset<byte> ENG_StartSelector = new Offset<byte>("pmdg", 0x64FC);
        public static Offset<byte> ENG_IgnitionSelector = new Offset<byte>("pmdg", 0x64FE);
        public static Offset<byte> LTS_LogoSw = new Offset<byte>("pmdg", 0x64FF);
        public static Offset<byte> LTS_PositionSw = new Offset<byte>("pmdg", 0x6500);
        public static Offset<byte> LTS_AntiCollisionSw = new Offset<byte>("pmdg", 0x6501);
        public static Offset<byte> LTS_WingSw = new Offset<byte>("pmdg", 0x6502);
        public static Offset<byte> LTS_WheelWellSw = new Offset<byte>("pmdg", 0x6503);
        // 
        // Glareshield
        // WARNINGS
        public static Offset<byte> WARN_annunFIRE_WARN = new Offset<byte>("pmdg", 0x6504);
        public static Offset<byte> WARN_annunMASTER_CAUTION = new Offset<byte>("pmdg", 0x6506);
        public static Offset<byte> WARN_annunFLT_CONT = new Offset<byte>("pmdg", 0x6508);
        public static Offset<byte> WARN_annunIRS = new Offset<byte>("pmdg", 0x6509);
        public static Offset<byte> WARN_annunFUEL = new Offset<byte>("pmdg", 0x650A);
        public static Offset<byte> WARN_annunELEC = new Offset<byte>("pmdg", 0x650B);
        public static Offset<byte> WARN_annunAPU = new Offset<byte>("pmdg", 0x650C);
        public static Offset<byte> WARN_annunOVHT_DET = new Offset<byte>("pmdg", 0x650D);
        public static Offset<byte> WARN_annunANTI_ICE = new Offset<byte>("pmdg", 0x650E);
        public static Offset<byte> WARN_annunHYD = new Offset<byte>("pmdg", 0x650F);
        public static Offset<byte> WARN_annunDOORS = new Offset<byte>("pmdg", 0x6510);
        public static Offset<byte> WARN_annunENG = new Offset<byte>("pmdg", 0x6511);
        public static Offset<byte> WARN_annunOVERHEAD = new Offset<byte>("pmdg", 0x6512);
        public static Offset<byte> WARN_annunAIR_COND = new Offset<byte>("pmdg", 0x6513);
        // EFIS CONTROL PANELS
        public static Offset<byte> EFIS_MinsSelBARO = new Offset<byte>("pmdg", 0x6514);
        public static Offset<byte> EFIS_BaroSelHPA = new Offset<byte>("pmdg", 0x6516);
        public static Offset<byte> EFIS_VORADFSel1 = new Offset<byte>("pmdg", 0x6518);
        public static Offset<byte> EFIS_VORADFSel2 = new Offset<byte>("pmdg", 0x651A);
        public static Offset<byte> EFIS_ModeSel = new Offset<byte>("pmdg", 0x651C);
        public static Offset<byte> EFIS_RangeSel = new Offset<byte>("pmdg", 0x651E);
        // MODE CONTROL PANEL
        public static Offset<ushort> MCP_CourseL = new Offset<ushort>(0x6520);
        public static Offset<ushort> MCP_CourseR = new Offset<ushort>(0x6522);
        public static Offset<byte> MCP_IASBlank = new Offset<byte>("pmdg", 0x6528);
        public static Offset<float> MCP_IASMach = new Offset<float>(0x6524);
        public static Offset<byte> MCP_IASOverspeedFlash = new Offset<byte>("pmdg", 0x6529);
        public static Offset<byte> MCP_IASUnderspeedFlash = new Offset<byte>("pmdg", 0x652A);
        public static Offset<short> MCP_Heading = new Offset<short>("pmdg", 0x652C);
        public static Offset<short> MCP_Altitude = new Offset<short>("pmdg", 0x652E);
        public static Offset<short> MCP_VertSpeed = new Offset<short>("pmdg", 0x6530);
        public static Offset<byte> MCP_VertSpeedBlank = new Offset<byte>("pmdg", 0x6532);
        public static Offset<byte> MCP_FDSwL = new Offset<byte>("pmdg", 0x6533);
        public static Offset<byte> MCP_FDSwR = new Offset<byte>("pmdg", 0x6534);
        public static Offset<byte> MCP_ATArmSw = new Offset<byte>("pmdg", 0x6535);
        public static Offset<byte> MCP_BankLimitSel = new Offset<byte>("pmdg", 0x6536);
        public static Offset<byte> MCP_DisengageBar = new Offset<byte>("pmdg", 0x6537);
        public static Offset<byte> MCP_annunFDL = new Offset<byte>("pmdg", 0x6538);
        public static Offset<byte> MCP_annunFDR = new Offset<byte>("pmdg", 0x6539);
        public static Offset<byte> MCP_annunATArm = new Offset<byte>("pmdg", 0x653A);
        public static Offset<byte> MCP_annunN1 = new Offset<byte>("pmdg", 0x653B);
        public static Offset<byte> MCP_annunSPEED = new Offset<byte>("pmdg", 0x653C);
        public static Offset<byte> MCP_annunVNAV = new Offset<byte>("pmdg", 0x653D);
        public static Offset<byte> MCP_annunLVL_CHG = new Offset<byte>("pmdg", 0x653E);
        public static Offset<byte> MCP_annunHDG_SEL = new Offset<byte>("pmdg", 0x653F);
        public static Offset<byte> MCP_annunLNAV = new Offset<byte>("pmdg", 0x6540);
        public static Offset<byte> MCP_annunVOR_LOC = new Offset<byte>("pmdg", 0x6541);
        public static Offset<byte> MCP_annunAPP = new Offset<byte>("pmdg", 0x6542);
        public static Offset<byte> MCP_annunALT_HOLD = new Offset<byte>("pmdg", 0x6543);
        public static Offset<byte> MCP_annunVS = new Offset<byte>("pmdg", 0x6544);
        public static Offset<byte> MCP_annunCMD_A = new Offset<byte>("pmdg", 0x6545);
        public static Offset<byte> MCP_annunCWS_A = new Offset<byte>("pmdg", 0x6546);
        public static Offset<byte> MCP_annunCMD_B = new Offset<byte>("pmdg", 0x6547);
        public static Offset<byte> MCP_annunCWS_B = new Offset<byte>("pmdg", 0x6548);
        // Forward Panel
        public static Offset<byte> MAIN_NoseWheelSteeringSwNORM = new Offset<byte>("pmdg", 0x6549);
        public static Offset<byte> MAIN_annunBELOW_GS = new Offset<byte>("pmdg", 0x654A);
        public static Offset<byte> MAIN_MainPanelDUSel = new Offset<byte>("pmdg", 0x654C);
public static Offset<byte> MAIN_LowerDUSel = new Offset<byte>("pmdg", 0x654E);
public static Offset<byte> MAIN_annunAP = new Offset<byte>("pmdg", 0x6550);
        public static Offset<byte> MAIN_annunAT = new Offset<byte>("pmdg", 0x6552);
        public static Offset<byte> MAIN_annunFMC = new Offset<byte>("pmdg", 0x6554);
        public static Offset<byte> MAIN_DisengageTestSelector = new Offset<byte>("pmdg", 0x6556);
        public static Offset<byte> MAIN_annunSPEEDBRAKE_ARMED = new Offset<byte>("pmdg", 0x6558);
public static Offset<byte> MAIN_annunSPEEDBRAKE_EXTENDED = new Offset<byte>("pmdg", 0x655A);
        public static Offset<byte> MAIN_annunSTAB_OUT_OF_TRIM = new Offset<byte>("pmdg", 0x655B);
        public static Offset<byte> MAIN_LightsSelector = new Offset<byte>("pmdg", 0x655C);
        public static Offset<byte> MAIN_RMISelector1_VOR = new Offset<byte>("pmdg", 0x655D);
        public static Offset<byte> MAIN_RMISelector2_VOR = new Offset<byte>("pmdg", 0x655E);
        public static Offset<byte> MAIN_N1SetSelector = new Offset<byte>("pmdg", 0x655F);
        public static Offset<byte> MAIN_SpdRefSelector = new Offset<byte>("pmdg", 0x6560);
        public static Offset<byte> HGS_annun_TO = new Offset<byte>("pmdg", 0x6582);
        public static Offset<byte> HGS_annun_TO_CTN = new Offset<byte>("pmdg", 0x6583);
        public static Offset<byte> HGS_annun_APCH = new Offset<byte>("pmdg", 0x6584);
        public static Offset<byte> HGS_annun_TO_WARN = new Offset<byte>("pmdg", 0x6585);
        public static Offset<byte> HGS_annun_Bar = new Offset<byte>("pmdg", 0x6586);
        public static Offset<byte> HGS_annun_FAIL = new Offset<byte>("pmdg", 0x6587);
        // Lower Forward Panel
        // 
        public static Offset<byte> LTS_MainPanelKnob = new Offset<byte>("pmdg", 0x6588);
        public static Offset<byte> LTS_BackgroundKnob = new Offset<byte>("pmdg", 0x658A);
        public static Offset<byte> LTS_AFDSFloodKnob = new Offset<byte>("pmdg", 0x658B);
        public static Offset<byte> LTS_OutbdDUBrtKnob = new Offset<byte>("pmdg", 0x658C);
public static Offset<byte> LTS_InbdDUBrtKnob = new Offset<byte>("pmdg", 0x658E);
        public static Offset<byte> LTS_InbdDUMapBrtKnob = new Offset<byte>("pmdg", 0x6590);
        public static Offset<byte> LTS_UpperDUBrtKnob = new Offset<byte>("pmdg", 0x6592);
        public static Offset<byte> LTS_LowerDUBrtKnob = new Offset<byte>("pmdg", 0x6593);
        public static Offset<byte> LTS_LowerDUMapBrtKnob = new Offset<byte>("pmdg", 0x6594);
        public static Offset<byte> GPWS_annunINOP = new Offset<byte>("pmdg", 0x6595);
        public static Offset<byte> GPWS_FlapInhibitSw_NORM = new Offset<byte>("pmdg", 0x6596);
        public static Offset<byte> GPWS_GearInhibitSw_NORM = new Offset<byte>("pmdg", 0x6597);
        public static Offset<byte> GPWS_TerrInhibitSw_NORM = new Offset<byte>("pmdg", 0x6598);
        // Control Stand
        // 
        public static Offset<byte> CDU_annunEXEC = new Offset<byte>("pmdg", 0x6599);
        public static Offset<byte> CDU_annunCALL = new Offset<byte>("pmdg", 0x659B);
        public static Offset<byte> CDU_annunFAIL = new Offset<byte>("pmdg", 0x659D);
        public static Offset<byte> CDU_annunMSG = new Offset<byte>("pmdg", 0x659F);
        public static Offset<byte> CDU_annunOFST = new Offset<byte>("pmdg", 0x65A1);
        public static Offset<byte> CDU_BrtKnob = new Offset<byte>("pmdg", 0x65A3);
        public static Offset<byte> TRIM_StabTrimMainElecSw_NORMAL = new Offset<byte>("pmdg", 0x65A5);
        public static Offset<byte> TRIM_StabTrimAutoPilotSw_NORMAL = new Offset<byte>("pmdg", 0x65A6);
        public static Offset<byte> PED_annunParkingBrake = new Offset<byte>("pmdg", 0x65A7);
        public static Offset<byte> FIRE_OvhtDetSw = new Offset<byte>("pmdg", 0x65A8);
        public static Offset<byte> FIRE_annunENG_OVERHEAT = new Offset<byte>("pmdg", 0x65AA);
        public static Offset<byte> FIRE_DetTestSw = new Offset<byte>("pmdg", 0x65AC);
        public static Offset<byte> FIRE_annunWHEEL_WELL = new Offset<byte>("pmdg", 0x65B3);
        public static Offset<byte> FIRE_annunFAULT = new Offset<byte>("pmdg", 0x65B4);
        public static Offset<byte> FIRE_annunAPU_DET_INOP = new Offset<byte>("pmdg", 0x65B5);
        public static Offset<byte> FIRE_annunAPU_BOTTLE_DISCHARGE = new Offset<byte>("pmdg", 0x65B6);
        public static Offset<byte> FIRE_annunBOTTLE_DISCHARGE = new Offset<byte>("pmdg", 0x65B7);
        public static Offset<byte> FIRE_ExtinguisherTestSw = new Offset<byte>("pmdg", 0x65B9);
        public static Offset<byte> CARGO_annunExtTest = new Offset<byte>("pmdg", 0x65BD);
        public static Offset<byte> CARGO_DetSelect = new Offset<byte>("pmdg", 0x65BF);
        public static Offset<byte> CARGO_ArmedSw = new Offset<byte>("pmdg", 0x65C1);
        public static Offset<byte> CARGO_annunFWD = new Offset<byte>("pmdg", 0x65C3);
        public static Offset<byte> CARGO_annunAFT = new Offset<byte>("pmdg", 0x65C4);
        public static Offset<byte> CARGO_annunDETECTOR_FAULT = new Offset<byte>("pmdg", 0x65C5);
        public static Offset<byte> CARGO_annunDISCH = new Offset<byte>("pmdg", 0x65C6);
        public static Offset<byte> HGS_annunRWY = new Offset<byte>("pmdg", 0x65C7);
        public static Offset<byte> HGS_annunGS = new Offset<byte>("pmdg", 0x65C8);
        public static Offset<byte> HGS_annunFAULT = new Offset<byte>("pmdg", 0x65C9);
        public static Offset<byte> HGS_annunCLR = new Offset<byte>("pmdg", 0x65CA);
        public static Offset<byte> XPDR_XpndrSelector_2 = new Offset<byte>("pmdg", 0x65CB);
        public static Offset<byte> XPDR_AltSourceSel_2 = new Offset<byte>("pmdg", 0x65CC);
        public static Offset<byte> XPDR_ModeSel = new Offset<byte>("pmdg", 0x65CD);
        public static Offset<byte> XPDR_annunFAIL = new Offset<byte>("pmdg", 0x65CE);
        public static Offset<byte> LTS_PedFloodKnob = new Offset<byte>("pmdg", 0x65CF);
        public static Offset<byte> LTS_PedPanelKnob = new Offset<byte>("pmdg", 0x65D0);
        public static Offset<byte> TRIM_StabTrimSw_NORMAL = new Offset<byte>("pmdg", 0x65D1);
        public static Offset<byte> PED_annunLOCK_FAIL = new Offset<byte>("pmdg", 0x65D2);
        public static Offset<byte> PED_annunAUTO_UNLK = new Offset<byte>("pmdg", 0x65D3);
        public static Offset<byte> PED_FltDkDoorSel = new Offset<byte>("pmdg", 0x65D4);
        // Additional variables: used by FS2Crew
        // 
        public static Offset<byte> ENG_StartValve = new Offset<byte>("pmdg", 0x65D5);
        public static Offset<byte> COMM_Attend_PressCount = new Offset<byte>("pmdg", 0x65E0);
        public static Offset<byte> COMM_GrdCall_PressCount = new Offset<byte>("pmdg", 0x65E1);
        public static Offset<byte> IRS_aligned = new Offset<byte>("pmdg", 0x65F4);
        public static Offset<byte> AircraftMode = new Offset<byte>("pmdg", 0x65F5);
        public static Offset<byte> WeightInKg = new Offset<byte>("pmdg", 0x65F6);
        public static Offset<byte> GPWS_V1CallEnabled = new Offset<byte>("pmdg", 0x65F7);
        public static Offset<byte> GroundConnAvailable = new Offset<byte>("pmdg", 0x65F8);
        public static Offset<byte> FMC_TakeoffFlaps = new Offset<byte>("pmdg", 0x65F9);
        public static Offset<byte> FMC_V1 = new Offset<byte>("pmdg", 0x65FA);
        public static Offset<byte> FMC_VR = new Offset<byte>("pmdg", 0x65FB);
        public static Offset<byte> FMC_V2 = new Offset<byte>("pmdg", 0x65FC);
        public static Offset<byte> FMC_LandingFlaps = new Offset<byte>("pmdg", 0x65FD);
        public static Offset<byte> FMC_LandingVREF = new Offset<byte>("pmdg", 0x65FE);
        public static Offset<byte> FMC_CruiseAlt = new Offset<byte>("pmdg", 0x6600);
        public static Offset<byte> FMC_LandingAltitude = new Offset<byte>("pmdg", 0x6602);
        public static Offset<byte> FMC_TransitionAlt = new Offset<byte>("pmdg", 0x6604);
        public static Offset<byte> FMC_TransitionLevel = new Offset<byte>("pmdg", 0x6606);
        public static Offset<byte> FMC_PerfInputComplete = new Offset<byte>("pmdg", 0x6608);
        // Additional variables: added by update SP1D March 2015
        public static Offset<byte> MAIN_annunAP_Amber = new Offset<byte>("pmdg", 0x6C0C);
        public static Offset<byte> MAIN_annunAT_Amber = new Offset<byte>("pmdg", 0x6C0E);
        public static Offset<byte> DOOR_annunFWD_ENTRY = new Offset<byte>("pmdg", 0x6C14);
        public static Offset<byte> DOOR_annunFWD_SERVICE = new Offset<byte>("pmdg", 0x6C15);
        public static Offset<byte> DOOR_annunAIRSTAIR = new Offset<byte>("pmdg", 0x6C16);
        public static Offset<byte> DOOR_annunLEFT_FWD_OVERWING = new Offset<byte>("pmdg", 0x6C17);
        public static Offset<byte> DOOR_annunRIGHT_FWD_OVERWING = new Offset<byte>("pmdg", 0x6C18);
        public static Offset<byte> DOOR_annunFWD_CARGO = new Offset<byte>("pmdg", 0x6C19);
        public static Offset<byte> DOOR_annunEQUIP = new Offset<byte>("pmdg", 0x6C1A);
        public static Offset<byte> DOOR_annunLEFT_AFT_OVERWING = new Offset<byte>("pmdg", 0x6C1B);
        public static Offset<byte> DOOR_annunRIGHT_AFT_OVERWING = new Offset<byte>("pmdg", 0x6C1C);
        public static Offset<byte> DOOR_annunAFT_CARGO = new Offset<byte>("pmdg", 0x6C1D);
        public static Offset<byte> DOOR_annunAFT_ENTRY = new Offset<byte>("pmdg", 0x6C1E);
        public static Offset<byte> DOOR_annunAFT_SERVICE = new Offset<byte>("pmdg", 0x6C1F);
        public static Offset<byte> AIR_annunAUTO_FAIL = new Offset<byte>("pmdg", 0x6C20);
        public static Offset<byte> AIR_annunOFFSCHED_DESCENT = new Offset<byte>("pmdg", 0x6C21);
        public static Offset<byte> AIR_annunALTN = new Offset<byte>("pmdg", 0x6C22);
        public static Offset<byte> AIR_annunMANUAL = new Offset<byte>("pmdg", 0x6C23);
        public static Offset<byte> IRS_DisplayShowsDots = new Offset<byte>("pmdg", 0x6C69);
        // Additional Offsets for NGXu only
        public static Offset<byte> AFS_AutothrottleServosConnected = new Offset<byte>("pmdg", 0x6C6E);
        public static Offset<byte> AFS_ControlsPitch = new Offset<byte>("pmdg", 0x6C6F);
        public static Offset<byte> AFS_ControlsRoll = new Offset<byte>("pmdg", 0x6C70);
        public static Offset<byte> MCP_indication_powered = new Offset<byte>("pmdg", 0x6C81);
        public static Offset<byte> MAIN_annunCABIN_ALTITUDE = new Offset<byte>("pmdg", 0x6C8E);
        public static Offset<byte> MAIN_annunTAKEOFF_CONFIG = new Offset<byte>("pmdg", 0x6C8F);
        public static Offset<byte> CVR_annunTEST = new Offset<byte>("pmdg", 0x6C90);
        public static Offset<byte> FUEL_AuxFwd = new Offset<byte>("pmdg", 0x6C91);
        public static Offset<byte> FUEL_AuxAft = new Offset<byte>("pmdg", 0x6C93);
        public static Offset<byte> FUEL_FWDBleed = new Offset<byte>("pmdg", 0x6C95);
        public static Offset<byte> FUEL_AFTBleed = new Offset<byte>("pmdg", 0x6C96);
        public static Offset<byte> FUEL_GNDXfr = new Offset<byte>("pmdg", 0x6C97);
        public static Offset<string> ELEC_MeterDisplayTop = new Offset<string>("pmdg", 0x6c40, 13);
        public static Offset<string> ELEC_MeterDisplayBottom = new Offset<string>("pmdg", 0x6c4d, 13);

        // constants for PMDG mouse click parameters
        public const int ClkL = 536870912;
        public const int ClkR = -2147483648;
        public const int Inc = 16384;
        public const int Dec = 8192;

        public static void InitOffsets()
        {
            // forces static fields to be initialised.
        }
        public static double ConvertRadiansToDegrees(double radians)
        {
            double degrees = (180 / Math.PI) * radians;
            return (degrees);
        }
        
    }
}
