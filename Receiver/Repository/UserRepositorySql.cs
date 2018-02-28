using Receiver.Model;
using Receiver.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static Receiver.Model.User;

namespace Receiver.Repository
{
    public class UserRepositorySql : IUserRepository
    {
        public void AddUser(RootObject rootObject)
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
