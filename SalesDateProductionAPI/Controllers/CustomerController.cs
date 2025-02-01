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
            try
            {
                var predictedDateCustomer = await _iHandlercustomer.GetAll();

                var predictedDateCustomerResponse = new ResponseHttpRequest<IEnumerable<CustomerDto>>
                {
                    isError = false,
                    data = predictedDateCustomer
                };

                return Ok(predictedDateCustomerResponse);
            }
            catch (NotFoundException ex)
            {

                var predictedDateCustomerResponse = new ResponseHttpRequest<IEnumerable<CustomerDto>>
                {
                    isError = true,
                    data = null,
                    messagge = ex.Message
                };

                return NotFound(predictedDateCustomerResponse);
            }
        }

    }
}
