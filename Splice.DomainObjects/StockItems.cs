using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.DomainObjects
{
    public class StockItems : Base
    {
        public virtual int StockId { get; set; }
        public virtual int ProductId { get; set; }
        //public virtual string Serial { get; set; }
        //public virtual string Name { get; set; }
        //public virtual decimal CostPrice { get; set; }
        //public virtual decimal SellingPrice { get; set; }
        //public virtual int Quantity { get; set; }
        //public virtual DateTime DateCreated { get; set; }
    }
}
