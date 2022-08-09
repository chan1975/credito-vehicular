using Microsoft.EntityFrameworkCore;
using WSProductos1001.Domain.Repository;
using WSProductos1001.Entities;
using WSProductos1001.Infrastucture.Context;

namespace WSProductos1001.Repository
{
    internal class VehicleRepository : IVehicleRepository
    {
        private readonly CreditContext _context;
        public VehicleRepository(CreditContext context)
        {
            _context = context;
        }
        public Task<EVehicle> CreateAsync(EVehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(EVehicle vehicleToDelete)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EVehicle>> GetAllAsync()
        {
            var vehicles = await _context.Vehicles.ToListAsync();
            return vehicles;

        }

        public Task<EVehicle> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(EVehicle vehicleToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
