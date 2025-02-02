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
    public class UseCaseEmployeeTests
    {
        [Fact]
        public async Task GetAll_ReturnsEmployees_WhenEmployeesExist()
        {
            var mockEmployeePersistancePort = new Mock<IEmployeeOutAdo>();
            var expectedEmployees = new List<EmployeeModel>
        {
            new EmployeeModel { empid = 1, fullName = "John Doe" },
            new EmployeeModel { empid = 2, fullName = "Jane Smith" }
        };

            mockEmployeePersistancePort
                .Setup(port => port.GetAll())
                .ReturnsAsync(expectedEmployees);

            var employeeService = new UseCaseEmployee(mockEmployeePersistancePort.Object);
            var result = await employeeService.GetAll();

            Assert.NotNull(result);
            Assert.Equal(expectedEmployees.Count, result.Count());
            Assert.Equal(expectedEmployees, result);
        }

        [Fact]
        public async Task GetAll_ThrowsNotFoundException_WhenNoEmployeesExist()
        {
            var mockEmployeePersistancePort = new Mock<IEmployeeOutAdo>();

            mockEmployeePersistancePort
                .Setup(port => port.GetAll())
                .ReturnsAsync(new List<EmployeeModel>());

            var employeeService = new UseCaseEmployee(mockEmployeePersistancePort.Object);

            var exception = await Assert.ThrowsAsync<NotFoundException>(() => employeeService.GetAll());
            Assert.Equal("No se encontraron Empleados", exception.Message);
        }

    }
}