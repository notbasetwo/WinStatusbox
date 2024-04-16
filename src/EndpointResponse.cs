using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WinStatusbox
{
    internal class EndpointResponse
    {

        private readonly HttpResponseMessage response;

        public EndpointResponse(HttpResponseMessage response) {
            this.response = response;

        }

    }
}
