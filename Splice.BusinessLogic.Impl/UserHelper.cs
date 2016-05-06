using Splice.BusinessLogic.Interface;
using Splice.DomainObjects;
using Splice.DTO;
using Splice.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.BusinessLogic.Impl
{
    public class UserHelper:IUserHelper
    {
        private IUserRepository _userRepo;
        public UserHelper(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public void Save(User user)
        {
            user.Type = "Retailer";
            _userRepo.Save(user);
        }

        public loginResult login(User user)
        {
            //var password = Encoding.Unicode.GetBytes(user.Password);
            var usr = _userRepo.Get1(x => x.UserName == user.UserName && x.Password == user.Password);
            if (usr != null)
            {
                return new loginResult
                {
                    Success = true

                };
            }
            return new loginResult
            {
                Success = false
            };
        }

    }
}
