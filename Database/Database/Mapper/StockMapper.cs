using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FluentMap.Dommel.Mapping;
using Domain;

namespace Database.Mapper
{
    class StockMapper : DommelEntityMap<Stock>
    {
        public StockMapper()
        {
            ToTable("stock");

            Map(x => x.Id).ToColumn("stock_id");
            Map(x => x.ProductId).ToColumn("stock_product_id");
            Map(x => x.ProductCount).ToColumn("stock_product_count");
            Map(x => x.WarehouseId).ToColumn("stock_warehouse_id");
        }
    }
}
