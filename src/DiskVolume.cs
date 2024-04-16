using Hardware.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStatusbox
{
    internal class DiskVolume
    {
        public readonly string name;
        public readonly ulong capacity;
        private readonly Volume vol;
        public DiskVolume(Volume volume) {
            name = volume.Name;
            capacity = volume.Size;

            vol = volume;
        }

    }
}
