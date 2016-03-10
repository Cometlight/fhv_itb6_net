using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Database.Mapper;

namespace Database
{
    public class DapperConfiguration
    {
        private static bool isInitialized;

        public static void Initialize()
        {
            if (!isInitialized)
            {
                FluentMapper.Initialize(config =>
                {
                    config.AddMap(new AddressMapper());
                    config.AddMap(new CartEntryMapper());
                    config.AddMap(new CartMapper());
                    config.AddMap(new CustomerMapper());
                    config.AddMap(new CustomerNotificationMapper());
                    config.AddMap(new DeliveryMapper());
                    config.AddMap(new InvoiceMapper());
                    config.AddMap(new OrderItemMapper());
                    config.AddMap(new OrderMapper());
                    config.AddMap(new ProductCategoryMapper());
                    config.AddMap(new ProductMapper());
                    config.AddMap(new ProductReviewMapper());
                    config.AddMap(new StockMapper());
                    config.AddMap(new SupplierMapper());
                    config.AddMap(new UserMapper());
                    config.AddMap(new WarehouseMapper());
                    config.ForDommel();
                });
                isInitialized = true;
            }
        }
    }
}
