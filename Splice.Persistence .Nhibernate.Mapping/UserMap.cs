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
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Email);
            Map(x => x.Password);
            Map(x => x.Address);
            Map(x => x.Country);
            Map(x => x.Phone);
            Map(x => x.StoreName);
            Map(x => x.RetailURL);
            Map(x => x.Type);
            Map(x => x.Deleted);
            Map(x => x.CreatedTime);
            Map(x => x.LastUpdateTime);
        }
    }
}
