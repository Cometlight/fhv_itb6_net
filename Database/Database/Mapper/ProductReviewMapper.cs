using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FluentMap.Dommel.Mapping;
using Domain;

namespace Database.Mapper
{
    class ProductReviewMapper : DommelEntityMap<ProductReview>
    {
        public ProductReviewMapper()
        {
            ToTable("productreview");

            Map(x => x.Id).ToColumn("productreview_id");
            Map(x => x.ProductId).ToColumn("productreview_product_id");
            Map(x => x.Text).ToColumn("productreview_text");
            Map(x => x.CustomerId).ToColumn("productreview_customer_id");
            Map(x => x.Points).ToColumn("productreview_points");
        }
    }
}
