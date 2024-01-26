using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Repositories.Abstract;
using WebApplication1.Facades.EmployeeFacade;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeFacade _employeeFacade;

        public EmployeeController(EmployeeFacade employeeFacade)
        {
            this._employeeFacade = employeeFacade;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("getAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            try
            {
                return Ok(_employeeFacade.GetEmployees());
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpDelete]
        [Route("deleteEmployeeById/{employeeId}")]
        public IActionResult DeleteEmployeeById(int employeeId)
        {
            try
            {
                bool deletionResult = _employeeFacade.DeleteEmployeeById(employeeId);
                if (deletionResult)
                {
                    return Ok("Employee deleted successfully");
                }
                else
                {
                    return StatusCode(500, "Failed to delete employee");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting employee");
            }
        }

        [HttpPut]
        [Route("updateEmployeeById/{employeeId}/{newName}/{departmentId}/{age}")]
        public IActionResult UpdateEmployeeById(int employeeId, string newName, int departmentId, int age)
        {
            try
            {
                bool deletionResult = _employeeFacade.UpdateEmployeeById(employeeId, newName, departmentId, age);
                if (deletionResult)
                {
                    return Ok("Employee updated successfully");
                }
                else
                {
                    return StatusCode(500, "Failed to update employee");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating employee");
            }
        }

        [HttpPost]
        [Route("createEmployee/{newName}/{departmentId}/{age}")]
        public IActionResult CreateEmployee(string newName, int departmentId, int age)
        {
            try
            {
                bool deletionResult = _employeeFacade.CreateEmployee(newName, departmentId, age);
                if (deletionResult)
                {
                    return Ok("Employee created successfully");
                }
                else
                {
                    return StatusCode(500, "Failed to create employee");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating employee");
            }
        }
    }
}
