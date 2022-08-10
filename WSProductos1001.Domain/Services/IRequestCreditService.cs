using WSProductos1001.Domain.Features.RequestCredit;
using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Services;

public interface IRequestCreditService
{
    Task<ERequestCredit> CreateAsync(ERequestCredit requestCredit);
    Task UpdateCreditStatusAsync(int id, CreditStatus creditStatus);
    Task<ERequestCredit> GetByIdAsync(int id);
}