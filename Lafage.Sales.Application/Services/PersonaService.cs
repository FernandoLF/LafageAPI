using Lafage.Sales.Domain.DTOs;
using Lafage.Sales.Domain.Entities;
using Lafage.Sales.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Application.Services
{
    public class PersonaService
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaService(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        public async Task InsertarPersonaAsync(PersonaDto dto)
        {
            // Aquí transformas el DTO en entidad
            var persona = new Persona
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Direccion = dto.Direccion,
                Telefono = dto.Telefono,
                Email = dto.Email,
                NumeroIdentificacion = dto.NumeroIdentificacion
            };

            // Llamas al repositorio que ejecuta el SP
            await _personaRepository.InsertarPersonaAsync(persona);
        }

        public async Task<IEnumerable<PersonaDto>> ConsultarPersonasAsync()
        {
            var personas = await _personaRepository.ConsultarPersonasAsync();
            return personas.Select(p => new PersonaDto
            {
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Direccion = p.Direccion,
                Telefono = p.Telefono,
                Email = p.Email,
                NumeroIdentificacion = p.NumeroIdentificacion
            });
        }

        public async Task DesactivarPersonaAsync(int idPersona)
        {
            await _personaRepository.DesactivarPersonaAsync(idPersona);
        }

    }

}
