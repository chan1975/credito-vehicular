using WSProductos1001.Domain.Repository;
using WSProductos1001.Entities;

namespace WSProductos1001.Repository;

public class RequestCreditRepository: IRequestCreditRepository
{
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

    public Task<ERequestCredit> GetRequestCreditByVehicleRegistry(int vehicleId, int registryStatus)
    {
        throw new NotImplementedException();
    }
}