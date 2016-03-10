using Dapper.FluentMap.Mapping;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FluentMap.Dommel.Mapping;

namespace Database.Mapper
{
    class AddressMapper : DommelEntityMap<Address>
    {
        public AddressMapper()
        {
            ToTable("address");

            Map(x => x.Id).ToColumn("address_id");
            Map(x => x.Street).ToColumn("address_street");
            Map(x => x.HouseNumber).ToColumn("address_housenumber");
            Map(x => x.ZipCode).ToColumn("address_zipcode");
            Map(x => x.City).ToColumn("address_city");
            Map(x => x.Country).ToColumn("address_country");
        }
    }
}
