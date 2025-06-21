

using Delivery.Application.Abstractions.Messaging;
using Delivery.Application.Auths.Login;

namespace Delivery.Application.Auths.CheckStatus;

public record CheckStatusQuery( string Token) : IQuery<LoginUserResponse?>;