using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCRUD.Data;
using WebApiCRUD.Models;

namespace WebApiCRUD.Controllers
{
    [Route("employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeData _employeedata;

        public EmployeeController(IEmployeeData employeedata)
        {
            _employeedata = employeedata;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(_employeedata.GetEmployees());
        }

        [HttpGet]
        [Route("employee/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            if (_employeedata.GetEmployee(id) == null)
            {
                return BadRequest(id + " does not much with an existing employee id");
            }
            else
            {
                return Ok(_employeedata.GetEmployee(id));
            }
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeModel employee)
        {
            _employeedata.AddEmployee(employee);
            return Ok(employee + "Was created");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employeedata.GetEmployee(id);

            if (employee == null)
            {
                return BadRequest(id + " was not found");
            }
            else
            {
                _employeedata.DeleteEmployee(id);
                return Ok();
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult UpdateEmplpoyee(Guid id, EmployeeModel employee)
        {
            return Ok(_employeedata.UpdatedEmployee(id, employee));
        }
    }
}
