using Delivery.Application.Abstractions.Messaging;

namespace Delivery.Application.Parametros.RegisterParametros;

public sealed record RegisterParametrosCommand(
    string Nombre,
    string Descripcion,
    string Abreviatura,
    int Dependencia,
    int Nivel,
    string Valor
) : ICommand<int>;