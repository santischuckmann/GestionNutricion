using GestionNutricion.Infrastructure.Data;
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
    }
}