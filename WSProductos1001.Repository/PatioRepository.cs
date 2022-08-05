using Microsoft.EntityFrameworkCore;
using WSProductos1001.Domain.Repository;
using WSProductos1001.Entities;
using WSProductos1001.Infrastucture.Context;

namespace WSProductos1001.Repository;

public class PatioRepository : IPatioRepository
{
    private readonly CreditContext _context;
    public PatioRepository(CreditContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<EPatio>> GetAllAsync()
    {
        var patioLit = await _context.Patios.ToListAsync();
        return patioLit;
    }
}