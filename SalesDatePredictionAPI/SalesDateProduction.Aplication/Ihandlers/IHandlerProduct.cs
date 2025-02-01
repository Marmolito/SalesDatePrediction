using SalesDateProduction.Aplication.Models;
using System.Linq.Expressions;

namespace SalesDateProduction.Aplication
{
    public interface IHandlerProduct
    {
        Task<IEnumerable<ProductDto>> GetAll();

    }
}
