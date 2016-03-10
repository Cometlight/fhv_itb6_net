using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Address
    {
        public int? Id { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public int? Country { get; set; }

        public Address() { }

        public Address(string street, string houseNumber, string zipCode, string city, int country)
        {
            Street = street;
            HouseNumber = houseNumber;
            ZipCode = zipCode;
            City = city;
            Country = country;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Street: {Street}, HouseNumber: {HouseNumber}, ZipCode: {ZipCode}, City: {City}, Country: {Country}";
        }
    }
}
