using Hardware.Info;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinStatusbox
{
    internal class SystemInfo
    {

        private static IHardwareInfo hardwareInfo;

        public readonly string systemName;
        public readonly string cpuName;
        public readonly uint cpuCores;
        public readonly ulong totalMemory;
        public readonly string[] gpuName;
        public readonly string osName;
        public readonly StorageDevice[] storageDevices;
        public readonly NetworkDevice[] networkDevices;


        public SystemInfo(CoreInfo core) {

            // Set interface
            hardwareInfo = core.getInterface();

            // Set information
            systemName = System.Environment.MachineName;
            cpuName = HwCpuName();
            cpuCores = HwCpuCores();
            totalMemory = HwTotalMemory();
            gpuName = HwGpuName();
            osName = HwOsName();
            storageDevices = HwStorageDevice();
            networkDevices = HwNetworkDevice();
                      
        }

        /*
         * Get the CPU name of the system
         * - This implementation currently assumes all CPUs in the system are the same
         * - and grabs the name from the first CPU.
         */
        private string HwCpuName()
        {
            String cpu = hardwareInfo.CpuList[0].Name;
            return cpu;
        }

        /*
         * Calculate number of CPU Cores in the system
         */
        private uint HwCpuCores()
        {
            uint cpuCores = 0;
            foreach ( var cpu in hardwareInfo.CpuList )
            {
                cpuCores += cpu.NumberOfCores;
            }
            return cpuCores;
        }

        /*
         * Get the total memory capacity of the system
         */
        private ulong HwTotalMemory()
        {
            ulong totalMemory = hardwareInfo.MemoryStatus.TotalPhysical;
            return totalMemory;
        }

        /*
         * Get the names of the GPUs on the system
         */
        private string[] HwGpuName()
        {
            List<string> gpuList = new List<String>();

            foreach ( var gpu in hardwareInfo.VideoControllerList )
            {
                gpuList.Add(gpu.Name);
            }

            string[] gpuArray = gpuList.ToArray();
            return gpuArray;

        }

        /*
         * Get the operating system
         */
        private string HwOsName()
        {
            string osName = hardwareInfo.OperatingSystem.Name;
            return osName;
        }

        /*
         * Get storage devices
         */
        private StorageDevice[] HwStorageDevice()
        {
            List<StorageDevice> storageList = new List<StorageDevice>();

            foreach ( var storage in hardwareInfo.DriveList )
            {
                StorageDevice storageDevice = new StorageDevice(storage);
                storageList.Add(storageDevice);
            }

            StorageDevice[] storageArray = storageList.ToArray();
            return storageArray;
        }

        /*
         * Get network devices
         */
        private NetworkDevice[] HwNetworkDevice()
        {
            List<NetworkDevice> networkList = new List<NetworkDevice>();

            foreach ( var adapter in hardwareInfo.NetworkAdapterList )
            {
                NetworkDevice networkDevice = new NetworkDevice(adapter);
                networkList.Add(networkDevice);
            }

            NetworkDevice[] networkArray = networkList.ToArray();
            return networkArray;
        }

        public string MakeJson()
        {
            return JsonConvert.SerializeObject(this);
        }

    }

}
