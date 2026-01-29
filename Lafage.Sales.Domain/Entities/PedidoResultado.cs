using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Domain.Entities
{
    public class PedidoResultado
    {
        public int IdPedido { get; set; }
        public string Mensaje { get; set; } = null!;
    }

}
