using Lafage.Sales.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lafage.Sales.Infrastructure.Data
{
    public class LafageDbContext : DbContext
    {
        public LafageDbContext(DbContextOptions<LafageDbContext> options) : base(options) { }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<AsesorComercial> AsesoresComerciales { get; set; }
        public DbSet<LineaProducto> LineasProducto { get; set; }
        public DbSet<Producto> Productos { get; set; }

        public DbSet<PedidoResultado> PedidoResultados { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Persona", "personas");

                entity.HasKey(e => e.IdPersona);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20);

                entity.Property(e => e.Email)
                    .HasMaxLength(100);

                entity.Property(e => e.NumeroIdentificacion)
                    .HasMaxLength(20);

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime");

                entity.Property(e => e.Activo)
                    .HasColumnType("bit");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente", "ventas");

                entity.HasKey(e => e.IdCliente);

                entity.Property(e => e.IdPersona).IsRequired();
                entity.Property(e => e.NIT).HasMaxLength(20);
                entity.Property(e => e.Activo)
                    .HasColumnType("bit");
            });

            modelBuilder.Entity<AsesorComercial>(entity =>
            {
                entity.ToTable("AsesorComercial", "ventas");

                entity.HasKey(e => e.IdAsesorComercial);

                entity.Property(e => e.IdPersona).IsRequired();
                entity.Property(e => e.Nombre).HasMaxLength(50);
                entity.Property(e => e.Apellido).HasMaxLength(50);
                entity.Property(e => e.Meta).HasColumnType("decimal(10,2)");
                entity.Property(e => e.Activo).HasColumnType("bit");
            });

            modelBuilder.Entity<LineaProducto>(entity =>
            {
                entity.ToTable("LineaProducto", "catalogo");

                entity.HasKey(e => e.IdLineaProducto);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Activo)
                    .HasColumnType("bit");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto", "catalogo");

                entity.HasKey(e => e.IdProducto);

                entity.Property(e => e.IdLineaProducto).IsRequired();
                entity.Property(e => e.Descripcion).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Stock).IsRequired();
                entity.Property(e => e.FechaProduccion).HasColumnType("date");
                entity.Property(e => e.Precio).HasColumnType("decimal(10,2)");
                entity.Property(e => e.Activo).HasColumnType("bit");

                entity.Ignore(e => e.LineaProducto); // porque viene del JOIN
            });

            modelBuilder.Entity<PedidoResultado>().HasNoKey();


        }
    }

}
