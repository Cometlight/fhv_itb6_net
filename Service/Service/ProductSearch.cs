using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Service
{
    public class ProductSearch
    {
        // not static because there might be some configuration or caching later on
        public ICollection<Product> Search(IEnumerable<Product> candidates, int? id = null, string number = null, string name = null,
            decimal? minPrice = null, decimal? maxPrice = null, int? productCategoryId = null, int? supplierId = null)
        {
            ICollection<Product> productsFiltered = candidates
                .Where(p => id == null || p.Id == id)
                .Where(p => number == null || p.Number == number)
                .Where(p => name == null || p.Name == name)
                .Where(p => minPrice == null || p.Price >= minPrice)
                .Where(p => maxPrice == null || p.Price <= maxPrice)
                .Where(p => productCategoryId == null || p.CategoryId == productCategoryId)
                .Where(p => supplierId == null || p.SupplierId == supplierId).ToList();

            return productsFiltered;
        } 
    }
}
