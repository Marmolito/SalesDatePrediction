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
    public class UseCaseProduct : IProduct
    {
        private readonly IProductOutAdo _iProductPersistancePort;
        const string errorMessagge = "No se encontraron Productos";

        public UseCaseProduct(IProductOutAdo iProductPersistancePort)
        {
            _iProductPersistancePort = iProductPersistancePort;
        }
        public async Task<IEnumerable<ProductModel>> GetAll()
        {
            var products = await _iProductPersistancePort.GetAll();

            if (products == null || !products.Any())
            {
                throw new NotFoundException(errorMessagge);
            }

            return products;
        }
    }
}
