﻿using Splice.BusinessLogic.Interface;
using Splice.DomainObjects;
using Splice.DTO;
using Splice.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Splice.Web.Api.Controllers
{

    public class RetailerController : ApiController
    {
        private IUserHelper _userHelper;
        public RetailerController(IUserHelper userHelper)
        {
            _userHelper = userHelper;
        }

        [HttpPost]
        public HttpResult AddUser(User user)
        {
            try
            {
                return _userHelper.Save(user);

            }
            catch (AlreadyExistException aex)
            {
                throw aex;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public LoginResult Login(User user)
        {
            return _userHelper.Login(user.Email, user.Password);
        }
        [HttpPost]
        public void Logout(User user) 
        {
            _userHelper.Logout(user);
        }

    }
}
