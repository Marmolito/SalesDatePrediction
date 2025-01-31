using SalesDatePrediction.Domain.Iapi;
using SalesDatePrediction.Domain.Ispi;
using SalesDatePrediction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aplication
{
    public class UseCaseCustomer : ICustomer
    {
        private readonly ICustomerPersistancePort _iCustomerPersistancePort;

        public UseCaseCustomer(ICustomerPersistancePort iCustomerPersistancePort)
        {
            _iCustomerPersistancePort = iCustomerPersistancePort;
        }
        public async Task<IEnumerable<CustomerEntity>> GetAll()
        {
            var predictedDateCustomer = await _iCustomerPersistancePort.GetAll();
            return predictedDateCustomer;
        }
    }
}
