using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FluentMap;
using Database.Mapper;

namespace Database
{
    public class DapperConfiguration
    {
        private static bool mapped;
        public static void Map()
        {
            if (!mapped)
            {
                FluentMapper.Initialize(config =>
                {
                    config.AddMap(new AddressMapper());
                });
                mapped = true;
            }
        }
    }
}
