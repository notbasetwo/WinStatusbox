using Hardware.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStatusbox
{
    internal class MemoryInfo
    {

        private MemoryStatus memoryStatus;
        public readonly ulong memoryAvailable;

        public MemoryInfo(MemoryStatus status) {
            memoryStatus = status;
            memoryAvailable = status.AvailablePhysical;
        }


    }
}
