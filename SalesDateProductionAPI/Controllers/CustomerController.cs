using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesDateProduction.Aplication;

namespace SalesDateProductionAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IHandlerCustomer _iHandlercustomer;

        public CustomerController(IHandlerCustomer ihandlerCustomer)
        {
            _iHandlercustomer = ihandlerCustomer;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var predictedDateCustomer = await _iHandlercustomer.GetAll();
            return Ok(predictedDateCustomer);
        }

    }
}
