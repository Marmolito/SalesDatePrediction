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
    public class ProductUseCaseTests
    {
        [Fact]
        public async Task GetAll_ReturnsProducts_WhenProductsExist()
        {
            var mockProductPersistancePort = new Mock<IProductPersistancePort>();
            var expectedProducts = new List<ProductModel>
        {
            new ProductModel { productid = 1, productname = "Product A" },
            new ProductModel { productid = 2, productname = "Product B" }
        };

            mockProductPersistancePort
                .Setup(port => port.GetAll())
                .ReturnsAsync(expectedProducts);

            var productService = new UseCaseProduct(mockProductPersistancePort.Object);
            var result = await productService.GetAll();

            Assert.NotNull(result);
            Assert.Equal(expectedProducts.Count, result.Count());
            Assert.Equal(expectedProducts, result);
        }

        [Fact]
        public async Task GetAll_ThrowsNotFoundException_WhenNoProductsExist()
        {
            var mockProductPersistancePort = new Mock<IProductPersistancePort>();
            var errorMessage = "No se encontraron Productos";

            mockProductPersistancePort
                .Setup(port => port.GetAll())
                .ReturnsAsync(new List<ProductModel>());

            var productService = new UseCaseProduct(mockProductPersistancePort.Object);
            var exception = await Assert.ThrowsAsync<NotFoundException>(() => productService.GetAll());

            Assert.Equal(errorMessage, exception.Message);
        }
    }
}