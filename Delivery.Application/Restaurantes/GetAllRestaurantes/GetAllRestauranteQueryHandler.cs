


using AutoMapper;
using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Abstractions;
using Delivery.Domain.Restaurantes;

namespace Delivery.Application.Restaurantes.GetAllRestaurantes;

internal sealed class GetAllRestauranteQueryHandler : IQueryHandler<GetAllRestauranteQuery, List<RestauranteDto>>
{

    private readonly IRestauranteRepository _restauranteRepository;
    private readonly IMapper _mapper;

    public GetAllRestauranteQueryHandler(

        IRestauranteRepository restauranteRepository,
        IMapper mapper
    ) {
        _restauranteRepository = restauranteRepository;
        _mapper = mapper;
    }

    public async Task<Result<List<RestauranteDto>>> Handle(GetAllRestauranteQuery request, CancellationToken cancellationToken)
    {
        var restaurante = await _restauranteRepository.GetAll(cancellationToken);
        var restauranteDto = _mapper.Map<List<RestauranteDto>>(restaurante);

        return restauranteDto!;
    }




}

