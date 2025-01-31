﻿using AutoMapper;
using SalesDatePrediction.Domain.Models;
using SalesDateProduction.Aplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDateProduction.Aplication.Mappers
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeEntity, EmployeeDto>();
            // Otros mapeos si los necesitas
        }
    }
}
