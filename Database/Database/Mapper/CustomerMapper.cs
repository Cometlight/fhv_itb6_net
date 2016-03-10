using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FluentMap.Dommel.Mapping;
using Domain;

namespace Database.Mapper
{
    class CustomerMapper : DommelEntityMap<Customer>
    {
        public CustomerMapper()
        {
            ToTable("customer");

            Map(x => x.Id).ToColumn("customer_id");
            Map(x => x.FirstName).ToColumn("customer_firstname");
            Map(x => x.LastName).ToColumn("customer_lastname");
            Map(x => x.AddressId).ToColumn("customer_address_id");
            Map(x => x.UserId).ToColumn("customer_user_id");
        }
    }
}
