using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.DBProviders;
using WebApplication1.Facades.UserAccountFacade;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly UserAccountFacade _userAccountFacade;

        public UserAccountController(UserAccountFacade userAccountFacadeFacade)
        {
            this._userAccountFacade = userAccountFacadeFacade;
        }


        [HttpPost("login")]
        public IActionResult Login(UserViewModel user)
        {
            return Ok(_userAccountFacade.UserLogin(user.Username, user.Password));
        }

        [HttpPost("register")]
        public IActionResult Register(UserViewModel user)
        {
            return Ok(_userAccountFacade.Register(user.Username, user.Password, user.Role, user.Email));
        }
    }
}
