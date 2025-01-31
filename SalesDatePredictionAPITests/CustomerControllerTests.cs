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

namespace SalesDatePredictionAPITests
{
    public class CustomerControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsListOfCustomers()
        {
            var mockCustomerPersistancePort = new Mock<ICustomerPersistancePort>();
            var expectedCustomers = new List<CustomerEntity>
        {
            new CustomerEntity
            {
                ContactName = "Fabian Marmolejo",
                LastOrderDate = DateTime.UtcNow.AddDays(-10),
                NextPredictedDate = DateTime.UtcNow.AddDays(20)
            },
            new CustomerEntity
            {
                ContactName = "Juan Ortiz",
                LastOrderDate = DateTime.UtcNow.AddDays(-5),
                NextPredictedDate = DateTime.UtcNow.AddDays(15)
            }
        };

            mockCustomerPersistancePort.Setup(port => port.GetAll())
                                       .ReturnsAsync(expectedCustomers);

            var useCaseCustomer = new UseCaseCustomer(mockCustomerPersistancePort.Object);

            var result = await useCaseCustomer.GetAll();

            Assert.NotNull(result);
            Assert.Equal(expectedCustomers.Count, result.Count());

            foreach (var expectedCustomer in expectedCustomers)
            {
                var actualCustomer = result.FirstOrDefault(c => c.ContactName == expectedCustomer.ContactName);
                Assert.Equal(expectedCustomer.LastOrderDate, actualCustomer.LastOrderDate);
                Assert.Equal(expectedCustomer.NextPredictedDate, actualCustomer.NextPredictedDate); 
            }
        }

        [Fact]
        public async Task GetAll_ReturnsEmptyList_WhenNoCustomersExist()
        {
            var mockCustomerPersistancePort = new Mock<ICustomerPersistancePort>();
            mockCustomerPersistancePort.Setup(port => port.GetAll())
                                       .ReturnsAsync(new List<CustomerEntity>());

            var useCaseCustomer = new UseCaseCustomer(mockCustomerPersistancePort.Object);
            var result = await useCaseCustomer.GetAll();

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetAll_ThrowsException_WhenPersistancePortFails()
        {
            var mockCustomerPersistancePort = new Mock<ICustomerPersistancePort>();
            mockCustomerPersistancePort.Setup(port => port.GetAll())
                                       .ThrowsAsync(new Exception("Error en el puerto de persistencia"));

            var useCaseCustomer = new UseCaseCustomer(mockCustomerPersistancePort.Object);
            await Assert.ThrowsAsync<Exception>(() => useCaseCustomer.GetAll());
        }

    }
}