using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using SalesDateProduction.Aplication;
using SalesDateProductionAPI.Out;
using SalesDateProductionAPI.Controllers;
using SalesDateProduction.Aplication.Models;
using Domain.Aplication;
using SalesDatePrediction.Domain.Ispi;
using SalesDateProductionAPI.Models.Entities;

namespace SalesDatePredictionAPITests
{
    public class OrderUseCaseTests
    {
        [Fact]
        public async Task GetOrdersByCustomerId_ReturnsOrders_WhenCustomerHasOrders()
        {
            var mockOrderPersistancePort = new Mock<IOrderPersistancePort>();

            var expectedOrders = new List<OrderEntity>
        {
            new OrderEntity
            {
                orderid = 1,
                requireddate = DateTime.UtcNow.AddDays(5),
                shippeddate = DateTime.UtcNow.AddDays(2),
                shipname = "envio 1",
                shipaddress = "direccion 1",
                shipcity = "ciudad 1"
            },
            new OrderEntity
            {
                orderid = 2,
                requireddate = DateTime.UtcNow.AddDays(10),
                shippeddate = DateTime.UtcNow.AddDays(7),
                shipname = "envio 2",
                shipaddress = "direccion 2",
                shipcity = "ciudad 2"
            }
        };

            mockOrderPersistancePort.Setup(port => port.GetOrdersByCustomerId(1))
                                    .ReturnsAsync(expectedOrders);

            var orderService = new UseCaseOrder(mockOrderPersistancePort.Object);

            var result = await orderService.GetOrdersByCustomerId(1);

            Assert.NotNull(result);
            Assert.Equal(expectedOrders.Count, result.Count());

            foreach (var expectedOrder in expectedOrders)
            {
                var actualOrder = result.FirstOrDefault(o => o.orderid == expectedOrder.orderid);
                Assert.NotNull(actualOrder);
                Assert.Equal(expectedOrder.requireddate, actualOrder.requireddate);
                Assert.Equal(expectedOrder.shippeddate, actualOrder.shippeddate);
                Assert.Equal(expectedOrder.shipname, actualOrder.shipname);
                Assert.Equal(expectedOrder.shipaddress, actualOrder.shipaddress);
                Assert.Equal(expectedOrder.shipcity, actualOrder.shipcity);
            }
        }
    }
}