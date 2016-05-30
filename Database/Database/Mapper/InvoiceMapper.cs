using Dapper.FluentMap.Dommel.Mapping;
using Domain;

namespace Database.Mapper
{
    class InvoiceMapper : DommelEntityMap<Invoice>
    {
        public InvoiceMapper()
        {
            ToTable("invoice");

            Map(x => x.Id).ToColumn("invoice_id");
            Map(x => x.Date).ToColumn("invoice_date");
            Map(x => x.CustomerId).ToColumn("invoice_customer_id");
            Map(x => x.OrderId).ToColumn("invoice_order_id");
        }
    }
}
