using Application.Common.Behaviors;
using FluentValidation;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(typeof(AssemblyReference).Assembly);

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));
            services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}