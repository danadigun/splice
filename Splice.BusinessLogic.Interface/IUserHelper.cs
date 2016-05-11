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
        LoginResult Login(string email,string password);
        HttpResult Save(User user);
        void Logout(User user);
    }
}
