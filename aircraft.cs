using FSUIPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm
{
    public static class Aircraft
    {
        // =====================================
        // DECLARE OFFSETS YOU WANT TO USE HERE
        // =====================================
        public static  Offset<ushort> Com1Freq = new Offset<ushort>(0x034e);
        public static  Offset<ushort> Com2Freq = new Offset<ushort>(0x3118);
        public static  Offset<byte> RadioActive = new Offset<byte>(0x3122);
        public static  Offset<FsLatitude> aircraftLat = new Offset<FsLatitude>(0x0560, 8);
        public static  Offset<FsLongitude> aircraftLon = new Offset<FsLongitude>(0x0568, 8);
        public static  Offset<short> Flaps = new Offset<short>(0x30f0);
        public static  Offset<short> OnGround = new Offset<short>(0x0366);
        public static  Offset<short> ParkingBrake = new Offset<short>(0x0bc8);
        public static  Offset<uint> Gear = new Offset<uint>(0x0be8);
        public static  Offset<int> Altitude = new Offset<int>(0x3324);
        public static  Offset<uint> GroundAltitude = new Offset<uint>(0x0020);
        public static  Offset<uint> SpoilersArm = new Offset<uint>(0x0bcc);
        public static  Offset<uint> Spoilers = new Offset<uint>(0x0bd0);
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
        public static  Offset<uint> DestETE = new Offset<uint>(0x6198);
        public static  Offset<uint> DestETA = new Offset<uint>(0x619c);
        public static  Offset<double> RouteDistance = new Offset<double>(0x61a0);
        public static  Offset<double> FuelBurn = new Offset<double>(0x61a8);
        public static  Offset<uint> FuelQuantity = new Offset<uint>(0x126c);
        public static  Offset<double> ElevatorTrim = new Offset<double>(0x2ea0);
        public static  Offset<double> AileronTrim = new Offset<double>(0x2eb0);
        public static  Offset<double> RudderTrim = new Offset<double>(0x2ec0);
        public static  Offset<short> VerticalSpeed = new Offset<short>(0x0842);
        public static  Offset<short> AirTemp = new Offset<short>(0x0e8c);
        public static  Offset<byte> Nav1GS = new Offset<byte>(0x0c4c);
        public static  Offset<byte> Nav1Flags = new Offset<byte>(0x0c4d);
        public static  Offset<uint> Nav1Signal = new Offset<uint>(0x0c52);
        public static  Offset<ushort> Altimeter = new Offset<ushort>(0x0330);
        public static  Offset<byte> Doors = new Offset<byte>(0x3367);
        public static  Offset<byte> APUGenerator = new Offset<byte>(0x0b51);
        public static  Offset<byte> APUGeneratorActive = new Offset<byte>(0x0b52);
        public static  Offset<float> APUPercentage = new Offset<float>(0x0b54);
        public static  Offset<float> APUVoltage = new Offset<float>(0x0b5c);
        public static  Offset<double> Eng1RPM = new Offset<double>(0x2400);
        public static  Offset<uint> Eng1Starter = new Offset<uint>(0x3b00);
        public static  Offset<uint> Eng2Starter = new Offset<uint>(0x3a40);
        public static  Offset<uint> Eng3Starter = new Offset<uint>(0x3980);
        public static  Offset<uint> Eng4Starter = new Offset<uint>(0x38c0);
        public static  Offset<double> Eng1FuelFlow = new Offset<double>(0x2060);
        public static  Offset<double> Eng2FuelFlow = new Offset<double>(0x2160);
        public static  Offset<double> Eng3FuelFlow = new Offset<double>(0x2260);
        public static  Offset<double> Eng4FuelFlow = new Offset<double>(0x2360);
        public static  Offset<double> Eng1N1 = new Offset<double>(0x2010);
        public static  Offset<uint> Eng4Generator = new Offset<uint>(0x393c);
        public static  Offset<uint> Eng3Generator = new Offset<uint>(0x39fc);
        public static  Offset<uint> Eng2Generator = new Offset<uint>(0x3abc);
        public static  Offset<uint> Eng1Generator = new Offset<uint>(0x3b7c);
        public static  Offset<double> Eng1N2 = new Offset<double>(0x2018);
        public static  Offset<double> Eng2N1 = new Offset<double>(0x2110);
        public static  Offset<double> Eng2N2 = new Offset<double>(0x2118);
        public static  Offset<double> Eng3N1 = new Offset<double>(0x2210);
        public static  Offset<double> Eng3N2 = new Offset<double>(0x2218);
        public static  Offset<double> Eng4N1 = new Offset<double>(0x2310);
        public static  Offset<double> Eng4N2 = new Offset<double>(0x2318);
        public static  Offset<ushort> Eng1Combustion = new Offset<ushort>(0x0894);
        public static  Offset<ushort> Eng2Combustion = new Offset<ushort>(0x092c);
        public static  Offset<ushort> Eng3Combustion = new Offset<ushort>(0x09c4);
        public static  Offset<ushort> Eng4Combustion = new Offset<ushort>(0x0a5c);
        public static  Offset<uint> Eng1ITT = new Offset<uint>(0x08f0);
        public static  Offset<uint> Eng2ITT = new Offset<uint>(0x0988);
        public static  Offset<uint> Eng3ITT = new Offset<uint>(0x0a20);
        public static  Offset<uint> Eng4ITT = new Offset<uint>(0x0ab8);
        public static  Offset<uint> Eng1FuelValve = new Offset<uint>(0x3590);
        public static  Offset<uint> Eng2FuelValve = new Offset<uint>(0x3594);
        public static  Offset<uint> Eng3FuelValve = new Offset<uint>(0x3598);
        public static  Offset<uint> Eng4FuelValve = new Offset<uint>(0x359c);
        public static  Offset<byte> PitotHeat = new Offset<byte>(0x029c);
        // public static  Offset<BitArray> Lights = new Offset<BitArray>(0x0d0c);
        public static  Offset<ushort> WindSpeed = new Offset<ushort>(0x0e90);
        public static  Offset<ushort> WindDirection = new Offset<ushort>(0x0e92);
        public static  Offset<ushort> WindGust = new Offset<ushort>(0x0e94);
        public static  Offset<uint> RadioAltimeter = new Offset<uint>(0x31e4);
        public static  Offset<byte> FuelPump = new Offset<byte>(0x3104);
        public static  Offset<uint> lvl_center = new Offset<uint>(0x0b74);
        public static  Offset<uint> cap_center = new Offset<uint>(0x0b78);
        public static  Offset<uint> lvl_center2 = new Offset<uint>(0x1244);
        public static  Offset<uint> cap_center2 = new Offset<uint>(0x1248);
        public static  Offset<uint> lvl_center3 = new Offset<uint>(0x124c);
        public static  Offset<uint> cap_center3 = new Offset<uint>(0x1250);
        public static  Offset<uint> lvl_main_left = new Offset<uint>(0x0b7c);
        public static  Offset<uint> cap_main_left = new Offset<uint>(0x0b80);
        public static  Offset<uint> lvl_aux_left = new Offset<uint>(0x0b84);
        public static  Offset<uint> cap_aux_left = new Offset<uint>(0x0b88);
        public static  Offset<uint> lvl_tip_left = new Offset<uint>(0x0b8c);
        public static  Offset<uint> cap_tip_left = new Offset<uint>(0x0b90);
        public static  Offset<uint> lvl_main_right = new Offset<uint>(0x0b94);
        public static  Offset<uint> cap_main_right = new Offset<uint>(0x0b98);
        public static  Offset<uint> lvl_aux_right = new Offset<uint>(0x0b9c);
        public static  Offset<uint> cap_aux_right = new Offset<uint>(0x0ba0);
        public static  Offset<uint> lvl_tip_right = new Offset<uint>(0x0ba4);
        public static  Offset<uint> cap_tip_right = new Offset<uint>(0x0ba8);
        public static  Offset<ushort> fuel_weight = new Offset<ushort>(0x0af4);
        public static  Offset<ushort> num_engines = new Offset<ushort>(0x0aec);
        public static  Offset<double> eng1_fuel_flow = new Offset<double>(0x0918);
        public static  Offset<double> eng2_fuel_flow = new Offset<double>(0x09b0);
        public static  Offset<double> eng3_fuel_flow = new Offset<double>(0x0a48);
        public static  Offset<double> eng4_fuel_flow = new Offset<double>(0x0ae0);
        // public static  Offset<BitArray> EngineSelectFlags = new Offset<BitArray>(0x0888);
        public static  Offset<double> GyroSuction = new Offset<double>(0x0b18);
        public static  Offset<byte> OilQuantity = new Offset<byte>(0x66c9);
        public static  Offset<string> AircraftName = new Offset<string>(0x3d00, 255);
        public static  TextMenu textMenu = new TextMenu();
        
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
