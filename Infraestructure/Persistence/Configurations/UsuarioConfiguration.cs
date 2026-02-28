using Domain.Entities.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Configurations
{
    public class UsuarioConfiguration : BaseConfiguration<Usuario>
    {
        protected override void ConfigureKeys(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario")
                .HasKey(u => u.UsuarioId);
        }

        protected override void ConfigureColumns(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(u => u.UsuarioId)
                .HasColumnName("usuario_id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Uid)
                .HasColumnName("uid")
                .IsRequired();

            builder.Property(u => u.Nombre)
                .HasColumnName("nombre")
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("email")
                .IsRequired();

            builder.Property(u => u.EsAdmin)
                .HasColumnName("es_admin")
                .IsRequired();

            builder.Property(u => u.IsDeleted)
                .HasColumnName("is_deleted")
                .IsRequired();

            builder.Property(u => u.CreatedBy)
                .HasColumnName("created_by")
                .IsRequired();

            builder.Property(u => u.CreatedDate)
                .HasColumnName("created_date")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(u => u.UpdatedBy)
                .HasColumnName("updated_by");

            builder.Property(u => u.UpdatedDate)
                .HasColumnName("updated_date");
        }
    }
}
