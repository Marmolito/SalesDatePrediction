using AutoMapper;
using SalesDatePrediction.Domain.Models;
using SalesDatePrediction.Models;
using SalesDatePrediction.Models.Entities;
using SalesDateProductionAPI.Models.Entities;

namespace SalesDateProductionAPI.Mappers
{
    public class ProductEntityModelProfile : Profile
    {
        public ProductEntityModelProfile()
        {
            CreateMap<ProductEntity, ProductModel>();
        }
    }
}
