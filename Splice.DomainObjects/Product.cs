using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.DomainObjects
{
    public class Product : Base
    {
        public virtual string Name { get; set; }
        public virtual string SKU { get; set; }
        public virtual string LongDescription { get; set; }
        public virtual string ShortDescription { get; set; }
        public virtual byte[] ProductImage { get; set; }
        public virtual string ImageUrl { get; set; }
        public virtual string Title { get; set; }
        public virtual string SubTitle { get; set; }
    }
}
