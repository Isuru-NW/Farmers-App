using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.DBProviders;
using WebApplication1.Data.Repositories.Abstract;
using WebApplication1.Models;

namespace WebApplication1.Data.Repositories.UserAccount
{
    public class UserAccountRepository : SQLRepository, IUserAccountRepository
    {
        private readonly SQLDBContext SQLDbContext;

        public UserAccountRepository(SQLDBContext sqlDbContext)
        {
            SQLDbContext = sqlDbContext;
        }

        public bool Register(string uname, string password,string role, string email) 
        {
            try
            {
                var dbParams = new DbParameter[4];
                dbParams[0] = StringParameter("@Username", uname);
                dbParams[1] = StringParameter("@Password", password);
                dbParams[2] = StringParameter("@Role", role);
                dbParams[3] = StringParameter("@Email", email);

                DbDataReader dbDataReader = SQLDbContext.ExecuetReader("RegisterUser", dbParams);

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool UserLogin(string uname,string password) 
        {
            try
            {
                var dbParams = new DbParameter[2];
                dbParams[0] = StringParameter("@Username", uname);
                dbParams[1] = StringParameter("@Password", password);

                DbDataReader dbDataReader = SQLDbContext.ExecuetReader("LoginUser", dbParams);
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }
    }
}
