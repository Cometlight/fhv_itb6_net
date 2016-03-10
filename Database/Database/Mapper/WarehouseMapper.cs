using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FluentMap.Dommel.Mapping;
using Domain;

namespace Database.Mapper
{
    class WarehouseMapper : DommelEntityMap<Warehouse>
    {
        public WarehouseMapper()
        {
            ToTable("warehouse");

            Map(x => x.Id).ToColumn("warehouse_id");
            Map(x => x.Name).ToColumn("warehouse_name");
        }
    }
}
