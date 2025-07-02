using Vexplora.Application.Abstractions.Messaging;
using Vexplora.Domain.Parametros;

namespace Vexplora.Application.Parametros.GetSubnivelesById;

public sealed record GetSubnivelesByIdQuery : IQuery<List<ParametroDto>>
{
    public int Id { get; set; }
}