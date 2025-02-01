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
using SalesDatePrediction.Domain.Models;
using SalesDatePrediction.Domain.Exceptions;

namespace SalesDatePredictionAPITests
{
    public class OrderUseCaseTests
    {
        [Fact]
        public async Task GetOrdersByCustomerId_ReturnsOrders_WhenCustomerHasOrders()
        {
            var mockOrderPersistancePort = new Mock<IOrderPersistancePort>();
            var customerId = 1;
            var expectedOrders = new List<OrderModel>
        {
            new OrderModel { orderid = 1, requireddate = DateTime.Now, shippeddate = DateTime.Now, shipname = "Order 1", shipaddress = "Address 1", shipcity = "City 1" },
            new OrderModel { orderid = 2, requireddate = DateTime.Now, shippeddate = DateTime.Now, shipname = "Order 2", shipaddress = "Address 2", shipcity = "City 2" }
        };

            mockOrderPersistancePort
                .Setup(port => port.GetOrdersByCustomerId(customerId))
                .ReturnsAsync(expectedOrders);

            var orderService = new UseCaseOrder(mockOrderPersistancePort.Object);
            var result = await orderService.GetOrdersByCustomerId(customerId);

            Assert.NotNull(result);
            Assert.Equal(expectedOrders.Count, result.Count());
            Assert.Equal(expectedOrders, result);
        }

        [Fact]
        public async Task GetOrdersByCustomerId_ThrowsNotFoundException_WhenCustomerHasNoOrders()
        {
            var mockOrderPersistancePort = new Mock<IOrderPersistancePort>();
            var customerId = 1;

            mockOrderPersistancePort
                .Setup(port => port.GetOrdersByCustomerId(customerId))
                .ReturnsAsync(new List<OrderModel>());

            var orderService = new UseCaseOrder(mockOrderPersistancePort.Object);

            var exception = await Assert.ThrowsAsync<NotFoundException>(() => orderService.GetOrdersByCustomerId(customerId));
            Assert.Equal("No se encontraron Ordenes para el Cliente con el ID: " + customerId, exception.Message);
        }

        [Fact]
        public async Task CreateOrderProduct_DoesNotThrowException_WhenOrderIsCreatedSuccessfully()
        {
            // Arrange
            var mockOrderPersistancePort = new Mock<IOrderPersistancePort>();
            var orderProduct = new OrderProductModel
            {
                EmpID = 101,
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now.AddDays(7),
                ShippedDate = null,
                ShipperID = 2,
                Freight = 25.50m,
                ShipName = "Ejemplo Shipping",
                ShipAddress = "Calle Falsa 123",
                ShipCity = "Bogotá",
                ShipCountry = "Colombia",
                ProductID = 10,
                UnitPrice = 15.00m,
                Qty = 3,
                Discount = 0.05m
            };

            mockOrderPersistancePort
                .Setup(port => port.CreateOrderProduct(orderProduct))
                .ReturnsAsync(true);

            var orderService = new UseCaseOrder(mockOrderPersistancePort.Object);
            var exception = await Record.ExceptionAsync(() => orderService.CreateOrderProduct(orderProduct));
            Assert.Null(exception);
        }

        [Fact]
        public async Task CreateOrderProduct_ThrowsNotFoundException_WhenOrderCreationFails()
        {
            var mockOrderPersistancePort = new Mock<IOrderPersistancePort>();
            var orderProduct = new OrderProductModel
            {
                EmpID = 101,
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now.AddDays(7),
                ShippedDate = null,
                ShipperID = 2,
                Freight = 25.50m,
                ShipName = "Ejemplo Shipping",
                ShipAddress = "Calle Falsa 123",
                ShipCity = "Bogotá",
                ShipCountry = "Colombia",
                ProductID = 10,
                UnitPrice = 15.00m,
                Qty = 3,
                Discount = 0.05m
            };

            mockOrderPersistancePort
                .Setup(port => port.CreateOrderProduct(orderProduct))
                .ReturnsAsync(false);

            var orderService = new UseCaseOrder(mockOrderPersistancePort.Object);
            var errorMessaggeCreateProduct = "No se pudo crear la Orden";
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => orderService.CreateOrderProduct(orderProduct));
            Assert.Equal(errorMessaggeCreateProduct, exception.Message);
        }


    }
}