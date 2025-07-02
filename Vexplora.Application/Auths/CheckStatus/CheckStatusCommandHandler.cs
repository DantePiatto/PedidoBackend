
using AutoMapper;
using Vexplora.Application.Abstractions.Authentication;
using Vexplora.Application.Abstractions.Messaging;
using Vexplora.Application.Auths.CheckStatus;
using Vexplora.Application.Auths.Login;
using Vexplora.Domain.Abstractions;
using Vexplora.Domain.Usuarios;

namespace Vexplora.Application.Root.Users.LoginUser;

internal sealed class CheckStatusCommandHandler : IQueryHandler<CheckStatusQuery, LoginUserResponse?>
{

    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IJwtProvider _jwtProvider;

    private readonly IMapper _mapper;


    public CheckStatusCommandHandler(IUsuarioRepository usuarioRepository, IMapper mapper, IJwtProvider jwtProvider)
    {
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
        _jwtProvider = jwtProvider;
    }
    public async Task<Result<LoginUserResponse?>> Handle(CheckStatusQuery request, CancellationToken cancellationToken)
    {
        var email = _jwtProvider.GetEmailFromToken(request.Token);

        if(email.Length == 0)
        {
            return Result.Failure<LoginUserResponse?>(UsuarioErrors.CredencialesInvalidas);
        }

        var usuario = await _usuarioRepository.GetByEmailAsync(email, cancellationToken);
        

        if(usuario is null){
            return Result.Failure<LoginUserResponse?>(UsuarioErrors.CredencialesInvalidas);
        }


         var usuarioDto = _mapper.Map<UsuarioDto>(usuario);

        var token = await _jwtProvider.Generate(usuario);


        return LoginUserResponse.Create(token, usuarioDto)!;
    }
}