using Vexplora.Application.Abstractions.Authentication;
using Vexplora.Application.Abstractions.Messaging;
using Vexplora.Application.Auths.LoginOAuth2;
using Vexplora.Domain.Abstractions;
using Vexplora.Domain.Usuarios;
using MediatR;

public class LoginOAuth2CommandHandler : ICommandHandler<LoginOAuth2Command, LoginOAuth2Response>
{
    private readonly IOAuth2Validator _validator;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IJwtProvider _jwtProvider;

    public LoginOAuth2CommandHandler(IOAuth2Validator validator, IUsuarioRepository usuarioRepository, IJwtProvider jwtProvider)
    {
        _validator = validator;
        _usuarioRepository = usuarioRepository;
        _jwtProvider = jwtProvider;
    }

    public async  Task<Result<LoginOAuth2Response>>  Handle(LoginOAuth2Command request, CancellationToken cancellationToken)
    {
        var oauthUser = await _validator.ValidateAsync(request.Provider, request.Token);
        
        if (oauthUser == null)
            return Result.Failure<LoginOAuth2Response>(UsuarioErrors.CredencialesInvalidas)!;

        if (oauthUser.Email == null || oauthUser.Email!.Length == 0)
            return Result.Failure<LoginOAuth2Response>(UsuarioErrors.NotFoundEmail)!;

        var usuario = await _usuarioRepository.GetByEmailAsync(oauthUser.Email, cancellationToken);

        var isNewUser = false;

        if (usuario == null)
        {
            isNewUser = true;
            return new LoginOAuth2Response(string.Empty, isNewUser)!;
        }

        var jwt = await _jwtProvider.Generate(usuario!);

        return new LoginOAuth2Response(jwt, isNewUser)!;
    }

    // Task<Result<LoginOAuth2Response>> IRequestHandler<LoginOAuth2Command, Result<LoginOAuth2Response>>.Handle(LoginOAuth2Command request, CancellationToken cancellationToken)
    // {
    //     throw new NotImplementedException();
    // }
}
