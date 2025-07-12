

namespace Delivery.Application.Productos.GetByIdProductos;

using AutoMapper;
using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Abstractions;
using Delivery.Domain.Productos;
using Delivery.Domain.Restaurantes;

public sealed record GetByIdProductoQueryHandler : IQueryHandler<GetByIdProductoQuery, ProductoDto>
{

    public readonly IProductoRepository _productoRepository;
    public readonly IMapper _mapper;


    public GetByIdProductoQueryHandler(

        IProductoRepository productoRepository,
        IMapper mapper
    )
    {
        _productoRepository = productoRepository;
        _mapper = mapper;
    }

    public async Task<Result<ProductoDto>> Handle(GetByIdProductoQuery request, CancellationToken cancellationToken)
    {

        var productoId = new ProductoId(request.Id);

        var producto = await _productoRepository.GetByIdProductoAsync(productoId, cancellationToken);

        var productoDto = _mapper.Map<ProductoDto>(producto);

        return productoDto!;

    }
}