using Microsoft.AspNetCore.Cors;
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
    public class ProductController : ControllerBase
    {
        private readonly IHandlerProduct _iHandlerProduct;

        public ProductController(IHandlerProduct iHandlerProduct)
        {
            _iHandlerProduct = iHandlerProduct;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _iHandlerProduct.GetAll();

            var productsResponse = new ResponseHttpRequest<IEnumerable<ProductDto>>
            {
                isError = false,
                data = products
            };

            return Ok(productsResponse);

        }

    }
}
