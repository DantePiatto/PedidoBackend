

namespace Delivery.Domain.Pagos;


public record PagoId(Guid Value)
{

    public static PagoId New() => new(Guid.NewGuid());
}