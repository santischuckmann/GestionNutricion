using GestionNutricion.Core.Handlers;
using GestionNutricion.Core.Interfaces.Handlers;
using GestionNutricion.Core.Interfaces.Repositories;
using GestionNutricion.Infrastructure.Data;
using GestionNutricion.Infrastructure.Interfaces;
using GestionNutricion.Infrastructure.Repositories;
using GestionNutricion.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CedServicios.Infraestructura.Extensiones
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GestionNutricionContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("GestionNutricion")), ServiceLifetime.Transient
           );

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // repositories
            services.AddScoped<ISnackRepository, SnackRepository>();

            // services
            services.AddScoped<ISnackService, SnackService>();

            // handlers
            services.AddScoped<ISnackHandler, SnackHandler>();

            return services;
        }
    }
}