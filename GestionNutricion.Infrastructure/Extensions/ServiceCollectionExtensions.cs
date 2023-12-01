using GestionNutricion.Core.Handlers;
using GestionNutricion.Core.Interfaces.Handlers;
using GestionNutricion.Core.Interfaces.Repositories;
using GestionNutricion.Infrastructure.Data;
using GestionNutricion.Infrastructure.Proxies;
using GestionNutricion.Infrastructure.Repositories;
using GestionNutricion.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CedServicios.Infraestructura.Extensiones
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services)
        {
            string serverName = Environment.GetEnvironmentVariable("SERVER_NAME");
            string userSql = Environment.GetEnvironmentVariable("USER_SQL");
            string passwordSql = Environment.GetEnvironmentVariable("PASSWORD_SQL");

            string connectionString = $"Server={serverName};Database=GestionNutricion;User Id={userSql};Password={passwordSql};Trust Server Certificate=true";

            Console.WriteLine("connectionString: " + connectionString);

            services.AddDbContext<GestionNutricionContext>(options =>
               options.UseSqlServer(connectionString), ServiceLifetime.Transient
           );

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // repositories
            services.AddScoped<ISnackRepository, SnackRepository>();
            services.AddScoped<IDietaryPlanRepository,  DietaryPlanRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // services
            services.AddScoped<SnackService, SnackService>();
            services.AddScoped <DietaryPlanService, DietaryPlanService>();
            services.AddScoped<UserService, UserService>();

            // handlers
            services.AddScoped<ISnackHandler, SnackHandler>();
            services.AddScoped<IDietaryPlanHandler, DietaryPlanHandler>();
            services.AddScoped<IUserHandler, UserHandler>();

            // clients
            services.AddHttpClient<IFoodProxy, FoodProxy>();

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Gestion Nutricion API", Version = "v3.10" });

                doc.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Por favor ingrese un token válido",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                doc.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });

            return services;
        }
    }
}