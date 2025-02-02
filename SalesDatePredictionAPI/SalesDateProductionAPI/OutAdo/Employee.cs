using AutoMapper;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Domain.Ispi;
using SalesDatePrediction.Domain.Models;
using SalesDatePrediction.Models.Entities;

namespace SalesDateProductionAPI.Out
{
    public class Employee : IEmployeeOutAdo
    {
        private readonly string _connectionString;
        private readonly IMapper _mapper;

        public Employee(IConfiguration configuration, IMapper mapper)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _mapper = mapper;
        }


        async Task<IEnumerable<EmployeeModel>> IEmployeeOutAdo.GetAll()
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

                return _mapper.Map<IEnumerable<EmployeeModel>>(reservas);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar Empleados. {ex.Message}");
            }

        }
    }
}
