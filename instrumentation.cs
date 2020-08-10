using DavyKager;
using FSUIPC;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

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
        
        // initialize command mode sound
        // CachedSound cmdSound = new CachedSound(@"sounds\command.wav");

        List<string> hotkeys = new List<string>();
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
        public double CurrentHeading;   

        //public ReverseGeoCode<ExtendedGeoName> r = new ReverseGeoCode<ExtendedGeoName>(GeoFileReader.ReadExtendedGeoNames(@".\cities1000.txt"));
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
            // HotkeyManager.Current.AddOrReplace("command", Key.OemCloseBrackets, modifiers.None, commandMode);
        }

        public void ReadAircraftState()
        {
            // If this is the first time through the loop, don't read instruments.

            if (!FirstRun)
            {
                // Read when aircraft changes
                if (Aircraft.AircraftName.ValueChanged)
                {
                    Tolk.Output("Current aircraft: " + Aircraft.AircraftName.Value);
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
                ReadAutopilotInstruments();
                ReadSimConnectMessages();
                ReadTransponder();
                ReadComRadios();
                ReadAutoBrake();



                // TODO: engine select and lights
            }
            else
            {
                FirstRun = false;
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

        /* private void commandMode(object sender, HotkeyEventArgs e)
        {
            // play the command sound
            AudioPlaybackEngine.Instance.PlaySound(cmdSound);
            KeyDataCollection keyCol = cfgfile.data["hotkeys"  ];
            foreach (KeyData k in keyCol)
            {
                if (k.KeyName == "command_key") continue;
                hotkeys.Add(k.KeyName);
                string[] hkey = k.Value.Split(',');
                string mod = hkey[0];
                string keycode = hkey[1];

                // convert to integer, then to enum
                modifiers modkeys = (modifiers)Enum.ToObject(typeof(modifiers), int.Parse(mod));
                Key key = (Key)Enum.ToObject(typeof(Key), int.Parse(keycode));
                HotkeyManager.Current.AddOrReplace(k.KeyName, key, modkeys, onKeyPressed);
            }
            
        }

         private void onKeyPressed(object sender, HotkeyEventArgs e)
        {

            e.Handled = true;
            switch (e.Name)
            {
                case "asl_key":
                    onASLKey();
                    break;
                case "agl_key":
                    onAGLKey();
                    break;
                case "heading_key":
                    onHeadingKey();
                    break;
                case "ias_key":
                    onIASKey();
                    break;
                case "tas_key":
                    onTASKey();
                    break;
                case "mach_key":
                    onMachKey();
                    break;
                case "vspeed_key":
                    onVSpeedKey();
                    break;
                case "airtemp_key":
                    onAirtempKey();
                    break;
                case "trim_key":
                    onTrimKey();
                    break;
                case "mute_simconnect_key":
                    onMuteSimconnectKey();
                    break;
                case "city_key":
                    onCityKey();
                    break;
                case "waypoint_key":
                    onWaypointKey();
                    break;
                case "dest_key":
                    onDestKey();
                    break;
                case "attitude_key":
                    onAttitudeKey();
                    break;
                case "manual_key":
                    onManualKey();
                    break;
                case "autopilot_key":
                    onAutopilotKey();
                    break;
                case "director_key":
                    onDirectorKey();
                    break;
                case "toggle_gpws_key":
                    onGPWSKey();
                    break;
                case "toggle_ils_key":
                    onToggleILSKey();
                    break;
                case "toggle_flaps_key":
                    onToggleFlapsKey();
                    break;
                case "message_key":
                    onMessageKey();
                    break;
                case "wind_key":
                    onWindKey();
                    break;
                case "runway_guidance_key":
                    onRunwayGuidanceKey();
                    break;
                case "fuel_report_key":
                    onFuelReportKey();
                    break;
                case "fuel_flow_key":
                    onFuelFlowKey();
                    break;
                case "tank1_key":
                    onFuelTankKey(1);
                    break;
                case "tank2_key":
                    onFuelTankKey(2);
                    break;
                case "tank3_key":
                    onFuelTankKey(3);
                    break;
                case "tank4_key":
                    onFuelTankKey(4);
                    break;
                case "tank5_key":
                    onFuelTankKey(5);
                    break;
                case "tank6_key":
                    onFuelTankKey(6);
                    break;
                case "tank7_key":
                    onFuelTankKey(7);
                    break;
                case "tank8_key":
                    onFuelTankKey(8);
                    break;
                case "tank9_key":
                    onFuelTankKey(9);
                    break;
                case "tank10_key":
                    onFuelTankKey(10);
                    break;
                case "tcas_air_key":
                    onTCASAir();
                    break;
                case "tcas_ground_key":
                    onTCASGround();
                    break;
                case "eng1_key":
                    onEng1Key();
                    break;
                case "eng2_key":
                    onEng2Key();
                    break;
                case "eng3_key":
                    onEng3Key();
                    break;
                case "eng4_key":
                    onEng4Key();
                    break;

            }
        }
        */
        private void onWindKey()
        {
            Tolk.Output("not yet implemented.");
        }

        private void onEng4Key()
        {
            Tolk.Output("not yet implemented.");
        }

        private void onEng3Key()
        {
            Tolk.Output("not yet implemented.");
        }

        private void onEng2Key()
        {
            Tolk.Output("not yet implemented.");
        }

        private void onEng1Key()
        {
            Tolk.Output("not yet implemented.");
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
            Tolk.Output("not yet implemented.");
        }

        private void onFuelFlowKey()
        {
            Tolk.Output("not yet implemented.");
        }

        private void onFuelReportKey()
        {
            Tolk.Output("not yet implemented.");
        }

        private void onRunwayGuidanceKey()
        {
            Tolk.Output("not yet implemented.");
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
            Tolk.Output("not yet implemented.");
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
            Tolk.Output("not yet implemented.");
        }

        //private void onCityKey()
        //{
        //    double lat = aircraftLat.Value.DecimalDegrees;
        //    double lon = aircraftLon.Value.DecimalDegrees;
        //    // double lat = -48.876667;
        //    //double lon = -123.393333;
        //    flightFollowingOnline = true;
        //    if (!flightFollowingOnline)
        //    {
        //        var pos = r.CreateFromLatLong(lat, lon);
        //        var results = r.NearestNeighbourSearch(pos, 1);
        //        foreach (var res in results)
        //        {
        //            Tolk.Output(res.Name);
        //            Tolk.Output(res.Admincodes[1]);
        //        }
        //    }
        //    else
        //    {
        //        var xml = XElement.Load($"http://api.geonames.org/findNearbyPlaceName?style=long&lat={lat}&lng={lon}&username=jfayre&cities=cities5000&radius=200");
        //        var locations = xml.Descendants("geoname").Select(g => new {
        //            Name = g.Element("name").Value,
        //            Lat = g.Element("lat").Value,
        //            Long = g.Element("lng").Value,
        //            admin1 = g.Element("adminName1").Value
        //        });
                
        //        if (locations.Count() > 0)
        //        {
        //            var location = locations.First();

        //            Tolk.Output($"closest city: {location.Name} {location.admin1}.");
        //        }
        //        else
        //        {
        //            Tolk.Output("no locations in range.");
        //        }
        //    }
        //}
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

        //private void onAirtempKey()
        //{
        //    double tempC = (double)Aircraft.AirTemp.Value / 256d;
        //    double tempF = 9.0 / 5.0 * tempC + 32;
        //    if (cfgfile.data["config"]["use_metric"] == "True")
        //    {
        //        Tolk.Output("outside temperature: " + tempC.ToString("f0"));
        //    }
        //    else
        //    {
        //        Tolk.Output("outside temperature: " + tempF.ToString("f0") + " degrees F");
        //    }
        //}

        private void onVSpeedKey()
        {
            double vspeed = (double)Aircraft.VerticalSpeed.Value * 3.28084d * -1;
            Tolk.Output(vspeed.ToString("f0") + " feet per minute. ");
            ResetHotkeys();

        }

        private void onMachKey()
        {
            double mach = (double)Aircraft.AirspeedMach.Value / 20480d;
            Tolk.Output(mach.ToString("f0") + "knotts indicated. ");

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
            Tolk.Output("heading: "+ Aircraft.CompassHeading.Value);
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
            Tolk.Output("not implimented");            
            //    foreach (string k in hotkeys)
        //    {
        //        HotkeyManager.Current.Remove(k);
        //    }
        //    HotkeyManager.Current.AddOrReplace("command", Key.OemCloseBrackets, modifiers.None, commandMode);
        }

        
        private void onASLKey()
        {
            double asl = Math.Round((double)Aircraft.Altitude.Value, 0);
            Tolk.Output(asl.ToString() + " feet ASL");
            ResetHotkeys();
        }
    }
}
