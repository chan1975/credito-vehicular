using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Repository;

public interface IAssignClientRepository
{
    Task<EAssignClient> CreateAsync(EAssignClient eAssignClient);
    Task<EAssignClient> UpdateAsync(EAssignClient eAssignClient);
    Task<EAssignClient> GetByIdAsync(int id);
}