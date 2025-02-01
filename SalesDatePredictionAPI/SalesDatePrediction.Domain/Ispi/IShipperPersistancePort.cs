using SalesDatePrediction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Domain.Ispi
{
    public interface IShipperPersistancePort
    {
        Task<IEnumerable<ShipperModel>> GetAll();
    }
}
