using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Repository;

public interface IPatioRepository
{
    Task<IEnumerable<EPatio>> GetAllAsync();
}