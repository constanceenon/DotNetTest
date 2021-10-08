using DotnetTest.Model;
using DotnetTest.Repositories;
using DotnetTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly EmployeeRepo _employeeRepo;
        public EmployeeController(IEmployeeService employeeService, EmployeeRepo employeeRepo)
        {
            _employeeService = employeeService;
            _employeeRepo = employeeRepo;
        }

        [HttpPost]
        public IActionResult CreateNewEmployee(Employee model)
        {
            try
            {
                int employee = _employeeRepo.CreateEmployee(model);
                return Ok(employee);
               
            }
            catch (Exception ex )
            {

                return BadRequest(ex.Message);
            }

        }


        [HttpPut]
        public IActionResult UpdateEmployee(Employee model)
        {
            try
            {
                int employee = _employeeRepo.UpdateEmployee(model);
                return Ok(employee);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("id")]
        public IActionResult GetEmployee(int id)
        {
            try
            {
                var employee = _employeeRepo.GetEmployee(id);
                return Ok(employee);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                bool employee = _employeeRepo.DeleteEmployee(id);
                return Ok(employee);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public  IActionResult GetAllEmployees()
        {
            try
            {
                var list = _employeeRepo.GetAllEmployees();
                return Ok(list);

            }
            catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }

        }
    }
}
