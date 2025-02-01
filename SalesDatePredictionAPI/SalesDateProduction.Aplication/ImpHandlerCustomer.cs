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
    public class ImpHandlerCustomer : IHandlerCustomer
    {
        private readonly ICustomer _customer;
        private readonly IMapper _mapper;

        public ImpHandlerCustomer(ICustomer employee, IMapper mapper)
        {
            _customer = employee;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> GetAll()
        {
            var predictedDateCustomer = await _customer.GetAll();
            return _mapper.Map<IEnumerable<CustomerDto>>(predictedDateCustomer);

            //implementacion de dominio
        }
    }
}
