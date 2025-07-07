

using Delivery.Domain.Categorias;
using Delivery.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivery.Infrastructure.Configurations;

internal sealed class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>

{

    public void Configure(


        EntityTypeBuilder<Categoria> builder
    )
    {

        builder.ToTable("categorias");
        builder.HasKey(categoria => categoria.Id);

        builder.Property(categoria => categoria.Id)
        .HasConversion(categoriaId => categoriaId!.Value, value => new CategoriaId(value));

        builder.Property(categoria => categoria.Nombre).IsRequired();


        builder.Property(re => re.Activo)
            .IsRequired()
            .HasConversion(estado => estado!.Value, value => new Activo(value));


    }
}