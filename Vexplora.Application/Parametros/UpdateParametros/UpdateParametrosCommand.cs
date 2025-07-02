using Vexplora.Application.Abstractions.Messaging;
using Vexplora.Domain.Parametros;

namespace Vexplora.Application.Parametros.UpdateParametros;

public sealed record UpdateParametrosCommand(
    ParametroId Id,
    string? Nombre,
    string? Descripcion,
    string? Abreviatura,
    string? Valor
): ICommand<int>;