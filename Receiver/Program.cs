using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Receiver.Model;
using Receiver.Repository;
using Receiver.Service;
using Sender;
using System;
using System.Collections.Generic;
using System.Text;
using static Receiver.Model.User;

namespace Receiver
{
    //DOC: Pattern to acces a database: https://stackoverflow.com/questions/29350741/whats-the-best-approach-design-pattern-to-access-database-in-c
    class Receive
    {
        public static Text t = new Text();

        public static void Main()
        {
            t.highlightText("red");
            t.write("RECEIVER\n");
            t.unHighlightText();
            CommonService commonService = new CommonService();
            IConnection connection = commonService.GetRabbitMqConnection();
            IModel model = connection.CreateModel();
            ReceiveSerialisationMessages(model);
        }

        //TODO: Store rest of data
        //TODO: Code review and musts
        private static void ReceiveSerialisationMessages(IModel model)
        {
            model.BasicQos(0, 1, false);
            QueueingBasicConsumer consumer = new QueueingBasicConsumer(model);
            model.BasicConsume(CommonService.SerialisationQueueName, false, consumer);

            uint test = model.MessageCount("SerialisationDemoQueue"); 

            while (test >= 0)
            {
                test = model.MessageCount("SerialisationDemoQueue");
                BasicDeliverEventArgs deliveryArguments = consumer.Queue.Dequeue() as BasicDeliverEventArgs;
                String jsonified = Encoding.UTF8.GetString(deliveryArguments.Body);
                RootObject r = JsonConvert.DeserializeObject<RootObject>(jsonified); 
                var rootObjectList = new List<RootObject>();
                rootObjectList.Add(r);
                t.highlightText("blue");
                t.write(r.name);
                UserRepositorySql repo = new UserRepositorySql();
                repo.AddUser(r);
                t.unHighlightText();
                string jsonFormatted = JValue.Parse(jsonified).ToString(Formatting.Indented);
                t.write(jsonFormatted);
                model.BasicAck(deliveryArguments.DeliveryTag, false);
            }
        }

        public static string Startup() 
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath($"C:\\Users\\JCHACON\\Source\\Repos\\RabbitMQ_POC\\Receiver"); //"des-hardcodear"
            builder.AddJsonFile("appsettings.json", false, true);
            var configuration = builder.Build();

            return configuration["SiteSettings:connectionStr"];
        }

    }
}
