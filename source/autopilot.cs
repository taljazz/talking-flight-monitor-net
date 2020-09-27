using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm
{
    public class Autopilot
    {
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


    }
}
