
using AutoMapper;
using Delivery.Application.Abstractions.Authentication;
using Delivery.Application.Abstractions.Messaging;
using Delivery.Application.Paginations;
using Delivery.Application.Restaurantes.GetByIdRestaurantes;
using Delivery.Domain.Abstractions;
using Delivery.Domain.Parametros;
using Delivery.Domain.Productos;
using Delivery.Domain.Restaurantes;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Delivery.Application.Productos.GetByCategoriaPaginationProductos;

internal sealed class GetByCategoriaPaginationProductoQueryHandler : IQueryHandler<GetByCategoriaPaginationProductoQuery, PagedResults<ProductoDto>?>
{



    private readonly IPaginationProductoRepository _paginationProductoRepository;

    private readonly IRestauranteRepository _restauranteRepository;

    private readonly IMapper _mapper;
    private readonly IJwtProvider _jwtProvider;


    public GetByCategoriaPaginationProductoQueryHandler(


        IPaginationProductoRepository paginationProductoRepository,
        IRestauranteRepository restauranteRepository,
        IMapper mapper,
        IJwtProvider jwtProvider
    )
    {

        _paginationProductoRepository = paginationProductoRepository;
        _restauranteRepository = restauranteRepository;
        _mapper = mapper;
        _jwtProvider = jwtProvider;

    }

    public async Task<Result<PagedResults<ProductoDto>?>> Handle(GetByCategoriaPaginationProductoQuery request, CancellationToken cancellationToken)
    {

        try
        {

            var predicateB = PredicateBuilder.New<Producto>(true);

            if (!string.IsNullOrEmpty(request.CategoriId))
            {
                predicateB = predicateB.And(op => op.CategoriaId! == new ParametroId(int.Parse(request.CategoriId)));
            }

            if (!string.IsNullOrEmpty(request.Search))
            {
                var searchPredicate = PredicateBuilder.New<Producto>(false);

                searchPredicate = searchPredicate.Or(p => p.Nombre!.ToLower().Contains(request.Search.ToLower()));
                searchPredicate = searchPredicate.Or(p => p.Descripcion!.ToLower().Contains(request.Search.ToLower()));
                searchPredicate = searchPredicate.Or(p => p.Precio.ToString()!.ToLower().Contains(request.Search.ToLower()));
                searchPredicate = searchPredicate.Or(p => p.ImagenUrl!.ToLower().Contains(request.Search.ToLower()));

                predicateB = predicateB.And(searchPredicate);
            }

            var resultPagination = await _paginationProductoRepository.GetPaginationAsync(

                predicateB,
                p => p.Include(x => x.Restaurante!)
                .Include(x => x.Categoria!),
                request.PageNumber,
                request.PageSize,
                request.OrderBy!,
                request.OrderAsc


            );

            var resultDto = _mapper.Map<List<ProductoDto>>(resultPagination.Results);

            return new PagedResults<ProductoDto>
            {
                PageNumber = resultPagination.PageNumber,
                PageSize = resultPagination.PageSize,
                TotalNumberOfPages = resultPagination.TotalNumberOfPages,
                TotalNumberOfRecords = resultPagination.TotalNumberOfRecords,
                Results = resultDto
            };

        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;



            
        }


    }








}