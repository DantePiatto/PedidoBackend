using Microsoft.EntityFrameworkCore;
using Delivery.Infrastructure;

namespace Delivery.Api.Extensions
{
    public static class MultipleDatabaseExtensions
    {
        public static IServiceCollection AddAndMigrateTenantDatabases(this IServiceCollection services, IConfiguration configuration)
        {

            using IServiceScope scopeTenant = services.BuildServiceProvider().CreateScope();
            ApplicationDbContext ApplicationDbContext = scopeTenant.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (ApplicationDbContext.Database.GetPendingMigrations().Any())
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Applying BaseDb Migrations.");
                Console.ResetColor();
                ApplicationDbContext.Database.Migrate(); // apply migrations on baseDbContext
            }


        return services;
        }

    }
}
