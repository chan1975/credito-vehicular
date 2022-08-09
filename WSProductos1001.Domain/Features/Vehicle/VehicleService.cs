using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSProductos1001.Domain.Repository;
using WSProductos1001.Domain.Services;
using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Features.Vehicle
{
    internal class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        public async Task<IEnumerable<EVehicle>> GetAllAsync()
        {
            var vehicleList = await _vehicleRepository.GetAllAsync();
            return vehicleList;
        }
    }
}
