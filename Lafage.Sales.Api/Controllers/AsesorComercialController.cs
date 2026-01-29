using Lafage.Sales.Application.Services;
using Lafage.Sales.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Lafage.Sales.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsesorComercialController : ControllerBase
    {
        private readonly AsesorComercialService _service;

        public AsesorComercialController(AsesorComercialService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] AsesorComercialDto dto)
        {
            await _service.InsertarAsync(dto);
            return Ok(new { mensaje = "Asesor insertado correctamente" });
        }

        [HttpGet]
        public async Task<IActionResult> Consultar()
        {
            var asesores = await _service.ConsultarAsync();
            return Ok(asesores);
        }

        [HttpPut("{id}/desactivar")]
        public async Task<IActionResult> Desactivar(int id)
        {
            await _service.DesactivarAsync(id);
            return Ok(new { mensaje = "Asesor desactivado correctamente" });
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] AsesorComercialDetalleDto dto)
        {
            await _service.ActualizarAsync(dto);
            return Ok(new { mensaje = "Asesor actualizado correctamente" });
        }
    }

}
