using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Repositories.Abstract;

namespace WebApplication1.Facades.UserAccountFacade
{
    public class UserAccountFacade
    {
        private readonly IUserAccountRepository _userAccountFacade;

        public UserAccountFacade(IUserAccountRepository userAccountfacade)
        {
            this._userAccountFacade = userAccountfacade;
        }
        public string UserLogin(string uname, string password)
        {
            return _userAccountFacade.UserLogin(uname, password);
        }

        public bool Register(string email, string role, string firstname, string lastname, string password)
        {
            return _userAccountFacade.Register(email, role, firstname, lastname, password);
        }
    }
}
