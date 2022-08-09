using Microsoft.AspNetCore.Mvc;
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
    }
}
