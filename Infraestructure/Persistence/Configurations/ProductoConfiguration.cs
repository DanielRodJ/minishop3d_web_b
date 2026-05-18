using Domain.Entities.Productos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Configurations
{
    public class ProductoConfiguration : BaseConfiguration<Producto>
    {
        protected override void ConfigureKeys(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("producto")
                .HasKey(p => p.ProductoId);
        }

        protected override void ConfigureColumns(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(p => p.ProductoId)
                .HasColumnName("producto_id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.ColeccionId)
                .HasColumnName("coleccion_id");

            builder.Property(p => p.Nombre)
                .HasColumnName("nombre")
                .IsRequired();

            builder.Property(p => p.Descripcion)
                .HasColumnName("descripcion")
                .IsRequired();

            builder.Property(p => p.AutorNombre)
                .HasColumnName("autor_nombre");

            builder.Property(p => p.FechaLanzamiento)
                .HasColumnName("fecha_lanzamiento");

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
