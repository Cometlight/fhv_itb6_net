using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        private string email;
        private string password;

        public string Email { get; set; }
        public String Password { get; set; }

        public bool IsCorrectPassword(String password)
        {
            // TODO IsCorrectPassword
            return true;
        }
    }
}
