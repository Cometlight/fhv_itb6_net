using Dapper.FluentMap.Dommel.Mapping;
using Domain;

namespace Database.Mapper
{
    class CustomerNotificationMapper : DommelEntityMap<CustomerNotification>
    {
        public CustomerNotificationMapper()
        {
            ToTable("customernotification");

            Map(x => x.Id).ToColumn("customernotification_id");
            Map(x => x.CustomerId).ToColumn("customernotification_customer_id");
            Map(x => x.OrderId).ToColumn("customernotification_order_id");
            Map(x => x.Date).ToColumn("customernotification_date");
            Map(x => x.Message).ToColumn("customernotification_message");
        }
    }
}
