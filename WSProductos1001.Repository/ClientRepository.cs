using WSProductos1001.Domain.Repository;
using WSProductos1001.Entities;
using WSProductos1001.Infrastucture.Context;

namespace WSProductos1001.Repository;

public class ClientRepository : IClientRepository
{
    private readonly CreditContext _context;

    public ClientRepository(CreditContext context)
    {
        _context = context;
    }

    public async Task<EClient> CreateAsync(EClient client)
    {
        var result = await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<EClient> GetByIdAsync(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        return client;
    }
}