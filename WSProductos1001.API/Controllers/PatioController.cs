using Microsoft.AspNetCore.Mvc;
using WSProductos1001.Domain.Services;
using WSProductos1001.Entities;

namespace WSProductos1001.API.Controllers;

[ApiController]
[Route("api/v1/patios")]
public class PatioController: ControllerBase
{
    private IPatioService _patioService;
    public PatioController(IPatioService patioService)
    {
        _patioService = patioService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<IEnumerable<EPatio>>> GetAll001()
    {
        var listPatio = await _patioService.GetAll();
        if (listPatio.Count() == 0)
        {
            return NoContent();
        }
        return Ok(listPatio);
    }
}