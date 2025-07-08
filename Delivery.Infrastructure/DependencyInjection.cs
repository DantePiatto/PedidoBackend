
using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Delivery.Domain.Usuarios;
using Delivery.Infrastructure.Repositories;
using Delivery.Domain.Abstractions;
using Delivery.Application.Paginations;
using Delivery.Domain.Parametros;
using Delivery.Domain.DetallePedidos;
using Delivery.Domain.Direcciones;
using Delivery.Domain.EstadoPedidos;
using Delivery.Domain.Opiniones;
using Delivery.Domain.Pagos;
using Delivery.Domain.PedidoAsignados;
using Delivery.Domain.Pedidos;
using Delivery.Domain.Productos;
using Delivery.Domain.Repartidores;
using Delivery.Domain.Restaurantes;
using Delivery.Domain.UsuarioRoles;
using Delivery.Domain.Roles;
using Delivery.Domain.ProductoCategorias;

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

        services.AddScoped<IDetallePedidoRepository, DetallepedidoRepository>();
        services.AddScoped<IDireccionRepository, DireccionRepository>();
        services.AddScoped<IEstadoPedidoRepository, EstadoPedidoRepository>();
        services.AddScoped<IOpinionRepository, OpinionRepository>();
        services.AddScoped<IPagoRepository, PagoRepository>();
        services.AddScoped<IPedidoAsignadoRepository, PedidoAsignadoRepository>();
        services.AddScoped<IPedidoRepository, PedidoRepository>();
        services.AddScoped<IProductoRepository, ProductoRepository>();
        services.AddScoped<IRepartidorRepository, RepartidorRepository>();
        services.AddScoped<IRestauranteRepository, RestauranteRepository>();
        services.AddScoped<IUsuarioRolRepository, UsuarioRolRepository>();
        services.AddScoped<IRolRepository, RolRepository>();
        services.AddScoped<IProductoCategoriaRepository, ProductoCategoriaRepository>();


        
        services.AddScoped<IPaginationRestauranteRepository, RestauranteRepository>();
        services.AddScoped<IPaginationProductoRepository, ProductoRepository>();




    


        
        
        return services;
    }

}