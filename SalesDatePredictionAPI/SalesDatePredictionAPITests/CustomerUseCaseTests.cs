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
using SalesDatePrediction.Domain.Models;
using SalesDatePrediction.Domain.Exceptions;

namespace SalesDatePredictionAPITests
{
    public class CustomerUseCaseTests
    {
        [Fact]
        public async Task GetAll_ReturnsCustomers_WhenCustomersExist()
        {
            var mockCustomerPersistancePort = new Mock<ICustomerPersistancePort>();
            var expectedCustomers = new List<CustomerModel>
        {
            new CustomerModel { ContactName = "John Doe", LastOrderDate = DateTime.Now, NextPredictedDate = DateTime.Now.AddDays(30) },
            new CustomerModel { ContactName = "Jane Smith", LastOrderDate = DateTime.Now, NextPredictedDate = DateTime.Now.AddDays(45) }
        };

            mockCustomerPersistancePort
                .Setup(port => port.GetAll())
                .ReturnsAsync(expectedCustomers);

            var customerService = new UseCaseCustomer(mockCustomerPersistancePort.Object);
            var result = await customerService.GetAll();

            Assert.NotNull(result);
            Assert.Equal(expectedCustomers.Count, result.Count());
            Assert.Equal(expectedCustomers, result);
        }

        [Fact]
        public async Task GetAll_ThrowsNotFoundException_WhenNoCustomersExist()
        {
            var mockCustomerPersistancePort = new Mock<ICustomerPersistancePort>();

            mockCustomerPersistancePort
                .Setup(port => port.GetAll())
                .ReturnsAsync(new List<CustomerModel>());

            var customerService = new UseCaseCustomer(mockCustomerPersistancePort.Object);

            var exception = await Assert.ThrowsAsync<NotFoundException>(() => customerService.GetAll());
            Assert.Equal("No se encontraron Clientes", exception.Message);
        }
    }
}