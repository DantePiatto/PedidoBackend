using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Delivery.Application.Exceptions;
using Delivery.Domain.Abstractions;

namespace Delivery.Infrastructure
{


    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        // private IDbContextTransaction? _currentTransaction;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(builder);

        }

        public override async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default
        )
        {
            try
            {



                var result = await base.SaveChangesAsync(cancellationToken);

                return result;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyException("La excepcion por concurrencia se disparo", ex);
            }
        }

    }
}