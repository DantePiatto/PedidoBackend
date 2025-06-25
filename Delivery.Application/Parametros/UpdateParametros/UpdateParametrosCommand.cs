using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Parametros;

namespace Delivery.Application.Parametros.UpdateParametros;

public sealed record UpdateParametrosCommand(
    ParametroId Id,
    string? Nombre,
    string? Descripcion,
    string? Abreviatura,
    string? Valor
): ICommand<int>;