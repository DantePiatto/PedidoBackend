


using Delivery.Domain.PedidoAsignados;
using Delivery.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivery.Infrastructure.Configurations;

internal sealed class PedidoAsignadoConfiguration : IEntityTypeConfiguration<PedidoAsignado>
{

    public void Configure(

        EntityTypeBuilder<PedidoAsignado> builder
    )
    {

        builder.ToTable("producto_asignados");
        builder.HasKey(pa => pa.Id);

        builder.Property(pa => pa.Id)
        .HasConversion(paId => paId!.Value, value => new PedidoAsignadoId(value));

        builder.HasOne(pa => pa.Pedido)
        .WithMany(pe => pe.PedidoAsignado)
        .HasForeignKey(pa => pa.PedidoId);

        builder.HasOne(pa => pa.Repartidor)
        .WithMany(re => re.PedidoAsignado)
        .HasForeignKey(pa => pa.RepartidorId);

        builder.Property(pa => pa.FechaAsignacion).IsRequired();

         builder.Property(re => re.Activo)
		.IsRequired()
		.HasConversion(estado => estado!.Value, value => new Activo(value));

    }
}
