using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Sender.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using static Sender.Model.User;

namespace Sender.Controller 
{
    public class RestAPI
    {
       private readonly RestClient _client;

       public RestAPI()
       {
            _client = new RestClient("https://jsonplaceholder.typicode.com");
       }

       public IEnumerable<User> GetUserByUserName(string userId)
       {
            return null;
       }

       //TODO: Deserilize received data inside the Get() method.
       public List<RootObject> Get() 
       {
           var response = _client.Execute(RequestBuilder.CreateRequestState());
           var data = JsonConvert.DeserializeObject<List<RootObject>>(response);
           return data;
       }

    }

    public class RequestBuilder
    {
        public static HttpWebRequest CreateRequestState()
        {
            IRestRequest request = new RestRequest();
            //request.AddHeader("Postman-Token", "855916d5-0354-b992-a9cb-9eae4d4aaa5e"); //This example shows how to set a bearer
            //request.AddHeader("Cache-Control", "no cache");  
            return request.CreateWebRequest(Send.Startup());
        }
    }
}
