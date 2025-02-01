using SalesDatePrediction.Domain.Models;

namespace SalesDatePrediction.Domain.Ispi
{
    public interface IEmployeePersistancePort
    {
        Task<IEnumerable<EmployeeModel>> GetAll();
    }
}
