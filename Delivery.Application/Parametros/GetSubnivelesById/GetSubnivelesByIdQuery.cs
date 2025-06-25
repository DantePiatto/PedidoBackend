using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Parametros;

namespace Delivery.Application.Parametros.GetSubnivelesById;

public sealed record GetSubnivelesByIdQuery : IQuery<List<ParametroDto>>
{
    public int Id { get; set; }
}