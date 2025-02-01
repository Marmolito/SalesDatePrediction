using AutoMapper;
using SalesDatePrediction.Aplication.Models;
using SalesDatePrediction.Domain.Iapi;
using SalesDatePrediction.Domain.Models;
using SalesDateProduction.Aplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDateProduction.Aplication
{
    public class ImpHandlerOrder : IHandlerOrder
    {
        private readonly IOrder _iOrder;
        private readonly IMapper _mapper;

        public ImpHandlerOrder(IOrder iOrder, IMapper mapper)
        {
            _iOrder = iOrder;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByCustomerId(int id)
        {
            var OrdersByClientId = await _iOrder.GetOrdersByCustomerId(id);
            return _mapper.Map<IEnumerable<OrderDto>>(OrdersByClientId);

        }
        public async Task CreateOrdeProduct(OrderProductDto orderProduct)
        {
            var mappedOrderProduct = _mapper.Map<OrderProductModel>(orderProduct);
            await _iOrder.CreateOrderProduct(mappedOrderProduct);

        }
    }
}
