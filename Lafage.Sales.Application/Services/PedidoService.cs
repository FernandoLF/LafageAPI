using Lafage.Sales.Domain.DTOs;
using Lafage.Sales.Domain.Entities;
using Lafage.Sales.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Application.Services
{
    public class PedidoService
    {
        private readonly IPedidoRepository _repository;

        public PedidoService(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public async Task<PedidoResultado> CrearPedidoAsync(PedidoDto dto)
        {
            return await _repository.CrearPedidoAsync(dto);
        }

        public async Task<PedidoResultado> CrearPedidoMultipleAsync(PedidoMultipleDto dto)
        {
            return await _repository.CrearPedidoMultipleAsync(dto);
        }
    }

}
