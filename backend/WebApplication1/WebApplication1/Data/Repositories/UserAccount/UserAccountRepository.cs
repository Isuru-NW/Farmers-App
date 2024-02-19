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

        public bool Register(string email, string role, string firstname, string lastname, string password) 
        {
            try
            {
                var dbParams = new DbParameter[5];
                dbParams[0] = StringParameter("@Email", email);
                dbParams[1] = StringParameter("@Role", role);
                dbParams[2] = StringParameter("@Firstname", firstname);
                dbParams[3] = StringParameter("@Lastname", lastname);               
                dbParams[4] = StringParameter("@Password", password); 

                object result = SQLDbContext.ExecuteScalar("RegisterUser", dbParams);

                if (result != null && result.ToString() == "Success")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string UserLogin(string email, string password)
        {
            try
            {
                var dbParams = new DbParameter[2];
                dbParams[0] = StringParameter("@Email", email);
                dbParams[1] = StringParameter("@Password", password);

                object result = SQLDbContext.ExecuteScalar("LoginUser", dbParams);

                return result.ToString();
            }
            catch (Exception)
            {
                // Handle exceptions if needed
                throw;
            }
        }

    }
}
