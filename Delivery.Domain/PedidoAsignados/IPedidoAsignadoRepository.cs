

namespace Delivery.Domain.PedidoAsignados;

public interface IPedidoAsignadoRepository
{
    void Add(PedidoAsignado pedidoAsignado);
    void Update(PedidoAsignado pedidoAsignado);
}