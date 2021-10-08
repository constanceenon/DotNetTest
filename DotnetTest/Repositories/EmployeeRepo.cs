using DotnetTest.Model;
using DotnetTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetTest.Repositories
{
    public class EmployeeRepo
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeRepo(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public int CreateEmployee(Employee model)
        {
            return _employeeService.CreateEmployee(model);
        }
        public int UpdateEmployee(Employee model)
        {
            return _employeeService.UpdateEmployee(model);
        }

        public Employee GetEmployee(int id)
        {
            return _employeeService.GetEmployee(id);
        }
        public List<Employee> GetAllEmployees()
        {
            return _employeeService.GetAllEmployees();
        }
        public bool DeleteEmployee(int id)
        {
            return _employeeService.DeleteEmployee(id);
        }
    }
}
