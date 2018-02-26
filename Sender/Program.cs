using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Sender.Controller;
using Sender.Service;
using System;
using System.Collections;
using System.Text;

namespace Sender
{

    //Doc: https://dotnetcodr.com/messaging/
    class Send
    {
        public static void Main()
        {
            CommonService commonService = new CommonService();
            IConnection connection = commonService.GetRabbitMqConnection();
            IModel model = connection.CreateModel();
            SetupSerialisationMessageQueue(model);
            RunSerialisation(model);
        }

        private static void SetupSerialisationMessageQueue(IModel model)
        {
            model.QueueDeclare(CommonService.SerialisationQueueName, true, false, false, null);
        }

        private static void RunSerialisation(IModel model)
        {  
            RestAPI r = new RestAPI();
            String jsonified = null;
            byte[] userBuffer = null;
            IBasicProperties basicProperties = model.CreateBasicProperties();
            basicProperties.SetPersistent(true);

            foreach (var item in r.Get())
            {
                jsonified = JsonConvert.SerializeObject(item);
                userBuffer = Encoding.UTF8.GetBytes(jsonified);
                model.BasicPublish("", CommonService.SerialisationQueueName, basicProperties, userBuffer);
            }
          

        }

        public static string Startup() //Utiliar la interfaz IHostingEnvironment pasada como parámetro E.j. public string Startup(IHostingEnvironment)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath($"C:\\Users\\JCHACON\\Source\\Repos\\RabbitMQ_POC\\Sender"); //"des-hardcodear"
            builder.AddJsonFile("appsettings.json", false, true);
            var configuration = builder.Build();

            return configuration["SiteSettings:reqStr"];
        }
    }
}
