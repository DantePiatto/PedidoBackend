using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Parametros;

namespace Delivery.Application.Parametros.DesactiveParametros;

public sealed record DesactiveParametrosCommand(
    ParametroId Id
): ICommand<int>;