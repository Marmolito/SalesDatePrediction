using Dapper;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SalesDatePrediction.Domain.Ispi;
using SalesDatePrediction.Domain.Models;
using AutoMapper;
using SalesDateProductionAPI.Models.Entities;

namespace SalesDateProductionAPI.Out
{
    public class Order : IOrderPersistancePort
    {
        private readonly string _connectionString;
        private readonly IMapper _mapper;

        public Order(IConfiguration configuration, IMapper mapper)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _mapper = mapper;
        }


        async Task<IEnumerable<OrderModel>> IOrderPersistancePort.GetOrdersByCustomerId(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            try
            {
                string query = @"
                                SELECT 
	                                O.orderid,
	                                O.requireddate,
	                                O.shippeddate,
	                                O.shipname,
	                                O.shipaddress,
	                                O.shipcity
                                FROM Sales.Orders O
                                JOIN Sales.Customers C ON O.custid = C.custid
                                WHERE C.custid = " + id;

                var ordersByCustomerId = await connection.QueryAsync<OrderEntity>(query);

                return _mapper.Map<IEnumerable<OrderModel>>(ordersByCustomerId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar Ordenes. {ex.Message}");
            }

        }
    }
}
