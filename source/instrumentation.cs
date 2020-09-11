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
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Timers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Configuration;
using NGeoNames;
using NGeoNames.Entities;
using TimeZoneConverter;
using System.Diagnostics;
using System.Reflection;



namespace tfm
{
    public class Instrumentation
    {
        // this class handles automatic reading of instrumentation, as well as reading in response to hotkeys

        // The event that handles speech/braille output.
public        event EventHandler<ScreenReaderOutputEventArgs> ScreenReaderOutput;

        // The virtual method for the event. Used as a shell and fired when needed.
        protected virtual void onScreenReaderOutput(ScreenReaderOutputEventArgs e)
        {
            EventHandler<ScreenReaderOutputEventArgs> handler = ScreenReaderOutput;
            if(handler != null)
            {
                handler(this, e);
            } // End event callback.
        } // End onScreenReaderOutput method.

        public void fireOnScreenReaderOutputEvent(string gaugeName = "",string gaugeValue = "",bool isGauge = false,string output = "")
        {
            ScreenReaderOutputEventArgs args = new ScreenReaderOutputEventArgs();
            args.output = output;
            args.gaugeName = gaugeName;
            args.gaugeValue = gaugeValue;
            args.isGauge = isGauge;

            this.onScreenReaderOutput(args);
        } // End event fire method.


        private SineWaveProvider pitchSineProvider;
        private SineWaveProvider bankSineProvider;

        
        // timers
        private static System.Timers.Timer RunwayGuidanceTimer;
        private static System.Timers.Timer GroundSpeedTimer = new System.Timers.Timer(3000); // 3 seconds;
        private static System.Timers.Timer AttitudeTimer;
        private static System.Timers.Timer flightFollowingTimer;
        private double HdgRight;
        private double HdgLeft;

        // Audio objects
        IWavePlayer driverOut;
        SignalGenerator wg;
        SignalGenerator BankWG;
        PanningSampleProvider pan;
        OffsetSampleProvider pulse;
        MixingSampleProvider mixer;

        // initialize sound objects
        readonly SoundPlayer cmdSound = new SoundPlayer(@"sounds\command.wav");
        // list to store registered hotkey identifiers
        List<string> hotkeys = new List<string>();
        FsFuelTanksCollection FuelTanks = null;
        // list to store fuel tanks present on the aircraft
        List<FsFuelTank> ActiveTanks = new List<FsFuelTank>();
        // dictionaries for altitude and GPWS callouts
        private Dictionary<int, bool> altitudeCalloutFlags = new Dictionary<int, bool>();
        private Dictionary<int, bool> gpwsFlags = new Dictionary<int, bool>() {
            {2500, false },
            {1000, false },
            {500, false },
            {400, false },
            {300, false },
            {200, false },
            {100, false },
            {50, false },
            {40, false },
            {30, false },
            {20, false },
            {10, false }
        };

        static bool FirstRun = true;
        // flags for tfm features   
        private bool FlightFollowingEnabled;
        private bool InstrumentationEnabled;
        private bool SimConnectMessagesEnabled;
        private bool calloutsEnabled;
        private bool ILSEnabled;
        private bool groundspeedEnabled = true;
        private bool groundSpeedActive;
        private bool onGround;
        private bool TrimEnabled = true;
        private bool FlapsMoving;
        private bool flapsEnabled = true;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private bool muteSimconnect;
        private bool flightFollowingOnline;
        private bool runwayGuidanceEnabled;
        private bool attitudeModeEnabled;
        private bool localiserDetected;
        private bool AttitudePitchPlaying;
        private bool AttitudeBankLeftPlaying;

        private bool apMaster;
        [DisplayName("autopilot master switch")]
        public bool ApMaster
        {
            get
            {
                apMaster = Aircraft.ApMaster.Value != 0;
                return apMaster;
            }
            set
            {
                Aircraft.ApMaster.Value = (value) ? (uint)1 : (uint)0;
                apMaster = value;
            }
        }
        private bool apNavLock;
        [DisplayName("nav lock")]
        public bool ApNavLock
        {
            get
            {
                apNavLock = (Aircraft.ApNavLock.Value == 0) ? false : true;
                return apNavLock;
            }
            set
            {
                Aircraft.ApNavLock.Value = (value) ? (uint)1 : (uint)0;
                apNavLock = value;
            }
        }
        private bool apWingLeveler;
        [DisplayName("Wing Leveler")]
        public bool ApWingLeveler
        {
            get
            {
                apWingLeveler = (Aircraft.ApWingLeveler.Value == 0) ? false : true;
                return apWingLeveler;
            }
            set
            {
                Aircraft.ApWingLeveler.Value = (value) ? (uint)1 : (uint)0;
                apWingLeveler = value;
            }
        }
        private bool apAttitudeHold;
        [DisplayName("attitude hold")]
        public bool ApAttitudeHold
        {
            get
            {
                apAttitudeHold = (Aircraft.ApAttitudeHold.Value == 0) ? false : true;
                return apAttitudeHold;
            }
            set
            {
                Aircraft.ApAttitudeHold.Value = (value) ? (uint)1 : (uint)0;
                apAttitudeHold = value;
            }
        }
        private bool apApproachHold;
        [DisplayName("Approach hold")]
        public bool ApApproachHold
        {
            get
            {
                apApproachHold = (Aircraft.ApApproachHold.Value == 0) ? false : true;
                return apApproachHold;
            }
            set
            {
                Aircraft.ApApproachHold.Value = (value) ? (uint)1 : (uint)0;
                apApproachHold = value;
            }
        }
        [DisplayName("Heading")]
        public double ApHeading
        {
            get
            {
                apHeading = (double)Math.Round(Aircraft.ApHeading.Value / 65536d * 360d);
                return apHeading;
            }
            set
            {
                if (value > 0 && value < 360)
                {
                    // convert the supplied heading into the proper FSUIPC format(degrees*65536/360)
                    Aircraft.ApHeading.Value = (ushort)(value * 65536 / 360);
                    apHeading = value;
                }
                else
                {
                    throw new ArgumentException("Heading values must be between 0 and 360");
                }
            }
        }
        private bool apHeadingLock;
        [DisplayName("heading lock")]
        public bool ApHeadingLock
        {
            get
            {
                apHeadingLock = (Aircraft.ApHeadingLock.Value == 0) ? false : true;
                return apHeadingLock;
            }
            set
            {
                Aircraft.ApHeadingLock.Value = (value) ? (uint)1 : (uint)0;
                apHeadingLock = value;
            }
        }
        [DisplayName("Altitude")]
        public double ApAltitude
        {
            get
            {
                apAltitude = Math.Round((double)Aircraft.ApAltitude.Value / 65536d * 3.28084d);
                return apAltitude;
            }
            set
            {
                if (value > 0)
                {
                    Aircraft.ApAltitude.Value = (uint)(value / 3.28084 * 65536);
                    apAltitude = value;
                }
                else
                {
                    throw new ArgumentException("altitude must be greter than 0");
                }
            }
        }
        private bool apAltitudeLock;
        [DisplayName("altitude lock")]
        public bool ApAltitudeLock
        {
            get
            {
                apAltitudeLock = (Aircraft.ApAltitudeLock.Value == 0) ? false : true;
                return apAltitudeLock;
            }
            set
            {
                Aircraft.ApAltitudeLock.Value = (value) ? (uint)1 : (uint)0;
                apAltitudeLock = value;
            }
        }

        private double apAirspeed;
        [DisplayName("Airspeed")]
        public double ApAirspeed
        {
            get
            {
                apAirspeed = Aircraft.ApAirspeed.Value;
                return apAirspeed;
            }
            set
            {
                if (value > 0)
                {
                    Aircraft.ApAirspeed.Value = (short)value;
                    apAirspeed = value;
                }
                else
                {
                    throw new ArgumentException("speed must be greater than 0");
                }
            }
        }
        private bool apAirspeedHold;
        [DisplayName("airspeed hold")]
        public bool ApAirspeedHold
        {
            get
            {
                apAirspeedHold = (Aircraft.ApSpeedHold.Value == 0) ? false : true;
                return apAirspeedHold;
            }
            set
            {
                Aircraft.ApSpeedHold.Value = (value) ? (uint)1 : (uint)0;
                apAirspeedHold = value;
            }
        }

        private double apMachSpeed;
        [DisplayName("Mach")]
        public double ApMachSpeed
        {
            get
            {
                double mach = (double)Aircraft.ApMach.Value / 65536d;
                string strMach = mach.ToString("F2");
                apMachSpeed = double.Parse(strMach);
                return apMachSpeed;
            }
            set
            {
                if (value > 0)
                {
                    // FSUIPC needs the mach multiplied by 65536            }
                    Aircraft.ApMach.Value = (uint)(value * 65536);
                    apMachSpeed = value;
                }
                else
                {
                    throw new ArgumentException("Mach must be greater than 0");
                }
            }
        }
        private bool apMachHold;
        [DisplayName("mach hold")]
        public bool ApMachHold
        {
            get
            {
                apMachHold = (Aircraft.ApMachHold.Value == 0) ? false : true;
                return apMachHold;
            }
            set
            {
                Aircraft.ApMachHold.Value = (value) ? (uint)1 : (uint)0;
                apMachHold = value;
            }
        }


        private double apVerticalSpeed;
        [DisplayName("Vertical speed")]
        public double ApVerticalSpeed
        {
            get
            {
                apVerticalSpeed = Aircraft.ApVerticalSpeed.Value;
                return apVerticalSpeed;
            }
            set
            {
                Aircraft.ApVerticalSpeed.Value = (short)value;
                apVerticalSpeed = value;

            }
        }
        private bool apVerticalSpeedHold;
        [DisplayName("vertical speed hold")]
        public bool ApVerticalSpeedHold
        {
            get
            {
                apVerticalSpeedHold = (Aircraft.ApVerticalSpeedHold.Value == 0) ? false : true;
                return apVerticalSpeedHold;
            }
            set
            {
                Aircraft.ApVerticalSpeedHold.Value = (value) ? (uint)1 : (uint)0;
                apVerticalSpeedHold = value;
            }
        }


        private decimal com1Freq;
        [DisplayName("com 1")]
        [Category("communications")]
        public decimal Com1Freq
        {
            get
            {
                FsFrequencyCOM com1Helper = new FsFrequencyCOM(Aircraft.Com1Freq.Value);
                com1Freq = com1Helper.ToDecimal();
                return com1Freq;
            }
            set
            {
                if (value > 0)
                {
                    // 1. Create a new instance of the COM helper class using the decimal value entered
                    FsFrequencyCOM com1Helper = new FsFrequencyCOM(value);
                    // 2. Now use the helper class to get the BCD value required by FSUIPC and set the offset to this new value
                    Aircraft.Com1Freq.Value = com1Helper.ToBCD();
                    com1Freq = value;
                }
                else
                {
                    throw new ArgumentException("com 1 frequency must be greater than 0");
                }
            }
        }

        private decimal com2Freq;
        [DisplayName("com 2")]
        [Category("communications")]
        public decimal Com2Freq
        {
            get
            {
                FsFrequencyCOM com2Helper = new FsFrequencyCOM(Aircraft.Com2Freq.Value);
                com2Freq = com2Helper.ToDecimal();
                return com2Freq;
            }
            set
            {
                if (value > 0)
                {
                    // 1. Create a new instance of the COM helper class using the decimal value entered
                    FsFrequencyCOM com2Helper = new FsFrequencyCOM(value);
                    // 2. Now use the helper class to get the BCD value required by FSUIPC and set the offset to this new value
                    Aircraft.Com2Freq.Value = com2Helper.ToBCD();
                    com2Freq = value;
                }
                else
                {
                    throw new ArgumentException("com 2 frequency must be greater than 0");
                }
            }
        }
        private int transponder;
        [DisplayName("transponder")]
        [Category("communications")]
        public int Transponder
        {
            get
            {
                FsTransponderCode txHelper = new FsTransponderCode(Aircraft.Transponder.Value);
                transponder = txHelper.ToInteger();
                return transponder;
            }
            set
            {
                if (value > 0)
                {
                    // 1. Create a new instance of the Transponder helper class using the integer that was entered
                    //    Note the number box always returns the value as a 'decimal' type. So we have to cast to Int32
                    FsTransponderCode txHelper = new FsTransponderCode((int)value);
                    // 2. Now use the helper class to get the BCD value required by FSUIPC and set the offset to this new value
                    Aircraft.Transponder.Value = txHelper.ToBCD();
                    transponder = value;
                }
                else
                {
                    throw new ArgumentException("Transponder values mush be greater than 0");
                }
            }
        }
        private decimal adf1Freq;
        [DisplayName("ADF frequency")]
        [Category("navigation")]
        public decimal Adf1Freq
        {
            get
            {
                // 1. Create a new instance of the helper ADF class using the values of the main AND extended offsets
                //    This is taking in the BCD values sent from FSUIPC
                FsFrequencyADF adf1Helper = new FsFrequencyADF(Aircraft.adf1Main.Value, Aircraft.adf1Extended.Value);
                // 2. Now use the helper class to get the string representation and show it on the form
                adf1Freq = adf1Helper.ToDecimal();
                return adf1Freq;
            }
            set
            {
                if (value > 0)
                {
                    // 1. Create a new instance of the ADF helper class using the decimal value entered
                    FsFrequencyADF adf1Helper = new FsFrequencyADF(value);
                    // 2. Now use the helper class to get the two BCD values required by FSUIPC (main and extended)
                    //    Set the offsets to these new values
                    Aircraft.adf1Main.Value = adf1Helper.ToBCDMain();
                    Aircraft.adf1Extended.Value = adf1Helper.ToBCDExtended();
                    adf1Freq = value;
                }
                else
                {
                    throw new ArgumentException("aDF frequency must be greater than 0");
                }
            }
        }
        private double altimeterQNH;
        [DisplayName("Altimeter QNH")]
        public double AltimeterQNH
        {
            get
            {
                double AltQNH = (double)Aircraft.Altimeter.Value / 16d;
                altimeterQNH = Math.Floor(AltQNH + 0.5);
                return altimeterQNH;
            }
            set
            {
                Aircraft.Altimeter.Value = (ushort)(value * 16);
                altimeterQNH = value;
            }
        }
        private double altimeterInches;
        [DisplayName("Altimeter Inches")]
        public double AltimeterInches
        {
            get
            {
                double AltQNH = (double)Aircraft.Altimeter.Value / 16d;
                altimeterInches = Math.Floor(((100 * AltQNH * 29.92) / 1013.2) + 0.5);
                return altimeterInches;
            }
            set
            {
                double qnh = value * 33.864;
                qnh = Math.Round(qnh, 1) * 16;
                Aircraft.Altimeter.Value = (ushort)qnh;
                altimeterInches = value;

            }
        }

        private decimal nav1Freq;
        [DisplayName("nav 1")]
        [Category("navigation")]
        public decimal Nav1Freq
        {
            get
            {
                FsFrequencyNAV nav1Helper = new FsFrequencyNAV(Aircraft.Nav1Freq.Value);
                nav1Freq = nav1Helper.ToDecimal();
                return nav1Freq;
            }
            set
            {
                if (value > 0)
                {
                    // 1. Create a new instance of the COM helper class using the decimal value entered
                    FsFrequencyNAV nav1Helper = new FsFrequencyNAV(value);
                    // 2. Now use the helper class to get the BCD value required by FSUIPC and set the offset to this new value
                    Aircraft.Nav1Freq.Value = nav1Helper.ToBCD();
                    nav1Freq = value;
                }
                else
                {
                    throw new ArgumentException("nav 1 frequency must be greater than 0");
                }
            }
        }
        private decimal nav2Freq;
        [DisplayName("nav 2")]
        [Category("navigation")]
        public decimal Nav2Freq
        {
            get
            {
                FsFrequencyNAV nav2Helper = new FsFrequencyNAV(Aircraft.Nav2Freq.Value);
                nav2Freq = nav2Helper.ToDecimal();
                return nav2Freq;
            }
            set
            {
                if (value > 0)
                {
                    // 1. Create a new instance of the NAV helper class using the decimal value entered
                    FsFrequencyNAV nav2Helper = new FsFrequencyNAV(value);
                    // 2. Now use the helper class to get the BCD value required by FSUIPC and set the offset to this new value
                    Aircraft.Nav2Freq.Value = nav2Helper.ToBCD();
                    nav2Freq = value;
                }
                else
                {
                    throw new ArgumentException("nav 2 frequency must be greater than 0");
                }
            }
        }

        public double oldBank { get; private set; }

        public double CurrentHeading;

        public ReverseGeoCode<ExtendedGeoName> r = new ReverseGeoCode<ExtendedGeoName>(GeoFileReader.ReadExtendedGeoNames(@".\data\cities1000.txt"));
        private int OldSpoilersValue;
        private double RunwayGuidanceTrackedHeading;
        private string OldSimConnectMessage;
        private double apHeading;
        private double apAltitude;
        private bool AttitudeBankRightPlaying;
        private bool readNavRadios;
        private double groundSpeed;
        public double GroundSpeed
        {
            get
            {
                groundSpeed = ((double)Aircraft.GroundSpeed.Value * 3600d) / (65536d * 1852d);
                groundSpeed = Math.Round(groundSpeed);
                return groundSpeed;

            }
        }
        private int attitudeModeSelect;
        private int RunwayGuidanceModeSelect;
        private double oldPitch;
        private string oldTimezone;

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
            var version = typeof(Instrumentation).Assembly.GetName().Version.Build;
            Tolk.Output($"Talking Flight Monitor test build {version}");
            HotkeyManager.Current.AddOrReplace("command", (Keys)Properties.Hotkeys.Default.command, commandMode);
            // HotkeyManager.Current.AddOrReplace("test", Keys.OemOpenBrackets, OffsetTest);
            runwayGuidanceEnabled = false;


            // hook up the event for the groundspeed timer so we can enable it later
            GroundSpeedTimer.Elapsed += onGroundSpeedTimerTick;
            // start the flight following timer if it is enabled in settings
            SetupFlightFollowing();
            // populate the dictionary for the altitude callout flags
            for (int i = 1000; i < 65000; i += 1000)
            {
                altitudeCalloutFlags.Add(i, false);
            }

        }

        public void SetupFlightFollowing()
        {
            flightFollowingTimer = new System.Timers.Timer(TimeSpan.FromMinutes(Properties.Settings.Default.FlightFollowingTimeInterval).TotalMilliseconds);
            flightFollowingTimer.Elapsed += onFlightFollowingTimerTick;
            if (Properties.Settings.Default.FlightFollowing)
            {
                flightFollowingTimer.AutoReset = true;
                flightFollowingTimer.Enabled = true;

            }
            else
            {
                flightFollowingTimer.Stop();


            }

        }

        private void onFlightFollowingTimerTick(object sender, ElapsedEventArgs e)
        {
            // this just reads the flight following info, same as the hotkey
            onCityKey();
        }

        private void OffsetTest(object sender, HotkeyEventArgs e)
        {
            PMDG_NGX_CDU_Screen PM = new PMDG_NGX_CDU_Screen(0X5800);
            PM.RefreshData();
            Tolk.Output(PM.ToString());


        }

        public void ReadAircraftState()
        {
            // If this is the first time through the loop, don't read instruments.

            if (!FirstRun || InstrumentationEnabled)
            {
                // Read when aircraft changes
                if (Aircraft.AircraftName.ValueChanged)
                {
                    fireOnScreenReaderOutputEvent(isGauge: false, output:"Current aircraft: " + Aircraft.AircraftName.Value);
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
                if (Properties.Settings.Default.ReadFlaps) ReadFlaps();
                ReadLandingGear();
                if (Properties.Settings.Default.ReadAutopilot) ReadAutopilotInstruments();
                if (groundspeedEnabled) ReadGroundSpeed();
                if (Properties.Settings.Default.AltitudeAnnouncements) ReadAltitudeAnnouncement();
                ReadSimConnectMessages();
                ReadTransponder();
                ReadRadios();
                ReadAutoBrake();
                ReadSpoilers();
                ReadTrim();
                ReadAltimeter();
                ReadNextWaypoint();
                ReadLights();
                ReadDoors();
                if (Properties.Settings.Default.ReadILS) ReadILSInfo();
                ReadSimulationRate(TriggeredByKey : false);
                // TODO: engine select
            }
            else
            {
                fireOnScreenReaderOutputEvent(isGauge: false, output: "Current aircraft: " + Aircraft.AircraftName.Value);
                DetectFuelTanks();
                FirstRun = false;
            }
        }

        private void ReadAltitudeAnnouncement()
        {
            // read altitude every 1000 feet
            double alt = Math.Round((double)Aircraft.Altitude.Value);
            double radioAlt = Math.Round((double)Aircraft.RadioAltimeter.Value / 65536d * 3.28084d);
            double vSpeed = Math.Round((Aircraft.VerticalSpeed.Value * 3.28084) * -1);

            for (int i = 1000; i < 65000; i += 1000)
            {
                if (alt >= i-10 && alt <= i-10 && altitudeCalloutFlags[i] == false)
                {
                    fireOnScreenReaderOutputEvent(isGauge:false, output:$"{i} feet. ");
                    altitudeCalloutFlags[i] = true;

                }
                else
                {
                    if (alt >= i + 100)
                    {
                        altitudeCalloutFlags[i] = false;

                    }
                }
            }
            if (radioAlt < 10000 && vSpeed < -50)
            {
                var gpwsKeys = new List<int>(gpwsFlags.Keys);
                foreach (int key in gpwsKeys)
                {
                    if (radioAlt <= key + 5 && radioAlt >= key - 5 && gpwsFlags[key] == false)
                    {
                        SoundPlayer snd = new SoundPlayer("sounds\\" + key.ToString() + ".wav");
                        snd.Play();
                        gpwsFlags[key] = true;
                    }
                }
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

        private void ReadRadios()
        {
            FsFrequencyCOM com1Helper = new FsFrequencyCOM(Aircraft.Com1Freq.Value);
            FsFrequencyCOM com2Helper = new FsFrequencyCOM(Aircraft.Com2Freq.Value);
            FsFrequencyNAV nav1Helper = new FsFrequencyNAV(Aircraft.Nav1Freq.Value);
            FsFrequencyNAV nav2Helper = new FsFrequencyNAV(Aircraft.Nav2Freq.Value);
            if (Aircraft.Com1Freq.ValueChanged)
            {
                Tolk.Output("Com1: " + com1Helper.ToString());
            }
            if (Aircraft.Com2Freq.ValueChanged)
            {
                Tolk.Output("Com1: " + com2Helper.ToString());
            }
            if (readNavRadios)
            {
                if (Aircraft.Nav1Freq.ValueChanged)
                {
                    Tolk.Output($"Nav 1: {nav1Helper.ToString()}");
                }
                if (Aircraft.Nav2Freq.ValueChanged)
                {
                    Tolk.Output($"Nav 2: {nav2Helper.ToString()}");
                }

            }
        }

        private void ReadTransponder()
        {
            FsTransponderCode txHelper = new FsTransponderCode(Aircraft.Transponder.Value);
            if (Aircraft.Transponder.ValueChanged)
            {
                Tolk.Output("squawk " + txHelper.ToString());
            }
            Transponder = txHelper.ToInteger();

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
                string strTime = string.Format("{0:%h} hours, {0:%m} minutes, {0:%s} seconds", TimeEnroute);
                if (TimeEnroute.Hours == 0)
                {
                    strTime = string.Format("{0:%m} minutes, {0:%s} seconds", TimeEnroute);
                }
                if (TimeEnroute.Minutes == 0 && TimeEnroute.Hours == 0)
                {
                    strTime = string.Format("{0:%s} seconds", TimeEnroute);
                }
                fireOnScreenReaderOutputEvent(isGauge: false, output:$"Next waypoint: {name}.\nDistance: {strDist} nautical miles.\nBaring: {strBaring} degrees.\n{strTime}");
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
                        string state = (Aircraft.Doors.Value[i]) ? "open" : "closed";
                        Tolk.Output($"door {i + 1} {state}. ");
                    }
                }
            }

        }
        private void ReadILSInfo()
        {
            if (Aircraft.Nav1Signal.Value == 256 && localiserDetected == false && Aircraft.Nav1Flags.Value[7])
            {
                Tolk.PreferSAPI(true);
                Tolk.Output("Localiser is alive. ");
                localiserDetected = true;
            }
        }
        private void ReadSimulationRate(bool TriggeredByKey)
        {
            double rate = (double)Aircraft.SimulationRate.Value / 256;
            if (TriggeredByKey)
            {
                Tolk.Output($"simulation rate: {rate}");
            }
            if (Aircraft.SimulationRate.ValueChanged && rate >= 0.25)
            {
                Tolk.Output($"simulation rate: {rate}");
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
        public void ReadLandingGear()
        {
            if (Aircraft.LandingGear.ValueChanged)
            {
                if (Aircraft.LandingGear.Value == 0)
                {
                    Tolk.Output("gear up. ");
                }
                if (Aircraft.LandingGear.Value == 16383)
                {
                    Tolk.Output("Gear down. ");
                }
            }
        }
        // read autopilot settings
        public void ReadAutopilotInstruments()
        {
            // heading
            if (Aircraft.ApHeading.ValueChanged)
            {
                Tolk.Output("Heading: " + ApHeading.ToString());
            }
            // Altitude
            if (Aircraft.ApAltitude.ValueChanged)
            {
                Tolk.Output($"Altitude set to {ApAltitude} feet. ");
            }
            // airspeed
            if (Aircraft.ApAirspeed.ValueChanged)
            {
                Tolk.Output($"{ApAirspeed} knotts.");
            }
        }
        public void ReadGroundSpeed()
        {
            if (!groundSpeedActive)
            {
                // only read if aircraft is on ground
                if (Aircraft.OnGround.Value == 1)
                {
                    if (GroundSpeed > 10)
                    {
                        groundSpeedActive = true;
                        GroundSpeedTimer.AutoReset = true;
                        GroundSpeedTimer.Enabled = true;
                        
                    }
                    


                }

            }
        }

        private void onGroundSpeedTimerTick(object sender, ElapsedEventArgs e)
        {
            
            if (GroundSpeed > 10)
            {
                Tolk.Output($"{GroundSpeed} knotts. ");
            }
            if (GroundSpeed < 10 || Aircraft.OnGround.Value == 0)
            {
                groundSpeedActive = false;
                GroundSpeedTimer.Stop();
            }
        }

        public void ReadSimConnectMessages()
        {
            Aircraft.textMenu.RefreshData();
            if (Aircraft.textMenu.Changed) // Check if the text/menu is different from the last time we called RefreshData()
            {
                if (!muteSimconnect)
                {
                    if (Aircraft.textMenu.IsMenu) // Check if it's a menu (true) or a simple message (false)
                    {
                        if (Aircraft.textMenu.ToString() == "") return;
                        Logger.Debug("simconnect menu: " + Aircraft.textMenu.ToString());
                        Tolk.Output(Aircraft.textMenu.ToString());
                    }
                    else
                    {
                        if (Aircraft.textMenu.Message == "") return;
                        Logger.Debug("simconnect message: " + Aircraft.textMenu.Message);
                        Tolk.Output(Aircraft.textMenu.ToString());
                    }

                }
                OldSimConnectMessage = Aircraft.textMenu.ToString();
            }
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
                // AudioPlaybackEngine.Instance.PlaySound(cmdSound);
                cmdSound.Play();
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
                HotkeyManager.Current.AddOrReplace("RepeatLastSimconnectMessage", (Keys)Properties.Hotkeys.Default.RepeatLastSimconnectMessage, onKeyPressed);
                HotkeyManager.Current.AddOrReplace("ReadSimulationRate", (Keys)Properties.Hotkeys.Default.ReadSimulationRate, onKeyPressed);
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
                HotkeyManager.Current.AddOrReplace("GroundSpeed", (Keys)Properties.Hotkeys.Default.GroundSpeed, onKeyPressed);


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
                case "ReadSimulationRate":
                    ReadSimulationRate(true);
                    break;
                case "GroundSpeed":
                    onGroundSpeedKey();
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
                case "RepeatLastSimconnectMessage":
                    onRepeatLastSimconnectMessage();
                    break;
                case "FlightFollowing":
                    onCityKey();
                    break;
                case "NextWaypoint":
                    onWaypointKey();
                    break;
                case "DestinationInfo":
                    onDestinationKey();
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
                case "ToggleFlapsAnnouncement":
                    onToggleFlapsAnnouncementKey();
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

        private void onGroundSpeedKey()
        {
            Tolk.Output($"{GroundSpeed} knotts ground speed");
        }

        private void onRepeatLastSimconnectMessage()
        {
            if (OldSimConnectMessage != null)
            {
                Tolk.Output(OldSimConnectMessage);
            }
            else
            {
                Tolk.Output("no recent message");
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
            double eng1 = Math.Round(Aircraft.eng1_fuel_flow.Value);
            double eng2 = Math.Round(Aircraft.eng2_fuel_flow.Value);
            double eng3 = Math.Round(Aircraft.eng3_fuel_flow.Value);
            double eng4 = Math.Round(Aircraft.eng4_fuel_flow.Value);
            Tolk.Output("Fuel flow (pounds per hour): ");
            Tolk.Output($"Engine 1: {eng1}. ");
            if (NumEngines >= 2)
            {
                Tolk.Output($"Engine 2: {eng2}. ");
            }
            if (NumEngines >= 3)
            {
                Tolk.Output($"Engine 3: {eng3}. ");
            }
            if (NumEngines >= 4)
            {
                Tolk.Output($"Engine 4: {eng4}. ");
            }

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
            if (!runwayGuidanceEnabled)
            {
                runwayGuidanceEnabled = true;
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
                wg = new SignalGenerator();
                wg.Type = SignalGeneratorType.Square;
                wg.Gain = 0.1;
                // set up panning provider, with the signal generator as input
                pan = new PanningSampleProvider(wg.ToMono());
                // we use an OffsetSampleProvider to allow playing beep tones
                pulse = new OffsetSampleProvider(pan)
                {
                    Take = TimeSpan.FromMilliseconds(50),
                };
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
                runwayGuidanceEnabled = false;
                Tolk.Output("Runway Guidance disabled. ");
            }

        }
        private void OnRunwayGuidanceTickEvent(Object source, ElapsedEventArgs e)
        {
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


        
        private void onToggleFlapsAnnouncementKey()
        {
            if (Properties.Settings.Default.ReadFlaps)
            {
                Properties.Settings.Default.ReadFlaps = false;
                Tolk.Output("flaps announcement disabled. ");
            }
            else
            {
                Properties.Settings.Default.ReadFlaps = true;
                Tolk.Output("Flaps announcement enabled. ");
            }
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
            if (Properties.Settings.Default.ReadAutopilot)
            {
             Properties.Settings.Default.ReadAutopilot = false;
                Tolk.Output("read autopilot instruments disabled");
            }
            else
            {
                Properties.Settings.Default.ReadAutopilot = true;
                Tolk.Output("Read autopilot instruments enabled. ");
            }
        }

        private void onManualKey()
        {
            Tolk.Output("not yet implemented.");
        }
        private void onAttitudeKey()
        {
            if (!attitudeModeEnabled)
            {
                attitudeModeEnabled = true;
                // set up the timer
                AttitudeTimer = new System.Timers.Timer(150); // 200 milliseconds
                // Hook up the Elapsed event for the timer. 
                AttitudeTimer.Elapsed += OnAttitudeModeTickEvent;
                AttitudeTimer.AutoReset = true;
                Tolk.Output("Attitude mode enabled. ");
                // start audio
                // signal generator for generating tones
                driverOut = new WaveOutEvent();
                mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 2));
                mixer.ReadFully = true;
                driverOut.Init(mixer);
                pitchSineProvider = new SineWaveProvider();
                bankSineProvider = new SineWaveProvider();
                // start the mixer. We can then add audio sources as needed.
                driverOut.Play();
                AttitudeTimer.Enabled = true;
            }
            else
            {
                driverOut.Stop();
                mixer.RemoveAllMixerInputs();
                AttitudePitchPlaying = false;
                AttitudeBankLeftPlaying = false;
                AttitudeBankRightPlaying = false;
                AttitudeTimer.Stop();
                attitudeModeEnabled = false;
                Tolk.Output("Attitude mode disabled. ");
            }
        }
        private void OnAttitudeModeTickEvent(Object source, ElapsedEventArgs e)
        {
            attitudeModeSelect = 2;
            pan = new PanningSampleProvider(bankSineProvider);
            FSUIPCConnection.Process("attitude");
            double Pitch = Math.Round((double)Aircraft.AttitudePitch.Value * 360d / (65536d * 65536d));
            double Bank = Math.Round((double)Aircraft.AttitudeBank.Value * 360d / (65536d * 65536d));
            // pitch down
            if (Pitch > 0 && Pitch < 20)
            {
                if (attitudeModeSelect == 2 || attitudeModeSelect == 3)
                {
                    if (Pitch != oldPitch)
                    {
                        Tolk.Output($"down {Pitch}", true);
                        oldPitch = Pitch;
                        if (attitudeModeSelect == 2) return;
                    }
                }
                if (attitudeModeSelect == 1 || attitudeModeSelect == 3)
                {
                    if (!AttitudePitchPlaying)
                    {
                        mixer.AddMixerInput(new SampleToWaveProvider(pitchSineProvider.ToStereo()));
                        Logger.Debug("pitch: " + Pitch);
                        AttitudePitchPlaying = true;
                    }

                    double freq = mapOneRangeToAnother(Pitch, 0, 20, 600, 200, 0);
                    pitchSineProvider.Frequency = freq;
                }

            }            
            // pitch up
            if (Pitch < 0 && Pitch > -20)
            {
                if (attitudeModeSelect == 2 || attitudeModeSelect == 3)
                {
                    if (Pitch != oldPitch)
                    {
                        Tolk.Output($"up {Math.Abs(Pitch)}", true);
                        oldPitch = Pitch;
                        if (attitudeModeSelect == 2) return;
                    }
                }

                if (attitudeModeSelect == 1 || attitudeModeSelect == 3)
                {
                    if (!AttitudePitchPlaying)
                    {
                        mixer.AddMixerInput(new SampleToWaveProvider(pitchSineProvider.ToStereo()));
                        Logger.Debug("pitch: " + Pitch);
                        AttitudePitchPlaying = true;
                    }
                    double freq = mapOneRangeToAnother(Pitch, -20, 0, 1200, 800, 0);
                    pitchSineProvider.Frequency = freq;
                }

            }            
            // bank left
            if (Bank > 0 && Bank < 90)
            {
                if (attitudeModeSelect == 2 || attitudeModeSelect == 3)
                {
                    if (Bank != oldBank)
                    {
                        Tolk.Output($"left {Bank}", true);
                        oldBank = Bank;
                        if (attitudeModeSelect == 2) return;
                    }
                }
                if (attitudeModeSelect == 1 || attitudeModeSelect == 3)
                {
                    double freq = mapOneRangeToAnother(Bank, 1, 90, 400, 800, 0);
                    bankSineProvider.Frequency = freq;
                    if (!AttitudeBankLeftPlaying)
                    {
                        mixer.RemoveAllMixerInputs();
                        pan.Pan = -1;
                        mixer.AddMixerInput(pan);
                        mixer.AddMixerInput(new SampleToWaveProvider(pitchSineProvider));
                        AttitudeBankLeftPlaying = true;
                        AttitudeBankRightPlaying = false;
                    }

                }


            }
            // bank right
            if (Bank < 0 && Bank > -90)
            {
                Bank = Math.Abs(Bank);
                if (attitudeModeSelect == 2 || attitudeModeSelect == 3)
                {
                    if (Bank != oldBank)
                    {
                        Tolk.Output($"right {Bank}", true);
                        oldBank = Bank;
                        if (attitudeModeSelect == 2) return;
                    }
                }

                if (attitudeModeSelect == 1 || attitudeModeSelect == 3)
                {
                    double freq = mapOneRangeToAnother(Bank, 1, 90, 400, 800, 0);
                    bankSineProvider.Frequency = freq;
                    if (!AttitudeBankRightPlaying)
                    {
                        mixer.RemoveAllMixerInputs();
                        pan.Pan = 1;
                        mixer.AddMixerInput(pan);
                        mixer.AddMixerInput(new SampleToWaveProvider(pitchSineProvider));
                        AttitudeBankLeftPlaying = false;
                        AttitudeBankRightPlaying = true;
                    }

                }
            }
            if (Bank == 0)
            {
                if (attitudeModeSelect == 1 || attitudeModeSelect == 3)
                {
                    mixer.RemoveAllMixerInputs();
                    mixer.AddMixerInput(new SampleToWaveProvider(pitchSineProvider));
                    AttitudeBankLeftPlaying = false;
                    AttitudeBankRightPlaying = false;
                    AttitudePitchPlaying = true;

                }
            }

        }


        private void onDestinationKey()
        {
            TimeSpan TimeEnroute = TimeSpan.FromSeconds(Aircraft.DestinationTimeEnroute.Value);
            string strTime = string.Format("{0:%h} hours {0:%m} minutes, {0:%s} seconds", TimeEnroute);
            if (TimeEnroute.Hours == 0)
            {
                strTime = string.Format("{0:%m} minutes, {0:%s} seconds", TimeEnroute);
            }
            if (TimeEnroute.Minutes == 0 && TimeEnroute.Hours == 0)
            {
                strTime = string.Format("{0:%s} seconds", TimeEnroute);
            }
            fireOnScreenReaderOutputEvent(isGauge:false, output:$"Time enroute to destination, {strTime}. ");


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
            // double lon = -123.393333;
            flightFollowingOnline = true;
            if (Properties.Settings.Default.FlightFollowingOffline)
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
                var xmlNearby = XElement.Load($"http://api.geonames.org/findNearbyPlaceName?style=long&lat={lat}&lng={lon}&username=jfayre&cities=cities1000&radius=200");
                var locations = xmlNearby.Descendants("geoname").Select(g => new
                {
                    Name = g.Element("name").Value,
                    Lat = g.Element("lat").Value,
                    Long = g.Element("lng").Value,
                    admin1 = g.Element("adminName1").Value,
                    countryName = g.Element("countryName").Value
                });
                if (locations.Count() > 0)
                {
                    var location = locations.First();
                    Tolk.Output($"closest city: {location.Name} {location.admin1}, {location.countryName}. ");
                }

                var xmlOcean = XElement.Load($"http://api.geonames.org/ocean?lat={lat}&lng={lon}&username=jfayre");
                var ocean = xmlOcean.Descendants("ocean").Select(g => new
                {
                    Name = g.Element("name").Value
                });
                if (ocean.Count() > 0)
                {
                    var currentOcean = ocean.First();
                    Tolk.Output($"{currentOcean.Name}. ");
                }
                var xmlTimezone = XElement.Load($"http://api.geonames.org/timezone?lat={lat}&lng={lon}&username=jfayre&radius=50");
                var timezone = xmlTimezone.Descendants("timezone").Select(g => new
                {
                    Name = g.Element("timezoneId").Value
                });
                if (timezone.Count() > 0)
                {
                    var currentTimezone = timezone.First();
                    if (currentTimezone.Name != oldTimezone)
                    {
                        string tzName = TZConvert.IanaToWindows(currentTimezone.Name);
                        Tolk.Output($"{tzName}. ");
                        oldTimezone = currentTimezone.Name;
                    }

                }


            }
        }
        private void onMuteSimconnectKey()
        {
            if (muteSimconnect)
            {
                muteSimconnect = false;
                Tolk.Output("SimConnect messages unmuted. ");
            }
            else
            {
                muteSimconnect = true;
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
            double tempC = (double)Aircraft.AirTemp.Value / 256d;
            double tempF = 9.0 / 5.0 * tempC + 32;
            var gaugeName = "Outside temperature";
            var isGauge = true;
            var gaugeValue = "";
            if (Properties.Settings.Default.UseMetric)
            {
                gaugeValue = tempC.ToString("F0");
            }
            else
            {
                gaugeValue = tempF.ToString("F0");
            }
            fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge);
        }

        private void onVSpeedKey()
        {
            double vspeed = (double)Aircraft.VerticalSpeed.Value * 3.28084d * -1;

            // used in the onScreenReaderOutput event in the main form.
            var gageName = "Vertical speed";
            var gageValue = vspeed.ToString("f0");
            var isGage = true;

            //Tolk.Output(vspeed.ToString("f0") + " feet per minute. ");
            // Test the new event.
            fireOnScreenReaderOutputEvent(gageName, gageValue, isGage);
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
            Tolk.Output("heading: " + Math.Round(Aircraft.CompassHeading.Value));
            ResetHotkeys();
        }

        private void onAGLKey()
        {
            double groundAlt = (double)Aircraft.GroundAltitude.Value / 256d * 3.28084d;
            double agl = (double)Aircraft.Altitude.Value - groundAlt;
            agl = Math.Round(agl, 0);
            Tolk.Output(agl.ToString() + " feet A G L.");
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
            var gaugeName = "ASL Altitude";
            var gaugeValue = asl.ToString("F0");
            var isGauge = true;
            fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge);
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
