using SalesDatePrediction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Domain.Iapi
{
    public interface IOrder
    {
        Task<IEnumerable<OrderModel>> GetOrdersByCustomerId(int id);
    }
}
