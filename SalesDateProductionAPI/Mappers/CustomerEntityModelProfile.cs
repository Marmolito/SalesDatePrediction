using AutoMapper;
using SalesDatePrediction.Domain.Models;
using SalesDatePrediction.Models;
using SalesDatePrediction.Models.Entities;
using SalesDateProductionAPI.Models.Entities;

namespace SalesDateProductionAPI.Mappers
{
    public class CustomerEntityModelProfile : Profile
    {
        public CustomerEntityModelProfile()
        {
            CreateMap<CustomerEntity, CustomerModel>();
        }
    }
}
