using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Repository;

public interface IAssignClientRepository
{
    Task<AssignClient> CreateAsync(AssignClient assignClient);
    Task<AssignClient> UpdateAsync(AssignClient assignClient);
    Task<AssignClient> GetByIdAsync(int id);
}