using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Warehouse
    {
        private IDictionary<Product, int /* amount */> products;

        public ICollection<Product> GetProductsAll()
        {
            if (products == null)   // TODO Check if null check necessary...
            {
                return new Collection<Product>();
            }
            return products.Keys;
        }

        public ICollection<Product> GetProductsAvailable()
        {
            if (products == null)   // TODO Check if null check necessary...
            {
                return new Collection<Product>();
            }
            return products.Where(kvp => kvp.Value > 0)
                .Select(kvp => kvp.Key)
                .ToList();
        }
    }
}
