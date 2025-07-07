
using Delivery.Domain.Productos;
using Delivery.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivery.Infrastructure.Configurations;


internal sealed class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{


    public void Configure(

        EntityTypeBuilder<Producto> builder
    )
    {
        builder.ToTable("productos");
        builder.HasKey(producto => producto.Id);

        builder.Property(producto => producto.Id)
        .HasConversion(productoId => productoId!.Value, value => new ProductoId(value));

        builder.HasOne(pedido => pedido.Categoria)
        .WithMany()
        .HasForeignKey(pedido => pedido.CategoriaId);

        builder.HasOne(producto => producto.Restaurante)
        .WithMany(restaurante => restaurante.Producto)
        .HasForeignKey(producto => producto.RestauranteId);


        builder.Property(producto => producto.Nombre).IsRequired();
        builder.Property(producto => producto.Descripcion).IsRequired();
        builder.Property(producto => producto.Precio).IsRequired();
        builder.Property(producto => producto.Imagen_Url).IsRequired();

        builder.Property(producto => producto.Activo)
		.IsRequired()
		.HasConversion(estado => estado!.Value, value => new Activo(value));
        
        
    }
}