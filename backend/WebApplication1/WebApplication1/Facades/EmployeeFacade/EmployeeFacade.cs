using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Models;
using WebApplication1.Data.Repositories.Abstract;

namespace WebApplication1.Facades.EmployeeFacade
{
    public class EmployeeFacade 
    {
        private readonly IEmployeeRepository _employeefacade;

        public EmployeeFacade(IEmployeeRepository employeefacade)
        {
            this._employeefacade = employeefacade;
        }

        public List<EmployeeViewModel> GetEmployees()
        {
            return _employeefacade.GetEmployees();
        }

        public bool DeleteEmployeeById(int id)
        {
            return _employeefacade.DeleteEmployeeById(id);
        }

        public bool UpdateEmployeeById(int employeeId, string newName, int newDepartmentId, int newAge)
        {
            return _employeefacade.UpdateEmployeeById(employeeId, newName, newDepartmentId, newAge);
        }

        public bool CreateEmployee(string newEmpName, int newDepartmentId, int newEmpAge)
        {
            return _employeefacade.CreateEmployee(newEmpName, newDepartmentId, newEmpAge);
        }
    }
}
