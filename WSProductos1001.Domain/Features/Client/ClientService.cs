using FluentValidation;
using WSProductos1001.Domain.Exceptions;
using WSProductos1001.Domain.Repository;
using WSProductos1001.Domain.Services;
using WSProductos1001.Entities;
using ValidationException = WSProductos1001.Domain.Exceptions.ValidationException;

namespace WSProductos1001.Domain.Features.Client;

public class ClientService: IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IValidator<EClient> _validator;
    private readonly ICatalogRepository _catalogRepository;
    
    public ClientService(IClientRepository clientRepository, IValidator<EClient> validator, ICatalogRepository catalogRepository)
    {
        _clientRepository = clientRepository;
        _validator = validator;
        _catalogRepository = catalogRepository;
    }
    
    public async Task UploadClients(List<EClient> listClient)
    {
        var listMaritalStatus = await _catalogRepository.GetAllMaritalStatus();
        var listSubjectCredit = await _catalogRepository.GetAllSubjectCredit();
        //check if marital status and subject credit are valid and valid model
        foreach (var client in listClient)
        {
            if (!listMaritalStatus.Any(x => x.Id == client.MaritalStatus))
                throw new BadRequestException("No existe el estado civil");
            if (!listSubjectCredit.Any(x => x.Id == client.SubjectCredit))
                throw new BadRequestException("No existe el tipo de sujecto de credito");
            var result = await  _validator.ValidateAsync(client);
            if(!result.IsValid) throw new ValidationException(result.Errors);
        }
        //check if identification is unique in listClient
        var listIdentification = listClient.Select(x => x.Identification).ToList();
        if (listIdentification.Distinct().Count() != listIdentification.Count())
            throw new BadRequestException("Identificacion no es unica");
        //insert clients
        foreach (var client in listClient)
        {
            await _clientRepository.CreateAsync(client);
        }

    }
}