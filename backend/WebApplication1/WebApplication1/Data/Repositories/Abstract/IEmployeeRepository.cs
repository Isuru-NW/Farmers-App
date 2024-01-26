using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Repositories.Abstract
{
    public interface IEmployeeRepository
    {
        public List<EmployeeViewModel> GetEmployees();
        public bool DeleteEmployeeById(int id);
        bool UpdateEmployeeById(int employeeId, string newName, int newDepartmentId, int newAge);
        bool CreateEmployee(string newEmpName, int newDepartmentId, int newEmpAge);
    }
}
