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
    public class ShipperUseCaseTests
    {
        [Fact]
        public async Task GetAll_ReturnsShippers_WhenShippersExist()
        {
            var mockShipperPersistancePort = new Mock<IShipperOutAdo>();
            var expectedShippers = new List<ShipperModel>
        {
            new ShipperModel { shipperid = 1, companyname = "Shipper A" },
            new ShipperModel { shipperid = 2, companyname = "Shipper B" }
        };

            mockShipperPersistancePort
                .Setup(port => port.GetAll())
                .ReturnsAsync(expectedShippers);

            var shipperService = new UseCaseShipper(mockShipperPersistancePort.Object);
            var result = await shipperService.GetAll();

            Assert.NotNull(result);
            Assert.Equal(expectedShippers.Count, result.Count());
            Assert.Equal(expectedShippers, result);
        }

        [Fact]
        public async Task GetAll_ThrowsNotFoundException_WhenNoShippersExist()
        {
            var mockShipperPersistancePort = new Mock<IShipperOutAdo>();
            var errorMessage = "No se encontraron Transportadoras";

            mockShipperPersistancePort
                .Setup(port => port.GetAll())
                .ReturnsAsync(new List<ShipperModel>());

            var shipperService = new UseCaseShipper(mockShipperPersistancePort.Object);
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => shipperService.GetAll());

            Assert.Equal(errorMessage, exception.Message);
        }

    }
}