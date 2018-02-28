using Receiver.Model;
using Receiver.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Receiver.Repository
{
    public class UserRepositorySql : IUserRepository
    {
        //TODO: Develop with Dapper
        public void AddUser(User.RootObject rootObject)
        {
            throw new NotImplementedException();
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
