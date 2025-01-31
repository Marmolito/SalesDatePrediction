using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesDateProduction.Aplication;

namespace SalesDateProductionAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IHandlerEmployee _iHandlerEmployee;

        public EmployeeController(IHandlerEmployee iHandlerEmployee)
        {
            _iHandlerEmployee = iHandlerEmployee;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _iHandlerEmployee.GetAll();
            return Ok(employees);
        }

    }
}
