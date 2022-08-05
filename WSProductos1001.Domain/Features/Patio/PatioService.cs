using WSProductos1001.Domain.Repository;
using WSProductos1001.Domain.Services;
using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Features.Patio;

public class PatioService: IPatioService
{
    private readonly IPatioRepository _patioRepository;
    
    public PatioService(IPatioRepository patioRepository)
    {
        _patioRepository = patioRepository;
    }
    public async Task<IEnumerable<EPatio>> GetAllAsync()
    {
        var patioList = await _patioRepository.GetAllAsync();
        return patioList;
    }

    public Task<EPatio?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<EPatio> CreateAsync(EPatio patio)
    {
        throw new NotImplementedException();
    }
}