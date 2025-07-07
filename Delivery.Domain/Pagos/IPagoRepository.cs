
namespace Delivery.Domain.Pagos;

public interface IPagoRepository
{
    void Add(Pago pago);
    void Update(Pago pago);
}