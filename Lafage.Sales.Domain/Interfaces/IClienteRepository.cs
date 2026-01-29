using Lafage.Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task InsertarClienteAsync(int idPersona, string nit);
        Task<IEnumerable<Cliente>> ConsultarClientesAsync();
        Task DesactivarClienteAsync(int idCliente);
    }
}
