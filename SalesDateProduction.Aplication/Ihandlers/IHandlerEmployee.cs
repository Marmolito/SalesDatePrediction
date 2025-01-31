using SalesDateProduction.Aplication.Models;
using System.Linq.Expressions;

namespace SalesDateProduction.Aplication
{
    public interface IHandlerEmployee
    {
        Task<IEnumerable<EmployeeDto>> GetAll();

    }
}
