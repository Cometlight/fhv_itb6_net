using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ProductCategory
    {
        private string name;
        private ICollection<Product> products;

        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
