using AutoMapper;
using SalesDatePrediction.Domain.Iapi;
using SalesDateProduction.Aplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDateProduction.Aplication
{
    public class ImpHandlerShipper : IHandlerShipper
    {
        private readonly IShipper _iShipper;
        private readonly IMapper _mapper;

        public ImpHandlerShipper(IShipper iShipper, IMapper mapper)
        {
            _iShipper = iShipper;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShipperDto>> GetAll()
        {
            var OrdersByClientId = await _iShipper.GetAll();
            return _mapper.Map<IEnumerable<ShipperDto>>(OrdersByClientId);

        }
    }
}
