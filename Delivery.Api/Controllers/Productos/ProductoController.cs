
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Delivery.Api.Utils;
using Delivery.Application.Restaurantes.Register;
using Delivery.Domain.Restaurantes;
using Delivery.Application.Restaurantes.GetAllRestaurantes;
using Delivery.Application.Restaurantes.DeleteRestaurantes;
using Delivery.Application.Restaurantes.GetByIdRestaurantes;
using Delivery.Domain.Abstractions;
using Delivery.Application.Restaurantes.GetByPaginationRestaurantes;
using Delivery.Application.Restaurantes.UpdateRestaurantes;
using Delivery.Domain.Productos;
using Delivery.Application.Productos.Register;
using Delivery.Application.Parametros.GetByIdParametro;
using Delivery.Application.Productos.GetByIdProductos;
using Delivery.Application.Productos.DeleteProductos;
using Delivery.Application.Productos.UpdateProductos;
using Delivery.Application.Productos.GetByRestaurantePaginationProductos;
using Delivery.Application.Productos.GetByCategoriaPaginationProductos;

namespace Delivery.Api.Controllers.Productos;

[ApiController]
[ApiVersion(ApiVersions.V1)]
[ApiVersion(ApiVersions.V2)]
[Route("api/v{version:apiVersion}/productos")]

public class ProductoController : ControllerBase
{

    public readonly ISender _sender;

    public ProductoController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("get-all")]
    [ApiVersion(ApiVersions.V1)]

    public async Task<ActionResult<List<ProductoDto>>> GetAllProductos(


   )
    {
        var query = new GetAllProductoQuery();
        var results = await _sender.Send(query);

        return Ok(results);

    }


    [HttpPost("register")]
    [MapToApiVersion(ApiVersions.V1)]

    public async Task<IActionResult> CrearProducto(
       [FromBody] RegisterProductoRequest request,
       CancellationToken cancellationToken


   )
    {
        var command = new RegisterProductoCommand(


            request.RestaurantesId,
            request.CategoriaId,
            request.Nombre,
            request.Descripcion,
            request.Precio,
            request.ImagenUrl
        );

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpGet("get-by-id/{id}")]
    [MapToApiVersion(ApiVersions.V1)]

    public async Task<ActionResult<List<ProductoDto>>> GetByIdProducto(

       Guid id
   )
    {
        var request = new GetByIdProductoQuery { Id = id };
        var result = await _sender.Send(request);

        return Ok(result);
    }


    [HttpDelete("delete/{id}")]
    [MapToApiVersion(ApiVersions.V1)]

    public async Task<IActionResult> DeleteProducto(

        Guid id,
        CancellationToken cancellationToken
    )
    {
        var command = new DeleteProductoCommand(

            new ProductoId(id)


        );

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPut("update")]
    [MapToApiVersion(ApiVersions.V1)]

    public async Task<IActionResult> UpdateProducto(

        [FromBody] UpdateProductoRequest request,
        CancellationToken cancellationToken
    )
    {

        var command = new UpdateProductoCommand(

            new ProductoId(Guid.Parse(request.Id)),
            request.CategoriaId,
            request.Nombre,
            request.Descripcion,
            request.Precio,
            request.ImagenUrl,
            request.Activo


        );

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpGet("get-pagination-restaurante")]
    [ApiVersion(ApiVersions.V1)]

    public async Task<ActionResult<PaginationResult<ProductoDto>>> GetPaginatioProductoRestaurante(

        [FromQuery] GetByRestaurantePaginationProductoQuery request
    )
    {

        var results = await _sender.Send(request);

        return Ok(results);

    }
    
    [HttpGet("get-pagination-categoria")]
    [ApiVersion(ApiVersions.V1)]

    public async Task<ActionResult<PaginationResult<ProductoDto>>> GetPaginatioProductoCategoria(

        [FromQuery] GetByCategoriaPaginationProductoQuery request
    )
    {

        var results = await _sender.Send(request);

        return Ok(results);

    }





}

