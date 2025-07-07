

using Delivery.Domain.Abstractions;
using Delivery.Domain.Parametros;
using Delivery.Domain.Pedidos;
using Delivery.Domain.Usuarios;

namespace Delivery.Domain.Opiniones;

public sealed class Opinion : Entity<OpinionId>
{

    public Opinion() { }

    public Opinion(

        OpinionId id,
        PedidoId pedidoId,
        UsuarioId usuarioId,
        int puntaje,
        string comentario,
        ParametroId tipo



    ) : base(id)

    {

        PedidoId = pedidoId;
        UsuarioId = usuarioId;
        Puntaje = puntaje;
        Comentario = comentario;
        TipoId = tipo;

    }

    public PedidoId? PedidoId { get; set; }
    public Pedido? Pedido { get; set; }
    public UsuarioId? UsuarioId { get; set; }

    public Usuario? Usuario { get; set; }
    public int? Puntaje { get; set; }

    public string? Comentario { get; set; }

    public ParametroId? TipoId { get; set; }

    public Parametro? Tipo { get; set; }

    public static Opinion Create(

        OpinionId id,
        PedidoId pedidoId,
        UsuarioId usuarioId,
        int puntaje,
        string comentario,
        ParametroId tipo

    )
    {

        var opinion = new Opinion(id, pedidoId, usuarioId, puntaje, comentario, tipo);

        return opinion;
    }

    public Result Update(

        PedidoId pedidoId,
        UsuarioId usuarioId,
        int puntaje,
        string comentario,
        ParametroId tipo
    )
    {
        PedidoId = pedidoId;
        UsuarioId = usuarioId;
        Puntaje = puntaje > 0 ? puntaje : Puntaje;
        Comentario = comentario.Length > 0 ? comentario : Comentario;
        TipoId = tipo;

        return Result.Success();
    }
    
    


}