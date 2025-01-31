using Dapper;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SalesDatePrediction.Domain.Ispi;
using SalesDatePrediction.Domain.Models;
using System;

namespace SalesDateProductionAPI.Out
{
    public class Employee : IEmployeePersistancePort
    {
        private readonly string _connectionString;

        public Employee(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        async Task<IEnumerable<EmployeeEntity>> IEmployeePersistancePort.GetAll()
        {
            using var connection = new SqlConnection(_connectionString);

            try
            {
                string query = @"
                                SELECT 
                                    empid AS empid, 
                                    CONCAT(firstname, ' ', lastname) AS fullName 
                                FROM HR.Employees";
                var reservas = await connection.QueryAsync<EmployeeEntity>(query);

                return reservas;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar Empleados. {ex.Message}");
            }

        }
    }
}
