using Hardware.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStatusbox
{
    internal class ProcessorInfo
    {

        private List<CPU> cpus;

        public readonly uint[] clockSpeeds;
        public readonly ulong[] cpuUtil;


        public ProcessorInfo(List<CPU> cpus) { 
            this.cpus = cpus;
            clockSpeeds = HwClockSpeeds();
            cpuUtil = HwProcessorTime();
        }

        public uint[] HwClockSpeeds()
        {
            List<uint> clockSpeeds = new List<uint>();
            foreach ( var cpu in cpus )
            {
                clockSpeeds.Add(cpu.CurrentClockSpeed);
         
            }
            uint[] clockArray = clockSpeeds.ToArray(); 
            return clockArray;
        }

        public ulong[] HwProcessorTime()
        {
            List<ulong> processorTimes = new List<ulong>();
            foreach ( var cpu in cpus )
            {
                processorTimes.Add(cpu.PercentProcessorTime);
            }
            ulong[] timeArray = processorTimes.ToArray();
            return timeArray;
        }
       
    }
}
