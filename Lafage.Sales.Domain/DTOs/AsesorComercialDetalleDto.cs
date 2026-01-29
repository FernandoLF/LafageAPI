using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Domain.DTOs
{
    public class AsesorComercialDetalleDto
    {
        public int IdAsesorComercial { get; set; }
        public int IdPersona { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public decimal Meta { get; set; }
        public bool Activo { get; set; }
    }
}
