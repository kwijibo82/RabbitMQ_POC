using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Configuration;

namespace Receiver.Service
{
    interface IDataBaseManager
    {
        /// <summary>
        /// The current connection string settings.
        /// </summary>
        /// 
        public static volatile ConnectionStringSettings CurrentConnectionStringSettings; //TODO: Add reference to System.Configuration

        public static readonly object Locker = new object();

        public static IDbConnection GetOpenConnection()
        {
            lock (Locker)
            {
                if (CurrentConnectionStringSettings == null)
                {
                    CurrentConnectionStringSettings = ConfigurationManager.ConnectionStrings["AXADrive"];
                }
            }

            var conn = new SqlConnection(CurrentConnectionStringSettings.ConnectionString);
            conn.Open();
            return conn;
        }

        //TODO: Continue from here, 
    }
}
