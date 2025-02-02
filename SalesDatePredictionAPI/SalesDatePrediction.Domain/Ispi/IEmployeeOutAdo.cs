using SalesDatePrediction.Domain.Models;

namespace SalesDatePrediction.Domain.Ispi
{
    public interface IEmployeeOutAdo
    {
        Task<IEnumerable<EmployeeModel>> GetAll();
    }
}
