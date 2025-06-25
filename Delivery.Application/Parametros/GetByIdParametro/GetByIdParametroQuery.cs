using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Parametros;

namespace Delivery.Application.Parametros.GetByIdParametro;

public sealed record GetByIdParametroQuery : IQuery<ParametroDto>
{
    public int Id { get; set; }
}