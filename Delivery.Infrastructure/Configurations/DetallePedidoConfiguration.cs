


using Delivery.Domain.DetallePedidos;
using Delivery.Domain.Pedidos;
using Delivery.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivery.Infrastructure.Configurations;


internal sealed class DetallePedidoConfiguration : IEntityTypeConfiguration<DetallePedido>
{


    public void Configure(

        EntityTypeBuilder<DetallePedido> builder
    )
    {
        builder.ToTable("detalles_pedidos");
        builder.HasKey(dp => dp.Id);

        builder.Property(dp => dp.Id)
        .HasConversion(dpId => dpId!.Value, value => new DetallePedidoId(value));

        builder.HasOne(dp => dp.Pedido)
        .WithMany(pedido => pedido.DetallePedidos)
        .HasForeignKey(dp => dp.PedidoId);

        builder.HasOne(dp => dp.Producto)
        .WithMany(producto => producto.DetallePedidos)
        .HasForeignKey(dp => dp.ProductoId);

        builder.Property(dp => dp.Cantidad).IsRequired();

        builder.Property(dp => dp.SubTotal).IsRequired();
   
        
    }
}