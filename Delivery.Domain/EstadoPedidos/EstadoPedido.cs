

using Delivery.Domain.Abstractions;
using Delivery.Domain.EstadoPedidos;
using Delivery.Domain.Parametros;
using Delivery.Domain.Pedidos;

namespace Delivery.Domain.EstadoPedidos;

public sealed class EstadoPedido : Entity<EstadoPedidoId>
{


    public EstadoPedido() { }

    public EstadoPedido(

        EstadoPedidoId id,
        PedidoId pedidoId,
        ParametroId estadoId,
        DateTime fechaEstado
    ) : base(id)
    {
        PedidoId = pedidoId;
        EstadoId = estadoId;
        FechaEstado = fechaEstado;


    }

    public PedidoId? PedidoId { get; set; }

    public Pedido? Pedido { get; set; }

    public ParametroId? EstadoId { get; set; }

    public Parametro? Estado { get; set; }

    public DateTime? FechaEstado { get; set; }

    public static EstadoPedido Create(

        EstadoPedidoId id,
        PedidoId pedidoId,
        ParametroId estadoId,
        DateTime fechaEstado

    )
    {
        var estadoPedido = new EstadoPedido(id, pedidoId, estadoId, fechaEstado);

        return estadoPedido;
    }

    public Result Update(

        PedidoId pedidoId,
        ParametroId estadoId,
        DateTime fechaEstado

    )
    {

        PedidoId = pedidoId;
        EstadoId = estadoId;
        FechaEstado = fechaEstado;


        return Result.Success();
        


    }


}