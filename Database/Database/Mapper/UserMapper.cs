using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FluentMap.Dommel.Mapping;
using Domain;

namespace Database.Mapper
{
    class UserMapper : DommelEntityMap<User>
    {
        public UserMapper()
        {
            ToTable("user");

            Map(x => x.Id).ToColumn("user_id");
            Map(x => x.Login).ToColumn("user_login");
            Map(x => x.Password).ToColumn("user_password");
        }
    }
}
