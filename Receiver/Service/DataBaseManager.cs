using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Receiver.Service
{
    public class DatabaseManager 
    {
        /// <summary>
        /// The current connection string settings.
        /// </summary>
        public static volatile string conString = Receive.Startup();

        public static readonly object Locker = new object();

        public static IDbConnection GetOpenConnection()
        {
            lock (Locker)
            {
                if (conString == null)
                {
                    conString = Receive.Startup();
                }
            }

            var conn = new SqlConnection(conString);
            conn.Open();
            return conn;
        }

    }

}
