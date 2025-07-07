
using Delivery.Domain.EstadoPedidos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivery.Infrastructure.Configurations;


internal sealed class EstadoPedidoConfiguration : IEntityTypeConfiguration<EstadoPedido>
{


    public void Configure(

        EntityTypeBuilder<EstadoPedido> builder
    )
    {
        builder.ToTable("estados_pedidos");
        builder.HasKey(ep => ep.Id);

        builder.Property(ep => ep.Id)
        .HasConversion(epId => epId!.Value, value => new EstadoPedidoId(value));

        builder.HasOne(ep => ep.Pedido)
        .WithMany(pedido => pedido.EstadoPedidos)
        .HasForeignKey(dp => dp.PedidoId);

        builder.HasOne(dp => dp.Estado)
        .WithMany()
        .HasForeignKey(dp => dp.EstadoId);

        builder.Property(dp => dp.FechaEstado).IsRequired();

        
   
        
    }
}