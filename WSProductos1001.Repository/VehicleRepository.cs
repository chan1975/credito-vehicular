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
        public async Task<EVehicle> CreateAsync(EVehicle vehicle)
        {
            var newVehicle = await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
            return newVehicle.Entity;
        }

        public async Task DeleteAsync(EVehicle vehicleToDelete)
        {
            _context.Vehicles.Remove(vehicleToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EVehicle>> GetAllAsync()
        {
            var vehicles = await _context.Vehicles.ToListAsync();
            return vehicles;

        }

        public async Task<EVehicle> GetByIdAsync(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            return vehicle;
        }

        public async Task UpdateAsync(EVehicle vehicleToUpdate)
        {
            _context.Vehicles.Update(vehicleToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
