using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ProductItem
    {
        private string name;
        private decimal price;
        private Supplier supplier;
        private int amount;

        public string Name { get; set; }
        public decimal Price { get; set; }
        public Supplier Supplier { get; set; }
        public int Amount { get; set; }
    }
}
