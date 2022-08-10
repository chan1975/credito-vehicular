using WSProductos1001.Domain.Features.RequestCredit;
using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Repository;

public interface IRequestCreditRepository
{
    Task<IEnumerable<ERequestCredit>> GetRequestCreditByClientId(int clientId);
    Task<ERequestCredit> CreateAsync(ERequestCredit requestCredit);
    Task<ERequestCredit> GetByIdAndRegsitryAsync(int id, int registryStatus);
    Task<ERequestCredit> UpdateAsync(ERequestCredit requestCredit);
    Task<ERequestCredit> GetRequestCreditByVehicleRegistry(int vehicleId, int registryStatus);
    Task<ERequestCredit> GetRequestRegistryByClientIdAndPatioId(int clientId, int patioId, int registryStatus);
}