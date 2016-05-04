using FluentNHibernate.Mapping;
using Splice.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.Persistence.Nhibernate.Mapping
{
    public class SalesTransactionMap:ClassMap<SalesTransaction>
    {
        public SalesTransactionMap()
        {
            Table("SalesTransaction");
            Id(x => x.Id);
            Map(x => x.SoldBy);
            Map(x => x.DateCreated);
        }
    }
}
