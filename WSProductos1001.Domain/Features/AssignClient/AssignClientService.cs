using FluentValidation;
using WSProductos1001.Domain.Exceptions;
using WSProductos1001.Domain.Features.RequestCredit;
using WSProductos1001.Domain.Repository;
using WSProductos1001.Domain.Services;
using WSProductos1001.Entities;
using ValidationException = FluentValidation.ValidationException;

namespace WSProductos1001.Domain.Features.AssignClient;



public class AssignClientService : IAssignClientService
{
    private readonly IAssignClientRepository _assignClientRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IPatioRepository _patioRepository;
    private readonly IValidator<EAssignClient> _validator;
    private readonly IRequestCreditRepository _requestCreditRepository;

    public AssignClientService(IAssignClientRepository assignClientRepository, IClientRepository clientRepositoryObject,
        IPatioRepository patioRepositoryObject, IValidator<EAssignClient> validator,
        IRequestCreditRepository requestCreditRepository)
    {
        _assignClientRepository = assignClientRepository;
        _clientRepository = clientRepositoryObject;
        _patioRepository = patioRepositoryObject;
        _validator = validator;
        _requestCreditRepository = requestCreditRepository;
    }

    public async Task<EAssignClient> CreateAsync(EAssignClient eAssignClient)
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

    public async Task UpdateAsync(int id, EAssignClient eAssignClient)
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
            throw new NotFoundException(nameof(EAssignClient), id);

        assignClientToUpdate.AssignDate = eAssignClient.AssignDate;
        assignClientToUpdate.ClientId = eAssignClient.ClientId;
        assignClientToUpdate.PatioId = eAssignClient.PatioId;

        await _assignClientRepository.UpdateAsync(eAssignClient);
    }

    public async Task DeleteAsync(int id)
    {
        var assignClientToDelete = await _assignClientRepository.GetByIdAsync(id);
        if (assignClientToDelete == null)
            throw new NotFoundException(nameof(EAssignClient), id);
        var requestCredit = await _requestCreditRepository.GetRequestRegistryByClientIdAndPatioId(assignClientToDelete.ClientId, assignClientToDelete.PatioId, (int) CreditStatus.Registry);
        if (requestCredit != null)
            throw new BadRequestException("La asignacion no puede ser eliminada, ya que existe un credito registrado para el cliente y patio");
        
        await _assignClientRepository.DeleteAsync(assignClientToDelete);
    }

    public async Task<EAssignClient> GetByIdAsync(int id)
    {
        var assignClient = await _assignClientRepository.GetByIdAsync(id);
        if (assignClient == null)
            throw new NotFoundException(nameof(EAssignClient), id);
        return assignClient;
    }
}