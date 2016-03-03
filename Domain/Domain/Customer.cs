using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Customer : User
    {
        private string firstName;
        private string lastName;
        private Address address;
        private Cart cart;
        private ICollection<Order> orders;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public Cart Cart { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
