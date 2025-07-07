

using Delivery.Domain.Abstractions;
using Delivery.Domain.Pagos;
using Delivery.Domain.Parametros;
using Delivery.Domain.Pedidos;

namespace Delivery.Domain.Pagos;

public sealed class Pago : Entity<PagoId>
{

    public Pago() { }

    public Pago(

        PagoId id,
        PedidoId pedidoId,
        ParametroId metodoPagoId,
        ParametroId estadoPagoId,
        DateTime fechaPago
    ) : base(id)
    {

        PedidoId = pedidoId;
        MetodoPagoId = metodoPagoId;
        EstadoPagoId = estadoPagoId;
        FechaPago = fechaPago;

    }


    public PedidoId? PedidoId { get; set; }

    public Pedido? Pedido { get; set; }

    public ParametroId? MetodoPagoId { get; set; }
    public Parametro? MetodoPago { get; set; }

    public ParametroId? EstadoPagoId { get; set; }

    public Parametro? EstadoPago { get; set; }

    public DateTime? FechaPago { get; set; }

    public static Pago Create(

        PagoId id,
        PedidoId pedidoId,
        ParametroId metodoPagoId,
        ParametroId estadoPagoId,
        DateTime fechaPago

    )
    {
        var pago = new Pago(id, pedidoId, metodoPagoId, estadoPagoId, fechaPago);

        return pago;
    }
    



}