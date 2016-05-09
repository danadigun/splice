using FluentNHibernate.Mapping;
using Splice.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.Persistence.Nhibernate.Mapping
{
    public class StockMap : ClassMap<Stock>
    {
        public StockMap()
        {
            Table("Stock");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Status);
            Map(x => x.Deleted);
            Map(x => x.MaxQuantity);
            Map(x => x.Title);
            Map(x => x.Description);
            Map(x => x.CreatedTime);
            Map(x => x.LastUpdateTime);
            Map(x => x.AvailabilityDate);
            
        }
    }
}
