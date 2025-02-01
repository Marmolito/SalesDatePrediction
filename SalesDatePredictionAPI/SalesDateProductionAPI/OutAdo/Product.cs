using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Domain.Ispi;
using SalesDatePrediction.Domain.Models;
using AutoMapper;
using SalesDateProductionAPI.Models.Entities;
using SalesDateProduction.Aplication;

namespace SalesDateProductionAPI.Out
{
    public class Product : IProductPersistancePort
    {
        private readonly string _connectionString;
        private readonly IMapper _mapper;

        public Product(IConfiguration configuration, IMapper mapper)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _mapper = mapper;
        }

        async Task<IEnumerable<ProductModel>> IProductPersistancePort.GetAll()
        {
            using var connection = new SqlConnection(_connectionString);

            try
            {
                string query = @"
                                SELECT 
	                                productid,
	                                productname
                                FROM Production.Products";

                var products = await connection.QueryAsync<ProductEntity>(query);

                return _mapper.Map<IEnumerable<ProductModel>>(products);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar Transportadoras. {ex.Message}");
            }

        }
    }
}
