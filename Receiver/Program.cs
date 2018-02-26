using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Receiver.Model;
using Receiver.Service;
using System;
using System.Collections.Generic;
using System.Text;
using static Receiver.Model.User;

namespace Receiver
{
    class Receive
    {
        public static void Main()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("RECEIVER");
            Console.ResetColor();

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
                User u = JsonConvert.DeserializeObject<User>(jsonified);
                Console.WriteLine(jsonified);
                model.BasicAck(deliveryArguments.DeliveryTag, false);
            }
        }

        public void Startup() //Utiliar la interfaz IHostingEnvironment pasada como parámetro E.j. public string Startup(IHostingEnvironment)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath($"C:\\Users\\JCHACON\\Source\\Repos\\RabbitMQ_POC\\Receiver"); //"des-hardcodear"
            builder.AddJsonFile("appsettings.json", false, true);
            var configuration = builder.Build();
        }
    }
}
