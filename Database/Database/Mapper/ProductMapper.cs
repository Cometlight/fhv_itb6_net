using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FluentMap.Dommel.Mapping;
using Domain;

namespace Database.Mapper
{
    class ProductMapper : DommelEntityMap<Product>
    {
        public ProductMapper()
        {
            ToTable("product");

            Map(x => x.Id).ToColumn("product_id");
            Map(x => x.Name).ToColumn("product_name");
            Map(x => x.Description).ToColumn("product_description");
            Map(x => x.Image).ToColumn("product_image");
            Map(x => x.Number).ToColumn("product_number");
            Map(x => x.CategoryId).ToColumn("product_category_id");
            Map(x => x.SupplierId).ToColumn("product_supplier_id");
            Map(x => x.Price).ToColumn("product_price");
        }
    }
}
