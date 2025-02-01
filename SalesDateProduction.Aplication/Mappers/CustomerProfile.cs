using AutoMapper;
using SalesDatePrediction.Domain.Models;
using SalesDateProduction.Aplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDateProduction.Aplication.Mappers
{
    public class CustomerModelDtoProfile : Profile
    {
        public CustomerModelDtoProfile()
        {
            CreateMap<CustomerModel, CustomerDto>();
            // Otros mapeos si los necesitas
        }
    }
}
