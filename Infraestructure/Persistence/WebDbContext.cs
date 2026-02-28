using Application.Interfaces;
using Domain.Common;
using Domain.Entities.Productos;
using Domain.Entities.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence
{
    public class WebDbContext : DbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public WebDbContext(
            DbContextOptions<WebDbContext> options,
            ICurrentUserService currentUserService
            )
            : base(options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<Coleccion> Colecciones => Set<Coleccion>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var uid = _currentUserService.FirebaseUid;

            var usuario = uid is null
                ? null
                : await Usuarios.FirstOrDefaultAsync(u => u.Uid == uid, cancellationToken);

            var now = DateTime.UtcNow;
            var user = usuario?.UsuarioId ?? 0;

            foreach (var entry in ChangeTracker.Entries<SoftDeletableEntity>())
            {
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    // entry.Entity.DeletedBy = user;
                    // entry.Entity.DeletedDate = now;
                }
            }

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = user;
                        entry.Entity.CreatedDate = now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = user;
                        entry.Entity.UpdatedDate = now;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}