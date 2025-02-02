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
        private readonly IOrderOutAdo _iOrderPersistancePort;
        const string errorMessagge = "No se encontraron Ordenes para el Cliente con el ID: ";
        const string errorMessaggeCreateProduct = "No se pudo crear la Orden";

        public UseCaseOrder(IOrderOutAdo iOrderPersistancePort)
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
        public async Task CreateOrderProduct(OrderProductModel orderProduct)
        {

            string orderDateString = orderProduct.OrderDate;
            DateTime orderDate;

            string requiredDateString = orderProduct.RequiredDate;
            DateTime RequiredDate;

            string shippedDateString = orderProduct.ShippedDate;
            DateTime ShippedDate;

            string inputFormat = "yyyy/MM/dd";
            if (
                DateTime.TryParseExact(orderDateString, inputFormat, null, System.Globalization.DateTimeStyles.None, out orderDate) &&
                DateTime.TryParseExact(requiredDateString, inputFormat, null, System.Globalization.DateTimeStyles.None, out RequiredDate) &&
                DateTime.TryParseExact(shippedDateString, inputFormat, null, System.Globalization.DateTimeStyles.None, out ShippedDate)
                )
            {
                string formattedOrderDate = orderDate.ToString("dd/MM/yyyy");
                string formattedRequiredDateString = RequiredDate.ToString("dd/MM/yyyy");
                string formattedShippedDateString = ShippedDate.ToString("dd/MM/yyyy");

                orderProduct.OrderDate = formattedOrderDate;
                orderProduct.RequiredDate = formattedRequiredDateString;
                orderProduct.ShippedDate = formattedShippedDateString;
            }
            else
            {
                string formattedOrderDate = "Fecha inválida";
                string formattedRequiredDateString = "Fecha inválida";
                string formattedShippedDateString = "Fecha inválida";
            }


            var orderCreated = await _iOrderPersistancePort.CreateOrderProduct(orderProduct);

            if (!orderCreated)
            {
                throw new NotFoundException(errorMessaggeCreateProduct);
            }
        }

    }
}
