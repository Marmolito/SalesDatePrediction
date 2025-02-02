using SalesDatePrediction.Domain.Exceptions;
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
        private readonly ICustomerOutAdo _iCustomerPersistancePort;
        const string errorMessagge = "No se encontraron Clientes";

        public UseCaseCustomer(ICustomerOutAdo iCustomerPersistancePort)
        {
            _iCustomerPersistancePort = iCustomerPersistancePort;
        }
        public async Task<IEnumerable<CustomerModel>> GetAll()
        {
            var predictedDateCustomer = await _iCustomerPersistancePort.GetAll();

            if (predictedDateCustomer == null || !predictedDateCustomer.Any())
            {
                throw new NotFoundException(errorMessagge);
            }

            return predictedDateCustomer;
        }
    }
}
