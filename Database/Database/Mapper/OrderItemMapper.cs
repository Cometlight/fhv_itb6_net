using Dapper.FluentMap.Dommel.Mapping;
using Domain;

namespace Database.Mapper
{
    class OrderItemMapper : DommelEntityMap<OrderItem>
    {
        public OrderItemMapper()
        {
            ToTable("orderitem");

            Map(x => x.Id).ToColumn("orderitem_id");
            Map(x => x.ProductId).ToColumn("orderitem_product_id");
            Map(x => x.ProductCount).ToColumn("orderitem_product_count");
            Map(x => x.Sequence).ToColumn("orderitem_sequence");
            Map(x => x.OrderId).ToColumn("orderitem_order_id");
            Map(x => x.Price).ToColumn("orderitem_price");
        }
    }
}
