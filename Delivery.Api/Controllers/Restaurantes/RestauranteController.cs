
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

namespace Delivery.Api.Controllers.Restaurantes;

[ApiController]
[ApiVersion(ApiVersions.V1)]
[ApiVersion(ApiVersions.V2)]
[Route("api/v{version:apiVersion}/restaurantes")]

public class RestauranteController : ControllerBase
{

    public readonly ISender _sender;

    public RestauranteController(ISender sender)
    {

        _sender = sender;
    }

    [HttpGet("get-all")]
    [ApiVersion(ApiVersions.V1)]

    public async Task<ActionResult<List<RestauranteDto>>> GetAllRestaurantes(


    )
    {
        var query = new GetAllRestauranteQuery();
        var results = await _sender.Send(query);

        return Ok(results);

    }


    [HttpPost("register")]
    [MapToApiVersion(ApiVersions.V1)]

    public async Task<IActionResult> CrearRestaurante(
        [FromBody] RegisterRestauranteRequest request,
        CancellationToken cancellationToken


    )
    {
        var command = new RegisterRestauranteComand(

            request.Nombre,
            request.Descripcion,
            request.LogoUrl,
            request.TiempoEntrega
        );

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    [MapToApiVersion(ApiVersions.V1)]

    public async Task<IActionResult> DeleteRestaurante(

        Guid id,
        CancellationToken cancellationToken
    )
    {
        var command = new DeleteRestauranteCommand(

            new RestauranteId(id)


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

    public async Task<ActionResult<List<RestauranteDto>>> GetByIdRestaurante(

        Guid id
    )
    {
        var request = new GetByIdRestaurantesQuery { Id = id };
        var result = await _sender.Send(request);

        return Ok(result);
    }

    [HttpGet("get-pagination")]
    [ApiVersion(ApiVersions.V1)]

    public async Task<ActionResult<PaginationResult<RestauranteDto>>> GetPaginatioRestaurante(

        [FromQuery] GetByPaginationRestauranteQuery request
    )
    {
        //var authorizationHeader = HttpContext.Request.Headers["Authorization"].ToString();
        //string? token = null;

        //if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
        //{
        //  token = authorizationHeader["Bearer ".Length..].Trim();
        // }

        //request.Token = token;

        var results = await _sender.Send(request);

        return Ok(results);

    }

    [HttpPut("update")]
    [MapToApiVersion(ApiVersions.V1)]

    public async Task<IActionResult> UpdateRestaurante(

        [FromBody] UpdateRestauranteRequest request,
        CancellationToken cancellationToken
    )
    {

        var command = new UpdateRestauranteCommand(

            new RestauranteId(Guid.Parse(request.Id)),
            request.Nombre,
            request.Descripcion,
            request.LogoUrl,
            request.TiempoEntrega,
            request.Activo


        );

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }





}