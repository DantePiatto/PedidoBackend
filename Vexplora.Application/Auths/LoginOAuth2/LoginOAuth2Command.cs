
using Vexplora.Application.Abstractions.Messaging;

namespace Vexplora.Application.Auths.LoginOAuth2;

public record LoginOAuth2Command(string Token, string Provider) : ICommand<LoginOAuth2Response>;

