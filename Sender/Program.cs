using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Sender.Controller;
using System;
using System.Text;

namespace Sender
{
    class Send
    {
        public static void Main()
        {          
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

                RestAPI r = new RestAPI();
                var message = JsonConvert.SerializeObject(r.Get());
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);
                Console.WriteLine(" [x] Sent {0}", message);
                Console.ReadLine();
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
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
