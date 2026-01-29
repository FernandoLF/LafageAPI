using Lafage.Sales.Domain.Entities;
using Lafage.Sales.Domain.Interfaces;
using Lafage.Sales.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Infrastructure.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly LafageDbContext _context;

        public PersonaRepository(LafageDbContext context)
        {
            _context = context;
        }

        public async Task InsertarPersonaAsync(Persona persona)
        {
            var parameters = new[]
            {
                new SqlParameter("@Nombre", persona.Nombre),
                new SqlParameter("@Apellido", persona.Apellido),
                new SqlParameter("@Direccion", (object?)persona.Direccion ?? DBNull.Value),
                new SqlParameter("@Telefono", (object?)persona.Telefono ?? DBNull.Value),
                new SqlParameter("@Email", (object?)persona.Email ?? DBNull.Value),
                new SqlParameter("@NumeroIdentificacion", (object?)persona.NumeroIdentificacion ?? DBNull.Value)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC personas.spPersona_Insertar @Nombre, @Apellido, @Direccion, @Telefono, @Email, @NumeroIdentificacion", parameters);
        }

        public async Task<IEnumerable<Persona>> ConsultarPersonasAsync()
        {
            return await _context.Personas
                .FromSqlRaw("EXEC personas.spPersona_Consultar")
                .ToListAsync();
        }

        public async Task DesactivarPersonaAsync(int idPersona)
        {
            var parameter = new SqlParameter("@IdPersona", idPersona);
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC personas.spPersona_Desactivar @IdPersona", parameter);
        }

    }

}
