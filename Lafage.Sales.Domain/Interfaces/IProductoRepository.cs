using Lafage.Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Domain.Interfaces
{
    public interface IProductoRepository
    {
        Task InsertarAsync(Producto producto);
        Task<IEnumerable<Producto>> ConsultarAsync(bool soloActivos);
        Task ActualizarAsync(int idProducto, string descripcion, decimal precio, bool activo);
    }

}
