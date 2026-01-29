using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Domain.Entities
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public int IdPersona { get; set; }
        public string NIT { get; set; } = null!;
        public bool Activo { get; set; }
    }

}
