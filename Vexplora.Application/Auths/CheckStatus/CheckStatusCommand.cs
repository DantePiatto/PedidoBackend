

using Vexplora.Application.Abstractions.Messaging;
using Vexplora.Application.Auths.Login;

namespace Vexplora.Application.Auths.CheckStatus;

public record CheckStatusQuery( string Token) : IQuery<LoginUserResponse?>;