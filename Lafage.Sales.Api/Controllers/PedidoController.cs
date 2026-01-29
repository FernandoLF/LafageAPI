using Lafage.Sales.Application.Services;
using Lafage.Sales.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Lafage.Sales.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _service;

        public PedidoController(PedidoService service)
        {
            _service = service;
        }

        [HttpPost("simple")]
        public async Task<IActionResult> CrearPedido([FromBody] PedidoDto dto)
        {
            var resultado = await _service.CrearPedidoAsync(dto);
            return Ok(resultado);
        }

        [HttpPost("multiple")]
        public async Task<IActionResult> CrearPedidoMultiple([FromBody] PedidoMultipleDto dto)
        {
            var resultado = await _service.CrearPedidoMultipleAsync(dto);
            return Ok(resultado);
        }
    }

}
