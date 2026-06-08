using Application.Interfaces;
using Domain.Interfaces;
using Infraestructure.Persistence;
using Infraestructure.Persistence.Repositories;
using Infraestructure.Services;
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
            services.AddScoped<IDateTimeService, DateTimeService>();
            services.AddScoped<IProductoPricingService, ProductoPricingService>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IColeccionRepository, ColeccionRepository>();
            services.AddScoped<IPublicacionRepository, PublicacionRepository>();
            services.AddScoped<IProductoPresentacionRepository, ProductoPresentacionRepository>();
            services.AddScoped<IFilamentoRepository, FilamentoRepository>();

            return services;
        }
    }
}