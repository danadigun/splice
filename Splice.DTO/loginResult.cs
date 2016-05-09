using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.DTO
{
    public class LoginResult
    {
        public virtual bool Success { get; set; }
        public virtual string Message { get; set; }
    }
}
