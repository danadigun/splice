using Splice.DomainObjects;
using Splice.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.BusinessLogic.Interface
{
    public interface IUserHelper
    {
        LoginResult login(User user);
        //bool IsAdmin(int aserId);
        void Save(User user);
    }
}
