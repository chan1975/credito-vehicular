using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Repository;

public interface IPatioRepository
{
    Task<IEnumerable<EPatio>> GetAllAsync();
    Task<EPatio> GetByIdAsync(int id);
    Task<EPatio> CreateAsync(EPatio patio);
    Task UpdateAsync(EPatio patioToUpdate);
    Task DeleteAsync(EPatio patioToDelete);
}