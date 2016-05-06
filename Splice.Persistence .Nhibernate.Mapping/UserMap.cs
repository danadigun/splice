using FluentNHibernate.Mapping;
using Splice.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.Persistence.Nhibernate.Mapping
{
    public  class UserMap:ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.UserName);
            Map(x => x.Name);
            Map(x => x.Password);
            Map(x => x.Position);
            Map(x => x.StoreName);
            Map(x => x.StreetAddress);
            Map(x => x.City);
            Map(x => x.Country);
            Map(x => x.Phone);
            Map(x => x.Fax);
            Map(x => x.RetailURL);
            Map(x => x.EmailAddress);
            Map(x => x.Type);
        }
    }
}
