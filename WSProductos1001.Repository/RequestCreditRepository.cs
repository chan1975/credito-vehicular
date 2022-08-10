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
    public Task<IEnumerable<ERequestCredit>> GetRequestCreditByClientId(int clientId)
    {
        throw new NotImplementedException();
    }

    public Task<ERequestCredit> CreateAsync(ERequestCredit requestCredit)
    {
        throw new NotImplementedException();
    }

    public Task<ERequestCredit> GetByIdAndRegsitryAsync(int id, int registryStatus)
    {
        throw new NotImplementedException();
    }

    public Task<ERequestCredit> UpdateAsync(ERequestCredit requestCredit)
    {
        throw new NotImplementedException();
    }

    public async Task<ERequestCredit> GetRequestCreditByVehicleRegistry(int vehicleId, int registryStatus)
    {
        var requestCredit = await _context.RequestCredit.FirstOrDefaultAsync(x => x.VehicleId == vehicleId && x.CreditStatus == registryStatus);
        return requestCredit;
    }

    public Task<ERequestCredit> GetRequestRegistryByClientIdAndPatioId(int clientId, int patioId, int registryStatus)
    {
        throw new NotImplementedException();
    }
}