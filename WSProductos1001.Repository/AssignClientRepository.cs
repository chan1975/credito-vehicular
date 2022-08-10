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
    public async Task<EAssignClient> CreateAsync(EAssignClient eAssignClient)
    {
        var result = await _context.AssignClients.AddAsync(eAssignClient);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task UpdateAsync(EAssignClient eAssignClient)
    {
        _context.AssignClients.Update(eAssignClient);
        await _context.SaveChangesAsync();
    }

    public async Task<EAssignClient> GetByIdAsync(int id)
    {
        var assignClient = await _context.AssignClients.FirstOrDefaultAsync(x => x.Id == id);
        return assignClient;
    }

    public async Task<IEnumerable<EAssignClient>> GetByPatioId(int patioId)
    {
        var assignClient = await _context.AssignClients.Where(x => x.PatioId == patioId).ToListAsync();
        return assignClient;
    }

    public async Task DeleteAsync(EAssignClient eAssignClient)
    {
        _context.AssignClients.Remove(eAssignClient);
        await _context.SaveChangesAsync();
    }
}