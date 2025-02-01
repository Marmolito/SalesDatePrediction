using AutoMapper;
using SalesDatePrediction.Domain.Models;
using SalesDatePrediction.Models.Entities;
using SalesDateProductionAPI.Models.Entities;

namespace SalesDateProductionAPI.Mappers
{
    public class EmployeeEntityModelProfile : Profile
    {
        public EmployeeEntityModelProfile()
        {
            CreateMap<EmployeeEntity, EmployeeModel>();
        }
    }
}
