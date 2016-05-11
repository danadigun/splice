using Splice.BusinessLogic.Interface;
using Splice.DomainObjects;
using Splice.DTO;
using Splice.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Splice.BusinessLogic.Impl
{
    public class UserHelper : IUserHelper
    {
        private IUserRepository _userRepo;
        public UserHelper(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public HttpResult Save(User user)
        {
            try
            {
                if (_userRepo.IsExist(x => x.Email == user.Email && x.Deleted == 0))
                {
                    throw new AlreadyExistException(string.Format("{0} already exist.", user.Email));
                }
                var encreptedPass = user.Password.EncreptedPassword();
                user.Password = encreptedPass;
                user.Type = "Retailer";
                user.CreatedTime = DateTime.Now;
                user.LastUpdateTime = DateTime.Now;
                user.Deleted = 0;
                _userRepo.Save(user);
            }
            catch (AlreadyExistException aex)
            {
                return new HttpResult(aex.Message, false);

            }

            catch (Exception ex)
            {
                return new HttpResult(ex.Message, false);
            }
            return new HttpResult("Created Successfully!", true);
        }

        public LoginResult Login(string email, string password)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {

                    var encreptedPass = password.EncreptedPassword();
                    var user = _userRepo.Get(x => x.Email == email && x.Password == encreptedPass);

                    string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

                    if (user != null)
                    {
                        user.AuthToken = token;
                        _userRepo.Update(user);
                        scope.Complete();
                        return new LoginResult
                        {
                            Success = true,
                            Token = token

                        };
                    }

                    return new LoginResult
                    {
                        Success = false,
                        Token = ""
                    };

                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    return new LoginResult
                    {
                        Success = false,
                        Token = "",
                        Message = ex.InnerException.Message
                    };

                }
            }
        }

        public void Logout(User user)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                var dbUser = _userRepo.Get(x => x.AuthToken == user.AuthToken);
                if (dbUser != null)
                {
                    dbUser.AuthToken = "";
                    _userRepo.Update(dbUser);
                    scope.Complete();
                }
            }
        }
    }
}
