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


        //[HttpGet]
        //[Route("login/{username}/{passowrd}")]
        //public IActionResult Login(string username, string passowrd)
        //{
        //    return Ok(_userAccountFacade.UserLogin(username, passowrd));
        //}

        [HttpGet]
        [Route("login/{username}/{password}")]
        public IActionResult Login(string username, string password)
        {
            string loginSuccess = _userAccountFacade.UserLogin(username, password);

            if (loginSuccess != "UserNotFound")
            {
                string[] userInfo = loginSuccess.Split(',');

                var response = new StandardJsonResponse<object>
                {
                    Code = 200,
                    Message = "Success",
                    Data = new
                    {
                        UserId = Convert.ToInt32(userInfo[0]),
                        FirstName = userInfo[1],
                        LastName = userInfo[2],
                        Role = userInfo[3]
                    }
                };
                return Ok(response);
            }
            else
            {
                var response = new StandardJsonResponse<object>
                {
                    Code = 400,
                    Message = "Invalid credentials",
                    Data = null
                };
                return BadRequest(response);
            }
        }

        //[Route("login/{username}/{password}")]
        [HttpPost]
        [Route("register/{email}/{role}/{firstname}/{lastname}/{password}")]
        public IActionResult Register(string email,string role, string firstname,string lastname, string password)
        {
            try
            {
                bool registerSuccess = _userAccountFacade.Register(email, role, firstname, lastname, password);
                if (registerSuccess)
                {
                    return Ok(new { success = true });
                }
                else
                {
                    return BadRequest(new { success = false, error = "User already exist" });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
