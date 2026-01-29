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
    public class ProductoRepository : IProductoRepository
    {
        private readonly LafageDbContext _context;

        public ProductoRepository(LafageDbContext context)
        {
            _context = context;
        }

        public async Task InsertarAsync(Producto producto)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdLineaProducto", producto.IdLineaProducto),
                new SqlParameter("@Descripcion", producto.Descripcion),
                new SqlParameter("@Stock", producto.Stock),
                new SqlParameter("@FechaProduccion", (object?)producto.FechaProduccion ?? DBNull.Value),
                new SqlParameter("@Precio", producto.Precio)
            };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC catalogo.spProducto_Insertar @IdLineaProducto, @Descripcion, @Stock, @FechaProduccion, @Precio",
                parameters);
        }

        public async Task<IEnumerable<Producto>> ConsultarAsync(bool soloActivos)
        {
            var parameter = new SqlParameter("@SoloActivos", soloActivos);
            return await _context.Productos
                .FromSqlRaw("EXEC catalogo.spProducto_Consultar @SoloActivos", parameter)
                .ToListAsync();
        }

        public async Task ActualizarAsync(int idProducto, string descripcion, decimal precio, bool activo)
        {
            var parameters = new[]
            {
                new SqlParameter("@IdProducto", idProducto),
                new SqlParameter("@Descripcion", descripcion),
                new SqlParameter("@Precio", precio),
                new SqlParameter("@Activo", activo)
            };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC catalogo.spProducto_Actualizar @IdProducto, @Descripcion, @Precio, @Activo", parameters);
        }
    }

}
