using FluentNHibernate.Mapping;
using Splice.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.Persistence.Nhibernate.Mapping
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("Product");
            Id(x=>x.Id).GeneratedBy.Identity();
            Map(x=>x.Name);
            Map(x=>x.SKU);
            Map(x=>x.LongDescription);
            Map(x=>x.ShortDescription);
            Map(x=>x.ProductImage);
            Map(x=>x.ImageUrl);
            Map(x=>x.Title);
            Map(x=>x.SubTitle);
            Map(x=>x.CreatedTime);
            Map(x=>x.LastUpdateTime);
        }
    }
}
