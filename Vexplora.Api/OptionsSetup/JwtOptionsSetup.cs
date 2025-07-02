using Microsoft.Extensions.Options;
using Vexplora.Infrastructure.Authentication;

namespace Vexplora.Api.OptionsSetup;

public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
    public const string SectionName = "Jwt";

    private readonly IConfiguration _configuration;

    public JwtOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtOptions options)
    {
        _configuration.GetSection(SectionName).Bind(options);

        
    }
}