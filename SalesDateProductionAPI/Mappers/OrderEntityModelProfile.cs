using AutoMapper;
using SalesDatePrediction.Domain.Models;
using SalesDateProductionAPI.Models.Entities;

namespace SalesDateProductionAPI.Mappers
{
    public class OrderEntityModelProfile : Profile
    {
        public OrderEntityModelProfile()
        {
            CreateMap<OrderEntity, OrderModel>();
        }
    }
}
