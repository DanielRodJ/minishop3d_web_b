using Application.Interfaces;
using Domain.Interfaces;
using Infraestructure.Persistence;
using Infraestructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<WebDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("PostgresConnection")));

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IColeccionRepository, ColeccionRepository>();

            return services;
        }
    }
}