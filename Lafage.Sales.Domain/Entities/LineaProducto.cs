using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Domain.Entities
{
    public class LineaProducto
    {
        public int IdLineaProducto { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool Activo { get; set; }
    }

}
