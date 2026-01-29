using Lafage.Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Domain.Interfaces
{
    public interface IAsesorComercialRepository
    {
        Task InsertarAsync(int idPersona, decimal meta);
        Task<IEnumerable<AsesorComercial>> ConsultarAsync();
        Task DesactivarAsync(int idAsesorComercial);
        Task ActualizarAsync(int idAsesorComercial, decimal meta, bool activo);
    }

}
