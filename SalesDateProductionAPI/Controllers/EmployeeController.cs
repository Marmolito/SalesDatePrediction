using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesDateProduction.Aplication;

namespace SalesDateProductionAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IHandlerEmployee _employee;

        public EmployeeController(IHandlerEmployee employee)
        {
            _employee = employee;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employee.GetAll();
            return Ok(employees);
        }

    }
}
