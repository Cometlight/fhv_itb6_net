using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FluentMap.Dommel.Mapping;
using Domain;

namespace Database.Mapper
{
    class ProductCategoryMapper : DommelEntityMap<ProductCategory>
    {
        public ProductCategoryMapper()
        {
            ToTable("productcategory");

            Map(x => x.Id).ToColumn("productcategory_id");
            Map(x => x.Name).ToColumn("productcategory_name");
        }
    }
}
