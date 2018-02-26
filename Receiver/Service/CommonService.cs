using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Receiver.Service
{
    public class CommonService
    {
        private string _hostName = "localhost";
        private string _userName = "guest";
        private string _password = "guest";

        public static string SerialisationQueueName = "SerialisationDemoQueue";

        public IConnection GetRabbitMqConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = _hostName;
            connectionFactory.UserName = _userName;
            connectionFactory.Password = _password;

            return connectionFactory.CreateConnection();
        }

    }
}
