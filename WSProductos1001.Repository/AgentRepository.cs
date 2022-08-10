using Microsoft.EntityFrameworkCore;
using WSProductos1001.Domain.Repository;
using WSProductos1001.Entities;
using WSProductos1001.Infrastucture.Context;

namespace WSProductos1001.Repository;

public class AgentRepository: IAgentRepository
{
    private readonly CreditContext _context;
    public AgentRepository(CreditContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<EAgent>> GetAllAsync()
    {
        var result = await _context.Agents.ToListAsync();
        return result;
    }

    public async Task<EAgent> CreateAsync(EAgent agent)
    {
        var newAgent = await _context.Agents.AddAsync(agent);
        await _context.SaveChangesAsync();
        return newAgent.Entity;
    }

    public Task<EAgent> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}