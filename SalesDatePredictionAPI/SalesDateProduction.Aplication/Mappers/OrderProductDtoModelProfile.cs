using AutoMapper;
using SalesDatePrediction.Aplication.Models;
using SalesDatePrediction.Domain.Models;
using SalesDateProduction.Aplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDateProduction.Aplication.Mappers
{
    public class OrderProductDtoModelProfile : Profile
    {
        public OrderProductDtoModelProfile()
        {
            CreateMap<OrderProductDto, OrderProductModel>();
        }
    }
}
