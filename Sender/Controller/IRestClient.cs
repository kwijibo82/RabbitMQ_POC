using System.Net;

namespace Sender.Controller
{
    public interface IRestClient
    {
        HttpWebResponse Execute(string reqStr);
    }
}