using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace WinStatusbox
{
    internal class ReportScheduler
    {

        public System.Timers.Timer timer;
        private EndpointReport endpointReport;
        private EndpointRequest endpointRequest;
        private int timerDuration;

        public ReportScheduler(EndpointReport report, EndpointRequest request) {

            endpointReport = report;
            endpointRequest = request;

            timerDuration = Int32.Parse(ConfigurationSettings.AppSettings.Get("Interval")) * 1000;

            timer = new System.Timers.Timer(60000);
            timer.Elapsed += TickEvent;

            RunSchedule();

        }

        private void TickEvent(object sender, EventArgs e)
        {
            endpointReport.Refresh();
            endpointRequest.Body = endpointReport.GetJson();
            endpointRequest.MakeRequest();
            Console.WriteLine("Request Made!");
        }

        private void RunSchedule()
        {
            timer.Start();
        }
        

        public void EndSchedule()
        {
            timer.Stop();
            timer.Enabled = false;
        }

        


    }
}
