
using Delivery.Domain.ProductoCategorias;
using Delivery.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivery.Infrastructure.Configurations;

internal sealed class PrductoCategoriaConfoguration : IEntityTypeConfiguration<ProductoCategoria>
{

    public void Configure(

        EntityTypeBuilder<ProductoCategoria> builder
    )
    {

        builder.ToTable("producto_categoria");
        builder.HasKey(pc => pc.Id);


        builder.Property(pc => pc.Id)
        .HasConversion(pcId => pcId!.Value, value => new ProductoCategoriaId(value));

        builder.HasOne(pc => pc.Producto)
        .WithMany(p => p.ProductoCategoria)
        .HasForeignKey(pc => pc.ProductoId);

        builder.HasOne(pc => pc.Categoria)
        .WithMany()
        .HasForeignKey(pc => pc.CategoriaId);

        builder.Property(producto => producto.Activo)
		.IsRequired()
		.HasConversion(estado => estado!.Value, value => new Activo(value));
        
        

    }



}