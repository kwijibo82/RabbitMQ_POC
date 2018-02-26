using System;
using System.Collections.Generic;
using System.Text;
using static Receiver.Model.User;

namespace Receiver.Model.DTO
{
    class UserDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public Company company { get; set; }
    }
}
