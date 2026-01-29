using Lafage.Sales.Application.Services;
using Lafage.Sales.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Lafage.Sales.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _service;

        public ProductoController(ProductoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] ProductoDto dto)
        {
            await _service.InsertarAsync(dto);
            return Ok(new { mensaje = "Producto insertado correctamente" });
        }

        [HttpGet]
        public async Task<IActionResult> Consultar([FromQuery] bool soloActivos = true)
        {
            var productos = await _service.ConsultarAsync(soloActivos);
            return Ok(productos);
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] ProductoDetalleDto dto)
        {
            await _service.ActualizarAsync(dto);
            return Ok(new { mensaje = "Producto actualizado correctamente" });
        }
    }

}
