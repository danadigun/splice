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
    public class UserHelper : IUserHelper
    {
        private IUserRepository _userRepo;
        public UserHelper(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public void Save(User user)
        {
            var encreptedPass = user.Password.EncreptedPassword();
            user.Password = encreptedPass;
            user.Type = "Retailer";
            _userRepo.Save(user);
        }

        public LoginResult login(User user)
        {
            var encreptedPass = user.Password.EncreptedPassword();
            user.Password = encreptedPass;
            var usr = _userRepo.Get1(x => x.UserName == user.UserName && x.Password == encreptedPass);
            if (usr != null)
            {
                return new LoginResult
                {
                    Success = true

                };
            }
            return new LoginResult
            {
                Success = false
            };
        }


    }
}
