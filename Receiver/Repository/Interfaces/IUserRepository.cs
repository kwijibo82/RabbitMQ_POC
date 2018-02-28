using Receiver.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static Receiver.Model.User;

namespace Receiver.Repository.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetModels();

        User GetUserByID();

        void AddUser(RootObject rootObject);
    }
}
