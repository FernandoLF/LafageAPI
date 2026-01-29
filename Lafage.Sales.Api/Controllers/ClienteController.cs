using Lafage.Sales.Application.Services;
using Lafage.Sales.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Lafage.Sales.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertarCliente([FromBody] ClienteDto dto)
        {
            await _clienteService.InsertarClienteAsync(dto);
            return Ok(new { mensaje = "Cliente insertado correctamente" });
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarClientes()
        {
            var clientes = await _clienteService.ConsultarClientesAsync();
            return Ok(clientes);
        }

        [HttpPut("{id}/desactivar")]
        public async Task<IActionResult> DesactivarCliente(int id)
        {
            await _clienteService.DesactivarClienteAsync(id);
            return Ok(new { mensaje = "Cliente desactivado correctamente" });
        }
    }

}
