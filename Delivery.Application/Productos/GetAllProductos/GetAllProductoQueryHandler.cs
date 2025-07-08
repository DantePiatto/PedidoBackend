



using AutoMapper;
using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Abstractions;
using Delivery.Domain.Productos;
using Delivery.Domain.Restaurantes;

namespace Delivery.Application.Restaurantes.GetAllRestaurantes;

internal sealed class GetAllProductoQueryHandler : IQueryHandler<GetAllProductoQuery, List<ProductoDto>>
{

    private readonly IProductoRepository _productoRepository;
    private readonly IMapper _mapper;

    public GetAllProductoQueryHandler(

        IProductoRepository productoRepository,
        IMapper mapper
    ) {
        _productoRepository = productoRepository;
        _mapper = mapper;
    }

    public async Task<Result<List<ProductoDto>>> Handle(GetAllProductoQuery request, CancellationToken cancellationToken)
    {
        var producto = await _productoRepository.GetAll(cancellationToken);
        var productoDto = _mapper.Map<List<ProductoDto>>(producto);

        return productoDto!;
    }




}

