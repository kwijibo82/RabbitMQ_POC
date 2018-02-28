using System;
using System.Collections.Generic;
using System.Text;

namespace Receiver.Service
{
    public class DatabaseManagerBase : IDataBaseManager
    {

        /// <summary>
        /// The current connection string settings.
        /// </summary>
        public static volatile ConnectionStringSettings CurrentConnectionStringSettings;

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

        public List<TripBK> getLastsTripsFromBK()
        {
            using (IDbConnection conn = GetOpenConnection())
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT *");
                    sb.Append("FROM [AXADrive].[dbo].[Trips]");
                    sb.Append("WHERE FromDate BETWEEN dateadd(day, datediff(day, 1, getdate()),0) AND dateadd(day, datediff(day, 0, getdate()), 0);");

                    return conn.Query<TripBK>(sb.ToString()).ToList();

                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void insertTrip(TripDIL trip)
        {
            using (IDbConnection conn = GetOpenConnection())
            {
                try
                {
                    foreach (var t in trip.trips)
                    {

                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO Trip_test_connectivity");
                        sb.Append(" (Distance, end_location, score, start_location, start_time, stop_time, trip_id, clientID) ");
                        sb.Append("VALUES (");
                        sb.Append("@Distance, ");
                        sb.Append("@end_location, ");
                        sb.Append("@score, ");
                        sb.Append("@start_location, ");
                        sb.Append("@start_time, ");
                        sb.Append("@stop_time, ");
                        sb.Append("@trip_id, ");
                        sb.Append("@clientID)");

                        string sql = sb.ToString();

                        Console.WriteLine($"Inserting trip {t.trip_id}");

                        conn.Execute(sql, new
                        {
                            Distance = t.distance,
                            end_location = t.end_location,
                            score = t.score,
                            start_location = t.start_location,
                            start_time = t.start_time,
                            stop_time = t.stop_time,
                            trip_id = t.trip_id,
                            clientID = trip.client_id
                        });
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }

}
