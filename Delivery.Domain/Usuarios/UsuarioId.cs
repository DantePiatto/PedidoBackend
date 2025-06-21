namespace Delivery.Domain.Usuarios;

public record UsuarioId(Guid Value){
    public static UsuarioId New() => new(Guid.NewGuid()); 
};