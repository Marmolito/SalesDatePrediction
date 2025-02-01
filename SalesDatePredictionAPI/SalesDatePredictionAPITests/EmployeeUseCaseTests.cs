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
    public class UseCaseEmployeeTests
    {
        [Fact]
        public async Task GetAll_ReturnsListOfEmployees()
        {
            // Arrange
            var mockEmployeePersistancePort = new Mock<IEmployeePersistancePort>();

            // Datos simulados que el puerto de persistencia devolverá
            var expectedEmployees = new List<EmployeeEntity>
        {
            new EmployeeEntity { empid = 1, fullName = "John Doe" },
            new EmployeeEntity { empid = 2, fullName = "Jane Doe" }
        };

            // Configura el mock para devolver los datos simulados
            mockEmployeePersistancePort.Setup(port => port.GetAll())
                                       .ReturnsAsync(expectedEmployees);

            // Crea una instancia de UseCaseEmployee con el mock
            var useCaseEmployee = new UseCaseEmployee(mockEmployeePersistancePort.Object);

            // Act
            var result = await useCaseEmployee.GetAll();

            // Assert
            Assert.NotNull(result); // Verifica que el resultado no sea nulo
            Assert.Equal(expectedEmployees.Count, result.Count()); // Verifica que la cantidad de elementos sea la esperada

            // Verifica que los datos coincidan
            foreach (var expectedEmployee in expectedEmployees)
            {
                var actualEmployee = result.FirstOrDefault(e => e.empid == expectedEmployee.empid);
                Assert.NotNull(actualEmployee); // Verifica que el empleado exista en el resultado
                Assert.Equal(expectedEmployee.fullName, actualEmployee.fullName); // Verifica que el nombre coincida
            }
        }

        [Fact]
        public async Task GetAll_ReturnsEmptyList_WhenNoEmployeesExist()
        {
            // Arrange
            var mockEmployeePersistancePort = new Mock<IEmployeePersistancePort>();

            // Configura el mock para devolver una lista vacía
            mockEmployeePersistancePort.Setup(port => port.GetAll())
                                       .ReturnsAsync(new List<EmployeeEntity>());

            var useCaseEmployee = new UseCaseEmployee(mockEmployeePersistancePort.Object);

            // Act
            var result = await useCaseEmployee.GetAll();

            // Assert
            Assert.NotNull(result); // Verifica que el resultado no sea nulo
            Assert.Empty(result); // Verifica que la lista esté vacía
        }

        [Fact]
        public async Task GetAll_ThrowsException_WhenPersistancePortFails()
        {
            // Arrange
            var mockEmployeePersistancePort = new Mock<IEmployeePersistancePort>();

            // Configura el mock para lanzar una excepción
            mockEmployeePersistancePort.Setup(port => port.GetAll())
                                       .ThrowsAsync(new Exception("Error en el puerto de persistencia"));

            var useCaseEmployee = new UseCaseEmployee(mockEmployeePersistancePort.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => useCaseEmployee.GetAll());
        }
    }
}