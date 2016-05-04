using FluentNHibernate.Mapping;
using Splice.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.Persistence.Nhibernate.Mapping
{
    public class SalesTransactionItemMap:ClassMap<SalesTransactionItem>
    {
        public SalesTransactionItemMap()
        {
            Table("SalesTransactionItem");
            Id(x => x.Id);
            Map(x=>x.SalesTransactionId);
            Map(x => x.Serial);
            Map(x => x.Name);
            Map(x => x.Price);
            Map(x => x.Quantity);
        }
    }
}
