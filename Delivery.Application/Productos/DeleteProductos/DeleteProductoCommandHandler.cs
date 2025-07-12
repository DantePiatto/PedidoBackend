
using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Abstractions;
using Delivery.Domain.Productos;
using Delivery.Domain.Restaurantes;

namespace Delivery.Application.Productos.DeleteProductos;

internal sealed class DeleteProductoCommandHandler : ICommandHandler<DeleteProductoCommand, Guid>
{

    public readonly IProductoRepository _productoRepository;
    public readonly IUnitOfWork _unitOfWork;

    public DeleteProductoCommandHandler(

        IProductoRepository productoRepository,
        IUnitOfWork unitOfWork
    )
    {
        _productoRepository = productoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(DeleteProductoCommand request, CancellationToken cancellationToken)
    {

        var producto = await _productoRepository.GetByIdProductoAsync(request.Id, cancellationToken);

        if (producto is null)
        {
            return Result.Failure<Guid>(ProductoErrors.NotFound);
        }

        producto.Desactivar();

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(producto.Id!.Value, Message.Delete);


    }



}