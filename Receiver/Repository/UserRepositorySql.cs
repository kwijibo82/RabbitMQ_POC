using Dapper;
using Dapper.Contrib.Extensions;
using Receiver.Model;
using Receiver.Repository.Interfaces;
using Receiver.Service;
using System;
using System.Collections.Generic;
using System.Data;
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

                    var identity = conn.Insert(

                        new RootObject { id = r.id, name = r.name, username = r.username, email = r.email, phone = r.phone, website = r.website }

                        );

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
