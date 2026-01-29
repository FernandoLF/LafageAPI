using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Domain.DTOs
{
    public class PedidoDto
    {
        public int IdCliente { get; set; }
        public int IdVendedor { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; } = 0;
    }
}
