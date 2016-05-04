using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.DomainObjects
{
    public class Expense : Base
    {        
        public virtual string Title { get; set; }
        public virtual DateTime DateCreated { get; set; }
    }
}
