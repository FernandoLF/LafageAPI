using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Domain.Entities
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? NumeroIdentificacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }
    }

}
