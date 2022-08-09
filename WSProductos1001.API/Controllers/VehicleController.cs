using Microsoft.AspNetCore.Mvc;
using WSProductos1001.Domain.Exceptions;
using WSProductos1001.Domain.Services;
using WSProductos1001.Entities;

namespace WSProductos1001.API.Controllers
{
    [ApiController]
    [Route("api/v1/vehiculos")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _service;
        public VehicleController(IVehicleService service)
        {
            _service = service;

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<EVehicle>>> GetAll001()
        {
            var result = await _service.GetAllAsync();
            if(result.Count() == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EVehicle>> GetById002(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EVehicle>> Create203([FromBody] EVehicle vehicle)
        {
            try
            {
                var result = await _service.CreateAsync(vehicle);
                return CreatedAtAction(nameof(GetById002), new { id = result.Id }, result);
            }
            catch (ValidationException ex) 
            {
                return BadRequest(ex.Message);
            }
            catch(BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<EVehicle>> Update204(int id, [FromBody] EVehicle vehicle)
        {
            try
            {
                await _service.UpdateAsync(id, vehicle);
                
                return NoContent();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<EVehicle>> Delete205(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
