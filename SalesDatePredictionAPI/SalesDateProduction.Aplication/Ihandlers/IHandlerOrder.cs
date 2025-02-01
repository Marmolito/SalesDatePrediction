using SalesDateProduction.Aplication.Models;
using System.Linq.Expressions;

namespace SalesDateProduction.Aplication
{
    public interface IHandlerOrder
    {
        Task<IEnumerable<OrderDto>> GetOrdersByCustomerId(int id);

    }
}
