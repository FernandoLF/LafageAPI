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
    public class ClienteRepository : IClienteRepository
    {
        private readonly LafageDbContext _context;

        public ClienteRepository(LafageDbContext context)
        {
            _context = context;
        }

        public async Task InsertarClienteAsync(int idPersona, string nit)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdPersona", idPersona),
                new SqlParameter("@NIT", nit)
            };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC ventas.spCliente_Insertar @IdPersona, @NIT", parameters);
        }

        public async Task<IEnumerable<Cliente>> ConsultarClientesAsync()
        {
            return await _context.Clientes
                .FromSqlRaw("EXEC ventas.spCliente_Consultar")
                .ToListAsync();
        }

        public async Task DesactivarClienteAsync(int idCliente)
        {
            var parameter = new SqlParameter("@IdCliente", idCliente);
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC ventas.spCliente_Desactivar @IdCliente", parameter);
        }
    }

}
