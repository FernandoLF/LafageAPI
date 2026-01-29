using Lafage.Sales.Application.Services;
using Lafage.Sales.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Lafage.Sales.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LineaProductoController : ControllerBase
    {
        private readonly LineaProductoService _service;

        public LineaProductoController(LineaProductoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] string descripcion)
        {
            await _service.InsertarAsync(descripcion);
            return Ok(new { mensaje = "Línea de producto insertada correctamente" });
        }

        [HttpGet]
        public async Task<IActionResult> Consultar([FromQuery] bool soloActivos = true)
        {
            var lineas = await _service.ConsultarAsync(soloActivos);
            return Ok(lineas);
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] LineaProductoDto dto)
        {
            await _service.ActualizarAsync(dto);
            return Ok(new { mensaje = "Línea de producto actualizada correctamente" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _service.EliminarAsync(id);
            return Ok(new { mensaje = "Línea de producto eliminada correctamente" });
        }
    }

}
