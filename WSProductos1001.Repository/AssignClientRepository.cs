using WSProductos1001.Domain.Repository;
using WSProductos1001.Entities;

namespace WSProductos1001.Repository;

public class AssignClientRepository:IAssignClientRepository
{
    public Task<AssignClient> CreateAsync(AssignClient assignClient)
    {
        throw new NotImplementedException();
    }

    public Task<AssignClient> UpdateAsync(AssignClient assignClient)
    {
        throw new NotImplementedException();
    }

    public Task<AssignClient> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}