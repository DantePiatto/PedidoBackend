


using Delivery.Domain.Repartidores;
using Delivery.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivery.Infrastructure.Configurations;


internal sealed class RepartidorConfiguration : IEntityTypeConfiguration<Repartidor>
{

    public void Configure(

        EntityTypeBuilder<Repartidor> builder
    )
    {
        builder.ToTable("repartidores");
        builder.HasKey(re => re.Id);


        builder.Property(re => re.Id)
        .HasConversion(reId => reId!.Value, value => new RepartidorId(value));


        builder.HasOne(re => re.Usuario)
        .WithOne(user => user.Repartidor)
        .HasForeignKey<Repartidor>(re => re.UsuarioId);


        builder.HasOne(re => re.Vehiculo)
        .WithMany()
        .HasForeignKey(re => re.VehiculoId);


        builder.Property(re => re.Activo)
		.IsRequired()
		.HasConversion(estado => estado!.Value, value => new Activo(value));
        
        





    }



}