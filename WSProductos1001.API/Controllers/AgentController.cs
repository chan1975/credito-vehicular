using System.Globalization;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using WSProductos1001.Domain.Exceptions;
using WSProductos1001.Domain.Services;
using WSProductos1001.Entities;
using ValidationException = WSProductos1001.Domain.Exceptions.ValidationException;

namespace WSProductos1001.API.Controllers;

[ApiController]
[Route("api/v1/agentes")]
public class AgentController: ControllerBase
{
    private readonly IAgentService _agentService;
    public AgentController(IAgentService agentService)
    {
        _agentService = agentService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<IEnumerable<EAgent>>> GetAll001()
    {
        var agents = await _agentService.GetAllAsync();
        if (agents.Count() == 0)
        {
            return NoContent();
        }
        return Ok(agents);
    }

    [HttpPost("carga")]
    public async Task<IActionResult> UploadAgents(IFormFile agents)
    {
        if (agents == null)
        {
            return BadRequest("No se ha enviado ningun archivo");
        }

        try
        {
            var listAgent = new List<EAgent>();
            using (var reader = new StreamReader(agents.OpenReadStream()))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<AgentMap>();
                listAgent = csv.GetRecords<EAgent>().ToList();
            }

            if (listAgent.Count() == 0) return BadRequest("El archivo no contiene datos");
            await _agentService.UploadAgents(listAgent);
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