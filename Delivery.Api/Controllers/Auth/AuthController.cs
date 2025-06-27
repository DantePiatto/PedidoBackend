using System.Security.Claims;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Delivery.Api.Utils;
using Delivery.Application.Auths.CheckStatus;
using Delivery.Application.Auths.Login;
using Delivery.Application.Auths.LoginOAuth2;

namespace Delivery.Api.Controllers.Auth;

[ApiController]
[ApiVersion(ApiVersions.V1)]
[ApiVersion(ApiVersions.V2)]
[Route("api/v{version:apiVersion}/auth")]
public class AuthController : Controller
{

    private readonly ISender _sender;

    public AuthController(ISender sender)
    {
        _sender = sender;
    }

    [Authorize]
    [HttpGet("check-status")]
    [MapToApiVersion(ApiVersions.V1)]
    public async Task<IActionResult> CheckStatus(
        CancellationToken cancellationToken
    )
    {

        var authorizationHeader = HttpContext.Request.Headers["Authorization"].ToString();
        string? token = null;

        if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
        {
            token = authorizationHeader["Bearer ".Length..].Trim();
        }


        var command = new CheckStatusQuery(Token: token!);

        var result = await _sender.Send(command, cancellationToken);


        if (result.IsFailure)
        {
            return Unauthorized(result);
        }

        return Ok(result);

    }

    [HttpPost("login")]
    [ApiVersion(ApiVersions.V1)]
    public async Task<IActionResult> Login(
        [FromBody] LoginRequest request,
        CancellationToken cancellationToken)
    {
        var command = new LoginCommand(
            request.Correo,
            request.Password
        );

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }


    [HttpPost("oauth2")]
    public async Task<IActionResult> LoginOAuth2([FromBody] LoginOAuth2Command command)
    {
        var result = await _sender.Send(command);

        if (result.IsFailure)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }


}