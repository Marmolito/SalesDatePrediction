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
        private readonly IEmployeePersistancePort _iEmployeePersistancePort;

        public UseCaseEmployee(IEmployeePersistancePort iEmployeePersistancePort)
        {
            _iEmployeePersistancePort = iEmployeePersistancePort;
        }
        public async Task<IEnumerable<EmployeeModel>> GetAll()
        {
            var employee = await _iEmployeePersistancePort.GetAll();

            if (employee == null || !employee.Any())
            {
                throw new NotFoundException("No se encontraron Empleados");
            }

            return employee;
        }
    }
}
