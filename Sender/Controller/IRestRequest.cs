using System.Net;

namespace Sender.Controller
{
    public interface IRestRequest
    {
        void AddHeader(string v1, string v2);

        HttpWebRequest CreateWebRequest(string reqStr);
   
    }
}