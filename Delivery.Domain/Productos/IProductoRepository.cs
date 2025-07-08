

namespace Delivery.Domain.Productos;

public interface IProductoRepository
{
    void Add(Producto producto);

    void Update(Producto producto);


    Task<bool> NombreExists(string nombre, CancellationToken cancellationToken);

    Task<List<Producto>> GetAll(CancellationToken cancellationToken = default);
    Task<Producto?> GetByIdProductoAsync(ProductoId id, CancellationToken cancellationToken = default);
    Task<Producto?> GetByIdAsync(ProductoId id, CancellationToken cancellationToken = default);

    

    



}