
using AutoMapper;
using Delivery.Application.Abstractions.Authentication;
using Delivery.Application.Abstractions.Messaging;
using Delivery.Application.Auths.CheckStatus;
using Delivery.Application.Auths.Login;
using Delivery.Domain.Abstractions;
using Delivery.Domain.Usuarios;

namespace MsAcceso.Application.Root.Users.LoginUser;

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