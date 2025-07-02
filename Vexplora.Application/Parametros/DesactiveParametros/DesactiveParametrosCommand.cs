using Vexplora.Application.Abstractions.Messaging;
using Vexplora.Domain.Parametros;

namespace Vexplora.Application.Parametros.DesactiveParametros;

public sealed record DesactiveParametrosCommand(
    ParametroId Id
): ICommand<int>;