
using AutoMapper;
using Delivery.Application.Abstractions.Messaging;
using Delivery.Application.Paginations;
using Delivery.Domain.Abstractions;
using Delivery.Domain.Restaurantes;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Delivery.Application.Restaurantes.GetByPaginationRestaurantes;

internal sealed class GetByPaginationRestauranteQueryHandler : IQueryHandler<GetByPaginationRestauranteQuery, PagedResults<RestauranteDto>?>
{

    public readonly IPaginationRestauranteRepository _paginationRestauranteRepository;
    public readonly IMapper _mapper;

    public GetByPaginationRestauranteQueryHandler(

        IPaginationRestauranteRepository paginationRestauranteRepository,
        IMapper mapper
    )
    {
        _paginationRestauranteRepository = paginationRestauranteRepository;
        _mapper = mapper;
    }

    public async Task<Result<PagedResults<RestauranteDto>?>> Handle(GetByPaginationRestauranteQuery request, CancellationToken cancellationToken)
    {




        try
        {
            var predicateB = PredicateBuilder.New<Restaurante>(true);
            if (!string.IsNullOrEmpty(request.Search))
            {
                var searchPredicate = PredicateBuilder.New<Restaurante>(false);

                searchPredicate = searchPredicate.Or(r => r.Nombre!.ToLower().Contains(request.Search.ToLower()));
                searchPredicate = searchPredicate.Or(r => r.Descripcion!.ToLower().Contains(request.Search.ToLower()));

                predicateB = predicateB.And(searchPredicate);
            }

            var resultPagination = await _paginationRestauranteRepository.GetPaginationAsync(

                predicateB,
                null,
                request.PageNumber,
                request.PageSize,
                request.OrderBy!,
                request.OrderAsc


            );

            var resultDto = _mapper.Map<List<RestauranteDto>>(resultPagination.Results);

            return new PagedResults<RestauranteDto>
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
            //Console.WriteLine(ex.ToString());
            //throw;

            return Result.Failure<PagedResults<RestauranteDto>?>(RestauranteErrors.PaginationFailed(ex.Message));

            
        }

    }



}