

using AutoMapper;
using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Abstractions;
using Delivery.Domain.Restaurantes;

namespace Delivery.Application.Restaurantes.GetByIdRestaurantes;


public sealed record GetByIdRestaurantesQueryHandler : IQueryHandler<GetByIdRestaurantesQuery, RestauranteDto>
{

    public readonly IRestauranteRepository _restauranteRepository;
    public readonly IMapper _mapper;


    public GetByIdRestaurantesQueryHandler(

        IRestauranteRepository restauranteRepository,
        IMapper mapper
    )
    {
        _restauranteRepository = restauranteRepository;
        _mapper = mapper;
    }

    public async Task<Result<RestauranteDto>> Handle(GetByIdRestaurantesQuery request, CancellationToken cancellationToken)
    {

        var restauranteId = new RestauranteId(request.Id);

        var restaurante = await _restauranteRepository.GetByIdRestauranteAsync(restauranteId, cancellationToken);

        var restauranteDto = _mapper.Map<RestauranteDto>(restaurante);

        return restauranteDto!;

    }
}