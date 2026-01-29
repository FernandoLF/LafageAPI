using Lafage.Sales.Domain.DTOs;
using Lafage.Sales.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Application.Services
{
    public class AsesorComercialService
    {
        private readonly IAsesorComercialRepository _repository;

        public AsesorComercialService(IAsesorComercialRepository repository)
        {
            _repository = repository;
        }

        public async Task InsertarAsync(AsesorComercialDto dto)
        {
            await _repository.InsertarAsync(dto.IdPersona, dto.Meta);
        }

        public async Task<IEnumerable<AsesorComercialDetalleDto>> ConsultarAsync()
        {
            var asesores = await _repository.ConsultarAsync();
            return asesores.Select(a => new AsesorComercialDetalleDto
            {
                IdAsesorComercial = a.IdAsesorComercial,
                IdPersona = a.IdPersona,
                Nombre = a.Nombre,
                Apellido = a.Apellido,
                Meta = a.Meta,
                Activo = a.Activo
            });
        }

        public async Task DesactivarAsync(int id)
        {
            await _repository.DesactivarAsync(id);
        }

        public async Task ActualizarAsync(AsesorComercialDetalleDto dto)
        {
            await _repository.ActualizarAsync(dto.IdAsesorComercial, dto.Meta, dto.Activo);
        }
    }

}
