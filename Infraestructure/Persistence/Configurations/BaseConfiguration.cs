using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Configurations
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            ConfigureKeys(builder);
            ConfigureColumns(builder);
            ConfigureRelations(builder);
        }

        protected abstract void ConfigureKeys(EntityTypeBuilder<T> builder);
        protected abstract void ConfigureColumns(EntityTypeBuilder<T> builder);
        protected virtual void ConfigureRelations(EntityTypeBuilder<T> builder) { }
    }
}
