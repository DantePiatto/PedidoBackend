
using Delivery.Domain.Abstractions;
using Delivery.Domain.DetallePedidos;
using Delivery.Domain.Direcciones;
using Delivery.Domain.EstadoPedidos;
using Delivery.Domain.Opiniones;
using Delivery.Domain.Pagos;
using Delivery.Domain.Parametros;
using Delivery.Domain.PedidoAsignados;
using Delivery.Domain.Usuarios;

namespace Delivery.Domain.Pedidos;

public sealed class Pedido : Entity<PedidoId>
{
    public Pedido() { }

    public Pedido(

        PedidoId id,
        UsuarioId usuarioId,
        DireccionId direccionId,
        double total,
        ParametroId metodoPagoId,
        ParametroId estadoId,
        DateTime fechaPedido

    ) : base(id)
    {

        UsuarioId = usuarioId;
        DireccionId = direccionId;
        Total = total;
        MetodoPagoId = metodoPagoId;
        EstadoId = estadoId;
        FechaPedido = fechaPedido;

    }

    public UsuarioId? UsuarioId { get; set; }
    public DireccionId? DireccionId { get; set; }
    public double? Total { get; set; }
    public ParametroId? MetodoPagoId { get; set; }
    public Parametro? MetodoPago { get; set; }

    public ParametroId? EstadoId { get; set; }
    public Parametro? Estado { get; set; }

    public DateTime? FechaPedido { get; set; }

    public Usuario? Usuario { get; set; }

    public Direccion? Direccion { get; set; }

    public List<DetallePedido>? DetallePedidos { get; set; }

    public List<EstadoPedido>? EstadoPedidos { get; set; }

    public Pago? Pago { get; set; }

    public List<PedidoAsignado>?PedidoAsignado { get; set;}
     public List<Opinion>?Opinion { get; set;}


    public static Pedido Create(

        PedidoId id,
        UsuarioId usuarioId,
        DireccionId direccionId,
        double total,
        ParametroId metodo_pago_id,
        ParametroId estado_id,
        DateTime fecha_pedido

    )
    {
        var pedido = new Pedido(id, usuarioId, direccionId, total, metodo_pago_id, estado_id, fecha_pedido);

        return pedido;
    }

    
    


}