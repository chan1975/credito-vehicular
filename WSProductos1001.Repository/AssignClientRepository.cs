using WSProductos1001.Domain.Repository;
using WSProductos1001.Entities;

namespace WSProductos1001.Repository;

public class AssignClientRepository:IAssignClientRepository
{
    public Task<EAssignClient> CreateAsync(EAssignClient eAssignClient)
    {
        throw new NotImplementedException();
    }

    public Task<EAssignClient> UpdateAsync(EAssignClient eAssignClient)
    {
        throw new NotImplementedException();
    }

    public Task<EAssignClient> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<EAssignClient>> GetByPatioId(int patioId)
    {
        throw new NotImplementedException();
    }
}