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
    public class UseCaseShipper : IShipper
    {
        private readonly IShipperPersistancePort _iShipperPersistancePort;
        const string errorMessagge = "No se encontraron Transportadoras";

        public UseCaseShipper(IShipperPersistancePort iShipperPersistancePort)
        {
            _iShipperPersistancePort = iShipperPersistancePort;
        }
        public async Task<IEnumerable<ShipperModel>> GetAll()
        {
            var shippers = await _iShipperPersistancePort.GetAll();

            if (shippers == null || !shippers.Any())
            {
                throw new NotFoundException(errorMessagge);
            }

            return shippers;
        }
    }
}
