using CedServicios.Infraestructura.Extensiones;
using CedServicios.Infraestructura.Filtros;
using FluentValidation.AspNetCore;
using GestionNutricion.Infrastructure.Proxies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

ConfigurationManager Configuration = builder.Configuration;

Configuration.AddJsonFile("appsettings.json", optional:  false, reloadOnChange: true);

var _policyName = "configuracionCors";

builder.Services.AddCors(x =>
{
    x.AddPolicy(_policyName, builder =>
    {
        builder.WithOrigins(Configuration["UrlCors"])
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .SetPreflightMaxAge(TimeSpan.FromDays(365));
    });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContexts();
builder.Services.AddControllers();
builder.Services.AddServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    var jwtAppSettings = builder.Configuration.GetSection("JwtIssuerOptions");

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwtAppSettings["Issuer"],

        ValidateAudience = true,
        ValidAudience = jwtAppSettings["Audience"],

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAppSettings["SecretKey"])),

        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };

    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Add("Token-Expired", "true");
            }
            return System.Threading.Tasks.Task.CompletedTask;
        }
    };
});

builder.Services.Configure<ApiUrls>(
    options => Configuration.GetSection("ApiUrls").Bind(options)
);

builder.Services.AddMvc(options =>
{
    options.Filters.Add<ValidationMiddleware>();
});
    
builder.Services.AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(_policyName);

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
