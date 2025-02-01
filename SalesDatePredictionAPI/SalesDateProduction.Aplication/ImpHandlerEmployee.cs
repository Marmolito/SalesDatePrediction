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
    public class ImpHandlerEmployee : IHandlerEmployee
    {
        private readonly IEmployee _employee;
        private readonly IMapper _mapper;

        public ImpHandlerEmployee(IEmployee employee, IMapper mapper)
        {
            _employee = employee;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            var employees = await _employee.GetAll();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }
    }
}
