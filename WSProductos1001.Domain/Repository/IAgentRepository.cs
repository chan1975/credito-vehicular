using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Repository;

public interface IAgentRepository
{
    Task<IEnumerable<EAgent>> GetAllAsync();
    Task<EAgent> CreateAsync(EAgent agent);
    Task<EAgent> GetByIdAsync(int id);
}