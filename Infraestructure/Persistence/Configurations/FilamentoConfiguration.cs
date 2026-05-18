using Domain.Entities.Productos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Configurations
{
    public class FilamentoConfiguration : BaseConfiguration<Filamento>
    {
        protected override void ConfigureKeys(EntityTypeBuilder<Filamento> builder)
        {
            builder.ToTable("filamento")
                .HasKey(p => p.FilamentoId);
        }

        protected override void ConfigureColumns(EntityTypeBuilder<Filamento> builder)
        {
            builder.Property(p => p.FilamentoId)
                .HasColumnName("filamento_id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Codigo)
                .HasColumnName("codigo")
                .IsRequired();

            builder.Property(p => p.Nombre)
                .HasColumnName("nombre")
                .IsRequired();

            builder.Property(p => p.TipoMaterial)
                .HasColumnName("tipo_material")
                .IsRequired();

            builder.Property(p => p.Color)
                .HasColumnName("color")
                .IsRequired();

            builder.Property(p => p.Acabado)
                .HasColumnName("acabado")
                .IsRequired();

            builder.Property(p => p.PrecioPorKg)
                .HasColumnName("precio_por_kg")
                .IsRequired();

            builder.Property(p => p.Activo)
                .HasColumnName("activo")
                .IsRequired();
        }
    }
}