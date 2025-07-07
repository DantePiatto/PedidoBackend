

using Delivery.Domain.Abstractions;
using Delivery.Domain.Pedidos;
using Delivery.Domain.Repartidores;

namespace Delivery.Domain.PedidoAsignados;

public sealed class PedidoAsignado : Entity<PedidoAsignadoId>
{
    public PedidoAsignado() { }

    public PedidoAsignado(

        PedidoAsignadoId id,
        PedidoId pedidoId,
        RepartidorId repartidorId,
        DateTime fechaAsignacion
    ) : base(id)
    {

        PedidoId = pedidoId;
        RepartidorId = repartidorId;
        FechaAsignacion = fechaAsignacion;

    }

    public PedidoId? PedidoId { get; set; }
    public Pedido? Pedido { get; set; }

    public RepartidorId? RepartidorId { get; set; }

    public Repartidor? Repartidor { get; set; }

    public DateTime? FechaAsignacion { get; set; }


    public static PedidoAsignado Create(

        PedidoAsignadoId id,
        PedidoId pedidoId,
        RepartidorId repartidorId,
        DateTime fechaAsignacion


    )
    {
        var pedidoAsignado = new PedidoAsignado(id, pedidoId, repartidorId, fechaAsignacion);
        return pedidoAsignado;
    }
    


}