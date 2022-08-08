using FluentValidation;
using WSProductos1001.Domain.Repository;
using WSProductos1001.Domain.Services;
using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Features.Patio;

public class PatioService: IPatioService
{
    private readonly IPatioRepository _patioRepository;
    private readonly IValidator<EPatio> _validator;
    
    public PatioService(IPatioRepository patioRepository, IValidator<EPatio> validator)
    {
        _patioRepository = patioRepository;
        _validator = validator;
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

    public async Task<EPatio> CreateAsync(EPatio patio)
    {
        await _validator.ValidateAndThrowAsync(patio);
        return patio;
        
    }
}