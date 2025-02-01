using SalesDatePrediction.Aplication.Models;
using SalesDateProduction.Aplication.Models;
using System.Linq.Expressions;

namespace SalesDateProduction.Aplication
{
    public interface IHandlerOrder
    {
        Task<IEnumerable<OrderDto>> GetOrdersByCustomerId(int id);

        Task CreateOrdeProduct(OrderProductDto orderProduct);

    }
}
