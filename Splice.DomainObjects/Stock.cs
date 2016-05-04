using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.DomainObjects
{
    public class Stock : Base
    {
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime DateCreated { get; set; }
    }
}
