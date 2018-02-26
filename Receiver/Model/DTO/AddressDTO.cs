using System;
using System.Collections.Generic;
using System.Text;
using static Receiver.Model.User;

namespace Receiver.Model.DTO
{
    class AddressDTO
    {

        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public Geo geo { get; set; }
    }

}
