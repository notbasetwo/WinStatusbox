using Hardware.Info;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStatusbox
{
    internal class EndpointReport
    {
        [JsonProperty]
        private AgentInfo agent;
        [JsonProperty]
        private SystemInfo system;
        [JsonProperty]
        private ResourceInfo resources;

        public EndpointReport(CoreInfo core) {

            agent = new AgentInfo();
            system = new SystemInfo(core);
            resources = new ResourceInfo(core);

        }

        public void Refresh()
        {
            resources.Refresh();
        }

        public string GetJson()
        {
            string Json = JsonConvert.SerializeObject(this);
            return Json;
        }



    }
}
