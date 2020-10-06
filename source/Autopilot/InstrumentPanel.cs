using FSUIPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm
{
    public class InstrumentPanel
    {
        private double aslAltitude;
        public double AslAltitude
        {
            get
            {
                aslAltitude = Math.Round((double)Aircraft.Altitude.Value, 0);
                return aslAltitude;
            }
        }
        private double heading;
        public double Heading
        {
            get
            {
                heading = (double)Math.Round(Aircraft.CompassHeading.Value);
                return heading;
            }
        }
        private double aglAltitude;
        public double AglAltitude
        {
            get
            {
                double groundAlt = (double)Aircraft.GroundAltitude.Value / 256d * 3.28084d;
                aglAltitude = (double)Aircraft.Altitude.Value - groundAlt;
                return Math.Round(aglAltitude);
            }
        }
        private double indicatedAirspeed;
        public double IndicatedAirspeed
        {
            get
            {
                indicatedAirspeed = (double)Aircraft.AirspeedIndicated.Value / 128d;
                return Math.Round(indicatedAirspeed);
            }
        }
        private double trueAirspeed;
        public double TrueAirspeed
        {
            get
            {
                trueAirspeed = (double)Aircraft.AirspeedTrue.Value / 128d;
                return Math.Round(trueAirspeed);
            }
        }
        private double machSpeed;
        public double MachSpeed
        {
            get
            {
                machSpeed = (double)Aircraft.AirspeedMach.Value / 20480d;
                return Math.Round(machSpeed, 2);
            }
        }
        private double latitude;
        public double Latitude
        {
            get
            {
                latitude = Aircraft.aircraftLat.Value.DecimalDegrees;
                return latitude;
            }
        }
        
        private double longitude;
        public double Longitude
        {
            get
            {
                longitude = Aircraft.aircraftLon.Value.DecimalDegrees;
                return longitude;
            }
        }
        
        private double verticalSpeed;
        public double VerticalSpeed
        {
            get
            {
                verticalSpeed = (double)Aircraft.VerticalSpeed.Value * 3.28084d * -1;
                return Math.Round(verticalSpeed);
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
        private double apHeading;
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
        private double apAltitude;
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
        
        private decimal com1StandbyFreq;
        [DisplayName("com 1 Standby")]
        [Category("communications")]
        public decimal Com1StandbyFreq
        {
            get
            {
                FsFrequencyCOM com1StandbyHelper = new FsFrequencyCOM(Aircraft.Com1StandbyFreq.Value);
                com1StandbyFreq = com1StandbyHelper.ToDecimal();
                return com1StandbyFreq;
            }
            set
            {
                if (value > 0)
                {
                    // 1. Create a new instance of the COM helper class using the decimal value entered
                    FsFrequencyCOM com1StandbyHelper = new FsFrequencyCOM(value);
                    // 2. Now use the helper class to get the BCD value required by FSUIPC and set the offset to this new value
                    Aircraft.Com1StandbyFreq.Value = com1StandbyHelper.ToBCD();
                    com1StandbyFreq = value;
                }
                else
                {
                    throw new ArgumentException("com 1 standby frequency must be greater than 0");
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



    }
}
