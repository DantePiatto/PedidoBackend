namespace Delivery.Domain.Abstractions;

public class PagedResults<TEntity, TEntityId>
where TEntity : Entity<TEntityId>
where TEntityId : class
{
    public int PageNumber {get; set;}   

    public int PageSize {get; set;}

    public int TotalNumberOfPages {get; set;}   

    public int TotalNumberOfRecords {get; set;}

    public List<TEntity> Results {get; set;}   = new List<TEntity>();    
}

public class PagedResults<TDto>
where TDto : class
{
    public int PageNumber {get; set;}   

    public int PageSize {get; set;}

    public int TotalNumberOfPages {get; set;}   

    public int TotalNumberOfRecords {get; set;}

    public List<TDto> Results {get; set;}   = new List<TDto>();    

}