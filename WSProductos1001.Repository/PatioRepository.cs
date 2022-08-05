using WSProductos1001.Domain.Repository;
using WSProductos1001.Entities;

namespace WSProductos1001.Repository;

public class PatioRepository : IPatioRepository
{
    public async Task<EPatio> CreateAsync(EPatio entity)
    {
        return entity;
    }
}