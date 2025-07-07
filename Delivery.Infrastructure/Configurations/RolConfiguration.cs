

using Delivery.Domain.Categorias;
using Delivery.Domain.Roles;
using Delivery.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivery.Infrastructure.Configurations;

internal sealed class RolConfiguration : IEntityTypeConfiguration<Rol>

{

    public void Configure(


        EntityTypeBuilder<Rol> builder
    )
    {

        builder.ToTable("roles");
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
        .HasConversion(rId => rId!.Value, value => new RolId(value));

        builder.Property(r => r.Nombre).IsRequired();

         builder.Property(re => re.Activo)
		.IsRequired()
		.HasConversion(estado => estado!.Value, value => new Activo(value));
        
    }
}