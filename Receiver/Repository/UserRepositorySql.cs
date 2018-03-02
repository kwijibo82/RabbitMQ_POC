using Dapper;
using Dapper.Contrib.Extensions;
using Receiver.Model;
using Receiver.Repository.Interfaces;
using Receiver.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using static Receiver.Model.User;

namespace Receiver.Repository
{
    public class UserRepositorySql : IUserRepository
    {
        public void AddUser(RootObject r)
        {
            using (IDbConnection conn = DatabaseManager.GetOpenConnection())
            {
                try
                {
                    conn.Insert(
                             new RootObject { id = r.id, name = r.name, username = r.username, email = r.email, phone = r.phone, website = r.website }
                         );

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("\nDATA INSERTED SUCCESFULLY!");
                    Console.ResetColor();
                    
                }
                catch (SqlException ex)  //TODO: Improve with custom exceptions
                {
                    switch (ex.Number)
                    {
                        case 2627:
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\nError: 2627, duplicated PRIMARY KEY!, The data was not inserted.");
                            Console.ResetColor();
                            break;
                        default:
                            break;
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
        }


        public List<User> GetModels()
        {
            throw new NotImplementedException();
        }

        public User GetUserByID()
        {
            throw new NotImplementedException();
        }
    }
}
