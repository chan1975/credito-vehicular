using FluentValidation;
using WSProductos1001.Domain.Exceptions;
using WSProductos1001.Domain.Repository;
using WSProductos1001.Domain.Services;
using WSProductos1001.Entities;
using ValidationException = WSProductos1001.Domain.Exceptions.ValidationException;

namespace WSProductos1001.Domain.Features.Agent;

public class AgentService: IAgentService
{
    private readonly IAgentRepository _agentRepository;
    private readonly IValidator<EAgent> _validator;
    private readonly IPatioRepository _patioRepository;
    
    public AgentService(IAgentRepository agentRepository, IPatioRepository patioRepository, IValidator<EAgent> validator)
    {
        _agentRepository = agentRepository;
        _patioRepository = patioRepository;
        _validator = validator;
    }
    public async Task<IEnumerable<EAgent>> GetAllAsync()
    {
        var agents =await  _agentRepository.GetAllAsync();
        return agents;
    }

    public async Task UploadAgents(List<EAgent> listAgent)
    {
        if (listAgent.Count() != listAgent.Select(x => x.Identification).Distinct().Count())
            throw new BadRequestException("La lista contiene agentes repetidos");
        foreach (var agent in listAgent)
        {
            var resultValidation = await  _validator.ValidateAsync(agent);
            if (!resultValidation.IsValid)
                throw new ValidationException(resultValidation.Errors);
            var patio = await _patioRepository.GetByIdAsync(agent.PatioId);
            if(patio is null)
                throw new BadRequestException("El patio no existe");
        }
        
        foreach (var eAgent in listAgent)
        {
            await _agentRepository.CreateAsync(eAgent);
        }
    }
}