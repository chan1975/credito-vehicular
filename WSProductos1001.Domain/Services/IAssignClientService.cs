using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Services;

public interface IAssignClientService
{
    Task<EAssignClient> CreateAsync(EAssignClient eAssignClient);
    Task UpdateAsync(int id, EAssignClient eAssignClient);
    Task DeleteAsync(int id);
    Task<EAssignClient> GetByIdAsync(int id);
}