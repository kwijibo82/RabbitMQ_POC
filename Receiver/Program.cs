using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Receiver.Model;
using Receiver.Service;
using System;
using System.Text;
using static Receiver.Model.User;

namespace Receiver
{
    class Receive
    {
        public static void Main()
        {
            highlightText("red");
            Console.Write("RECEIVER\n");
            unHighlightText();
            CommonService commonService = new CommonService();
            IConnection connection = commonService.GetRabbitMqConnection();
            IModel model = connection.CreateModel();
            ReceiveSerialisationMessages(model);
        }

        private static void ReceiveSerialisationMessages(IModel model)
        {
            model.BasicQos(0, 1, false);
            QueueingBasicConsumer consumer = new QueueingBasicConsumer(model);
            model.BasicConsume(CommonService.SerialisationQueueName, false, consumer);
            while (true)
            {
                BasicDeliverEventArgs deliveryArguments = consumer.Queue.Dequeue() as BasicDeliverEventArgs;
                String jsonified = Encoding.UTF8.GetString(deliveryArguments.Body);
                RootObject r = JsonConvert.DeserializeObject<RootObject>(jsonified); //Store this data using Dapper
                highlightText("blue");
                Console.WriteLine(r.name);
                unHighlightText();
                string jsonFormatted = JValue.Parse(jsonified).ToString(Formatting.Indented);
                Console.WriteLine(jsonFormatted);
                model.BasicAck(deliveryArguments.DeliveryTag, false);
            }
        }

        public void Startup() 
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath($"C:\\Users\\JCHACON\\Source\\Repos\\RabbitMQ_POC\\Receiver"); //"des-hardcodear"
            builder.AddJsonFile("appsettings.json", false, true);
            var configuration = builder.Build();
        }

        public static void highlightText(string color)
        {
            if (color.Equals("red"))
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (color.Equals("blue"))
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (color.Equals("green"))
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
            }
            //TODO: Add more colors
            
        }

        public static void unHighlightText()
        {
            Console.ResetColor();
        }
    }
}
