using System;
using System.IO;
using System.Net;

namespace Sender.Controller
{
    internal class RestClient : IRestClient
    {
        private string v;

        public RestClient(string v)
        {
            this.v = v;
        }

        public HttpWebResponse Execute(string reqStr)
        {
            string receivedData;
            HttpWebRequest req = (HttpWebRequest )WebRequest
                   .Create(reqStr);

            req.ContentType = "application/json";
            var response = (HttpWebResponse) req.GetResponse();

            return response;
        }

        internal object Execute(IRestRequest restRequest)
        {
            throw new NotImplementedException();
        }
    }
}