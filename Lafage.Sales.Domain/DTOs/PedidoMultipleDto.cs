using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Domain.DTOs
{
    public class PedidoMultipleDto
    {
        public int IdCliente { get; set; }
        public int IdVendedor { get; set; }
        public List<DetallePedidoDto> Detalle { get; set; } = new();
    }
}
