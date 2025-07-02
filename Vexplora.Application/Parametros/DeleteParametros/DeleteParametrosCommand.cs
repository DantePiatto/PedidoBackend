using Vexplora.Application.Abstractions.Messaging;
using Vexplora.Domain.Parametros;

namespace Vexplora.Application.Parametros.DeleteParametros;

public sealed record DeleteParametrosCommand(
    ParametroId Id
): ICommand<int>;