using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Domain.DTOs
{
    public class ProductoDetalleDto
    {
        public int IdProducto { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string LineaProducto { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
