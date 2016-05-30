using Dapper.FluentMap.Dommel.Mapping;
using Domain;

namespace Database.Mapper
{
    class CartEntryMapper : DommelEntityMap<CartEntry>
    {
        public CartEntryMapper()
        {
            ToTable("cartentry");

            Map(x => x.Id).ToColumn("cartentry_id");
            Map(x => x.ProductId).ToColumn("cartentry_product_id");
            Map(x => x.ProductCount).ToColumn("cartentry_product_count");
            Map(x => x.Sequence).ToColumn("cartentry_sequence");
            Map(x => x.CartId).ToColumn("cartentry_cart_id");
        }
    }
}
