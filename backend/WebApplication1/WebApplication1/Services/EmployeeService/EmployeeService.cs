using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Repositories.Abstract;
using WebApplication1.Data.Repositories.Employee;
using WebApplication1.Data.Repositories.Product;
using WebApplication1.Data.Repositories.UserAccount;
using WebApplication1.Facades.EmployeeFacade;
using WebApplication1.Facades.ProductFacade;
using WebApplication1.Facades.UserAccountFacade;

namespace WebApplication1.Services.EmployeeService
{
    public class EmployeeService
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<EmployeeFacade>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<UserAccountFacade>();
            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            services.AddScoped<ProductFacade>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
