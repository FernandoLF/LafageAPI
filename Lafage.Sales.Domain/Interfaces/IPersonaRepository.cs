using Lafage.Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Domain.Interfaces
{
    public interface IPersonaRepository
    {
        Task InsertarPersonaAsync(Persona persona);
        Task<IEnumerable<Persona>> ConsultarPersonasAsync();
        Task DesactivarPersonaAsync(int idPersona);

    }

}
