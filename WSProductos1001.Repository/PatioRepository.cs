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

    public async Task<EPatio> CreateAsync(EPatio patio)
    {
        var newPatio = await _context.Patios.AddAsync(patio);
        await _context.SaveChangesAsync();
        return newPatio.Entity;
    }

    public async Task DeleteAsync(EPatio patioToDelete)
    {
        _context.Patios.Remove(patioToDelete);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<EPatio>> GetAllAsync()
    {
        var patioLit = await _context.Patios.ToListAsync();
        return patioLit;
    }

    public async Task<EPatio> GetByIdAsync(int id)
    {
        var patio = await _context.Patios.FindAsync(id);
        return patio;
    }

    public async Task UpdateAsync(EPatio patioToUpdate)
    {
        _context.Patios.Update(patioToUpdate);
        await _context.SaveChangesAsync();
    }
}