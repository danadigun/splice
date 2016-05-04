using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.DomainObjects
{
    public class SalesTransactionItem : Base
    {
        public virtual int SalesTransactionId { get; set; }
        public virtual string Serial { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
        public virtual int Quantity { get; set; }
    }
}
