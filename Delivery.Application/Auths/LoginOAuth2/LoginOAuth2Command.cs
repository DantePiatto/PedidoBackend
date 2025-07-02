
using Delivery.Application.Abstractions.Messaging;

namespace Delivery.Application.Auths.LoginOAuth2;

public record LoginOAuth2Command(string Token, string Provider) : ICommand<LoginOAuth2Response>;

