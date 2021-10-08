using DotnetTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetTest.Services
{
    public interface IEmployeeService
    {
        int CreateEmployee(Employee model);
        Employee GetEmployee(int id);
        List<Employee> GetAllEmployees();
        int UpdateEmployee(Employee model);
        bool DeleteEmployee(int id);
    }
}
