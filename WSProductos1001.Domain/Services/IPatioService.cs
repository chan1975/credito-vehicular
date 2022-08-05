using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Services;

public interface IPatioService
{
    Task<IEnumerable<EPatio>> GetAllAsync();
    Task<EPatio?> GetByIdAsync(int id);
    Task<EPatio> CreateAsync(EPatio patio);
}