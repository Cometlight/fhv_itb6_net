using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FluentMap.Dommel.Mapping;
using Domain;

namespace Database.Mapper
{
    class SupplierMapper : DommelEntityMap<Supplier>
    {
        public SupplierMapper()
        {
            ToTable("supplier");

            Map(x => x.Id).ToColumn("supplier_id");
            Map(x => x.Name).ToColumn("supplier_name");
        }
    }
}
