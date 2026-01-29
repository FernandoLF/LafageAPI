using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Domain.DTOs
{
    public class ProductoDto
    {
        public int IdLineaProducto { get; set; }
        public string Descripcion { get; set; } = null!;
        public int Stock { get; set; }
        public DateTime? FechaProduccion { get; set; }
        public decimal Precio { get; set; }
    }
}
