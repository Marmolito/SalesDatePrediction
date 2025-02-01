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
    public class ShipperController : ControllerBase
    {
        private readonly IHandlerShipper _iHandlerShipper;

        public ShipperController(IHandlerShipper iHandlerShipper)
        {
            _iHandlerShipper = iHandlerShipper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var shippers = await _iHandlerShipper.GetAll();

            var predictedDateCustomerResponse = new ResponseHttpRequest<IEnumerable<ShipperDto>>
            {
                isError = false,
                data = shippers
            };

            return Ok(predictedDateCustomerResponse);

        }

    }
}
