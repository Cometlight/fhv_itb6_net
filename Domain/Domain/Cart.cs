using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Cart : IId
    {
        public int? Id { get; set; }
        public int? CustomerId { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, CustomerId: {CustomerId}";
        }
    }
}
