using Microsoft.OpenApi.Models;
using Vexplora.Api.Extensions;
using Vexplora.Infrastructure;
using Vexplora.Application;
using Serilog;
using Vexplora.Api.Documentation;
using Vexplora.Application.Abstractions.Authentication;
using Vexplora.Infrastructure.Authentication;
using Vexplora.Api.OptionsSetup;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Host.UseSerilog((context, configuration)=> configuration.ReadFrom.Configuration(context.Configuration));


builder.Services.AddControllers();

builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddTransient<IJwtProvider, JwtProvider>();
builder.Services.AddHttpClient<IOAuth2Validator, OAuth2Validator>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],   // 👈 Issuer definido en appsettings.json
            ValidAudience = builder.Configuration["Jwt:Audience"], // 👈 Audience definido en appsettings.json
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]!)) // 👈 Clave secreta
        };
    });


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // o tu dominio de Angular
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials(); // Solo si usas cookies o auth headers
        });
});

builder.Services.AddAuthorization();

builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
//Esta configuracion es si el modelo como User es primitivo
// builder.Services.AddSwaggerGen();

//Esta configuracion es para como lo tenemos ahora con object values
builder.Services.AddSwaggerGen(options => {
    options.CustomSchemaIds( type => type.ToString());

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\""
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAndMigrateTenantDatabases(builder.Configuration);

// builder.Services.Configure<IdentityOptions>(options =>
// {
//     options.ClaimsIdentity.RoleClaimType = "Rol"; // Aquí le decimos a ASP.NET que busque "Rol" en el JWT
// });


var app = builder.Build();

app.UseCors("AllowFrontend");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var descriptions = app.DescribeApiVersions();

        foreach (var description in descriptions)
        {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }

    });
}


// await app.ApplyMigration();

app.UseRequestContextLogging();
app.UseSerilogRequestLogging();
app.UseCustomExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();

