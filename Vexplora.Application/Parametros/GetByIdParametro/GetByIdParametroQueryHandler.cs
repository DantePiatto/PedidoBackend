using AutoMapper;
using Vexplora.Application.Abstractions.Messaging;
using Vexplora.Domain.Abstractions;
using Vexplora.Domain.Parametros;

namespace Vexplora.Application.Parametros.GetByIdParametro;

internal sealed class GetByIdParametroQueryHandler : IQueryHandler<GetByIdParametroQuery, ParametroDto>
{
    private readonly IParametroRepository _parametroRepository;

    private readonly IMapper _mapper;

    public GetByIdParametroQueryHandler(
        IParametroRepository parametroRepository,
        IMapper mapper
    )
    {
        _parametroRepository = parametroRepository;
        _mapper = mapper;
    }

    public async Task<Result<ParametroDto>> Handle(GetByIdParametroQuery request, CancellationToken cancellationToken)
    {
        var parametro = await _parametroRepository.GetByIdAsync(new ParametroId(request.Id), cancellationToken);

        if(parametro is null){
            return Result.Failure<ParametroDto>(ParametroErrors.ParametroNotFound)!;
        }

        var parametroDto = _mapper.Map<ParametroDto>(parametro);

        return parametroDto!;
    }
}