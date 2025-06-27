
using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Delivery.Domain.Usuarios;
using Delivery.Infrastructure.Repositories;
using Delivery.Domain.Abstractions;
using Delivery.Application.Paginations;
using Delivery.Domain.Parametros;

namespace Delivery.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
        )
    {

        services.AddApiVersioning(options => 
        {
            options.DefaultApiVersion = new ApiVersion(1);
            options.ReportApiVersions = true;
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        }).AddMvc()
        .AddApiExplorer(options => 
        {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
        });
        

        var connectionString = configuration.GetConnectionString("ConnectionString") 
             ?? throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options => {
            options.UseNpgsql(connectionString);
        });


            
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IPaginationParametrosRepository, ParametroRepository>();
        services.AddScoped<IParametroRepository, ParametroRepository>();
        // services.AddScoped<IPaginationRutinaRepository, RutinaRepository>();
        // services.AddScoped<IClienteRutinaRepository, ClienteRutinaRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
        
        return services;
    }

}