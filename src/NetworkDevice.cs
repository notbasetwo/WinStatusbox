using Hardware.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStatusbox
{
    internal class NetworkDevice
    {

        public readonly String name;
        public readonly ulong speed;


        public NetworkDevice(NetworkAdapter adapter)
        {
            name = adapter.Name; 
            speed = adapter.Speed;
        }

    }
}
