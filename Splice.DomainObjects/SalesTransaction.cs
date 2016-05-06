using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.DomainObjects
{
    public class SalesTransaction : Base
    {
        public virtual DateTime DateCreated { get; set; }
        public virtual string SoldBy { get; set; }
    }
}
