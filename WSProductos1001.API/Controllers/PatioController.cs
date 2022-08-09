using Microsoft.AspNetCore.Mvc;
using WSProductos1001.Domain.Exceptions;
using WSProductos1001.Domain.Services;
using WSProductos1001.Entities;

namespace WSProductos1001.API.Controllers;

[ApiController]
[Route("api/v1/patios")]
public class PatioController : ControllerBase
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
        var listPatio = await _patioService.GetAllAsync();
        if (listPatio.Count() == 0)
        {
            return NoContent();
        }
        return Ok(listPatio);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EPatio>> GetById002(int id)
    {
        var patio = await _patioService.GetByIdAsync(id);
        if (patio == null)
        {
            return NotFound();
        }
        return Ok(patio);
    }
    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EPatio>> Create203(EPatio patio)
    {
        try
        {
            var newPatio = await _patioService.CreateAsync(patio);
            return CreatedAtAction(nameof(GetById002), new { id = newPatio.Id }, newPatio);

        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("{id}")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update304(int id, EPatio patio){
        try
        {
            await _patioService.UpdateAsync(id, patio);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound();
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete305(int id)
    {
        try
        {
            await _patioService.DeleteAsync(id);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest(ex.Message);
        }
    }

}