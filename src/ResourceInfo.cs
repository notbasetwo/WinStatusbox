using Hardware.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStatusbox
{
    internal class ResourceInfo
    {

        private CoreInfo info;
        private IHardwareInfo hardwareInfo;

        public ProcessorInfo cpu;
        public MemoryInfo memory;

        public ResourceInfo(CoreInfo info) {

            this.info = info;
            hardwareInfo = info.getInterface();
            cpu = new ProcessorInfo(hardwareInfo.CpuList);
            memory = new MemoryInfo(hardwareInfo.MemoryStatus);

        }

        public void Refresh()
        {
            info.Refresh();
            cpu = new ProcessorInfo(hardwareInfo.CpuList);
            memory = new MemoryInfo(hardwareInfo.MemoryStatus);
        }

    }
}
