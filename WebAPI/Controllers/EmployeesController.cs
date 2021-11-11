using Business.Abstract;
using Entity.Concrete;
using Entity.Concrete.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll(string key = null)
        {
            var result = _employeeService.GetList(key);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getemployeescount")]
        public IActionResult GetEmployeesCount()
        {
            var result = _employeeService.GetList();
           
            List<CountOfEmployees> countOfEmployees = new List<CountOfEmployees>
            {
               new CountOfEmployees
               {
                   Count = result.Data.Where(c => c.EmployeeStatus == true).Count(),
                   IsActive = true
               },
               new CountOfEmployees
               {
                   Count = result.Data.Where(c => c.EmployeeStatus == false).Count(),
                   IsActive = false
               }
            };

           

            if (result.Success)
            {
                return Ok(countOfEmployees);
            }
            return BadRequest(result);
        }

       
        [HttpPost("add")]
        public IActionResult Add(Employee employee)
        {
            var result = _employeeService.Add(employee);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Employee employee)
        {
            var result = _employeeService.Delete(employee);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Employee employee)
        {
            var result = _employeeService.Update(employee);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
     internal class CountOfEmployees
    {
        public int Count { get; set; }
        public bool IsActive { get; set; }
    }
}
