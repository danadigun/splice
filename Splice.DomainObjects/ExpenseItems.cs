using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.DomainObjects
{
    public class ExpenseItems : Base
    {
        public virtual int ExpenseId { get; set; }
        public virtual string ItemName { get; set; }
        public virtual decimal Price { get; set; }
        public virtual DateTime DateCreated { get; set; }
    }
}
