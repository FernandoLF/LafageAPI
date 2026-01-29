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
    public class LineaProductoRepository : ILineaProductoRepository
    {
        private readonly LafageDbContext _context;

        public LineaProductoRepository(LafageDbContext context)
        {
            _context = context;
        }

        public async Task InsertarAsync(string descripcion)
        {
            var parameter = new SqlParameter("@Descripcion", descripcion);
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC catalogo.spLineaProducto_Insertar @Descripcion", parameter);
        }

        public async Task<IEnumerable<LineaProducto>> ConsultarAsync(bool soloActivos)
        {
            var parameter = new SqlParameter("@SoloActivos", soloActivos);
            return await _context.LineasProducto
                .FromSqlRaw("EXEC catalogo.spLineaProducto_Consultar @SoloActivos", parameter)
                .ToListAsync();
        }

        public async Task ActualizarAsync(int idLineaProducto, string descripcion, bool activo)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdLineaProducto", idLineaProducto),
                new SqlParameter("@Descripcion", descripcion),
                new SqlParameter("@Activo", activo)
            };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC catalogo.spLineaProducto_Actualizar @IdLineaProducto, @Descripcion, @Activo", parameters);
        }

        public async Task EliminarAsync(int idLineaProducto)
        {
            var parameter = new SqlParameter("@IdLineaProducto", idLineaProducto);
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC catalogo.spLineaProducto_Eliminar @IdLineaProducto", parameter);
        }
    }

}
