using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.DomainObjects
{
    public class Base
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedTime { get; set; }
        public virtual DateTime LastUpdateTime  { get; set; }
    }
}
