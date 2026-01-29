using Lafage.Sales.Domain.DTOs;
using Lafage.Sales.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Application.Services
{
    public class LineaProductoService
    {
        private readonly ILineaProductoRepository _repository;

        public LineaProductoService(ILineaProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task InsertarAsync(string descripcion)
        {
            await _repository.InsertarAsync(descripcion);
        }

        public async Task<IEnumerable<LineaProductoDto>> ConsultarAsync(bool soloActivos = true)
        {
            var lineas = await _repository.ConsultarAsync(soloActivos);
            return lineas.Select(lp => new LineaProductoDto
            {
                IdLineaProducto = lp.IdLineaProducto,
                Descripcion = lp.Descripcion,
                Activo = lp.Activo
            });
        }

        public async Task ActualizarAsync(LineaProductoDto dto)
        {
            await _repository.ActualizarAsync(dto.IdLineaProducto, dto.Descripcion, dto.Activo);
        }

        public async Task EliminarAsync(int idLineaProducto)
        {
            await _repository.EliminarAsync(idLineaProducto);
        }
    }

}
