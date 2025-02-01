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
    public class UseCaseOrder : IOrder
    {
        private readonly IOrderPersistancePort _iOrderPersistancePort;
        const string errorMessagge = "No se encontraron Ordenes para el Cliente con el ID: ";

        public UseCaseOrder(IOrderPersistancePort iOrderPersistancePort)
        {
            _iOrderPersistancePort = iOrderPersistancePort;
        }
        public async Task<IEnumerable<OrderModel>> GetOrdersByCustomerId(int id)
        {
            var ordersByCustomerId = await _iOrderPersistancePort.GetOrdersByCustomerId(id);

            if (ordersByCustomerId == null || !ordersByCustomerId.Any())
            {
                throw new NotFoundException(errorMessagge + id);
            }

            return ordersByCustomerId;
        }
    }
}
