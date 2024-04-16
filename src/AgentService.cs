using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinStatusbox
{
    public partial class AgentService : ServiceBase
    {

        CoreInfo core;
        EndpointReport ep;
        EndpointRequest er;
        ReportScheduler rs;

        public AgentService()
        {
            InitializeComponent();

            core = new CoreInfo();
            ep = new EndpointReport(core);
            er = new EndpointRequest("", ep.GetJson());           

        }

        protected override void OnStart(string[] args)
        {
            er.MakeRequest();
            rs = new ReportScheduler(ep, er);
        }

        protected override void OnStop()
        {
            rs.timer.Enabled = false;
            rs.timer.Stop();
        }
    }
}
