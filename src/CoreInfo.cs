using Hardware.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStatusbox
{
    internal class CoreInfo
    {

        // Create HW info class
        static IHardwareInfo hardwareInfo;

        public CoreInfo()
        {
            // Create new instance
            hardwareInfo = new HardwareInfo();

            // Perform first refresh
            Refresh();

        }

        /**
         * Refresh information from relevant system(s).
         */
        public void Refresh()
        {
            hardwareInfo.RefreshAll();
        }

    
        /* Get direct access to hardware info */
        public IHardwareInfo getInterface()
        {
            return hardwareInfo;
        }

    }
}
