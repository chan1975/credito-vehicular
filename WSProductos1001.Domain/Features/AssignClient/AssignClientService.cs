using FluentValidation;
using WSProductos1001.Domain.Exceptions;
using WSProductos1001.Domain.Repository;
using ValidationException = FluentValidation.ValidationException;

namespace WSProductos1001.Domain.Features.AssignClient;

public class AssignClientService
{
    private readonly IAssignClientRepository _assignClientRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IPatioRepository _patioRepository;
    private readonly IValidator<Entities.AssignClient> _validator;
    public AssignClientService(IAssignClientRepository assignClientRepository, IClientRepository clientRepositoryObject,
        IPatioRepository patioRepositoryObject, IValidator<Entities.AssignClient> validator)
    {
        _assignClientRepository = assignClientRepository;
        _clientRepository = clientRepositoryObject;
        _patioRepository = patioRepositoryObject;
        _validator = validator;
    }

    public async Task<Entities.AssignClient> CreateAsync(Entities.AssignClient assignClient)
    {
        var result = await _validator.ValidateAsync(assignClient);
        if (!result.IsValid)
            throw new ValidationException(result.Errors);
        
        var client = await _clientRepository.GetByIdAsync(assignClient.ClientId);
        if (client == null)
            throw new BadRequestException("No existe el cliente para asignar");
        var patio = await _patioRepository.GetByIdAsync(assignClient.PatioId);
        if (patio == null)
            throw new BadRequestException("No existe el patio para asignar");
        
        var newAssignClient = await _assignClientRepository.CreateAsync(assignClient);
        return newAssignClient;
    }

    public async Task UpdateAsync(int id, Entities.AssignClient assignClient)
    {
        var result = await _validator.ValidateAsync(assignClient);
        if (!result.IsValid)
            throw new ValidationException(result.Errors);
        
        var client = await _clientRepository.GetByIdAsync(assignClient.ClientId);
        if (client == null)
            throw new BadRequestException("No existe el cliente para asignar");
        var patio = await _patioRepository.GetByIdAsync(assignClient.PatioId);
        if (patio == null)
            throw new BadRequestException("No existe el patio para asignar");
        
        var assignClientToUpdate = await _assignClientRepository.GetByIdAsync(id);
        if (assignClientToUpdate == null)
            throw new NotFoundException(nameof(Entities.AssignClient), id);
        
        assignClientToUpdate.AssignDate = assignClient.AssignDate;
        assignClientToUpdate.ClientId = assignClient.ClientId;
        assignClientToUpdate.PatioId = assignClient.PatioId;
        
        await _assignClientRepository.UpdateAsync(assignClient);
    }
}