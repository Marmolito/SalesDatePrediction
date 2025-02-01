using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Domain.Ispi;
using SalesDatePrediction.Domain.Models;
using AutoMapper;
using SalesDateProductionAPI.Models.Entities;

namespace SalesDateProductionAPI.Out
{
    public class Shipper : IShipperPersistancePort
    {
        private readonly string _connectionString;
        private readonly IMapper _mapper;

        public Shipper(IConfiguration configuration, IMapper mapper)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _mapper = mapper;
        }

        async Task<IEnumerable<ShipperModel>> IShipperPersistancePort.GetAll()
        {
            using var connection = new SqlConnection(_connectionString);

            try
            {
                string query = @"
                                SELECT 
	                                shipperid,
	                                companyname
                                FROM Sales.Shippers";

                var shippers = await connection.QueryAsync<ShipperEntity>(query);

                return _mapper.Map<IEnumerable<ShipperModel>>(shippers);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar Transportadoras. {ex.Message}");
            }

        }
    }
}
