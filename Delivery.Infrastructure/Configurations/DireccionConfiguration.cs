

using Delivery.Domain.Categorias;
using Delivery.Domain.Direcciones;
using Delivery.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivery.Infrastructure.Configurations;

internal sealed class DireccionConfiguration : IEntityTypeConfiguration<Direccion>

{

    public void Configure(


        EntityTypeBuilder<Direccion> builder
    )
    {

        builder.ToTable("direcciones");
        builder.HasKey(direc => direc.Id);

        builder.Property(direc => direc.Id)
        .HasConversion(direcId => direcId!.Value, value => new DireccionId(value));

        builder.HasOne(direc => direc.Usuario)
        .WithMany(user => user.Direccion)
        .HasForeignKey(direc => direc.UsuarioId);

        builder.Property(direc => direc.Direc).IsRequired();
        builder.Property(direc => direc.Referencia).IsRequired();
        builder.Property(direc => direc.Latitud).IsRequired();
        builder.Property(direc => direc.Altitud).IsRequired();
        builder.Property(direc => direc.Predeterminado).IsRequired();
        
         builder.Property(re => re.Activo)
		.IsRequired()
		.HasConversion(estado => estado!.Value, value => new Activo(value));
        
    }
}