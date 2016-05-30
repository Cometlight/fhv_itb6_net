using Dapper.FluentMap.Dommel.Mapping;
using Domain;

namespace Database.Mapper
{
    class OrderMapper : DommelEntityMap<Order>
    {
        public OrderMapper()
        {
            ToTable("order");

            Map(x => x.Id).ToColumn("order_id");
            Map(x => x.Date).ToColumn("order_date");
            Map(x => x.CustomerId).ToColumn("order_customer_id");
        }
    }
}
