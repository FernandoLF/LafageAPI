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
    public class AsesorComercialRepository : IAsesorComercialRepository
    {
        private readonly LafageDbContext _context;

        public AsesorComercialRepository(LafageDbContext context)
        {
            _context = context;
        }

        public async Task InsertarAsync(int idPersona, decimal meta)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdPersona", idPersona),
                new SqlParameter("@Meta", meta)
            };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC ventas.spAsesor_Insertar @IdPersona, @Meta", parameters);
        }

        public async Task<IEnumerable<AsesorComercial>> ConsultarAsync()
        {
            return await _context.AsesoresComerciales
                .FromSqlRaw("EXEC ventas.spAsesor_Consultar")
                .ToListAsync();
        }

        public async Task DesactivarAsync(int idAsesorComercial)
        {
            var parameter = new SqlParameter("@IdAsesor", idAsesorComercial);
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC ventas.spAsesor_Desactivar @IdAsesor", parameter);
        }

        public async Task ActualizarAsync(int idAsesorComercial, decimal meta, bool activo)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdAsesorComercial", idAsesorComercial),
                new SqlParameter("@Meta", meta),
                new SqlParameter("@Activo", activo)
            };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC ventas.spAsesorComercial_Actualizar @IdAsesorComercial, @Meta, @Activo", parameters);
        }
    }

}
