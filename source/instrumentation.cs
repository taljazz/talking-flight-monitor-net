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
using System.ServiceModel.Security;
using System.Drawing.Text;
using System.Windows.Forms.VisualStyles;

namespace tfm
{
    public class Instrumentation
    {
        // this class handles automatic reading of instrumentation, as well as reading in response to hotkeys
        // get a logger object for this class
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
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

        public void fireOnScreenReaderOutputEvent(string gaugeName = "",string gaugeValue = "",bool isGauge = false,string output = "", bool textOutput = true, bool useSAPI = false, bool interruptSpeech = false)
        {
            ScreenReaderOutputEventArgs args = new ScreenReaderOutputEventArgs();
            args.output = output;
            args.gaugeName = gaugeName;
            args.gaugeValue = gaugeValue;
            args.isGauge = isGauge;
            args.textOutput = textOutput;
            args.useSAPI = useSAPI;
            args.interruptSpeech = interruptSpeech;
            this.onScreenReaderOutput(args);
        } // End event fire method.


        private SineWaveProvider pitchSineProvider;
        private SineWaveProvider bankSineProvider;

        
        // timers
        private static System.Timers.Timer RunwayGuidanceTimer;
        private static System.Timers.Timer GroundSpeedTimer = new System.Timers.Timer(3000); // 3 seconds;
        private static System.Timers.Timer AttitudeTimer;
        private static System.Timers.Timer flightFollowingTimer;
        private static System.Timers.Timer ilsTimer = new System.Timers.Timer(5000);
        private static System.Timers.Timer waypointTransitionTimer = new System.Timers.Timer(5000);
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
        private string nextWaypoint;
        private bool waypointTransition;

        // flags for tfm features   

        private bool FlightFollowingEnabled;
        private bool InstrumentationEnabled;
        private bool SimConnectMessagesEnabled;
        private bool calloutsEnabled;
        private bool ILSEnabled;
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

        // engine throttle properties
        private double engine1ThrottlePercent;
        public double Engine1ThrottlePercent
        {
            get
            {
                engine1ThrottlePercent = (double)Aircraft.Engine1ThrottleLever.Value / 16384d * 100d;
                return engine1ThrottlePercent;
            }
            set
            {
                value = value / 100 * 16384;
                Aircraft.Engine1ThrottleLever.Value = (short)value;
            }
        }
        private double engine2ThrottlePercent;
        public double Engine2ThrottlePercent
        {
            get
            {
                engine2ThrottlePercent = (double)Aircraft.Engine2ThrottleLever.Value / 16384d * 100d;
                return engine2ThrottlePercent;
            }
            set
            {
                value = value / 100 * 16384;
                Aircraft.Engine2ThrottleLever.Value = (short)value;
            }
        }
        private double engine3ThrottlePercent;
        public double Engine3ThrottlePercent
        {
            get
            {
                engine3ThrottlePercent = (double)Aircraft.Engine3ThrottleLever.Value / 16384d * 100d;
                return engine3ThrottlePercent;
            }
            set
            {
                value = value / 100 * 16384;
                Aircraft.Engine3ThrottleLever.Value = (short)value;
            }
        }
        private double engine4ThrottlePercent;
        public double Engine4ThrottlePercent
        {
            get
            {
                engine4ThrottlePercent = (double)Aircraft.Engine4ThrottleLever.Value / 16384d * 100d;
                return engine4ThrottlePercent;
            }
            set
            {
                value = value / 100 * 16384;
                Aircraft.Engine4ThrottleLever.Value = (short)value;
            }
        }
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

        public bool CommandKeyEnabled = true;
        
        private int attitudeModeSelect;
        
        private int RunwayGuidanceModeSelect;
        private double oldPitch;
        private string oldTimezone;
        private bool gsDetected;
        private bool hasLocaliser;
        private bool hasGlideSlope;
        private int waypointLoopCount;
        private bool readWaypointFlag;
        private bool apuStarting;
        private bool apuRunning;
        private bool apuShuttingDown;
        private bool apuOff = true;

        public Instrumentation()
        {
            
            Logger.Debug("initializing screen reader driver");
            Tolk.TrySAPI(true);
            Tolk.Load();
            var version = typeof(Instrumentation).Assembly.GetName().Version.Build;
            fireOnScreenReaderOutputEvent(textOutput:false, output: $"Talking Flight Monitor test build {version}");
            HotkeyManager.Current.AddOrReplace("Command_Key", (Keys)Properties.Hotkeys.Default.Command_Key, commandMode);
            //      HotkeyManager.Current.AddOrReplace("test", Keys.Q, OffsetTest);
            runwayGuidanceEnabled = false;


            // hook up events for timers
            GroundSpeedTimer.Elapsed += onGroundSpeedTimerTick;
            ilsTimer.Elapsed += onILSTimerTick;
            waypointTransitionTimer.Elapsed += onWaypointTransitionTimerTick;
            // start the flight following timer if it is enabled in settings
            SetupFlightFollowing();
            // populate the dictionary for the altitude callout flags
            for (int i = 1000; i < 65000; i += 1000)
            {
                altitudeCalloutFlags.Add(i, false);
            }

        }

        private void onWaypointTransitionTimerTick(object sender, ElapsedEventArgs e)
        {
            waypointTransition = false;
            readWaypointFlag = true;
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
            if (Properties.Settings.Default.GeonamesUsername == "") return;
            onCityKey();
        }

        private void OffsetTest(object sender, HotkeyEventArgs e)
        {
            Engine1ThrottlePercent = 50;

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
                ReadToggle(Aircraft.SeatbeltSign, Aircraft.SeatbeltSign.Value > 0, "seatbelt sign", "on", "off");
                ReadToggle(Aircraft.NoSmokingSign, Aircraft.NoSmokingSign.Value > 0, "no smoking sign", "on", "off");
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
                ReadToggle(Aircraft.ApGlideSlopeHold, Aircraft.ApGlideSlopeHold.Value > 0, "Glide slope hold", "active", "off");
                ReadToggle(Aircraft.ApSpeedHold, Aircraft.ApSpeedHold.Value > 0, "Airspeed hold", "active", "off");
                ReadToggle(Aircraft.ApMachHold, Aircraft.ApMachHold.Value > 0, "Mach hold", "Active", "off");
                ReadToggle(Aircraft.PropSync, Aircraft.PropSync.Value > 0, "Propeller Sync", "active", "off");
                ReadToggle(Aircraft.BatteryMaster, Aircraft.BatteryMaster.Value > 0, "Battery Master", "active", "off");
                // TODO: add check for a2a since below toggles aren't needed for a2a
                ReadToggle(Aircraft.FuelPump, Aircraft.FuelPump.Value > 0, "Fuel pump", "active", "off");
                if (Properties.Settings.Default.ReadFlaps) ReadFlaps();
                ReadLandingGear();
                if (Properties.Settings.Default.ReadAutopilot) ReadAutopilotInstruments();
                if (Properties.Settings.Default.ReadGroundSpeed) ReadGroundSpeed();
                readAutopilotAltitude();
                if (Properties.Settings.Default.AltitudeAnnouncements) ReadAltitudeAnnouncement();
                if (Properties.Settings.Default.ReadSimconnectMessages) ReadSimConnectMessages();
                ReadTransponder();
                ReadRadios();
                ReadAutoBrake();
                ReadSpoilers();
                ReadTrim();
                ReadAltimeter();
                NextWaypoint();
                ReadLights();
                ReadDoors();
                if (Properties.Settings.Default.ReadILS) ReadILSInfo();
                ReadSimulationRate(TriggeredByKey : false);
                readAPU();
                readOnGround();
                // TODO: engine select
            }
            else
            {
                fireOnScreenReaderOutputEvent(isGauge: false, output: "Current aircraft: " + Aircraft.AircraftName.Value);
                DetectFuelTanks();
                FirstRun = false;
            }
        }
        
        public void ReadLowPriorityInstruments()
        {
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

        }
        private void readOnGround()
        {
            if (Aircraft.OnGround.ValueChanged)
            {
                if (Aircraft.OnGround.Value == 1)
                {
                    fireOnScreenReaderOutputEvent(isGauge: false, useSAPI: true, output: "on ground. ");
                }
                else
                {
                    fireOnScreenReaderOutputEvent(isGauge: false, useSAPI: true, output: "airborn. ");
                }

            }
        }

        private void readAPU()
        {
            double apuPercent = Math.Round((double)Aircraft.APUPercentage.Value);
            if (Aircraft.APUPercentage.ValueChanged)
            {
                if (apuPercent > 4 && apuStarting == false && apuRunning == false && apuShuttingDown == false && apuOff == true)
                {
                    fireOnScreenReaderOutputEvent(isGauge: false, output: "A P U starting. ");
                    apuStarting = true;
                    apuOff = false;
                }
                if (apuPercent == 100 && apuStarting == true)
                    {
                    apuStarting = false;
                    apuRunning = true;
                    fireOnScreenReaderOutputEvent(isGauge: false, output: "A P U at 100 percent. ");
                }
                if (apuPercent < 100 && apuRunning == true)
                {
                    apuRunning = false;
                    apuShuttingDown = true;
                    fireOnScreenReaderOutputEvent(isGauge: false, output: "A P U shutting down. ");
                }
                if (apuPercent == 0 && apuOff == false)
                {
                    apuRunning = false;
                    apuStarting = false;
                    apuShuttingDown = false;
                    apuOff = true;
                    fireOnScreenReaderOutputEvent(isGauge: false, output: "A P U shut down. ");
                }

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
                if (alt >= i-10 && alt <= i+10 && altitudeCalloutFlags[i] == false)
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
                    fireOnScreenReaderOutputEvent(isGauge: false, output: $"Trim down {Math.Abs(Math.Round(elevator, 2)):F2}. ");
                }
                else
                {
                    fireOnScreenReaderOutputEvent(isGauge: false, output: $"Trim up: {Math.Round(elevator, 2):F2}");
                }

            }
            if (Aircraft.AileronTrim.ValueChanged && Aircraft.ApMaster.Value != 1 && TrimEnabled)
            {
                if (aileron < 0)
                {
                    fireOnScreenReaderOutputEvent(isGauge: false, output: $"Trim left {Math.Abs(Math.Round(aileron, 2))}. ");
                }
                else
                {
                    fireOnScreenReaderOutputEvent(isGauge: false, output: $"Trim right {Math.Round(aileron, 2)}");
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
                var isGauge = true;
                var gaugeName = "Altimeter";
                var gaugeValue = $"{AltHPA}, {AltInches / 100} inches. ";
                fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge);
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
                fireOnScreenReaderOutputEvent(isGauge: false, output: "Autobrake " + AbState);
            }
        }

        private void ReadRadios()
        {
            FsFrequencyCOM com1Helper = new FsFrequencyCOM(Aircraft.Com1Freq.Value);
            FsFrequencyCOM com2Helper = new FsFrequencyCOM(Aircraft.Com2Freq.Value);
            FsFrequencyNAV nav1Helper = new FsFrequencyNAV(Aircraft.Nav1Freq.Value);
            FsFrequencyNAV nav2Helper = new FsFrequencyNAV(Aircraft.Nav2Freq.Value);
            bool isGauge = true;
            string gaugeName;
            string gaugeValue;
            if (Aircraft.Com1Freq.ValueChanged)
            {
                gaugeName = "Com1";
                gaugeValue = com1Helper.ToString();
                fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge);

            }
            if (Aircraft.Com2Freq.ValueChanged)
            {
                gaugeName = "Com2";
                gaugeValue = com2Helper.ToString();
                fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge);

            }
            if (Properties.Settings.Default.ReadNavRadios == true)
            {
                if (Aircraft.Nav1Freq.ValueChanged)
                {
                    gaugeName = "Nav1";
                    gaugeValue = nav1Helper.ToString();
                    fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge);

                }
                if (Aircraft.Nav2Freq.ValueChanged)
                {
                    gaugeName = "Nav2";
                    gaugeValue = nav2Helper.ToString();
                    fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge);

                }

            }
        }

        private void ReadTransponder()
        {
            
            FsTransponderCode txHelper = new FsTransponderCode(Aircraft.Transponder.Value);
            if (Aircraft.Transponder.ValueChanged)
            {
                var gaugeName = "Transponder";
                var gaugeValue = txHelper.ToString();
                var isGauge = true;
                fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge);

            }
            Transponder = txHelper.ToInteger();

        }
        
        private void NextWaypoint()
        {
            // convert distance to nautical miles
            double dist = Aircraft.NextWPDistance.Value * 0.00053995D;
            
            if (waypointTransition == false && readWaypointFlag == true)
            {
                ReadWayPoint();
                return;
            }
            if (Aircraft.NextWPName.ValueChanged)
            {
                waypointTransitionTimer.AutoReset = false;
                waypointTransitionTimer.Start();

            }
            
        }
        
        private void ReadWayPoint()
            {
            double dist = Aircraft.NextWPDistance.Value * 0.00053995D;
            string name = Aircraft.NextWPName.Value;
                string strDist = dist.ToString("F0");
                TimeSpan TimeEnroute = TimeSpan.FromSeconds(Aircraft.NextWPETE.Value);
                double baring = Aircraft.ConvertRadiansToDegrees((double)Aircraft.NextWPBaring.Value);
                string strBaring = baring.ToString("F0");
                string strTime = string.Format("{0:%h} hours, {0:%m} minutes, {0:%s} seconds", TimeEnroute);
            readWaypointFlag = false;
                if (TimeEnroute.Hours == 0)
                {
                    strTime = string.Format("{0:%m} minutes, {0:%s} seconds", TimeEnroute);
                }
                if (TimeEnroute.Minutes == 0 && TimeEnroute.Hours == 0)
                {
                    strTime = string.Format("{0:%s} seconds", TimeEnroute);
                }
                fireOnScreenReaderOutputEvent(isGauge: false, output: $"Next waypoint: {name}.\nDistance: {strDist} nautical miles.\nBaring: {strBaring} degrees.\n{strTime}");
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
                        fireOnScreenReaderOutputEvent(isGauge: false, output: $"{name} {state}. ");
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
                        fireOnScreenReaderOutputEvent(isGauge: false, output: $"door {i + 1} {state}. ");
                    }
                }
            }

        }
        
        private void ReadILSInfo()
        {
            double vspeed = (double)Aircraft.VerticalSpeed.Value * 3.28084d * -1;
            if (Properties.Settings.Default.ReadILS && Aircraft.OnGround.Value == 0 && vspeed < 200 )
            {
                if (Aircraft.Nav1GS.Value == 1 && gsDetected == false)
                {
                    fireOnScreenReaderOutputEvent(isGauge: false, useSAPI: true, output: "glide slope is alive. ");
                    gsDetected = true;
                }
                if (Aircraft.Nav1Flags.Value[7] && hasLocaliser == false)
                {
                    fireOnScreenReaderOutputEvent(isGauge: false, useSAPI: true, output: "nav 1 has localiser.");
                    hasLocaliser = true;
                }
                if (Aircraft.Nav1Signal.Value == 256 && localiserDetected == false && Aircraft.Nav1Flags.Value[7])
                {
                    fireOnScreenReaderOutputEvent(isGauge: false, useSAPI: true, output: "Localiser is alive. ");
                    localiserDetected = true;
                    ilsTimer.AutoReset = true;
                    ilsTimer.Enabled = true;

                }
                if (Aircraft.Nav1Flags.Value[6] && hasGlideSlope == false)
                {
                    fireOnScreenReaderOutputEvent(isGauge: false, useSAPI: true, output: "nav 1 has glide slope. ");
                    hasGlideSlope = true;
                }

            }
            else
            {
                ilsTimer.Enabled = false;
                hasGlideSlope = false;
                hasLocaliser = false;
                localiserDetected = false;
                gsDetected = false;
            }
        }

        private void onILSTimerTick(object sender, ElapsedEventArgs e)
        {
            double gsNeedle = (double)Aircraft.Nav1GSNeedle.Value;
            double locNeedle = (double)Aircraft.Nav1LocNeedle.Value;
            double locPercent;
            double gsPercent;
            // if on ground, stop reading ILS values
            if (Aircraft.OnGround.Value == 1)
            {
                ilsTimer.Enabled = false;
                return;
            }
            // only read ils when approach mode is on
            if (Aircraft.ApApproachHold.Value == 1)
            {
                if (gsNeedle > 0 && gsNeedle < 119)
                {
                    gsPercent = gsNeedle / 119 * 100;
                    string strPercent = gsPercent.ToString("F0");
                    var gaugeName = "Glide slope";
                    var gaugeValue = $"up {strPercent} percent. ";
                    var isGauge = true;
                    fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge, useSAPI: true, textOutput: false);

                }
                if (gsNeedle < 0 && gsNeedle > -119)
                {
                    gsPercent = Math.Abs(gsNeedle) / 119 * 100;
                    string strPercent = gsPercent.ToString("F0");
                    var gaugeName = "Glide slope";
                    var gaugeValue = $"down {strPercent} percent. ";
                    var isGauge = true;
                    fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge, useSAPI: true, textOutput: false);

                }
                if (locNeedle > 0 && locNeedle < 127)
                {
                    locPercent = locNeedle / 127 * 100;
                    string strPercent = locPercent.ToString("F0");
                    var gaugeName = "Localiser";
                    var gaugeValue = $"{strPercent} percent right. ";
                    var isGauge = true;
                    fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge, useSAPI: true, textOutput: false);
                }
                if (locNeedle < 0 && locNeedle > -127)
                {
                    locPercent = Math.Abs(locNeedle) / 127 * 100;
                    string strPercent = locPercent.ToString("F0");
                    var gaugeName = "Localiser";
                    var gaugeValue = $"{strPercent} percent left. ";
                    var isGauge = true;
                    fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge, useSAPI: true, textOutput: false);
                }

            }
        }

        private void ReadSimulationRate(bool TriggeredByKey)
        {
            double rate = (double)Aircraft.SimulationRate.Value / 256;
            if (TriggeredByKey)
            {
                fireOnScreenReaderOutputEvent(isGauge: false, output: $"simulation rate: {rate}");
            }
            if (Aircraft.SimulationRate.ValueChanged && rate >= 0.25)
            {
                fireOnScreenReaderOutputEvent(isGauge: false, output: $"simulation rate: {rate}");
            }
        }
        private void ReadSpoilers()
        {
            if (Aircraft.Spoilers.ValueChanged)
            {
                uint sp = Aircraft.Spoilers.Value;
                if (sp == 4800) fireOnScreenReaderOutputEvent(isGauge: false, output: "Spoilers armed. ");
                else if (sp == 16384) fireOnScreenReaderOutputEvent(isGauge: false, output: "Spoilers deployed. ");
                else if (sp == 0)
                {
                    if (OldSpoilersValue == 4800)
                    {
                        fireOnScreenReaderOutputEvent(isGauge: false, output: "arm spoilers off. ");
                    }
                    else
                    {
                        fireOnScreenReaderOutputEvent(isGauge: false, output: "spoilers retracted. ");
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
                    var gaugeName = "Flaps";
                    var gaugeValue = FlapsAngle.ToString("f0");
                    var isGauge = true;
                    fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge);
                }

            }

        }
        public void ReadLandingGear()
        {
            var gaugeName = "Gear";
            var isGauge = true;
            string gaugeValue;
            if (Aircraft.LandingGear.ValueChanged)
            {
                if (Aircraft.LandingGear.Value == 0)
                {
                    gaugeValue = "up. ";
                    fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge);
                }
                if (Aircraft.LandingGear.Value == 16383)
                {
                    gaugeValue = "down. ";
                    fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge);
                }
                
            }
        }
        // read autopilot settings
        public void ReadAutopilotInstruments()
        {
            string gaugeName;
            string gaugeValue;
            bool isGauge = true;
            // heading
            if (Aircraft.ApHeading.ValueChanged)
            {
                gaugeName = "AP heading";
                gaugeValue = ApHeading.ToString();
                fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge);
            }
            // airspeed
            if (Aircraft.ApAirspeed.ValueChanged)
            {
                gaugeName = "AP airspeed";
                gaugeValue = ApAirspeed.ToString();
                fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge);
            }
            // vertical speed
            if (Aircraft.ApVerticalSpeed.ValueChanged)
            {
                gaugeName = "AP vertical speed";
                gaugeValue = ApVerticalSpeed.ToString();
                fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge);
            }
        }
        private void readAutopilotAltitude()
        {
            // Altitude
            var gaugeName = "AP altitude";
            var isGauge = true;

            if (Aircraft.ApAltitude.ValueChanged)
            {
                var gaugeValue = ApAltitude.ToString();
                fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge);


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
                fireOnScreenReaderOutputEvent(textOutput: false, isGauge: false, useSAPI: true, output:$"{GroundSpeed} knotts. ");
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
                        fireOnScreenReaderOutputEvent(isGauge: false, output: Aircraft.textMenu.ToString());
                    }
                    else
                    {
                        if (Aircraft.textMenu.Message == "") return;
                        fireOnScreenReaderOutputEvent(isGauge: false, output: Aircraft.textMenu.Message);
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
                    fireOnScreenReaderOutputEvent(isGauge:false, output:$"{name} {OnMsg}");
                }
                else
                {
                    fireOnScreenReaderOutputEvent(isGauge: false, output: $"{name} {OffMsg}");
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
                    if (s.Name == "Command_Key") continue;
                    hotkeys.Add(s.Name);
                    HotkeyManager.Current.AddOrReplace(s.Name, (Keys)Properties.Hotkeys.Default[s.Name], onKeyPressed);

                }
                // hotkey definitions
                    


            }
            else
            {
                Tolk.Output("not connected to simulator");

            }

        }

        private void onKeyPressed(object sender, HotkeyEventArgs e)
        {

            e.Handled = true;
            
            switch (e.Name)
            {
                case "ASL_Altitude":
                    onASLKey();
                    break;
                case "Current_Location":
                    onCurrentLocation();
                    break;
                case "AGL_Altitude":
                    onAGLKey();
                    break;
                case "Disable_Command_Key":
                    fireOnScreenReaderOutputEvent(isGauge: false, output: "command key disabled.");
                    CommandKeyEnabled = false;
                    break;

                case "Aircraft_Heading":
                    onHeadingKey();
                    break;
                case "Indicated_Airspeed":
                    onIASKey();
                    break;
                case "Read_Simulation_Rate":
                    ReadSimulationRate(true);
                    break;
                case "Ground_Speed":
                    onGroundSpeedKey();
                    break;

                case "True_Airspeed":
                    onTASKey();
                    break;
                case "Mach_Speed":
                    onMachKey();
                    break;
                case "Vertical_Speed":
                    onVSpeedKey();
                    break;
                case "Outside_Temperature":
                    onAirtempKey();
                    break;
                case "Toggle_Trim_Announcement":
                    onTrimKey();
                    break;
                case "Mute_Simconnect_Messages":
                    onMuteSimconnectKey();
                    break;
                case "Repeat_Last_Simconnect_Message":
                    onRepeatLastSimconnectMessage();
                    break;
                case "Nearest_City":
                    onCityKey();
                    break;
                case "Next_Waypoint":
                    onWaypointKey();
                    break;
                case "Destination_Info":
                    onDestinationKey();
                    break;
                case "Attitude_Mode":
                    onAttitudeKey();
                    break;
                case "Toggle_Autopilot_Announcement":
                    onAutopilotKey();
                    break;
                case "Toggle_GPWS_Announcement":
                    onGPWSKey();
                    break;
                case "Toggle_ILS_Announcement":
                    onToggleILSKey();
                    break;
                case "Toggle_Flaps_Announcement":
                    onToggleFlapsAnnouncementKey();
                    break;
                case "Wind_Information":
                    onWindKey();
                    break;
                case "Runway_Guidance_Mode":
                    onRunwayGuidanceKey();
                    break;
                case "Fuel_Report":
                    onFuelReportKey();
                    break;
                case "Fuel_Flow":
                    onFuelFlowKey();
                    break;
                case "Weight_Report":
                    onWeightReportKey();
                    break;

                case "Fuel_Tank_1":
                    onFuelTankKey(1);
                    break;
                case "Fuel_Tank_2":
                    onFuelTankKey(2);
                    break;
                case "Fuel_Tank_3":
                    onFuelTankKey(3);
                    break;
                case "Fuel_Tank_4":
                    onFuelTankKey(4);
                    break;
                case "Fuel_Tank_5":
                    onFuelTankKey(5);
                    break;
                case "Fuel_Tank_6":
                    onFuelTankKey(6);
                    break;
                case "Fuel_Tank_7":
                    onFuelTankKey(7);
                    break;
                case "Fuel_Tank_8":
                    onFuelTankKey(8);
                    break;
                case "Fuel_Tank_9":
                    onFuelTankKey(9);
                    break;
                case "Fuel_Tank_10":
                    onFuelTankKey(10);
                    break;
                case "Nearby_Airborn_Aircraft":
                    onTCASAir();
                    break;
                case "Nearby_Ground_Aircraft":
                    onTCASGround();
                    break;
                case "Engine_1_Throttle":
                    onEngineThrottleKey(1);
                    break;

                case "Engine_2_Throttle":
                    onEngineThrottleKey(2);
                    break;

                case "Engine_3_Throttle":
                    onEngineThrottleKey(3);
                    break;

                case "Engine_4_Throttle":
                    onEngineThrottleKey(4);
                    break;

                case "Engine_1_Info":
                    onEngineInfoKey(1);
                    break;
                case "Engine_2_Info":
                    onEngineInfoKey(2);
                    break;
                case "Engine_3_Info":
                    onEngineInfoKey(3);
                    break;
                case "Engine_4_Info":
                    onEngineInfoKey(4);
                    break;
                case "Toggle_Braille_Output":
                    onBrailleOutputKey();
                    break;

            }
            ResetHotkeys();
        }

        private void onBrailleOutputKey()
        {
            if (Properties.Settings.Default.OutputBraille)
            {
                Properties.Settings.Default.OutputBraille = false;
                fireOnScreenReaderOutputEvent(isGauge: false, output: "Braille output disabled. ");
            }
            else
            {
                Properties.Settings.Default.OutputBraille = true;
                fireOnScreenReaderOutputEvent(isGauge: false, output: "Braille output enabled. ");
            }
        }

        private void onEngineThrottleKey(int engine)
        {
            string throttleValue = null;
            string thrustValue = null;
            if (engine > Aircraft.num_engines.Value)
            {
                fireOnScreenReaderOutputEvent(isGauge: false, output: $"Only {Aircraft.num_engines.Value} available. ");
                return;
            }
            if (engine == 1)
            {
                double throttlePercent = (double)Aircraft.Engine1ThrottleLever.Value / 16384d * 100d;
                double thrust = Aircraft.Engine1JetThrust.Value;
                throttleValue = throttlePercent.ToString("F1");
                thrustValue = Aircraft.Engine1JetThrust.Value.ToString("F0");
                fireOnScreenReaderOutputEvent(isGauge: false, output: $"Engine 1: {throttleValue} percent, {thrustValue} pounds thrust.");
            }
            if (engine == 2)
            {
                double throttlePercent = (double)Aircraft.Engine2ThrottleLever.Value / 16384d * 100d;
                throttleValue = throttlePercent.ToString("F1");
                thrustValue = Aircraft.Engine2JetThrust.Value.ToString("F0");
                fireOnScreenReaderOutputEvent(isGauge: false, output: $"Engine 2: {throttleValue} percent, {thrustValue} pounds thrust.");
            }
            if (engine == 3)
            {
                double throttlePercent = (double)Aircraft.Engine3ThrottleLever.Value / 16384d * 100d;
                throttleValue = throttlePercent.ToString("F1");
                thrustValue = Aircraft.Engine3JetThrust.Value.ToString("F0");
                fireOnScreenReaderOutputEvent(isGauge: false, output: $"Engine 3: {throttleValue} percent, {thrustValue} pounds thrust.");
            }
            if (engine == 4)
            {
                double throttlePercent = (double)Aircraft.Engine4ThrottleLever.Value / 16384d * 100d;
                throttleValue = throttlePercent.ToString("F1");
                thrustValue = Aircraft.Engine4JetThrust.Value.ToString("F0");
                fireOnScreenReaderOutputEvent(isGauge: false, output: $"Engine 4: {throttleValue} percent, {thrustValue} pounds thrust.");

            }



        }

        private void onGroundSpeedKey()
        {
            var gaugeName = "Ground speed";
            var gaugeValue = GroundSpeed.ToString();
            var isGauge = true;
            fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge);
        }

        private void onRepeatLastSimconnectMessage()
        {
            if (OldSimConnectMessage != null)
            {
                fireOnScreenReaderOutputEvent(isGauge: false, output: OldSimConnectMessage);
            }
            else
            {
                fireOnScreenReaderOutputEvent(isGauge: false, output: "no recent message");
            }

        }

        private void onWindKey()
        {
            double WindSpeed = (double)Aircraft.WindSpeed.Value;
            double WindDirection = (double)Aircraft.WindDirection.Value * 360d / 65536d;
            WindDirection = Math.Round(WindDirection);
            double WindGust = (double)Aircraft.WindGust.Value;
            fireOnScreenReaderOutputEvent(isGauge: false, output: $"Wind: {WindDirection} at {WindSpeed} knotts. Gusts at {WindGust} knotts.");

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
            FSUIPCConnection.PayloadServices.RefreshData();
            if (tank > ActiveTanks.Count)
            {
                fireOnScreenReaderOutputEvent(isGauge: false, output: "tank not available");
            }
            else
            {
                tank = tank - 1;
                string name = ActiveTanks[tank].Tank.ToString();
                string pct = ActiveTanks[tank].LevelPercentage.ToString("F0");
                string weight = ActiveTanks[tank].WeightLbs.ToString("F0");
                string gal = ActiveTanks[tank].LevelUSGallons.ToString("F0");
                fireOnScreenReaderOutputEvent(isGauge: false, output: $"{name}.  {pct} percent, {weight} pounds, {gal} gallons.");
            }
        }

        private void onFuelFlowKey()
        {
            int NumEngines = Aircraft.num_engines.Value;
            double eng1 = Math.Round(Aircraft.eng1_fuel_flow.Value);
            double eng2 = Math.Round(Aircraft.eng2_fuel_flow.Value);
            double eng3 = Math.Round(Aircraft.eng3_fuel_flow.Value);
            double eng4 = Math.Round(Aircraft.eng4_fuel_flow.Value);
            fireOnScreenReaderOutputEvent(isGauge: false, output: "Fuel flow (pounds per hour): ");
            fireOnScreenReaderOutputEvent(isGauge: false, output: $"Engine 1: {eng1}. ");
            if (NumEngines >= 2)
            {
                fireOnScreenReaderOutputEvent(isGauge: false, output: $"Engine 2: {eng2}. ");
            }
            if (NumEngines >= 3)
            {
                fireOnScreenReaderOutputEvent(isGauge: false, output: $"Engine 3: {eng3}. ");
            }
            if (NumEngines >= 4)
            {
                fireOnScreenReaderOutputEvent(isGauge: false, output: $"Engine 4: {eng4}. ");
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
            fireOnScreenReaderOutputEvent(isGauge: false, output: $"total fuel: {TotalFuelWeight} pounds. ");
            fireOnScreenReaderOutputEvent(isGauge: false, output: $"{TotalFuelQuantity} gallons. ");
            double TotalFuelFlow = (double)Aircraft.eng1_fuel_flow.Value + Aircraft.eng2_fuel_flow.Value + Aircraft.eng3_fuel_flow.Value + Aircraft.eng4_fuel_flow.Value;
            TotalFuelFlow = Math.Round(TotalFuelFlow);
            fireOnScreenReaderOutputEvent(isGauge: false, output: $"Total fuel flow: {TotalFuelFlow}");
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
                fireOnScreenReaderOutputEvent(isGauge: false, output: "Overweight warning! ");
            }
            fireOnScreenReaderOutputEvent(isGauge: false, output: $"Fuel Weight: {FuelWeight} pounds");
            fireOnScreenReaderOutputEvent(isGauge: false, output: $"Payload Weight: {PayloadWeight} pounds. ");
            fireOnScreenReaderOutputEvent(isGauge: false, output: $"Gross Weight: {GrossWeight} of {MaxGrossWeight} pounds maximum.");

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
                fireOnScreenReaderOutputEvent(isGauge: false, output: $"Runway guidance enabled. current heading: {RunwayGuidanceTrackedHeading}. ");
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
                fireOnScreenReaderOutputEvent(isGauge: false, output: "Runway Guidance disabled. ");
            }

        }
        private void OnRunwayGuidanceTickEvent(Object source, ElapsedEventArgs e)
        {
            pulse = new OffsetSampleProvider(pan)
            {
                Take = TimeSpan.FromMilliseconds(50),
            };
            mixer.RemoveAllMixerInputs();
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
                fireOnScreenReaderOutputEvent(isGauge: false, output: "flaps announcement disabled. ");
            }
            else
            {
                Properties.Settings.Default.ReadFlaps = true;
                fireOnScreenReaderOutputEvent(isGauge: false, output: "Flaps announcement enabled. ");
            }
        }

        private void onToggleILSKey()
        {
            if (Properties.Settings.Default.ReadILS == true)
            {
                Properties.Settings.Default.ReadILS = false;
                ilsTimer.Enabled = false;
                fireOnScreenReaderOutputEvent(isGauge: false, output: "Read ILS disabled");
            }
            else
            {
                Properties.Settings.Default.ReadILS = true;
                fireOnScreenReaderOutputEvent(isGauge: false, output: "Read ILS enabled");

            }
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
                fireOnScreenReaderOutputEvent(isGauge: false, output: "read autopilot instruments disabled");
            }
            else
            {
                Properties.Settings.Default.ReadAutopilot = true;
                fireOnScreenReaderOutputEvent(isGauge: false, output: "Read autopilot instruments enabled. ");
            }
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
                fireOnScreenReaderOutputEvent(isGauge: false, output: "Attitude mode enabled. ");
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
                fireOnScreenReaderOutputEvent(isGauge: false, output: "Attitude mode disabled. ");
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
                        fireOnScreenReaderOutputEvent(isGauge: false, textOutput: false, interruptSpeech: true, output: $"down {Pitch}");
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
                        fireOnScreenReaderOutputEvent(interruptSpeech: true, isGauge: false, textOutput: false, output: $"up {Math.Abs(Pitch)}");
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
                        fireOnScreenReaderOutputEvent(interruptSpeech: true, isGauge: false, textOutput: false, output: $"left {Bank}");
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
                        fireOnScreenReaderOutputEvent(interruptSpeech: true, isGauge: false, textOutput: false, output: $"right {Bank}");
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
            ReadWayPoint();
        }

        private void onCityKey()
        {
            double lat = Aircraft.aircraftLat.Value.DecimalDegrees;
            double lon = Aircraft.aircraftLon.Value.DecimalDegrees;
            // double lat = -48.876667;
            // double lon = -123.393333;
            if (Properties.Settings.Default.GeonamesUsername == "")
            {
                fireOnScreenReaderOutputEvent(isGauge: false, output: "geonames username not configured");
                return;
            }
            var geonamesUser = Properties.Settings.Default.GeonamesUsername;
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
                try
                {
                    
                    var xmlNearby = XElement.Load($"http://api.geonames.org/findNearbyPlaceName?style=long&lat={lat}&lng={lon}&username={geonamesUser}&cities=cities1000&radius=200");
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
                        // get the current magnetic variation
                        double magVarDegrees = (double)Aircraft.MagneticVariation.Value * 360d / 65536d;
                        // create a point for the aircraft current position
                        FsLatLonPoint aircraftPos = new FsLatLonPoint(Aircraft.aircraftLat.Value, Aircraft.aircraftLon.Value);
                        // create a point for the nearest city
                        double nearestCityLat = double.Parse(location.Lat);
                        double nearestCityLong = double.Parse(location.Long);
                        FsLatLonPoint nearestCityPoint = new FsLatLonPoint(nearestCityLat, nearestCityLong);
                        string distanceNM = aircraftPos.DistanceFromInNauticalMiles(nearestCityPoint).ToString("F1");
                        double bearingTrue = aircraftPos.BearingTo(nearestCityPoint);
                        double bearingMagnetic = bearingTrue - magVarDegrees;
                        string strBearing = bearingMagnetic.ToString("F0");
                        fireOnScreenReaderOutputEvent(isGauge: false, output: $"{location.Name} {location.admin1}, {location.countryName}. ");
                        fireOnScreenReaderOutputEvent(isGauge: false, output: $"{distanceNM} nautical miles, {strBearing} degrees.");
                    }

                }
                catch (Exception ex)
                {
                    Logger.Debug($"error retrieving nearest city: {ex.Message}");
                    Tolk.Output("error retrieving nearest city. check log.");
                }
                try
                {
                    var xmlOcean = XElement.Load($"http://api.geonames.org/ocean?lat={lat}&lng={lon}&username={geonamesUser}");
                    var ocean = xmlOcean.Descendants("ocean").Select(g => new
                    {
                        Name = g.Element("name").Value
                    });
                    if (ocean.Count() > 0)
                    {
                        var currentOcean = ocean.First();
                        fireOnScreenReaderOutputEvent(isGauge: false, output: $"{currentOcean.Name}. ");
                    }

                }
                catch (Exception ex)
                {
                    Logger.Debug($"error retrieving oceanic info: {ex.Message}");

                }
                var xmlTimezone = XElement.Load($"http://api.geonames.org/timezone?lat={lat}&lng={lon}&username={geonamesUser}&radius=50");
                var timezone = xmlTimezone.Descendants("timezone").Select(g => new
                {
                    Name = g.Element("timezoneId").Value
                });
                if (timezone.Count() > 0)
                {
                    var currentTimezone = timezone.First();
                    if (currentTimezone.Name != oldTimezone)
                    {
                        try
                        {
                            string tzName = TZConvert.IanaToWindows(currentTimezone.Name);
                            fireOnScreenReaderOutputEvent(isGauge: false, output: $"{tzName}. ");
                        }
                        catch (Exception)
                        {

                            Logger.Debug($"cannot convert timezone: {currentTimezone.Name}");
                        }
                        
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
                fireOnScreenReaderOutputEvent(isGauge: false, output: "SimConnect messages unmuted. ");
            }
            else
            {
                muteSimconnect = true;
                fireOnScreenReaderOutputEvent(isGauge: false, output: "SimConnect messages muted.");
            }
            ResetHotkeys();
        }

        private void onTrimKey()
        {
            if (TrimEnabled)
            {
                TrimEnabled = false;
                fireOnScreenReaderOutputEvent(isGauge: false, output: "read trim disabled. ");
            }
            else
            {
                TrimEnabled = true;
                fireOnScreenReaderOutputEvent(isGauge: false, output: "trim enabled. ");
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
            var gaugeName = "Mach";
            var isGauge = true;
            var gaugeValue = mach.ToString("F2");
            fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge);

    }

        private void onTASKey()
        {
            double tas = (double)Aircraft.AirspeedTrue.Value / 128d;
            var gaugeName = "Airspeed true";
            var isGauge = true;
            var gaugeValue = tas.ToString("F0");
            fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge);
        }

        private void onIASKey()
        {
            double ias = (double)Aircraft.AirspeedIndicated.Value / 128d;
            var gaugeName = "Airspeed indicated";
            var isGauge = true;
            var gaugeValue = ias.ToString("F0");
            fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge);
        }

        private void onHeadingKey()
        {
            fireOnScreenReaderOutputEvent(isGauge: false,  output: "heading: " + Math.Round(Aircraft.CompassHeading.Value));
            ResetHotkeys();
        }

        private void onAGLKey()
        {
            double groundAlt = (double)Aircraft.GroundAltitude.Value / 256d * 3.28084d;
            double agl = (double)Aircraft.Altitude.Value - groundAlt;
            var gaugeName = "AGL altitude";
            var isGauge = true;
            var gaugeValue = Math.Round(agl, 0).ToString();
            fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge);
        }

        public void ResetHotkeys()
        {
            HotkeyManager.Current.Remove("Command_Key");
            foreach (string k in hotkeys)
            {
                HotkeyManager.Current.Remove(k);
            }
            if (CommandKeyEnabled)
            {
                HotkeyManager.Current.AddOrReplace("Command_Key", (Keys)Properties.Hotkeys.Default.Command_Key, commandMode);
            }
            
        }


        private void onASLKey()
        {
            double asl = Math.Round((double)Aircraft.Altitude.Value, 0);
            var gaugeName = "ASL altitude";
            var gaugeValue = asl.ToString("F0");
            var isGauge = true;
            fireOnScreenReaderOutputEvent(gaugeName, gaugeValue, isGauge);
        }


        private void onEngineInfoKey(int eng)
        {
            double N1 = 0;
            double N2 = 0;
            double cht = 0;
            double egt = 0;
            double manifold = 0;
            double rpm = 0;
            bool metric = Properties.Settings.Default.UseMetric;
            string units = null;
            string output = null;
            // check engine type. 0 - piston, 1- jet
            if (Aircraft.EngineType.Value == 0)
            {
                switch (eng)
                {
                    case 1:
                        // FSUIPC represents EGT in degrees Rankine, so we need to convert
                        egt = Aircraft.Engine1EGT.Value;
                        if (metric == true)
                        {
                            egt = Math.Round((egt - 491.67) * 5d / 9d);
                            units = "C";
                        }
                        else
                        {
                            egt = Math.Round(egt - 459.67);
                            units = "F";
                        }
                        cht = Aircraft.Engine1CHT.Value;
                        if (Properties.Settings.Default.UseMetric == true)
                        {
                            cht = Math.Round((cht - 32) * 5 / 9);
                            units = "C";
                        }
                        else
                        {
                            cht = Math.Round(cht);
                            units = "F";
                        }
                        rpm = Math.Round(Aircraft.Engine1RPM.Value);
                        manifold = Aircraft.Engine1ManifoldPressure.Value / 1024;
                        output = $"Engine 1: CHT: {cht} {units}, EGT: {egt} {units}, RPM: {rpm}, manifold: {manifold} inches. ";
                        fireOnScreenReaderOutputEvent(isGauge: false, output: output);
                        break;

                    case 2:
                        // FSUIPC represents EGT in degrees Rankine, so we need to convert
                        egt = Aircraft.Engine2EGT.Value;
                        if (metric == true)
                        {
                            egt = Math.Round((egt - 491.67) * 5d / 9d);
                            units = "C";
                        }
                        else
                        {
                            egt = Math.Round(egt - 459.67);
                            units = "F";
                        }
                        cht = Aircraft.Engine2CHT.Value;
                        if (Properties.Settings.Default.UseMetric == true)
                        {
                            cht = Math.Round((cht - 32) * 5 / 9);
                            units = "C";
                        }
                        else
                        {
                            cht = Math.Round(cht);
                            units = "F";
                        }
                        rpm = Math.Round(Aircraft.Engine2RPM.Value);
                        manifold = Aircraft.Engine2ManifoldPressure.Value / 1024;
                        output = $"Engine 2: CHT: {cht} {units}, EGT: {egt} {units}, RPM: {rpm}, manifold: {manifold} inches. ";
                        fireOnScreenReaderOutputEvent(isGauge: false, output: output);
                        break;

                    case 3:
                        // FSUIPC represents EGT in degrees Rankine, so we need to convert
                        egt = Aircraft.Engine3EGT.Value;
                        if (metric == true)
                        {
                            egt = Math.Round((egt - 491.67) * 5d / 9d);
                            units = "C";
                        }
                        else
                        {
                            egt = Math.Round(egt - 459.67);
                            units = "F";
                        }
                        cht = Aircraft.Engine3CHT.Value;
                        if (Properties.Settings.Default.UseMetric == true)
                        {
                            cht = Math.Round((cht - 32) * 5 / 9);
                            units = "C";
                        }
                        else
                        {
                            cht = Math.Round(cht);
                            units = "F";
                        }
                        rpm = Math.Round(Aircraft.Engine3RPM.Value);
                        manifold = Aircraft.Engine3ManifoldPressure.Value / 1024;
                        output = $"Engine 3: CHT: {cht} {units}, EGT: {egt} {units}, RPM: {rpm}, manifold: {manifold} inches. ";
                        fireOnScreenReaderOutputEvent(isGauge: false, output: output);
                        break;

                    case 4:
                        // FSUIPC represents EGT in degrees Rankine, so we need to convert
                        egt = Aircraft.Engine4EGT.Value;
                        if (metric == true)
                        {
                            egt = Math.Round((egt - 491.67) * 5d / 9d);
                            units = "C";
                        }
                        else
                        {
                            egt = Math.Round(egt - 459.67);
                            units = "F";
                        }
                        cht = Aircraft.Engine4CHT.Value;
                        if (Properties.Settings.Default.UseMetric == true)
                        {
                            cht = Math.Round((cht - 32) * 5 / 9);
                            units = "C";
                        }
                        else
                        {
                            cht = Math.Round(cht);
                            units = "F";
                        }
                        rpm = Math.Round(Aircraft.Engine4RPM.Value);
                        manifold = Aircraft.Engine4ManifoldPressure.Value / 1024;
                        output = $"Engine 4: CHT: {cht} {units}, EGT: {egt} {units}, RPM: {rpm}, manifold: {manifold} inches. ";
                        fireOnScreenReaderOutputEvent(isGauge: false, output: output);
                        break;
                }
            }
            if (Aircraft.EngineType.Value == 1)
            {
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
                fireOnScreenReaderOutputEvent(isGauge: false, output: $"Engine {eng}. ");
                fireOnScreenReaderOutputEvent(isGauge: false, output: $"N1: {Math.Round(N1)}. ");
                fireOnScreenReaderOutputEvent(isGauge: false, output: $"N2: {Math.Round(N2)}. ");
            }

        }

        private void onCurrentLocation()
        {
            var database = FSUIPCConnection.AirportsDatabase;
            database.SetReferenceLocation();
                        FsGate currentGate = null;
            FsTaxiway currentTaxiWay = null;
            FsRunway currentRunway = null;

            foreach (FsAirport airport in database.Airports)
            {
                foreach (FsGate gate in airport.Gates)
                {
                    if (gate.IsPlayerAtGate)
                    {
                        currentGate = gate;
                        break;
                    }
                } // Loop gates.
                foreach (FsRunway runway in airport.Runways)
                {
                    if (runway.IsPlayerOnRunway)
                                            {
                        currentRunway = runway;
                        break;
                    }
                } //Loop through runways.
                foreach (FsTaxiway taxiway in airport.Taxiways)
                {
                    if (taxiway.IsPlayerOnTaxiway)
                    {
                        currentTaxiWay = taxiway;
                        break;
                    }
                } // Loop through taxiways.
            } // loop through airports.
            
            if(currentTaxiWay != null && currentGate == null)
            {
                fireOnScreenReaderOutputEvent(isGauge: false, output: $"taxi way {currentTaxiWay.Name}@{currentTaxiWay.Airport.ICAO}");
            }
            else if(currentRunway != null)
            {
                fireOnScreenReaderOutputEvent(isGauge: false, output: $"runway {currentRunway.ID.ToString()}@{currentRunway.Airport.ICAO}");
            }
            else if(currentGate != null)
            {
                fireOnScreenReaderOutputEvent(isGauge: false, output: $"gate {currentGate.ID}@{currentGate.Airport.ICAO}");
            }
            else
            {
                fireOnScreenReaderOutputEvent(isGauge: false, output: $"{Aircraft.aircraftLat.Value}, {Aircraft.aircraftLon.Value}");
            }
        }                    
                    }
}
