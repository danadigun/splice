using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.DomainObjects
{
    public class SalesTransaction : Base
    {
        public DateTime DateCreated { get; set; }
        public string SoldBy { get; set; }
    }
}
