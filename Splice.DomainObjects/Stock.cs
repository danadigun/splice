using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.DomainObjects
{
    public class Stock : Base
    {
        public virtual string Name { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual int MaxQuantity { get; set; }
        public virtual DateTime AvailabilityDate { get; set; }
        public virtual string Status { get; set; }
    }
}
