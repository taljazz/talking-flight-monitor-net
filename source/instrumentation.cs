using DavyKager;
using FSUIPC;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using NHotkey;
using NHotkey.WindowsForms;
using NLog;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Configuration;
using NGeoNames;
using NGeoNames.Entities;
using System.Diagnostics;

namespace tfm
{
    public class Instrumentation
    {
        // this class handles automatic reading of instrumentation, as well as reading in response to hotkeys
        // timers
        private static System.Timers.Timer RunwayGuidanceTimer;
        private double HdgRight;
        private double HdgLeft;

        // Audio objects
        IWavePlayer driverOut;
        SignalGenerator wg;
        PanningSampleProvider pan;
        OffsetSampleProvider pulse;
        MixingSampleProvider mixer;

        // initialize command mode sound
        CachedSound cmdSound = new CachedSound(@"sounds\command.wav");
// list to store registered hotkey identifiers
        List<string> hotkeys = new List<string>();
        FsFuelTanksCollection FuelTanks = null;
        // list to store fuel tanks present on the aircraft
        List<FsFuelTank> ActiveTanks = new List<FsFuelTank>();

        static bool FirstRun = true;
        // flags for tfm features   
        bool FlightFollowingEnabled;
        bool InstrumentationEnabled;
        bool SimConnectMessagesEnabled;
        bool CalloutsEnabled;
        bool ILSEnabled;
        bool GroundspeedEnabled;
        bool TrimEnabled = true;
        private bool FlapsMoving;
        private bool MuteSimconnect;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public bool muteSimconnect { get; private set; }
        public bool flightFollowingOnline { get; private set; }
        public bool RunwayGuidanceEnabled { get; private set; }
        public bool LocaliserDetected { get; private set; }
        public bool ReadILSEnabled { get; private set; }
        public bool ReadAutopilot { get; private set; }

        public double CurrentHeading;   

        public ReverseGeoCode<ExtendedGeoName> r = new ReverseGeoCode<ExtendedGeoName>(GeoFileReader.ReadExtendedGeoNames(@".\data\cities1000.txt"));
        private int OldSpoilersValue;
        private double RunwayGuidanceTrackedHeading;

        public Instrumentation()
        {
            // set up logging
            var LoggingConfig = new NLog.Config.LoggingConfiguration();
            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "tfm.log" };
            // Rules for mapping loggers to targets            
            LoggingConfig.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
            // Apply config           
            NLog.LogManager.Configuration = LoggingConfig;
            
            Logger.Debug("initializing screen reader driver");
            Tolk.Load();
            Tolk.DetectScreenReader();
            Tolk.Output("TFM dot net started!");
            HotkeyManager.Current.AddOrReplace("command", (Keys)Properties.Hotkeys.Default.command, commandMode);
            RunwayGuidanceEnabled = false;

        }

        public void ReadAircraftState()
        {
            // If this is the first time through the loop, don't read instruments.

            if (!FirstRun || InstrumentationEnabled)
            {
                // Read when aircraft changes
                if (Aircraft.AircraftName.ValueChanged)
                {
                    Tolk.Output("Current aircraft: " + Aircraft.AircraftName.Value);
                    DetectFuelTanks();
                }

                // read any instruments that are toggles
                ReadToggle(Aircraft.AvionicsMaster, Aircraft.AvionicsMaster.Value > 0, "avionics master", "active", "off");
                ReadToggle(Aircraft.PitotHeat, Aircraft.PitotHeat.Value > 0, "Pitot Heat", "on", "off");
                ReadToggle(Aircraft.ParkingBrake, Aircraft.ParkingBrake.Value > 0, "Parking brake", "on", "off");
                ReadToggle(Aircraft.AutoFeather, Aircraft.AutoFeather.Value > 0, "Auto Feather", "Active", "off");
                ReadToggle(Aircraft.ApMaster, Aircraft.ApMaster.Value > 0, "Auto pilot master", "active", "off");
                ReadToggle(Aircraft.AutoThrottleArm, Aircraft.AutoThrottleArm.Value > 0, "Auto Throttle", "Armed", "off");
                ReadToggle(Aircraft.ApYawDamper, Aircraft.ApYawDamper.Value > 0, "Yaw Damper", "active", "off");
                ReadToggle(Aircraft.Toga, Aircraft.Toga.Value > 0, "take off power", "active", "off");
                ReadToggle(Aircraft.ApAltitudeLock, Aircraft.ApAltitudeLock.Value > 0, "altitude lock", "active", "off");
                ReadToggle(Aircraft.ApHeadingLock, Aircraft.ApHeadingLock.Value > 0, "Heading lock", "active", "off");
                ReadToggle(Aircraft.ApNavLock, Aircraft.ApNavLock.Value > 0, "nav lock", "active", "off");
                ReadToggle(Aircraft.ApFlightDirector, Aircraft.ApFlightDirector.Value > 0, "Flight Director", "Active", "off");
                ReadToggle(Aircraft.ApNavGPS, Aircraft.ApNavGPS.Value > 0, "Nav gps switch", "set to GPS", "set to nav");
                ReadToggle(Aircraft.ApWingLeveler, Aircraft.ApWingLeveler.Value > 0, "Wing leveler", "active", "off");
                ReadToggle(Aircraft.ApAutoRudder, Aircraft.ApAutoRudder.Value > 0, "Auto rudder", "active", "off");
                ReadToggle(Aircraft.ApApproachHold, Aircraft.ApApproachHold.Value > 0, "approach mode", "active", "off");
                ReadToggle(Aircraft.ApSpeedHold, Aircraft.ApSpeedHold.Value > 0, "Airspeed hold", "active", "off");
                ReadToggle(Aircraft.ApMachHold, Aircraft.ApMachHold.Value > 0, "Mach hold", "Active", "off");
                ReadToggle(Aircraft.PropSync, Aircraft.PropSync.Value > 0, "Propeller Sync", "active", "off");
                ReadToggle(Aircraft.BatteryMaster, Aircraft.BatteryMaster.Value > 0, "Battery Master", "active", "off");
                // TODO: add check for a2a since below toggles aren't needed for a2a
                ReadToggle(Aircraft.Eng1Starter, Aircraft.Eng1Starter.Value > 0, "Number 1 starter", "engaged", "off");
                ReadToggle(Aircraft.Eng2Starter, Aircraft.Eng2Starter.Value > 0, "Number 2 starter", "engaged", "off");
                ReadToggle(Aircraft.Eng3Starter, Aircraft.Eng3Starter.Value > 0, "Number 3 starter", "engaged", "off");
                ReadToggle(Aircraft.Eng4Starter, Aircraft.Eng4Starter.Value > 0, "Number 4 starter", "engaged", "off");
                ReadToggle(Aircraft.Eng1Combustion, Aircraft.Eng1Combustion.Value > 0, "Number 1 ignition", "on", "off");
                ReadToggle(Aircraft.Eng2Combustion, Aircraft.Eng2Combustion.Value > 0, "Number 2 ignition", "on", "off");
                ReadToggle(Aircraft.Eng3Combustion, Aircraft.Eng3Combustion.Value > 0, "Number 3 ignition", "on", "off");
                ReadToggle(Aircraft.Eng4Combustion, Aircraft.Eng4Combustion.Value > 0, "Number 4 ignition", "on", "off");
                ReadToggle(Aircraft.Eng1Generator, Aircraft.Eng1Generator.Value > 0, "Number 1 generator", "active", "off");
                ReadToggle(Aircraft.Eng2Generator, Aircraft.Eng2Generator.Value > 0, "Number 2 generator", "active", "off");
                ReadToggle(Aircraft.Eng3Generator, Aircraft.Eng3Generator.Value > 0, "Number 3 generator", "active", "off");
                ReadToggle(Aircraft.Eng4Generator, Aircraft.Eng4Generator.Value > 0, "Number 4 generator", "active", "off");
                ReadToggle(Aircraft.APUGenerator, Aircraft.APUGenerator.Value > 0, "A P U Generator", "active", "off");
                ReadToggle(Aircraft.Eng1FuelValve, Aircraft.Eng1FuelValve.Value > 0, "number 1 fuel valve", "open", "closed");
                ReadToggle(Aircraft.Eng2FuelValve, Aircraft.Eng2FuelValve.Value > 0, "number 2 fuel valve", "open", "closed");
                ReadToggle(Aircraft.Eng3FuelValve, Aircraft.Eng3FuelValve.Value > 0, "number 3 fuel valve", "open", "closed");
                ReadToggle(Aircraft.Eng4FuelValve, Aircraft.Eng4FuelValve.Value > 0, "number 4 fuel valve", "open", "closed");
                ReadToggle(Aircraft.FuelPump, Aircraft.FuelPump.Value > 0, "Fuel pump", "active", "off");
                ReadFlaps();
                if (ReadAutopilot) ReadAutopilotInstruments();
                ReadSimConnectMessages();
                ReadTransponder();
                ReadComRadios();
                ReadAutoBrake();
                ReadSpoilers();
                ReadTrim();
                ReadAltimeter();
                ReadNextWaypoint();
                ReadLights();
                ReadDoors();
                ReadILSInfo();
                // TODO: engine select
            }
            else
            {
                Tolk.Output("current aircraft: " + Aircraft.AircraftName.Value);
                DetectFuelTanks();
                FirstRun = false;
            }
        }

        
        private void DetectFuelTanks()
        {
            // grab fuel tank data from the sim
            FSUIPCConnection.PayloadServices.RefreshData();
            // Assign the fuel tanks to our class level variable for easier access
            FuelTanks = FSUIPCConnection.PayloadServices.FuelTanks;
            foreach (FsFuelTank tank in FuelTanks)
            {
                if (tank.IsPresent)
                {
                    ActiveTanks.Add(tank);
                    Logger.Debug("found " + tank.Tank.ToString());
                }
            }

        }
        private void ReadTrim()
        {
            // Elevator trim
            double elevator = (double)Aircraft.ConvertRadiansToDegrees(Aircraft.ElevatorTrim.Value);
            double aileron = (double)Aircraft.ConvertRadiansToDegrees(Aircraft.AileronTrim.Value);
            if (Aircraft.ElevatorTrim.ValueChanged && Aircraft.ApMaster.Value != 1 && TrimEnabled)
            {
                if (elevator < 0)
                {
                    Tolk.Output($"Trim down {Math.Abs(Math.Round(elevator, 2)):F2}. ");
                }
                else
                {
                    Tolk.Output($"Trim up: {Math.Round(elevator, 2):F2}");
                }

            }
            if (Aircraft.AileronTrim.ValueChanged && Aircraft.ApMaster.Value != 1 && TrimEnabled)
            {
                if (aileron < 0)
                {
                    Tolk.Output($"Trim left {Math.Abs(Math.Round(aileron, 2))}. ");
                }
                else
                {
                    Tolk.Output($"Trim right {Math.Round(aileron, 2)}");
                }
            }
        }

        private void ReadAltimeter()
        {
            if (Aircraft.Altimeter.ValueChanged)
            {
                double AltQNH = (double)Aircraft.Altimeter.Value / 16d;
                double AltHPA = Math.Floor(AltQNH + 0.5);
                double AltInches = Math.Floor(((100 * AltQNH * 29.92) / 1013.2) + 0.5);
                Tolk.Output($"Altimeter: {AltHPA}, {AltInches / 100} inches. ");
            }


        }



        private void ReadAutoBrake()
        {
            string AbState = null;
            if (Aircraft.AutoBrake.ValueChanged)
            {
                 switch (Aircraft.AutoBrake.Value)
                {
                    case 0:
                        AbState = "R T O";
                        break;
                    case 1:
                        AbState = "off";
                        break;
                    case 2:
                        AbState = "position 1";
                        break;
                    case 3:
                        AbState = "position 2";
                        break;
                    case 4:
                        AbState = "position 3";
                        break;
                    case 5:
                        AbState = "maximum";
                        break;

                }
                Tolk.Output("Autobrake " + AbState);
            }
        }

        private void ReadComRadios()
        {
            if (Aircraft.Com1Freq.ValueChanged)
            {
                FsFrequencyCOM com1Helper = new FsFrequencyCOM(Aircraft.Com1Freq.Value);
                Tolk.Output("Com1: " + com1Helper.ToString());
            }
            if (Aircraft.Com2Freq.ValueChanged)
            {
                FsFrequencyCOM com2Helper = new FsFrequencyCOM(Aircraft.Com2Freq.Value);
                Tolk.Output("Com1: " + com2Helper.ToString());
            }

        }

        private void ReadTransponder()
        {
            if (Aircraft.Transponder.ValueChanged)
            {
                FsTransponderCode txHelper = new FsTransponderCode(Aircraft.Transponder.Value);
                Tolk.Output("squawk " + txHelper.ToString());
            }

        }
        private void ReadNextWaypoint(bool TriggeredByHotkey = false)
        {
            if (Aircraft.NextWPName.ValueChanged || TriggeredByHotkey)
            {
                string name = Aircraft.NextWPName.Value;
                // convert distance to nautical miles
                double dist = Aircraft.NextWPDistance.Value * 0.00053995D;
                string strDist = dist.ToString("F0");
                TimeSpan TimeEnroute = TimeSpan.FromSeconds(Aircraft.NextWPETE.Value);
                double baring = Aircraft.ConvertRadiansToDegrees((double)Aircraft.NextWPBaring.Value);
                string strBaring = baring.ToString("F0");
                Tolk.Output($"Next waypoint: {name}. ");
                Tolk.Output($"Distance: {strDist} nautical miles.");
                Tolk.Output($"Baring: {strBaring} degrees");
                string strTime = string.Format("{0:D2} hours, {1:D2} minutes, {2:D2} seconds.",
                TimeEnroute.Hours,
                TimeEnroute.Minutes,
                TimeEnroute.Seconds);
                Tolk.Output(strTime);
            }
        }
        private void ReadLights()
        {
            // read when aircraft lights change
            if (Aircraft.Lights.ValueChanged)
            {
                // loop through each bit and announce which values have changed.
                FsBitArray lightBits = Aircraft.Lights.Value;
                for (int i = 0; i < lightBits.Changed.Length; i++)
                {
                    if (lightBits.Changed[i])
                    {
                        string name = Enum.GetName(typeof(Aircraft.light), i);
                        string state = (Aircraft.Lights.Value[i]) ? "off" : "on";
                        Tolk.Output($"{name} {state}. ");
                    }
                }
            }

        }
        private void ReadDoors()
        {
            // read aircraft exit status
            if (Aircraft.Doors.ValueChanged)
            {
                // loop through each bit and announce which values have changed.
                FsBitArray DoorBits = Aircraft.Doors.Value;
                for (int i = 0; i < DoorBits.Changed.Length; i++)
                {
                    if (DoorBits.Changed[i])
                    {
                        string state = (Aircraft.Doors.Value[i]) ? "closed" : "open";
                        Tolk.Output($"door {i+1} {state}. ");
                    }
                }
            }

        }
        private void ReadILSInfo()
        {
            if (ReadILSEnabled)
            {
                if (Aircraft.Nav1Signal.Value == 256 && LocaliserDetected == false && Aircraft.Nav1Flags.Value[7])
                {
                    Tolk.PreferSAPI(true);
                    Tolk.Output("Localiser is alive. ");
                    LocaliserDetected = true;
                }
            }
        }
        private void ReadSpoilers()
        {
            if (Aircraft.Spoilers.ValueChanged)
            {
                uint sp = Aircraft.Spoilers.Value;
                if (sp == 4800) Tolk.Output("Spoilers armed. ");
                else if (sp == 16384) Tolk.Output("Spoilers deployed. ");
                else if (sp == 0)
                {
                    if (OldSpoilersValue == 4800)
                    {
                        Tolk.Output("arm spoilers off. ");
                    }
                    else
                    {
                        Tolk.Output("spoilers retracted. ");
                    }

                }
            }
        }
        
        private void ReadFlaps()
        {
            if (Aircraft.Flaps.ValueChanged)
            {
                FlapsMoving = true;
            }
            else
            {
                if (FlapsMoving)
                {
                    FlapsMoving = false;
                    double FlapsAngle = (double)Aircraft.Flaps.Value / 256d;
                    Tolk.Output("flaps " + FlapsAngle.ToString("f0"));
                }

            }
        }
        // read autopilot settings
        public void ReadAutopilotInstruments()
        {
            // heading
            if (Aircraft.ApHeading.ValueChanged)
            {
                CurrentHeading = (double)Math.Round(Aircraft.ApHeading.Value / 65536d * 360d);
                Tolk.Output("Heading: " + CurrentHeading.ToString());
            }
            // Altitude
            if (Aircraft.ApAltitude.ValueChanged)
            {
                double curAlt = Math.Round((double)Aircraft.ApAltitude.Value / 65536d * 3.28084d);
                Tolk.Output($"Altitude set to {curAlt} feet. ");
            }
            // airspeed
            if (Aircraft.ApAirspeed.ValueChanged)
            {
                Tolk.Output($"{Aircraft.ApAirspeed.Value} knotts.");  
            }
        }
        public void ReadSimConnectMessages ()
        {
            Aircraft.textMenu.RefreshData();
            if (Aircraft.textMenu.Changed) // Check if the text/menu is different from the last time we called RefreshData()
            {
                if (Aircraft.textMenu.IsMenu) // Check if it's a menu (true) or a simple message (false)
                {
                    Tolk.Output(Aircraft.textMenu.ToString());
                }
                else
                {
                    Tolk.Output(Aircraft.textMenu.ToString());
                }
            }
        }
        // set autopilot heading
        public static void SetHeading(string hdg)
        {
            Tolk.Output("not implemented yet");
            Tolk.Output("heading: " + hdg);
        }
        
        private void ReadToggle(Offset instrument, bool toggleStateOn, string name, string OnMsg, string OffMsg)
        {
            if (instrument.ValueChanged)
            {
                if (toggleStateOn)
                {
                    Tolk.Output($"{name} {OnMsg}");
                }
                else
                {
                    Tolk.Output($"{name} {OffMsg}");
                }
            }
        }
        public static double mapOneRangeToAnother(double sourceNumber, double fromA, double fromB, double toA, double toB, int decimalPrecision)
        {
            double deltaA = fromB - fromA;
            double deltaB = toB - toA;
            double scale = deltaB / deltaA;
            double negA = -1 * fromA;
            double offset = (negA * scale) + toA;
            double finalNumber = (sourceNumber * scale) + offset;
            int calcScale = (int)Math.Pow(10, decimalPrecision);
            return (double)Math.Round(finalNumber * calcScale) / calcScale;
        }

        private void commandMode(object sender, HotkeyEventArgs e)
        {
            // Check to see if we are connected to the sim
            if (FSUIPCConnection.IsOpen)
            {
                // play the command sound
                AudioPlaybackEngine.Instance.PlaySound(cmdSound);
                // populate a list of hotkeys, so we can clear them later.
                foreach (SettingsProperty s in Properties.Hotkeys.Default.Properties)
                {
                    if (s.Name == "command") continue;
                    hotkeys.Add(s.Name);
                }
                // hotkey definitions
                HotkeyManager.Current.AddOrReplace("agl", (Keys)Properties.Hotkeys.Default.agl, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("asl", (Keys)Properties.Hotkeys.Default.asl, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("heading", (Keys)Properties.Hotkeys.Default.heading, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("IndicatedAirspeed", (Keys)Properties.Hotkeys.Default.IndicatedAirspeed, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("TrueAirspeed", (Keys)Properties.Hotkeys.Default.TrueAirspeed, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("MachSpeed", (Keys)Properties.Hotkeys.Default.MachSpeed, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("VerticalSpeed", (Keys)Properties.Hotkeys.Default.VerticalSpeed, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("AirTemperature", (Keys)Properties.Hotkeys.Default.AirTemperature, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("ToggleTrim", (Keys)Properties.Hotkeys.Default.ToggleTrim, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("MuteSimconnect", (Keys)Properties.Hotkeys.Default.MuteSimconnect, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("FlightFollowing", (Keys)Properties.Hotkeys.Default.FlightFollowing, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("NextWaypoint", (Keys)Properties.Hotkeys.Default.NextWaypoint, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("DestinationInfo", (Keys)Properties.Hotkeys.Default.DestinationInfo, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("AttitudeMode", (Keys)Properties.Hotkeys.Default.AttitudeMode, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("SpeakAttitude", (Keys)Properties.Hotkeys.Default.SpeakAttitude, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("SpeakAutopilot", (Keys)Properties.Hotkeys.Default.SpeakAutopilot, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("ToggleGPWS", (Keys)Properties.Hotkeys.Default.ToggleGPWS, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("ToggleILS", (Keys)Properties.Hotkeys.Default.ToggleILS, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("ToggleFlapsAnnouncement", (Keys)Properties.Hotkeys.Default.ToggleFlapsAnnouncement, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("ReadWind", (Keys)Properties.Hotkeys.Default.ReadWind, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("RunwayGuidance", (Keys)Properties.Hotkeys.Default.RunwayGuidance, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("FuelReport", (Keys)Properties.Hotkeys.Default.FuelReport, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("FuelFlow", (Keys)Properties.Hotkeys.Default.FuelFlow, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("WeightReport", (Keys)Properties.Hotkeys.Default.WeightReport, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("FuelTank1", (Keys)Properties.Hotkeys.Default.FuelTank1, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("FuelTank2", (Keys)Properties.Hotkeys.Default.FuelTank2, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("FuelTank3", (Keys)Properties.Hotkeys.Default.FuelTank3, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("FuelTank4", (Keys)Properties.Hotkeys.Default.FuelTank4, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("FuelTank5", (Keys)Properties.Hotkeys.Default.FuelTank5, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("FuelTank6", (Keys)Properties.Hotkeys.Default.FuelTank6, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("FuelTank7", (Keys)Properties.Hotkeys.Default.FuelTank7, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("FuelTank8", (Keys)Properties.Hotkeys.Default.FuelTank8, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("FuelTank9", (Keys)Properties.Hotkeys.Default.FuelTank9, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("FuelTank10", (Keys)Properties.Hotkeys.Default.FuelTank10, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("NearbyAirborn", (Keys)Properties.Hotkeys.Default.NearbyAirborn, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("NearbyGround", (Keys)Properties.Hotkeys.Default.NearbyGround, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("Engine1Info", (Keys)Properties.Hotkeys.Default.Engine1Info, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("Engine2Info", (Keys)Properties.Hotkeys.Default.Engine2Info, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("Engine3Info", (Keys)Properties.Hotkeys.Default.Engine3Info, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("Engine4Info", (Keys)Properties.Hotkeys.Default.Engine4Info, onKeyPressed);


            }
            else
            {
                Tolk.Output("not connected to simulator");
                
            }

        }

         private void onKeyPressed(object sender, HotkeyEventArgs e)
        {

            e.Handled = true;
            ResetHotkeys();
            switch (e.Name)
            {
                case "asl":
                    onASLKey();
                    break;
                case "agl":
                    onAGLKey();
                    break;
                case "heading":
                    onHeadingKey();
                    break;
                case "IndicatedAirspeed":
                    onIASKey();
                    break;
                case "TrueAirspeed":
                    onTASKey();
                    break;
                case "MachSpeed":
                    onMachKey();
                    break;
                case "VerticalSpeed":
                    onVSpeedKey();
                    break;
                case "AirTemperature":
                    onAirtempKey();
                    break;
                case "ToggleTrim":
                    onTrimKey();
                    break;
                case "MuteSimconnect":
                    onMuteSimconnectKey();
                    break;
                case "FlightFollowing":
                    onCityKey();
                    break;
                case "NextWaypoint":
                    onWaypointKey();
                    break;
                case "DestinationInfo":
                    onDestKey();
                    break;
                case "AttitudeMode":
                    onAttitudeKey();
                    break;
                case "SpeakAttitude":
                    onManualKey();
                    break;
                case "SpeakAutopilot":
                    onAutopilotKey();
                    break;
                case "ToggleGPWS":
                    onGPWSKey();
                    break;
                case "ToggleILS":
                    onToggleILSKey();
                    break;
                case "ToggleFlaps":
                    onToggleFlapsKey();
                    break;
                case "ReadLastSimconnectMessage":
                    onMessageKey();
                    break;
                case "ReadWind":
                    onWindKey();
                    break;
                case "RunwayGuidance":
                    onRunwayGuidanceKey();
                    break;
                case "FuelReport":
                    onFuelReportKey();
                    break;
                case "FuelFlow":
                    onFuelFlowKey();
                    break;
                case "WeightReport":
                    onWeightReportKey();
                    break;

                case "FuelTank1":
                    onFuelTankKey(1);
                    break;
                case "FuelTank2":
                    onFuelTankKey(2);
                    break;
                case "FuelTank3":
                    onFuelTankKey(3);
                    break;
                case "FuelTank4":
                    onFuelTankKey(4);
                    break;
                case "FuelTank5":
                    onFuelTankKey(5);
                    break;
                case "FuelTank6":
                    onFuelTankKey(6);
                    break;
                case "FuelTank7":
                    onFuelTankKey(7);
                    break;
                case "FuelTank8":
                    onFuelTankKey(8);
                    break;
                case "FuelTank9":
                    onFuelTankKey(9);
                    break;
                case "FuelTank10":
                    onFuelTankKey(10);
                    break;
                case "NearbyAirborn":
                    onTCASAir();
                    break;
                case "NearbyGround":
                    onTCASGround();
                    break;
                case "Engine1Info":
                    onEngineInfoKey(1);
                    break;
                case "Engine2Info":
                    onEngineInfoKey(2);
                    break;
                case "Engine3Info":
                    onEngineInfoKey(3);
                    break;
                case "Engine4Info":
                    onEngineInfoKey(4);
                    break;

            }
        }
        private void onWindKey()
        {
            double WindSpeed = (double)Aircraft.WindSpeed.Value;
            double WindDirection = (double)Aircraft.WindDirection.Value * 360 / 65536;
            WindDirection = Math.Round(WindDirection);
            double WindGust = (double)Aircraft.WindGust.Value;
            Tolk.Output($"Wind: {WindDirection} at {WindSpeed} knotts. Gusts at {WindGust} knotts.");

        }

        
        private void onTCASAir()
        {
            Tolk.Output("not yet implemented.");
        }

        private void onTCASGround()
        {
            Tolk.Output("not yet implemented.");
        }

        private void onFuelTankKey(int tank)
        {
            if (tank > ActiveTanks.Count)
            {
                Tolk.Output("tank not available");
            }
            else
            {
                tank = tank - 1;
                string name = ActiveTanks[tank].Tank.ToString();
                string pct = ActiveTanks[tank].LevelPercentage.ToString("F0");
                string weight = ActiveTanks[tank].WeightLbs.ToString("F0");
                string gal = ActiveTanks[tank].LevelUSGallons.ToString("F0");
                Tolk.Output($"{name}.  {pct} percent, {weight} pounds, {gal} gallons.");
            }
        }

        private void onFuelFlowKey()
        {
            int NumEngines = Aircraft.num_engines.Value;

        }

        private void onFuelReportKey()
        {
            // Make a variable to make accessing the payload services object quicker
            // NOTE: The connection must already be open in order to access payload services
            PayloadServices ps = FSUIPCConnection.PayloadServices;
            // Refresh the current payload data
            ps.RefreshData();
            string TotalFuelWeight = ps.FuelWeightLbs.ToString("F1");
            string TotalFuelQuantity = ps.FuelLevelUSGallons.ToString("F1");
            Tolk.Output($"total fuel: {TotalFuelWeight} pounds. ");
            Tolk.Output($"{TotalFuelQuantity} gallons. ");
            double TotalFuelFlow = (double)Aircraft.eng1_fuel_flow.Value + Aircraft.eng2_fuel_flow.Value + Aircraft.eng3_fuel_flow.Value + Aircraft.eng4_fuel_flow.Value;
            TotalFuelFlow = Math.Round(TotalFuelFlow);
            Tolk.Output($"Total fuel flow: {TotalFuelFlow}");
        }
        private void onWeightReportKey()
        {
            // Make a variable to make accessing the payload services object quicker
            // NOTE: The connection must already be open in order to access payload services
            PayloadServices ps = FSUIPCConnection.PayloadServices;
            // Refresh the current payload data
            ps.RefreshData();
            string GrossWeight = ps.GrossWeightLbs.ToString("F0");
            string EmptyWeight = ps.EmptyWeightLbs.ToString("F0");
            string FuelWeight = ps.FuelWeightLbs.ToString("F0");
            string PayloadWeight = ps.PayloadWeightLbs.ToString("F0");
            string MaxGrossWeight = ps.MaxGrossWeightLbs.ToString("F0");
            if (ps.GrossWeightLbs > ps.MaxGrossWeightLbs)
            {
                Tolk.Output("Overweight warning! ");
            }
            Tolk.Output($"Fuel Weight: {FuelWeight} pounds");
            Tolk.Output($"Payload Weight: {PayloadWeight} pounds. ");
            Tolk.Output($"Gross Weight: {GrossWeight} of {MaxGrossWeight} pounds maximum.");

        }
        private void onRunwayGuidanceKey()
        {
            if (!RunwayGuidanceEnabled)
            {
                RunwayGuidanceEnabled = true;
                // set up the timer
                RunwayGuidanceTimer = new System.Timers.Timer(200); // 200 milliseconds
                // Hook up the Elapsed event for the timer. 
                RunwayGuidanceTimer.Elapsed += OnRunwayGuidanceTickEvent;
                RunwayGuidanceTimer.AutoReset = true;
                RunwayGuidanceTrackedHeading = (double)Math.Round(Aircraft.CompassHeading.Value);
                Tolk.Output($"Runway guidance enabled. current heading: {RunwayGuidanceTrackedHeading}. ");
                // play tones for 45 degrees on either side of the tracked heading
                HdgRight = RunwayGuidanceTrackedHeading + 45;
                HdgLeft = RunwayGuidanceTrackedHeading - 45;
                if (HdgRight > 360)
                {
                    HdgRight = HdgRight - 360;
                }
                if (HdgLeft < 0)
                {
                    HdgLeft = HdgLeft + 360;
                }
                // start audio
                driverOut = new WaveOutEvent();
                mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 2));
                mixer.ReadFully = true;
                driverOut.Init(mixer);
                // start the mixer. We can then add audio sources as needed.
                driverOut.Play();
                RunwayGuidanceTimer.Enabled = true;
            }
            else
            {
                driverOut.Stop();
                RunwayGuidanceTimer.Stop();
                RunwayGuidanceEnabled = false;
                Tolk.Output("Runway Guidance disabled. ");
            }







        }
        private void OnRunwayGuidanceTickEvent(Object source, ElapsedEventArgs e)
        {
            // signal generator for generating tones
            wg = new SignalGenerator();
            wg.Type = SignalGeneratorType.Square;
            wg.Gain = 0.1;

            pan = new PanningSampleProvider(wg.ToMono());
            // we use an OffsetSampleProvider to allow playing beep tones
            pulse = new OffsetSampleProvider(pan)
            {
                Take = TimeSpan.FromMilliseconds(50),
            };
            double hdg = (double)Math.Round(Aircraft.CompassHeading.Value);
            if (hdg > RunwayGuidanceTrackedHeading && hdg < HdgRight)
            {
                double freq = mapOneRangeToAnother(hdg, RunwayGuidanceTrackedHeading, HdgRight, 400, 800, 0);
                wg.Frequency = freq;
                pan.Pan = 1;
                mixer.AddMixerInput(pulse);
            }
            if (hdg < RunwayGuidanceTrackedHeading && hdg > HdgLeft)
            {
                double freq = mapOneRangeToAnother(hdg, HdgLeft, RunwayGuidanceTrackedHeading, 800, 400, 0);
                wg.Frequency = freq;
                pan.Pan = -1;
                mixer.AddMixerInput(pulse);
            }
            if (hdg == RunwayGuidanceTrackedHeading)
            {
                mixer.RemoveAllMixerInputs();
            }
        }

        
        private void onMessageKey()
        {
            Tolk.Output("not yet implemented.");
        }

        private void onToggleFlapsKey()
        {
            Tolk.Output("not yet implemented.");
        }

        private void onToggleILSKey()
        {
            Tolk.Output("not yet implemented.");
        }

        private void onGPWSKey()
        {
            Tolk.Output("not yet implemented.");
        }

        private void onDirectorKey()
        {
            Tolk.Output("not yet implemented.");
        }

        private void onAutopilotKey()
        {
            if (ReadAutopilot)
            {
                ReadAutopilot = false;
                Tolk.Output("read autopilot instruments disabled");
            }
            else
            {
                ReadAutopilot = true;
                Tolk.Output("Read autopilot instruments enabled. ");
            }
        }

        private void onManualKey()
        {
            Tolk.Output("not yet implemented.");
        }

        private void onAttitudeKey()
        {
            Tolk.Output("not yet implemented.");
        }

        private void onDestKey()
        {
            Tolk.Output("not yet implemented.");
        }

        private void onWaypointKey()
        {
            ReadNextWaypoint(true);
        }

        private void onCityKey()
        {
            double lat = Aircraft.aircraftLat.Value.DecimalDegrees;
            double lon = Aircraft.aircraftLon.Value.DecimalDegrees;
            // double lat = -48.876667;
            //double lon = -123.393333;
            flightFollowingOnline = true;
            if (!flightFollowingOnline)
            {
                var pos = r.CreateFromLatLong(lat, lon);
                var results = r.NearestNeighbourSearch(pos, 1);
                foreach (var res in results)
                {
                    Tolk.Output(res.Name);
                    Tolk.Output(res.Admincodes[1]);
                }
            }
            else
            {
                var xml = XElement.Load($"http://api.geonames.org/findNearbyPlaceName?style=long&lat={lat}&lng={lon}&username=jfayre&cities=cities5000&radius=200");
                var locations = xml.Descendants("geoname").Select(g => new
                {
                    Name = g.Element("name").Value,
                    Lat = g.Element("lat").Value,
                    Long = g.Element("lng").Value,
                    admin1 = g.Element("adminName1").Value
                });

                if (locations.Count() > 0)
                {
                    var location = locations.First();

                    Tolk.Output($"closest city: {location.Name} {location.admin1}.");
                }
                else
                {
                    Tolk.Output("no locations in range.");
                }
            }
        }
        private void onMuteSimconnectKey()
        {
            if (muteSimconnect)
            {
                MuteSimconnect = false;
                Tolk.Output("SimConnect messages unmuted. ");
            }
            else
            {
                MuteSimconnect = true;
                Tolk.Output("SimConnect messages muted.");
            }
            ResetHotkeys();
        }

        private void onTrimKey()
        {
            if (TrimEnabled)
            {
                TrimEnabled = false;
                Tolk.Output("read trim disabled. ");
            }
            else
            {
                TrimEnabled = true;
                Tolk.Output("trim enabled. ");
            }
            ResetHotkeys();
        }

        private void onAirtempKey()
        {
            bool metric = true;
            double tempC = (double)Aircraft.AirTemp.Value / 256d;
            double tempF = 9.0 / 5.0 * tempC + 32;
            if (metric)
            {
                Tolk.Output("outside temperature: " + tempC.ToString("f0"));
            }
            else
            {
                Tolk.Output("outside temperature: " + tempF.ToString("f0") + " degrees F");
            }
        }

        private void onVSpeedKey()
        {
            double vspeed = (double)Aircraft.VerticalSpeed.Value * 3.28084d * -1;
            Tolk.Output(vspeed.ToString("f0") + " feet per minute. ");
            ResetHotkeys();

        }

        private void onMachKey()
        {
            double mach = (double)Aircraft.AirspeedMach.Value / 20480d;
            Tolk.Output("mach " + mach.ToString("f2"));

        }

        private void onTASKey()
        {
            double tas = (double)Aircraft.AirspeedTrue.Value / 128d;
            Tolk.Output(tas.ToString("f0") + "knotts true. ");
            ResetHotkeys();
        }

        private void onIASKey()
        {
            double ias = (double)Aircraft.AirspeedIndicated.Value / 128d;
            Tolk.Output(ias.ToString("f0") + "knotts indicated. ");
            ResetHotkeys();
        }

        private void onHeadingKey()
        {
            Tolk.Output("heading: "+ Math.Round(Aircraft.CompassHeading.Value));
            ResetHotkeys();
        }

        private void onAGLKey()
        {
            double groundAlt = (double)Aircraft.GroundAltitude.Value / 256d * 3.28084d;
            double agl = (double)Aircraft.Altitude.Value - groundAlt;
            agl = Math.Round(agl, 0);
            Tolk.Output(agl.ToString() +" feet A G L.");
            ResetHotkeys();
        }

        private void ResetHotkeys()
        {
            foreach (string k in hotkeys)
            {
                HotkeyManager.Current.Remove(k);
            }
            HotkeyManager.Current.AddOrReplace("command", (Keys)Properties.Hotkeys.Default.command, commandMode);
        }

        
        private void onASLKey()
        {
            double asl = Math.Round((double)Aircraft.Altitude.Value, 0);
            Tolk.Output(asl.ToString() + " feet ASL");
            ResetHotkeys();
        }


        private void onEngineInfoKey(int eng)
        {
            double N1 = 0;
            double N2 = 0;
            switch (eng)
            {
                case 1:
                    N1 = (double)Aircraft.Eng1N1.Value;
                    N2 = (double)Aircraft.Eng1N2.Value;
                    break;
                case 2:
                    N1 = (double)Aircraft.Eng2N1.Value;
                    N2 = (double)Aircraft.Eng2N2.Value;
                    break;
                case 3:
                    N1 = (double)Aircraft.Eng3N1.Value;
                    N2 = (double)Aircraft.Eng3N2.Value;
                    break;
                case 4:
                    N1 = (double)Aircraft.Eng4N1.Value;
                    N2 = (double)Aircraft.Eng4N2.Value;
                    break;
            }
            Tolk.Output($"Engine {eng}. ");
            Tolk.Output($"N1: {Math.Round(N1)}. ");
            Tolk.Output($"N2: {Math.Round(N2)}. ");
        }


        }
    }
