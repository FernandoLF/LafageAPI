using Lafage.Sales.Domain.DTOs;
using Lafage.Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        Task<PedidoResultado> CrearPedidoAsync(PedidoDto dto);
        Task<PedidoResultado> CrearPedidoMultipleAsync(PedidoMultipleDto dto);
    }

}
