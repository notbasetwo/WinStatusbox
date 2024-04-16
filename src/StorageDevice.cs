using Hardware.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WinStatusbox
{
    internal class StorageDevice
    {

        private readonly Drive drive;
        public readonly string name;
        public readonly ulong capacity;
        public readonly DiskVolume[] volumes;

        public StorageDevice(Drive drive) {

            this.drive = drive;
            name = drive.Name;
            capacity = drive.Size;
            volumes = GetVolumes();

        }

        private DiskVolume[] GetVolumes()
        {
            List<DiskVolume> diskVolumes = new List<DiskVolume>();

            foreach ( var partition in drive.PartitionList )
            {
                foreach ( var volume in partition.VolumeList)
                {
                    DiskVolume vol = new DiskVolume(volume);
                    diskVolumes.Add(vol);
                }
            }

            DiskVolume[] diskArray = diskVolumes.ToArray();
            return diskArray;
        }


    }
}
