
using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Abstractions;
using Delivery.Domain.Restaurantes;

namespace Delivery.Application.Restaurantes.Register;

internal sealed class RegisterRestauranteCommandHandler : ICommandHandler<RegisterRestauranteComand, Guid>
{

    private readonly IRestauranteRepository _restauranteRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterRestauranteCommandHandler(

        IRestauranteRepository restauranteRepository,
        IUnitOfWork unitOfWork
    )
    {
        _restauranteRepository = restauranteRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(RegisterRestauranteComand request, CancellationToken cancellationToken)
    {

        var existe = await _restauranteRepository.NombreExists(request.Nombre, cancellationToken);

        if (existe)
        {
            return Result.Failure<Guid>(RestauranteErrors.AlreadyExists);
        }

        var newRestaurante = Restaurante.Create(

            RestauranteId.New(),
            request.Nombre,
            request.Descripcion,
            request.LogoUrl,
            request.TiempoEntrega



        );

        _restauranteRepository.Add(newRestaurante);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(newRestaurante.Id!.Value, Message.Create);
    }



}