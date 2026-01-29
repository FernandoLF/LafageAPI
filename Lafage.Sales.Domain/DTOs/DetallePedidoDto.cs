using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Domain.DTOs
{
    public class DetallePedidoDto
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; } = 0;
    }
}
