

namespace Delivery.Domain.Productos;

public interface IProductoRepository
{
    void Add(Producto producto);

    void Update(Producto producto);
}