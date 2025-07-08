
using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Abstractions;
using Delivery.Domain.Parametros;
using Delivery.Domain.Productos;
using Delivery.Domain.Restaurantes;

namespace Delivery.Application.Productos.Register;

internal sealed class RegisterProductoCommandHandler : ICommandHandler<RegisterProductoCommand, Guid>
{

    private readonly IProductoRepository _productoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterProductoCommandHandler(

        IProductoRepository productoRepository,
        IUnitOfWork unitOfWork
    )
    {
        _productoRepository = productoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(RegisterProductoCommand request, CancellationToken cancellationToken)
    {

        var existe = await _productoRepository.NombreExists(request.Nombre, cancellationToken);

        if (existe)
        {
            return Result.Failure<Guid>(RestauranteErrors.AlreadyExists);
        }

        var restauranteId = new RestauranteId(request.RestaurantesId);
        var categoriaId = new ParametroId(request.CategoriaId);

        var newProducto = Producto.Create(

            ProductoId.New(),
            restauranteId,
            categoriaId,
            request.Nombre,
            request.Descripcion,
            request.Precio,
            request.ImagenUrl



        );

        _productoRepository.Add(newProducto);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(newProducto.Id!.Value, Message.Create);
    }



}