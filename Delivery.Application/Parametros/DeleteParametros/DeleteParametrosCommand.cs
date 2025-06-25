using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Parametros;

namespace Delivery.Application.Parametros.DeleteParametros;

public sealed record DeleteParametrosCommand(
    ParametroId Id
): ICommand<int>;