using Microsoft.EntityFrameworkCore;
using WSProductos1001.Domain.Repository;
using WSProductos1001.Entities;
using WSProductos1001.Infrastucture.Context;

namespace WSProductos1001.Repository;

public class AssignClientRepository:IAssignClientRepository
{
    private readonly CreditContext _context;
    public AssignClientRepository(CreditContext context)
    {
        _context = context;
    }
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

    public async Task<IEnumerable<EAssignClient>> GetByPatioId(int patioId)
    {
        var assignClient = await _context.AssignClients.Where(x => x.PatioId == patioId).ToListAsync();
        return assignClient;
    }

    public Task DeleteAsync(EAssignClient eAssignClient)
    {
        throw new NotImplementedException();
    }
}