using Lafage.Sales.Application.Services;
using Lafage.Sales.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Lafage.Sales.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly PersonaService _personaService;

        public PersonaController(PersonaService personaService)
        {
            _personaService = personaService;
        }

        // POST: api/persona
        [HttpPost]
        public async Task<IActionResult> InsertarPersona([FromBody] PersonaDto dto)
        {
            // ASP.NET Core + FluentValidation validan automáticamente el DTO antes de entrar aquí
            await _personaService.InsertarPersonaAsync(dto);
            return Ok(new { mensaje = "Persona insertada correctamente" });
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarPersonas()
        {
            var personas = await _personaService.ConsultarPersonasAsync();
            return Ok(personas);
        }

        [HttpPut("{id}/desactivar")]
        public async Task<IActionResult> DesactivarPersona(int id)
        {
            await _personaService.DesactivarPersonaAsync(id);
            return Ok(new { mensaje = "Persona desactivada correctamente" });
        }

    }

}
