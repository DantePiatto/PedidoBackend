

using Delivery.Domain.Abstractions;
using Delivery.Domain.Parametros;
using Delivery.Domain.PedidoAsignados;
using Delivery.Domain.Usuarios;

namespace Delivery.Domain.Repartidores;

public sealed class Repartidor : Entity<RepartidorId>
{


    public Repartidor() { }

    public Repartidor(

        RepartidorId id,
        UsuarioId usuarioId,
        ParametroId vehiculoId,
        string placa
    )
    {

        UsuarioId = usuarioId;
        VehiculoId = vehiculoId;
        Placa = placa;

    }

    public UsuarioId? UsuarioId { get; set; }

    public Usuario? Usuario { get; set; }

    public ParametroId? VehiculoId { get; set; }

    public Parametro? Vehiculo { get; set; }

    public string? Placa { get; set; }

    public List<PedidoAsignado>? PedidoAsignado { get; set; }

    public static Repartidor Create(

        RepartidorId id,
        UsuarioId usuarioId,
        ParametroId vehiculoId,
        string placa

    )
    {

        var repartidor = new Repartidor(id, usuarioId, vehiculoId, placa);

        return repartidor;
    }
    


}