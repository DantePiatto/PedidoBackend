
using Vexplora.Application.Abstractions.Messaging;

namespace Vexplora.Application.Auths.Login;

public record LoginCommand(
    string Correo,
    string Password
) : ICommand<LoginUserResponse>;