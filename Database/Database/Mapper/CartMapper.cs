using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FluentMap.Dommel.Mapping;
using Domain;

namespace Database.Mapper
{
    class CartMapper : DommelEntityMap<Cart>
    {
        public CartMapper()
        {
            ToTable("cart");

            Map(x => x.Id).ToColumn("cart_id");
            Map(x => x.CustomerId).ToColumn("cart_customer_id");
        }
    }
}
