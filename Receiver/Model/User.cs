using Sender;
using System;
using System.Collections.Generic;

using System.Text;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;

namespace Receiver.Model
{
    
    public class User : ValueObject
    {
        public class Geo
        {
            public string lat { get; set; }
            public string lng { get; set; }
        }

        public class Address
        {
            public string street { get; set; }
            public string suite { get; set; }
            public string city { get; set; }
            public string zipcode { get; set; }
            public Geo geo { get; set; }
        }

        public class Company
        {
            public string name { get; set; }
            public string catchPhrase { get; set; }
            public string bs { get; set; }
        }

        /// <summary>
        /// Mappings for Dapper
        /// </summary>
        [Table("[dbo].[Users]")]
        public class RootObject
        {
           
            public int id { get; set; }
            public string name { get; set; }
            public string username { get; set; }

            [ExplicitKey] //Fix that the [Key] tag will be a null value.
            public string email { get; set; }

            [Write(false)]
            [Computed]
            public Address address { get; set; }

            public string phone { get; set; }
            public string website { get; set; }

            [Write(false)]
            [Computed]
            public Company company { get; set; }
        }
    }
}
