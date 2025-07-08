

using Delivery.Domain.Restaurantes;
using FluentValidation;

namespace Delivery.Application.Restaurantes.UpdateRestaurantes;

public sealed class UpdateRestauranteCommandValidator : AbstractValidator<UpdateRestauranteCommand>
{

    public readonly IRestauranteRepository _restauranteRepository;

    public UpdateRestauranteCommandValidator(IRestauranteRepository restauranteRepository)
    {

        _restauranteRepository = restauranteRepository;

        RuleFor(r => r.Nombre)
        .NotEmpty().WithMessage("El nombre no puede ser nulo")
        .MaximumLength(200).WithMessage("El nombre no puede pasar mas de 200 caracteres");

        RuleFor(r => r.Descripcion)
        .NotEmpty().WithMessage("La Descripcion no puede ser nulo")
        .MaximumLength(500).WithMessage("La descripion no puede pasar mas de 500 caracteres");

        RuleFor(r => r.LogoUrl)
        .NotEmpty().WithMessage("El logo no puede ser nulo")
        .MaximumLength(500).WithMessage("El Logo no puede pasar mas de 500 caracteres");
        
        RuleFor(p => p.TiempoEntrega)
        .GreaterThan(0).WithMessage("El tiempo de entrega debe ser Mayor que 0");


    }



}