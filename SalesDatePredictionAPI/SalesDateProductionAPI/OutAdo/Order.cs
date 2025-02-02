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
    public class Order : IOrderOutAdo
    {
        private readonly string _connectionString;
        private readonly IMapper _mapper;

        public Order(IConfiguration configuration, IMapper mapper)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _mapper = mapper;
        }


        async Task<IEnumerable<OrderModel>> IOrderOutAdo.GetOrdersByCustomerId(int id)
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

        async Task<bool> IOrderOutAdo.CreateOrderProduct(OrderProductModel orderProduct)
        {
            using var connection = new SqlConnection(_connectionString);

            try
            {
                string query = @"
            DECLARE @RowsAffected INT = 0;

            BEGIN TRY
                BEGIN TRANSACTION;

                -- Insertar una nueva orden
                INSERT INTO Sales.Orders (empid, custid, shipperid, shipname, shipaddress, shipcity, orderdate, requireddate, shippeddate, freight, shipcountry)
                VALUES (@EmpID, @CustId, @ShipperID, @ShipName, @ShipAddress, @ShipCity, @OrderDate, @RequiredDate, @ShippedDate, @Freight, @ShipCountry);

                -- Obtener el OrderID generado
                DECLARE @NewOrderID INT = SCOPE_IDENTITY();

                -- Insertar un producto en la orden creada
                INSERT INTO Sales.OrderDetails (orderid, productid, unitprice, qty, discount)
                VALUES (@NewOrderID, @ProductID, @UnitPrice, @Qty, @Discount);

                COMMIT TRANSACTION;

                -- Establecer el número de filas afectadas
                SET @RowsAffected = 1;
            END TRY
            BEGIN CATCH
                ROLLBACK TRANSACTION;
                SET @RowsAffected = 0;
                THROW;
            END CATCH;

            -- Retornar el número de filas afectadas
            SELECT @RowsAffected AS RowsAffected;
                    "
                ;

                var rowsAffected = await connection.ExecuteScalarAsync<int>(query, orderProduct);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear Orden. {ex.Message}");
            }
        }
    }
}
