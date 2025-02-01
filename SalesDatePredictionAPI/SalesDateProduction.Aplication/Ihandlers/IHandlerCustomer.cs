using SalesDateProduction.Aplication.Models;
using System.Linq.Expressions;

namespace SalesDateProduction.Aplication
{
    public interface IHandlerCustomer
    {
        Task<IEnumerable<CustomerDto>> GetAll();

    }
}
