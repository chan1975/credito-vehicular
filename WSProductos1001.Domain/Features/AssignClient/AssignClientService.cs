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
    private readonly IValidator<Entities.EAssignClient> _validator;
    public AssignClientService(IAssignClientRepository assignClientRepository, IClientRepository clientRepositoryObject,
        IPatioRepository patioRepositoryObject, IValidator<Entities.EAssignClient> validator)
    {
        _assignClientRepository = assignClientRepository;
        _clientRepository = clientRepositoryObject;
        _patioRepository = patioRepositoryObject;
        _validator = validator;
    }

    public async Task<Entities.EAssignClient> CreateAsync(Entities.EAssignClient eAssignClient)
    {
        var result = await _validator.ValidateAsync(eAssignClient);
        if (!result.IsValid)
            throw new ValidationException(result.Errors);
        
        var client = await _clientRepository.GetByIdAsync(eAssignClient.ClientId);
        if (client == null)
            throw new BadRequestException("No existe el cliente para asignar");
        var patio = await _patioRepository.GetByIdAsync(eAssignClient.PatioId);
        if (patio == null)
            throw new BadRequestException("No existe el patio para asignar");
        
        var newAssignClient = await _assignClientRepository.CreateAsync(eAssignClient);
        return newAssignClient;
    }

    public async Task UpdateAsync(int id, Entities.EAssignClient eAssignClient)
    {
        var result = await _validator.ValidateAsync(eAssignClient);
        if (!result.IsValid)
            throw new ValidationException(result.Errors);
        
        var client = await _clientRepository.GetByIdAsync(eAssignClient.ClientId);
        if (client == null)
            throw new BadRequestException("No existe el cliente para asignar");
        var patio = await _patioRepository.GetByIdAsync(eAssignClient.PatioId);
        if (patio == null)
            throw new BadRequestException("No existe el patio para asignar");
        
        var assignClientToUpdate = await _assignClientRepository.GetByIdAsync(id);
        if (assignClientToUpdate == null)
            throw new NotFoundException(nameof(Entities.EAssignClient), id);
        
        assignClientToUpdate.AssignDate = eAssignClient.AssignDate;
        assignClientToUpdate.ClientId = eAssignClient.ClientId;
        assignClientToUpdate.PatioId = eAssignClient.PatioId;
        
        await _assignClientRepository.UpdateAsync(eAssignClient);
    }
}