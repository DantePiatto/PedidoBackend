using Vexplora.Application.Abstractions.Messaging;
using Vexplora.Domain.Parametros;

namespace Vexplora.Application.Parametros.GetByIdParametro;

public sealed record GetByIdParametroQuery : IQuery<ParametroDto>
{
    public int Id { get; set; }
}