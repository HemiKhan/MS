using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS_Models.Model;
using MS_Models.ViewModel;
using MS_Services.Employees;

namespace MS_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }


        [HttpGet("GetEmployee")]
        public async Task<IActionResult> GetEmployee()
        {
            if (ModelState.IsValid)
            {
                var result = await employeeService.GetEmployeeAsync();
                if (result.Status)
                    return Ok(result);
                return BadRequest(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpGet("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int EmpId)
        {
            var result = await employeeService.EmployeeGetByIdAsync(EmpId);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                var result = await employeeService.AddEmployeeAsync(model);
                if (result.Status)
                    return Ok(result);
                return BadRequest(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpPut("EditEmployee")]
        public async Task<IActionResult> EditEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                var result = await employeeService.EditEmployeeAsync(model);
                if (result.Status)
                    return Ok(result);
                return BadRequest(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int EmpId)
        {
            var result = await employeeService.DeleteByIdEmployeeAsync(EmpId);
            if (result.Status)
                return Ok(result);
            return BadRequest(result);
        }

    }
}
