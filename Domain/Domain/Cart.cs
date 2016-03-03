using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Cart
    {
        private IDictionary<Product, int /* amount */> entries;

        public IDictionary<Product, int> Entries { get; set; }
    }
}
