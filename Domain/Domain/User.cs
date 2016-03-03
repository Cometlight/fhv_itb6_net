using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class User
    {
        private string username;
        public string Username { get; set; }

        private string password;
        public String Password { get; set; }

        private Address address;
        public Address Address { get; set; }
    }
}
