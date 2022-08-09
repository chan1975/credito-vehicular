
using FluentValidation;
using WSProductos1001.Domain.Repository;
using WSProductos1001.Domain.Services;
using WSProductos1001.Entities;

namespace WSProductos1001.Domain.Features.Patio;

public class PatioService : IPatioService
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

    public async Task<EPatio?> GetByIdAsync(int id)
    {
        var result = await _patioRepository.GetByIdAsync(id);
        return result;
    }

    public async Task<EPatio?> CreateAsync(EPatio patio)
    {
        var result = await _validator.ValidateAsync(patio);
        if (result.Errors.Any()) throw new Exceptions.ValidationException(result.Errors);
        var newPatio = await _patioRepository.CreateAsync(patio);
        return newPatio;

    }

    public async Task UpdateAsync(int id, EPatio patio)
    {
        var result = await _validator.ValidateAsync(patio);
        if (result.Errors.Any()) throw new Exceptions.ValidationException(result.Errors);
        var patioToUpdate = await _patioRepository.GetByIdAsync(id);
        if (patioToUpdate == null) throw new Exceptions.NotFoundException(nameof(EPatio), id);
        patioToUpdate.Phone = patio.Phone;
        patioToUpdate.Name = patio.Name;
        patioToUpdate.Address = patio.Address;
        patioToUpdate.NumberSalePoint = patio.NumberSalePoint;
        await _patioRepository.UpdateAsync(patioToUpdate);
    }

    public async Task DeleteAsync(int id)
    {
        var patioToDelete = await _patioRepository.GetByIdAsync(id);
        if (patioToDelete == null) throw new Exceptions.NotFoundException(nameof(EPatio), id);
        await _patioRepository.DeleteAsync(patioToDelete);
    }
}