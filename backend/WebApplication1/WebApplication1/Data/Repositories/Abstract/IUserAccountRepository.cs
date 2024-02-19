using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data.Repositories.Abstract
{
    public interface IUserAccountRepository
    {
        public string UserLogin(string uname, string password);
        public bool Register(string email, string role, string firstname, string lastname, string password);
    }
}
