using System.Net;

namespace Sender.Controller
{
    internal class RestRequest : IRestRequest
    {
        private string v;

        public object Method { get; set; }

        public void AddHeader(string v1, string v2)
        {
            throw new System.NotImplementedException();
        }

        public HttpWebRequest CreateWebRequest(string reqStr)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(reqStr);
            req.ContentType = "application/json";

            return req;
        }
    }
}