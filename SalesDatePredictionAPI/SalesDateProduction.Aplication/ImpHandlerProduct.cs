using AutoMapper;
using SalesDatePrediction.Domain.Iapi;
using SalesDateProduction.Aplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDateProduction.Aplication
{
    public class ImpHandlerProduct : IHandlerProduct
    {
        private readonly IProduct _iProduct;
        private readonly IMapper _mapper;

        public ImpHandlerProduct(IProduct iProduct, IMapper mapper)
        {
            _iProduct = iProduct;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var products = await _iProduct.GetAll();
            return _mapper.Map<IEnumerable<ProductDto>>(products);

        }
    }
}
