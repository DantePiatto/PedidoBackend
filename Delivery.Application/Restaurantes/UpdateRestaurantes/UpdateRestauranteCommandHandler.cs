

using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Abstractions;
using Delivery.Domain.Productos;
using Delivery.Domain.Restaurantes;
using Delivery.Domain.Shared;

namespace Delivery.Application.Restaurantes.UpdateRestaurantes;


internal sealed class UpdateRestauranteCommandHandler : ICommandHandler<UpdateRestauranteCommand, Guid>
{

    public readonly IRestauranteRepository _restauranteRepository;

    public readonly IUnitOfWork _unitOfWork;


    public UpdateRestauranteCommandHandler(

        IRestauranteRepository restauranteRepository,
        IUnitOfWork unitOfWork
    )
    {
        _restauranteRepository = restauranteRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(UpdateRestauranteCommand request, CancellationToken cancellationToken)
    {


        var restaurante = await _restauranteRepository.GetByIdAsync(request.Id, cancellationToken);

        if (restaurante is null)
        {

            return Result.Failure<Guid>(RestauranteErrors.NotFound);
        }

        if (request.Nombre != restaurante.Nombre)
        {

            var existe = await _restauranteRepository.NombreExists(request.Nombre, cancellationToken);

            if (existe)
            {
                return Result.Failure<Guid>(RestauranteErrors.AlreadyExists);
            }
        }

        restaurante.Update(

            request.Nombre,
            request.Descripcion,
            request.LogoUrl,
            request.TiempoEntrega,
            request.Activo

        );

        restaurante.Activo = new Activo(request.Activo);

        _restauranteRepository.Update(restaurante);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(restaurante.Id!.Value, Message.Create);

    }


}


