using AutoMapper;
using SalesDatePrediction.Domain.Models;
using SalesDateProduction.Aplication.Models;

namespace SalesDateProduction.Aplication.Mappers
{
    public class EmployeeModelDtoProfile : Profile
    {
        public EmployeeModelDtoProfile()
        {
            CreateMap<EmployeeModel, EmployeeDto>();
            // Otros mapeos si los necesitas
        }
    }
}
