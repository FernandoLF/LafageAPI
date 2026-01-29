using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lafage.Sales.Domain.DTOs
{
    public class PersonaDto
    {
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Apellido { get; set; } = null!;

        [MaxLength(100)]
        public string? Direccion { get; set; }

        [Phone]
        [MaxLength(20)]
        public string? Telefono { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(20)]
        public string? NumeroIdentificacion { get; set; }
    }

}
