

namespace Delivery.Domain.Direcciones;

public interface IDireccionRepository
{
    void Add(Direccion direccion);

    void Update(Direccion direccion);
}