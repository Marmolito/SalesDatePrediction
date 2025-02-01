using Dapper;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SalesDatePrediction.Domain.Ispi;
using SalesDatePrediction.Domain.Models;
using System;
using AutoMapper;
using SalesDateProductionAPI.Models.Entities;

namespace SalesDateProductionAPI.Out
{
    public class Customer : ICustomerPersistancePort
    {
        private readonly string _connectionString;
        private readonly IMapper _mapper;

        public Customer(IConfiguration configuration, IMapper mapper)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _mapper = mapper;
        }


        async Task<IEnumerable<CustomerModel>> ICustomerPersistancePort.GetAll()
        {
            using var connection = new SqlConnection(_connectionString);

            try
            {
                string query = @"
                                WITH Diferencias AS (
                                    SELECT 
                                        O.custid,
                                        DATEDIFF(DAY, LAG(O.orderdate) OVER (PARTITION BY O.custid ORDER BY O.orderdate), O.orderdate) AS diferencia_dias
                                    FROM Sales.Orders O
                                )
                                SELECT DISTINCT
                                    C.contactname AS ContactName,
                                    MAX(O.orderdate) AS LastOrderDate,
                                    DATEADD(DAY, AVG(Diferencias.diferencia_dias), MAX(O.orderdate)) AS NextPredictedDate
                                FROM Sales.Orders O  
                                JOIN Sales.Customers C ON O.custid = C.custid
                                JOIN Diferencias ON O.custid = Diferencias.custid
                                WHERE Diferencias.diferencia_dias IS NOT NULL
                                GROUP BY C.contactname";

                var predictedDateCustomer = await connection.QueryAsync<CustomerEntity>(query);

                return _mapper.Map<IEnumerable<CustomerModel>>(predictedDateCustomer);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar Clientes. {ex.Message}");
            }

        }
    }
}
