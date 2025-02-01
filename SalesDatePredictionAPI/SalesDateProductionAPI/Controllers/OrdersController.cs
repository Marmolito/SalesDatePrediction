using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Aplication.Models;
using SalesDatePrediction.Domain.Exceptions;
using SalesDateProduction.Aplication;
using SalesDateProduction.Aplication.Models;
using SalesDateProductionAPI.Models.Entities;
using SalesDateProductionAPI.Models.Responses;

namespace SalesDateProductionAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IHandlerOrder _iHandlerOrder;
        public OrdersController(IHandlerOrder iHandlerOrder)
        {
            _iHandlerOrder = iHandlerOrder;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrdersByCustomerId(int id)
        {
            var orders = await _iHandlerOrder.GetOrdersByCustomerId(id);

            var ordersResponse = new ResponseHttpRequest<IEnumerable<OrderDto>>
            {
                isError = false,
                data = orders
            };

            return Ok(ordersResponse);

        }

        [HttpPost()]
        public async Task<IActionResult> CreateOrderProduct(OrderProductDto orderProduct)
        {
            await _iHandlerOrder.CreateOrdeProduct(orderProduct);

            var orderProductResponse = new ResponseHttpRequest<object>
            {
                isError = false,
                data = null,
                messagge = "Orden creada exitosamente"
            };

            return Ok(orderProductResponse);

        }

    }
}
