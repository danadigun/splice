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
            try
            {
                var encreptedPass = user.Password.EncreptedPassword();
                user.Password = encreptedPass;
                user.Type = "Retailer";
                user.CreatedTime = DateTime.Now;
                user.LastUpdateTime = DateTime.Now;
                user.Deleted = 0;
                _userRepo.Save(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LoginResult Login(string email,string password)
        {
            var encreptedPass = password.EncreptedPassword();
            var user = _userRepo.Get(x => x.Email == email && x.Password == encreptedPass);
            if (user != null)
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
