

using Delivery.Domain.Abstractions;
using Delivery.Domain.Pedidos;
using Delivery.Domain.Productos;

namespace Delivery.Domain.DetallePedidos;

public sealed class DetallePedido : Entity<DetallePedidoId>
{

    public DetallePedido() { }

    public DetallePedido(


        DetallePedidoId id,
        PedidoId pedidoId,
        ProductoId productoId,
        int cantidad,
        double subtotal
    )
    {
        PedidoId = pedidoId;
        ProductoId = productoId;
        Cantidad = cantidad;
        SubTotal = subtotal;
    }

    public PedidoId? PedidoId { get; set; }
    public ProductoId? ProductoId { get; set; }
    public int? Cantidad { get; set; }
    public double? SubTotal { get; set; }

    public Pedido? Pedido { get; set; }

    public Producto? Producto { get; set; }



    public static DetallePedido Create(

        DetallePedidoId id,
        PedidoId pedidoId,
        ProductoId productoId,
        int cantidad,
        double subtotal


    )
    {
        var detallePedido = new DetallePedido(id, pedidoId, productoId, cantidad, subtotal);

        return detallePedido;
    }
    
    




}

