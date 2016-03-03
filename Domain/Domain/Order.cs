using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order
    {
        private DateTime date;
        private Customer customer;
        private ICollection<ProductItem> items;
        private Delivery delivery;
        private Invoice invoice;

        public DateTime Date { get; set; }
        public Customer Customer { get; set; }
        public ICollection<ProductItem> Items { get; set; }
        public Delivery Delivery { get; set; }
        public Invoice Invoice { get; set; }
    }
}
