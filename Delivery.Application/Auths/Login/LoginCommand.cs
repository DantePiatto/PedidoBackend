
using Delivery.Application.Abstractions.Messaging;

namespace Delivery.Application.Auths.Login;

public record LoginCommand(
    string Correo,
    string Password
) : ICommand<LoginUserResponse>;