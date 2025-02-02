using SalesDatePrediction.Domain.Exceptions;
using SalesDatePrediction.Domain.Iapi;
using SalesDatePrediction.Domain.Ispi;
using SalesDatePrediction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aplication
{
    public class UseCaseEmployee : IEmployee
    {
        private readonly IEmployeeOutAdo _iEmployeePersistancePort;
        const string errorMessage = "No se encontraron Empleados";

        public UseCaseEmployee(IEmployeeOutAdo iEmployeePersistancePort)
        {
            _iEmployeePersistancePort = iEmployeePersistancePort;
        }
        public async Task<IEnumerable<EmployeeModel>> GetAll()
        {
            var employee = await _iEmployeePersistancePort.GetAll();

            if (employee == null || !employee.Any())
            {
                throw new NotFoundException(errorMessage);
            }

            return employee;
        }
    }
}
