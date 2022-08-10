using FluentValidation;
using WSProductos1001.Domain.Exceptions;
using WSProductos1001.Domain.Repository;
using WSProductos1001.Domain.Services;
using WSProductos1001.Entities;
using ValidationException = WSProductos1001.Domain.Exceptions.ValidationException;

namespace WSProductos1001.Domain.Features.RequestCredit;

public class RequestCreditService : IRequestCreditService
{
    private readonly IRequestCreditRepository _requestCreditRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IPatioRepository _patioRepository;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IAgentRepository _agentRepository;
    private readonly IValidator<ERequestCredit> _validator;
    private readonly IAssignClientRepository _assignClientRepository;
    
    public RequestCreditService(IRequestCreditRepository requestCreditRepository, IClientRepository clientRepository,
        IPatioRepository patioRepository, IVehicleRepository vehicleRepository, IAgentRepository agentRepository,
        IValidator<ERequestCredit> validator, IAssignClientRepository assignClientRepository)
    {
        _requestCreditRepository = requestCreditRepository;
        _clientRepository = clientRepository;
        _patioRepository = patioRepository;
        _vehicleRepository = vehicleRepository;
        _agentRepository = agentRepository;
        _validator = validator;
        _assignClientRepository = assignClientRepository;
    }

    public async Task<ERequestCredit> CreateAsync(ERequestCredit requestCredit)
    {
        var resultValidator = await _validator.ValidateAsync(requestCredit);
        if (!resultValidator.IsValid)
            throw new ValidationException(resultValidator.Errors);
        var client = await _clientRepository.GetByIdAsync(requestCredit.ClientId);
        if (client == null)
            throw new BadRequestException("El cliente no existe");
        var patio = await _patioRepository.GetByIdAsync(requestCredit.PatioId);
        if (patio == null)
            throw new BadRequestException("El patio no existe");
        var vehicle = await _vehicleRepository.GetByIdAsync(requestCredit.VehicleId);
        if (vehicle == null)
            throw new BadRequestException("El vehiculo no existe");
        var agent = await _agentRepository.GetByIdAsync(requestCredit.AgentId);
        if (agent == null)
            throw new BadRequestException("El agente no existe");

        var listRequestCreditCliendId =
            await _requestCreditRepository.GetRequestCreditByClientId(requestCredit.ClientId);
        //chack if the client has a request credit in same day
        foreach (var item in listRequestCreditCliendId)
        {
            if (item.BuildDate.Date == requestCredit.BuildDate.Date)
                throw new BadRequestException("El cliente ya tiene un credito en ese dia");
        }
        var vehicleAssign = await _requestCreditRepository.GetRequestCreditByVehicleRegistry(requestCredit.VehicleId, (int)CreditStatus.Registry);
        if (vehicleAssign != null)
            throw new BadRequestException("El vehiculo ya tiene un credito registrado");
        requestCredit.CreditStatus = (int)CreditStatus.Registry;
        var newRequestCredit = await _requestCreditRepository.CreateAsync(requestCredit);
        
        await _assignClientRepository.CreateAsync(new (){
            ClientId = requestCredit.ClientId,
            PatioId = newRequestCredit.Id,
            AssignDate = requestCredit.BuildDate
        });
        
        return newRequestCredit;
    }

    public async Task UpdateCreditStatusAsync(int id, CreditStatus creditStatus)
    {
        var requestCredit = await _requestCreditRepository.GetByIdAndRegsitryAsync(id, (int)CreditStatus.Registry);
        if (requestCredit == null)
            throw new NotFoundException(nameof(ERequestCredit), id);
        
        requestCredit.CreditStatus = (int)creditStatus;
        await _requestCreditRepository.UpdateAsync(requestCredit);
    }

    public async Task<ERequestCredit> GetByIdAsync(int id)
    {
        var requestCredit = await _requestCreditRepository.GetByIdAsync(id);
        if (requestCredit == null)
            throw new NotFoundException(nameof(ERequestCredit), id);
        return requestCredit;
    }
}