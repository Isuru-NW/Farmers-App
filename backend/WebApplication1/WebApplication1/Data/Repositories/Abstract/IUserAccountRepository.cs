using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data.Repositories.Abstract
{
    public interface IUserAccountRepository
    {
        public bool UserLogin(string uname, string password);
        public bool Register(string uname, string password, string role, string email);
    }
}
