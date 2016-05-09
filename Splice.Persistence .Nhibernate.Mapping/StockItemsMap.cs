using FluentNHibernate.Mapping;
using Splice.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.Persistence.Nhibernate.Mapping
{
    public class StockItemsMap : ClassMap<StockItems>
    {
        public StockItemsMap()
        {
            Table("StockItems");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.StockId);
            Map(x => x.ProductId);
            Map(x => x.CreatedTime);
            Map(x => x.LastUpdateTime);            
        }
    }
}
