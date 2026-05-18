using Domain.Entities.Productos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Configurations
{
    public class ProductoPresentacionConfiguration : BaseConfiguration<ProductoPresentacion>
    {
        protected override void ConfigureKeys(EntityTypeBuilder<ProductoPresentacion> builder)
        {
            builder.ToTable("producto_presentacion")
                .HasKey(pp => pp.ProductoPresentacionId);
        }

        protected override void ConfigureColumns(EntityTypeBuilder<ProductoPresentacion> builder)
        {
            builder.Property(pp => pp.ProductoPresentacionId)
                .HasColumnName("producto_presentacion_id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.ProductoId)
                .HasColumnName("producto_id");

            builder.Property(p => p.FilamentoId)
                .HasColumnName("filamento_id");

            builder.Property(p => p.EscalaCodigo)
                .HasColumnName("escala_codigo")
                .IsRequired();

            builder.Property(p => p.DimensionX)
                .HasColumnName("dimension_x")
                .IsRequired();

            builder.Property(p => p.DimensionY)
                .HasColumnName("dimension_y")
                .IsRequired();

            builder.Property(p => p.DimensionZ)
                .HasColumnName("dimension_z")
                .IsRequired();

            builder.Property(p => p.TiempoImpresionMinutos)
                .HasColumnName("tiempo_impresion_minutos")
                .IsRequired();

            builder.Property(p => p.CantidadGramosFilamentoUso)
                .HasColumnName("cantidad_gramos_filamento_uso")
                .IsRequired();

            builder.Property(p => p.EstadoProductoPresentacionCodigo)
                .HasColumnName("estado_producto_presentacion_codigo")
                .IsRequired();

            builder.Property(p => p.Stock)
                .HasColumnName("stock")
                .IsRequired();

            builder.Property(p => p.CostoProduccionAdicional)
                .HasColumnName("costo_produccion_adicional")
                .IsRequired();

            builder.Property(p => p.PrecioVenta)
                .HasColumnName("precio_venta")
                .IsRequired();

            builder.Property(p => p.IsDeleted)
                .HasColumnName("is_deleted")
                .IsRequired();

            builder.Property(p => p.CreatedBy)
                .HasColumnName("created_by")
                .IsRequired();

            builder.Property(p => p.CreatedDate)
                .HasColumnName("created_date")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.UpdatedBy)
                .HasColumnName("updated_by");

            builder.Property(p => p.UpdatedDate)
                .HasColumnName("updated_date");
        }
    }
}