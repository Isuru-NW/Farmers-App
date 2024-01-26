using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.DBProviders;
using WebApplication1.Data.Models;
using WebApplication1.Data.Repositories.Abstract;

namespace WebApplication1.Data.Repositories.Employee
{
    public class EmployeeRepository :SQLRepository, IEmployeeRepository
    {
        private readonly SQLDBContext SQLDbContext;

        public EmployeeRepository(SQLDBContext sqlDbContext)
        {
            SQLDbContext = sqlDbContext;
        }

        public List<EmployeeViewModel> GetEmployees()
        {
            List<EmployeeViewModel> employeesList = new List<EmployeeViewModel>();
            var dbParams = new DbParameter[0];
            DbDataReader dbDataReader = SQLDbContext.ExecuetReader("GetEmployeeData", dbParams);
            try
            {
                while (dbDataReader.Read())
                {
                    EmployeeViewModel employee = new EmployeeViewModel();
                    employee.EmployeeName = dbDataReader["EmployeeName"].ToString();
                    employee.EmployeeAge = Convert.ToInt32(dbDataReader["EmployeeAge"]);
                    employee.EmployeeId = Convert.ToInt32(dbDataReader["EmployeeId"]);
                    employee.DepartmentId = Convert.ToInt32(dbDataReader["DepartmentId"]);
                    employeesList.Add(employee);
                }
                dbDataReader.Close();

                return employeesList;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool DeleteEmployeeById(int employeeId)
        {
            try
            {
                var dbParams = new DbParameter[1];
                dbParams[0] = IntParameter("@EmployeeId", employeeId);
                DbDataReader dbDataReader = SQLDbContext.ExecuetReader("DeleteEmployeeById", dbParams);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateEmployeeById(int employeeId, string newName, int newDepartmentId, int newAge)
        {
            try
            {
                var dbParams = new DbParameter[4];
                dbParams[0] = IntParameter("@EmployeeId", employeeId);
                dbParams[1] = StringParameter("@NewName", newName);
                dbParams[2] = IntParameter("@NewDepartmentId", newDepartmentId);
                dbParams[3] = IntParameter("@NewEmployeeAge", newAge);

                DbDataReader dbDataReader = SQLDbContext.ExecuetReader("UpdateEmployeeById", dbParams);

                return true;
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                return false;
            }
        }

        public bool CreateEmployee(string newEmpName, int newDepartmentId, int newEmpAge)
        {
            try
            {
                var dbParams = new DbParameter[3];
                dbParams[0] = StringParameter("@NewName", newEmpName);
                dbParams[1] = IntParameter("@NewDepartmentId", newDepartmentId);
                dbParams[2] = IntParameter("@NewEmployeeAge", newEmpAge);

                DbDataReader dbDataReader = SQLDbContext.ExecuetReader("CreateEmployee", dbParams);

                return true;
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                return false;
            }
        }


    }
}   
