using Microsoft.AspNetCore.Mvc;
using WSProductos1001.Domain.Exceptions;
using WSProductos1001.Domain.Features.RequestCredit;
using WSProductos1001.Domain.Services;
using WSProductos1001.Entities;

namespace WSProductos1001.API.Controllers;
[ApiController]
[Route("api/v1/solicitudes")]
public class RequestCreditController: ControllerBase
{
    private readonly IRequestCreditService _requestCreditService;
    public RequestCreditController(IRequestCreditService requestCreditService)
    {
        _requestCreditService = requestCreditService;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ERequestCredit>> GetById001(int id)
    {
        try
        {
            var requestCredit = await _requestCreditService.GetByIdAsync(id);
            if (requestCredit == null)
            {
                return NotFound();
            }
            return Ok(requestCredit);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    } 
    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ERequestCredit>> Create202(ERequestCredit requestCredit)
    {
        try
        {
            var newRequestCredit = await _requestCreditService.CreateAsync(requestCredit);
            return CreatedAtAction(nameof(GetById001), new { id = newRequestCredit.Id }, newRequestCredit);

        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (BadRequestException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("despachar/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Despachar(int id)
    {
        try
        {
            await _requestCreditService.UpdateCreditStatusAsync(id, CreditStatus.Dispached);
            return NoContent();
            
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}