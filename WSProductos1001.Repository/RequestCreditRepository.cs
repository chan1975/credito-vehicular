using Microsoft.EntityFrameworkCore;
using WSProductos1001.Domain.Repository;
using WSProductos1001.Entities;
using WSProductos1001.Infrastucture.Context;

namespace WSProductos1001.Repository;

public class RequestCreditRepository: IRequestCreditRepository
{
    private readonly CreditContext _context;
    public RequestCreditRepository(CreditContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<ERequestCredit>> GetRequestCreditByClientId(int clientId)
    {
        return await _context.RequestCredit.Where(x => x.ClientId == clientId).ToListAsync();
    }

    public async Task<ERequestCredit> CreateAsync(ERequestCredit requestCredit)
    {
        var newRequestCredit = await _context.RequestCredit.AddAsync(requestCredit);
        await _context.SaveChangesAsync();
        return newRequestCredit.Entity;
    }

    public async Task<ERequestCredit> GetByIdAndRegsitryAsync(int id, int registryStatus)
    {
        var requestCredit = await _context.RequestCredit.FirstOrDefaultAsync(x => x.Id == id && x.CreditStatus == registryStatus);
        return requestCredit;
    }

    public async Task UpdateAsync(ERequestCredit requestCredit)
    {
        _context.RequestCredit.Update(requestCredit);
        await _context.SaveChangesAsync();
    }

    public async Task<ERequestCredit> GetRequestCreditByVehicleRegistry(int vehicleId, int registryStatus)
    {
        var requestCredit = await _context.RequestCredit.FirstOrDefaultAsync(x => x.VehicleId == vehicleId && x.CreditStatus == registryStatus);
        return requestCredit;
    }

    public async Task<ERequestCredit> GetRequestRegistryByClientIdAndPatioId(int clientId, int patioId, int registryStatus)
    {
        var requestCredit = await _context.RequestCredit.FirstOrDefaultAsync(x => x.ClientId == clientId && x.PatioId == patioId && x.CreditStatus == registryStatus);
        return requestCredit;
    }

    public async Task<ERequestCredit> GetByIdAsync(int id)
    {
        var request = await _context.RequestCredit.FirstOrDefaultAsync(x => x.Id == id);
        return request;
    }
}