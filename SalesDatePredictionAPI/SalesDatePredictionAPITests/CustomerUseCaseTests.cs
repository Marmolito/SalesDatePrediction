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
            var mockCustomerPersistancePort = new Mock<ICustomerOutAdo>();
            var expectedCustomers = new List<CustomerModel>
        {
            new CustomerModel { ContactName = "John Doe", LastOrderDate = "02/02/2000", NextPredictedDate = "02/02/2000" },
            new CustomerModel { ContactName = "Jane Smith", LastOrderDate = "02/02/2000", NextPredictedDate = "02/02/2000" }
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
            var mockCustomerPersistancePort = new Mock<ICustomerOutAdo>();

            mockCustomerPersistancePort
                .Setup(port => port.GetAll())
                .ReturnsAsync(new List<CustomerModel>());

            var customerService = new UseCaseCustomer(mockCustomerPersistancePort.Object);

            var exception = await Assert.ThrowsAsync<NotFoundException>(() => customerService.GetAll());
            Assert.Equal("No se encontraron Clientes", exception.Message);
        }
    }
}