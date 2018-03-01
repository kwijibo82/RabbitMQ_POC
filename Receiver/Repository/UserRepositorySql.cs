using Dapper;
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
                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO [dbo].[User]");
                    sb.Append(" (id, name, username, email, phone, website) ");
                    sb.Append("VALUES (");
                    sb.Append("@Id, ");
                    sb.Append("@Name, ");
                    sb.Append("@Username, ");
                    sb.Append("@Email, ");
                    sb.Append("@Phone, ");
                    sb.Append("@Website)");

                    string sql = sb.ToString();

                    conn.Execute(sql, new
                    {
                        Id = r.id.ToString().Trim(),
                        Name = r.name.Trim(),
                        Username = r.username.Trim(),
                        Email = r.username.Trim(),
                        Phone = r.phone.Trim(),
                        Website = r.website.Trim()
                    });
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
