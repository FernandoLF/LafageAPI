using Lafage.Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Domain.Interfaces
{
    public interface ILineaProductoRepository
    {
        Task InsertarAsync(string descripcion);
        Task<IEnumerable<LineaProducto>> ConsultarAsync(bool soloActivos);
        Task ActualizarAsync(int idLineaProducto, string descripcion, bool activo);
        Task EliminarAsync(int idLineaProducto);
    }

}
