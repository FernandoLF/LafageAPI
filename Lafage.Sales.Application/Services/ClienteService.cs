using Lafage.Sales.Domain.DTOs;
using Lafage.Sales.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Application.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task InsertarClienteAsync(ClienteDto dto)
        {
            await _clienteRepository.InsertarClienteAsync(dto.IdPersona, dto.NIT);
        }

        public async Task<IEnumerable<ClienteDto>> ConsultarClientesAsync()
        {
            var clientes = await _clienteRepository.ConsultarClientesAsync();
            return clientes.Select(c => new ClienteDto
            {
                IdPersona = c.IdPersona,
                NIT = c.NIT
            });
        }

        public async Task DesactivarClienteAsync(int idCliente)
        {
            await _clienteRepository.DesactivarClienteAsync(idCliente);
        }
    }

}
