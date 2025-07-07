

using Delivery.Domain.Pagos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivery.Infrastructure.Configurations;


internal sealed class PagoConfiguration : IEntityTypeConfiguration<Pago>
{


    public void Configure(

        EntityTypeBuilder<Pago> builder
    )
    {
        builder.ToTable("pagos");
        builder.HasKey(pa => pa.Id);

        builder.Property(pa => pa.Id)
        .HasConversion(paId => paId!.Value, value => new PagoId(value));

        builder.HasOne(pa => pa.Pedido)
        .WithOne(pedido => pedido.Pago)
        .HasForeignKey<Pago>(pa=>pa.PedidoId);

        builder.HasOne(pa => pa.MetodoPago)
        .WithMany()
        .HasForeignKey(pa => pa.MetodoPagoId);

        builder.Property(pa => pa.FechaPago).IsRequired();

        
   
        
    }
}