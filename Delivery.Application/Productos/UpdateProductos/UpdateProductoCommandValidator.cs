


using Delivery.Domain.Productos;
using Delivery.Domain.Restaurantes;
using FluentValidation;

namespace Delivery.Application.Productos.UpdateProductos;

public sealed class UpdateProductoCommandValidator : AbstractValidator<UpdateProductoCommand>
{

    public readonly IProductoRepository _productoRepository1;

    public UpdateProductoCommandValidator(IProductoRepository productoRepository)
    {

        _productoRepository1 = productoRepository;

        RuleFor(r => r.Nombre)
        .NotEmpty().WithMessage("El nombre no puede ser nulo")
        .MaximumLength(200).WithMessage("El nombre no puede pasar mas de 200 caracteres");

        RuleFor(r => r.Descripcion)
        .NotEmpty().WithMessage("La Descripcion no puede ser nulo")
        .MaximumLength(500).WithMessage("La descripion no puede pasar mas de 500 caracteres");


        RuleFor(r => r.ImagenUrl)
        .NotEmpty().WithMessage("El logo no puede ser nulo")
        .MaximumLength(500).WithMessage("El Logo no puede pasar mas de 500 caracteres");

        RuleFor(p => p.Precio)
        .GreaterThan(0).WithMessage("El precio de entrega debe ser Mayor que 0");
        
        RuleFor(p => p.CategoriaId)
        .GreaterThan(0).WithMessage("El precio de entrega debe ser Mayor que 0");


    }



}