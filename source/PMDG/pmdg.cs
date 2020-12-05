using FSUIPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace tfm
{
    class pmdg
    {
        /* This class contains functions for manipulating controls in the PMDG 737. 
         * Functions were ported from the PMDG 737 Linda module. */
        // constants for PMDG mouse click parameters
        public const int ClkL = 536870912;
        public const int ClkR = -2147483648;
        public const int Inc = 16384;
        public const int Dec = 8192;

        // overhead electrical
        // battery switch
        public void ElecBatteryOn()
        {
            // battery switch
            if (FSUIPCConnection.ReadLVar("switch_01_73X") != 100)
            {
                // battery switch guard
                if (FSUIPCConnection.ReadLVar("switch_02_73X") != 100)
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_BATTERY_GUARD, ClkR);
                    Thread.Sleep(50);
                }
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_BATTERY_SWITCH, ClkL);
                Thread.Sleep(250);
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_BATTERY_GUARD, ClkR);
            }
        }

        public void ElecBatteryOff()
        {
            // battery switch
            if (FSUIPCConnection.ReadLVar("switch_01_73X") != 0)
            {
                // battery switch guard
                if (FSUIPCConnection.ReadLVar("switch_02_73X") != 100)
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_BATTERY_GUARD, ClkR);
                    Thread.Sleep(50);
                }
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_BATTERY_SWITCH, ClkR);
            }
        }

        public void ElecBatteryToggle()
        {
            if (FSUIPCConnection.ReadLVar("switch_01_73X") != 100)
            {
                ElecBatteryOn();
            }
            else
            {
                ElecBatteryOff();
            }
        }

        // DC Meter Source
        public void ElecDCSource(int s)
        {
            if (s >= 0 && s <= 7)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_DC_METER, s);
            }

        }
        // AC Meter Source
        public void ElecACSource(int s)
        {
            if (s >= 0 && s <= 6)
            {
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_AC_METER, s);
            }

        }

        // Standby Power
        public void ElecStandbyBattery()
        {
            if (FSUIPCConnection.ReadLVar("switch_10_73X") != 0)
            {
                if (FSUIPCConnection.ReadLVar("switch_11_73X") != 100)
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_STBY_PWR_GUARD, ClkR);

                }
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_STBY_PWR_SWITCH, ClkL);
                Thread.Sleep(250);
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_STBY_PWR_SWITCH, ClkL);

            }
        }

        public void ElecStandbyOff()
        {
            if (FSUIPCConnection.ReadLVar("switch_10_73X") == 0)
            {
                if (FSUIPCConnection.ReadLVar("switch_11_73X") != 100)
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_STBY_PWR_GUARD, ClkR);
                    Thread.Sleep(50);
                }
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_STBY_PWR_SWITCH, ClkR);

            }
            if (FSUIPCConnection.ReadLVar("switch_10_73X") == 100)
            {
                if (FSUIPCConnection.ReadLVar("switch_11_73X") != 100)
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_STBY_PWR_GUARD, ClkL);
                    Thread.Sleep(50);
                }
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_STBY_PWR_SWITCH, ClkL);

            }
        }

        public void ElecStandbyAuto()
        {
            if (FSUIPCConnection.ReadLVar("switch_10_73X") != 100)
            {
                if (FSUIPCConnection.ReadLVar("switch_11_73X") != 100)
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_STBY_PWR_GUARD, ClkR);

                }
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_STBY_PWR_SWITCH, ClkR);
                Thread.Sleep(250);
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_STBY_PWR_SWITCH, ClkR);

            }
        }
        // Bus Transfer
        public void ElecBusTransferOff()
        {
            if (FSUIPCConnection.ReadLVar("switch_18_73X") != 0)
            {
                if (FSUIPCConnection.ReadLVar("switch_19_73X") != 100)
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_BUS_TRANSFER_GUARD, ClkR);
                }
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_BUS_TRANSFER_SWITCH, ClkL);
                FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_BUS_TRANSFER_SWITCH, ClkR);
            }
        }

        public void ElecBusTransferAuto()
        {
            if (FSUIPCConnection.ReadLVar("switch_18_73X") != 100)
            {
                if (FSUIPCConnection.ReadLVar("switch_19_73X") != 100)
                {
                    FSUIPCConnection.SendControlToFS(PMDG_737_NGX_Control.EVT_OH_ELEC_BUS_TRANSFER_GUARD, ClkR);
                }
            }
        }

    }
}
