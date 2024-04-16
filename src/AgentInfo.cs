using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WinStatusbox
{
    internal class AgentInfo
    {

        public readonly string version;
        public readonly string type;
        public readonly string license;
        public AgentInfo() {
            version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            type = "windows";
            license = "enterprise";
        }

    }
}
