using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.DomainObjects
{
    public class User : Base
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string Address { get; set; }
        public virtual string Country { get; set; }
        public virtual string Phone { get; set; }
        public virtual string StoreName { get; set; }
        public virtual string RetailURL { get; set; }
        public virtual string Type { get; set; }
        public virtual string AuthToken { get; set; }
    }
}
