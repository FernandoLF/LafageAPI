using Lafage.Sales.Domain.DTOs;
using Lafage.Sales.Domain.Entities;
using Lafage.Sales.Domain.Interfaces;
using Lafage.Sales.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Lafage.Sales.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly LafageDbContext _context;

        public PedidoRepository(LafageDbContext context)
        {
            _context = context;
        }

        public async Task<PedidoResultado> CrearPedidoAsync(PedidoDto dto)
        {
            var parameters = new[]
{
    new SqlParameter("@IdCliente", dto.IdCliente),
    new SqlParameter("@IdVendedor", dto.IdVendedor),
    new SqlParameter("@IdProducto", dto.IdProducto),
    new SqlParameter("@Cantidad", dto.Cantidad),
    new SqlParameter("@PrecioUnitario", dto.PrecioUnitario),
    new SqlParameter("@Descuento", dto.Descuento)
};

            var result = _context.PedidoResultados
                .FromSqlRaw("EXEC ventas.spCrearPedido @IdCliente, @IdVendedor, @IdProducto, @Cantidad, @PrecioUnitario, @Descuento", parameters)
                .AsNoTracking()
                .AsEnumerable()
                .First();

            return result;
        }

        public async Task<PedidoResultado> CrearPedidoMultipleAsync(PedidoMultipleDto dto)
        {
            var table = new DataTable();
            table.Columns.Add("IdProducto", typeof(int));
            table.Columns.Add("Cantidad", typeof(int));
            table.Columns.Add("PrecioUnitario", typeof(decimal));
            table.Columns.Add("Descuento", typeof(decimal));

            foreach (var item in dto.Detalle)
            {
                table.Rows.Add(item.IdProducto, item.Cantidad, item.PrecioUnitario, item.Descuento);
            }

            var detalleParam = new SqlParameter("@Detalle", table)
            {
                SqlDbType = SqlDbType.Structured,
                TypeName = "ventas.TVP_DetallePedido"
            };

            var parameters = new[]
            {
                new SqlParameter("@IdCliente", dto.IdCliente),
                new SqlParameter("@IdVendedor", dto.IdVendedor),
                detalleParam
            };

            var result = _context.PedidoResultados
    .FromSqlRaw("EXEC ventas.spCrearPedido_Multiple @IdCliente, @IdVendedor, @Detalle", parameters)
    .AsNoTracking()
    .AsEnumerable()
    .First();

            return result;
        }
    }

}
