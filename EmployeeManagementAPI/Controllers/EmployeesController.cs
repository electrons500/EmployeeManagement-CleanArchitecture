using EmployeeManagement.Application.Dtos.Employees;
using EmployeeManagement.Application.Features.Employees.Commands;
using EmployeeManagement.Application.Features.Employees.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ISender _Sender;
        public EmployeesController(ISender sender)
        {
            _Sender = sender;
        }

        [HttpGet("GetEmployees")]
        public async Task<ActionResult> GetEmployees()
        {
            var employees = await _Sender.Send(new GetEmployeeQueryRequest());
            if(employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        [HttpGet("GetEmployee/{id}")]
        public async Task<ActionResult> GetEmployee(int id) 
        {
            var employee = await _Sender.Send(new GetEmployeeByIdQueryRequest(id));
            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost("AddEmployee")]
        public async Task<ActionResult> AddEmployee([FromBody] AddEmployeeDto employee)
        {
           bool result =  await _Sender.Send(new AddEmployeeCommand(employee));
            if(result)
            {
                return Ok("Employee is successfully added!");
            }

            return BadRequest("Employee failed to be added!.");
        }

         [HttpPut("UpdateEmployee")]
        public async Task<ActionResult> UpdateEmployee([FromBody] UpdateEmployeeDto employee)
        {
           bool result =  await _Sender.Send(new UpdateEmployeeCommand(employee));
            if(result)
            {
                return Ok("Employee is successfully updated!");
            }

            return BadRequest("Employee failed to be updated!");
        }

         [HttpDelete("DeleteEmployee/{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
           bool result =  await _Sender.Send(new DeleteEmployeeCommand(id));
            if(result)
            {
                return Ok("Employee is successfully deleted!");
            }

            return BadRequest("Employee failed to be deleted!");
        }



    }
}
