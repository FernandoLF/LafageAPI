using Lafage.Sales.Domain.DTOs;
using Lafage.Sales.Domain.Entities;
using Lafage.Sales.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Application.Services
{
    public class ProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task InsertarAsync(ProductoDto dto)
        {
            var producto = new Producto
            {
                IdLineaProducto = dto.IdLineaProducto,
                Descripcion = dto.Descripcion,
                Stock = dto.Stock,
                FechaProduccion = dto.FechaProduccion,
                Precio = dto.Precio
            };

            await _repository.InsertarAsync(producto);
        }

        public async Task<IEnumerable<ProductoDetalleDto>> ConsultarAsync(bool soloActivos = true)
        {
            var productos = await _repository.ConsultarAsync(soloActivos);
            return productos.Select(p => new ProductoDetalleDto
            {
                IdProducto = p.IdProducto,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                Stock = p.Stock,
                LineaProducto = p.LineaProducto,
                Activo = p.Activo
            });
        }

        public async Task ActualizarAsync(ProductoDetalleDto dto)
        {
            await _repository.ActualizarAsync(dto.IdProducto, dto.Descripcion, dto.Precio, dto.Activo);
        }
    }

}
