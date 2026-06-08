using Domain.Entities.Publicaciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Configurations
{
    public class PublicacionConfiguration : BaseConfiguration<Publicacion>
    {

        protected override void ConfigureKeys(EntityTypeBuilder<Publicacion> builder)
        {
            builder.ToTable("publicacion")
                .HasKey(p => p.PublicacionId);
        }

        protected override void ConfigureColumns(EntityTypeBuilder<Publicacion> builder)
        {
            builder.Property(p => p.PublicacionId)
                .HasColumnName("publicacion_id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.ProductoId)
                .HasColumnName("producto_id")
                .IsRequired();

            builder.Property(p => p.Titulo)
                .HasColumnName("titulo")
                .IsRequired();

            builder.Property(p => p.Descripcion)
                .HasColumnName("descripcion")
                .IsRequired();

            builder.Property(p => p.EstadoPublicacionCodigo)
                .HasColumnName("estado_publicacion_codigo")
                .IsRequired();

            builder.Property(p => p.Destacado)
                .HasColumnName("destacado")
                .IsRequired();

            builder.Property(p => p.FechaPublicacion)
                .HasColumnName("fecha_publicacion");

            builder.Property(p => p.Slug)
                .HasColumnName("slug")
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