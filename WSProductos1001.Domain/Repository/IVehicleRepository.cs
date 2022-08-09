using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Repository
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<EVehicle>> GetAllAsync();
        Task<EVehicle> GetByIdAsync(int id);
        Task<EVehicle> CreateAsync(EVehicle vehicle);
        Task UpdateAsync(EVehicle vehicleToUpdate);
        Task DeleteAsync(EVehicle vehicleToDelete);
    }
}
