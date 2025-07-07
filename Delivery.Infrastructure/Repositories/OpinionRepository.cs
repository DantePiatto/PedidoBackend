

using Delivery.Domain.Opiniones;


namespace Delivery.Infrastructure.Repositories;

internal sealed class OpinionRepository : Repository<Opinion, OpinionId>, IOpinionRepository
{

    public OpinionRepository(ApplicationDbContext dbContext) : base(dbContext)

    {
        
    }
    

}