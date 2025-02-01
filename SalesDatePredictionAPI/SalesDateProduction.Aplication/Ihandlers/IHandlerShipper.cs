using SalesDateProduction.Aplication.Models;
using System.Linq.Expressions;

namespace SalesDateProduction.Aplication
{
    public interface IHandlerShipper
    {
        Task<IEnumerable<ShipperDto>> GetAll();

    }
}
