using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Domain.Exceptions;
using SalesDateProduction.Aplication;
using SalesDateProduction.Aplication.Models;
using SalesDateProductionAPI.Models.Responses;

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

            var employeesResponse = new ResponseHttpRequest<IEnumerable<EmployeeDto>>
            {
                isError = false,
                data = employees
            };

            return Ok(employeesResponse);

        }

    }
}
