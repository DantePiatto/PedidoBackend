

using AutoMapper;
using Delivery.Application.Abstractions.Authentication;
using Delivery.Application.Abstractions.Messaging;
using Delivery.Domain.Abstractions;
using Delivery.Domain.Usuarios;

namespace Delivery.Application.Auths.Login;

internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, LoginUserResponse>
{

    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;
    private readonly IJwtProvider _jwtProvider;


    public LoginCommandHandler(
        IUsuarioRepository usuarioRepository,
        IMapper mapper,
        IJwtProvider jwtProvider

    )
    {
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
        _jwtProvider = jwtProvider;
    }

    public async Task<Result<LoginUserResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {

        try
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(request.Correo, cancellationToken);

            if (usuario is null)
            {
                return Result.Failure<LoginUserResponse>(UsuarioErrors.CredencialesInvalidas)!;
            }

            try
            {
                if (!BCrypt.Net.BCrypt.Verify(request.Password, usuario.Password!))
                {
                    return Result.Failure<LoginUserResponse>(UsuarioErrors.CredencialesInvalidas)!;
                }
            }
            catch (System.Exception)
            {

                throw;
            }

            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);

            var token = await _jwtProvider.Generate(usuario);

            try
            {
                return LoginUserResponse.Create(token, usuarioDto)!;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        catch (System.Exception)
        {

            throw;
        }

    }
}