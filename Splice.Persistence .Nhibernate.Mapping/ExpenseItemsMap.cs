using FluentNHibernate.Mapping;
using Splice.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.Persistence.Nhibernate.Mapping
{
    public class ExpenseItemsMap : ClassMap<ExpenseItems>
    {
        public ExpenseItemsMap()
        {
            Table("ExpenseItems");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.ExpenseId);
            Map(x => x.ItemName);
            Map(x => x.Price);
            Map(x => x.DateCreated);
        }
    }
}
