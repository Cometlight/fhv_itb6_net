using Dapper.FluentMap.Dommel.Mapping;
using Domain;

namespace Database.Mapper
{
    class DeliveryMapper : DommelEntityMap<Delivery>
    {
        public DeliveryMapper()
        {
            ToTable("delivery");

            Map(x => x.Id).ToColumn("delivery_id");
            Map(x => x.CustomerId).ToColumn("delivery_customer_id");
            Map(x => x.OrderId).ToColumn("delivery_order_id");
            Map(x => x.Date).ToColumn("delivery_date");
            Map(x => x.Expected).ToColumn("delivery_expected");
        }
    }
}
