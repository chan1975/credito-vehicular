using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Repository;

public interface IClientRepository
{
    Task<EClient> CreateAsync(EClient client);
}