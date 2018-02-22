using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Receiver
{
    class Receive
    {
        public static void Main()
        {
            //Receive receive = new Receive();
            //receive.Startup();

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                    Console.ReadLine();
                };
                channel.BasicConsume(queue: "hello", autoAck: true, consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }

        public string Startup() //Utiliar la interfaz IHostingEnvironment pasada como parámetro E.j. public string Startup(IHostingEnvironment)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath($"C:\\Users\\JCHACON\\Source\\Repos\\RabbitMQ_POC\\Receiver"); //"des-hardcodear"
            builder.AddJsonFile("appsettings.json", false, true);
            var configuration = builder.Build();

            // return configuration["SiteSettings:reqStr"];
            return null;
        }
    }
}
