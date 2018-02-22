using Microsoft.Extensions.Configuration;
using Sender.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;

namespace Sender.Controller 
{
    class RestAPI
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
        //TODO: Continue here tomorrow, add JsonNewtonSoft and deserilize received data inside the Get() method.
        private string Get()
        {
            IRestRequest request = requestBuilder(); //<-- Solve this
            var response = _client.Execute(RequestBuilder.CreateRequestState());

        }
    }

    public class RequestBuilder
    {
        public static IRestRequest CreateRequestState()
        {
            IRestRequest request = new RestRequest();
            //request.AddHeader("Postman-Token", "855916d5-0354-b992-a9cb-9eae4d4aaa5e"); //This example shows how to set a bearer
            request.AddHeader("Cache-Control", "no cache");  
            request.CreateWebRequest(Send.Startup());

            return request; 
        }
    }
}
