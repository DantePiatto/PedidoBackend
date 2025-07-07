

using Delivery.Domain.Restaurantes;
using Delivery.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivery.Infrastructure.Configurations;

internal sealed class RestauranteConfiguration : IEntityTypeConfiguration<Restaurante>
{

    public void Configure(


        EntityTypeBuilder<Restaurante> builder
    )
    {

        builder.ToTable("restaurantes");
        builder.HasKey(restaurante => restaurante.Id);

        builder.Property(restaurante => restaurante.Id)
        .HasConversion(restauranteId => restauranteId!.Value, value => new RestauranteId(value));

        builder.Property(restaurante => restaurante.Nombre).IsRequired();
        builder.Property(restaurante => restaurante.Descripcion).IsRequired();
        builder.Property(restaurante => restaurante.LogoUrl).IsRequired();
        builder.Property(restaurante => restaurante.TiempoEntrega).IsRequired();

        builder.Property(producto => producto.Activo)
		.IsRequired()
		.HasConversion(estado => estado!.Value, value => new Activo(value));
        


        
    }
}