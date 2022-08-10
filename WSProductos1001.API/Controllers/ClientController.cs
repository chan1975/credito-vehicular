using System.Globalization;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using WSProductos1001.Domain.Exceptions;
using WSProductos1001.Domain.Services;
using WSProductos1001.Entities;
using ValidationException = CsvHelper.ValidationException;

namespace WSProductos1001.API.Controllers;

[ApiController]
[Route("api/v1/clientes")]
public class ClientController: ControllerBase
{
    private readonly IClientService _clientService;
    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpPost("carga")]
    public async Task<IActionResult> UploadClients(IFormFile clients)
    {
        if(clients == null)
        {
            return BadRequest("No se ha seleccionado ningun archivo");
        }
        try
        {
            var listClient = new List<EClient>();
            using (var reader = new StreamReader(clients.OpenReadStream()))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<ClientMap>();
                listClient = csv.GetRecords<EClient>().ToList();
            }

            if (listClient.Count() == 0) return BadRequest("El archivo no contiene datos");
            await _clientService.UploadClients(listClient);
            return Ok();
        }
        catch (BadRequestException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}