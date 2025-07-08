
using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Abstractions;
using Delivery.Domain.Restaurantes;

namespace Delivery.Application.Restaurantes.DeleteRestaurantes;

internal sealed class DeleteRestauranteCommandHandler : ICommandHandler<DeleteRestauranteCommand, Guid>
{

    public readonly IRestauranteRepository _restauranteRepository;
    public readonly IUnitOfWork _unitOfWork;

    public DeleteRestauranteCommandHandler(

        IRestauranteRepository restauranteRepository,
        IUnitOfWork unitOfWork
    )
    {
        _restauranteRepository = restauranteRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(DeleteRestauranteCommand request, CancellationToken cancellationToken)
    {

        var restaurante = await _restauranteRepository.GetByIdRestauranteAsync(request.Id, cancellationToken);

        if (restaurante is null)
        {
            return Result.Failure<Guid>(RestauranteErrors.NotFound);
        }

        restaurante.Desactivar();

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(restaurante.Id!.Value, Message.Delete);


    }



}