using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WSProductos1001.Domain.Exceptions;
using WSProductos1001.Domain.Services;

namespace WSProductos1001.API.Controllers
{
    [ApiController]
    [Route("api/v1/marcas")]
    public class BrandController: ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost("carga")]
        public async Task<IActionResult> UpdladBrands(IFormFile brands)
        {
            if (brands == null)
            {
                return BadRequest("No se ha enviado ningun archivo");
            }
            try
            {
                var listBrands = new List<string>();
                using (var reader = new StreamReader(brands.OpenReadStream()))
                {
                    while (reader.Peek() >= 0)
                        listBrands.Add(reader.ReadLine());
                }
                await _brandService.UploadBrands(listBrands);

                return Ok();
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
