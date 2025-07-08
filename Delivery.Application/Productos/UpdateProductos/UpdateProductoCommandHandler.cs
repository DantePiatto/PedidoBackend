
using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Abstractions;
using Delivery.Domain.Parametros;
using Delivery.Domain.Productos;
using Delivery.Domain.Restaurantes;
using Delivery.Domain.Shared;

namespace Delivery.Application.Productos.UpdateProductos;

internal sealed class UpdateProductoCommandHandler : ICommandHandler<UpdateProductoCommand, Guid>
{

    public readonly IProductoRepository _productoRepository;

    public readonly IUnitOfWork _unitOfWork;


    public UpdateProductoCommandHandler(

        IProductoRepository productoRepository,
        IUnitOfWork unitOfWork
    )
    {
        _productoRepository = productoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(UpdateProductoCommand request, CancellationToken cancellationToken)
    {


        var producto = await _productoRepository.GetByIdAsync(request.Id, cancellationToken);

        if (producto is null)
        {

            return Result.Failure<Guid>(ProductoErrors.NotFound);
        }

        if (request.Nombre != producto.Nombre)
        {

            var existe = await _productoRepository.NombreExists(request.Nombre, cancellationToken);

            if (existe)
            {
                return Result.Failure<Guid>(ProductoErrors.AlreadyExists);
            }
        }

        producto.Update(
            
            new ParametroId(request.CategoriaId),
            request.Nombre,
            request.Descripcion,
            request.Precio,
            request.ImagenUrl
           

        );

        producto.Activo = new Activo(request.Activo);

        _productoRepository.Update(producto);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(producto.Id!.Value, Message.Create);

    }


}

