using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Domain.Entities
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public int IdLineaProducto { get; set; }
        public string Descripcion { get; set; } = null!;
        public int Stock { get; set; }
        public DateTime? FechaProduccion { get; set; }
        public decimal Precio { get; set; }
        public string LineaProducto { get; set; } = null!;
        public bool Activo { get; set; }
    }

}
