

using Delivery.Domain.Pedidos;
using Delivery.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivery.Infrastructure.Configurations;


internal sealed class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{


    public void Configure(

        EntityTypeBuilder<Pedido> builder
    )
    {
        builder.ToTable("pedidos");
        builder.HasKey(pedido => pedido.Id);

        builder.Property(pedido => pedido.Id)
        .HasConversion(pedidoId => pedidoId!.Value, value => new PedidoId(value));

        builder.HasOne(pedido => pedido.Usuario)
        .WithMany(user => user.Pedido)
        .HasForeignKey(pedido => pedido.UsuarioId);

        builder.HasOne(pedido => pedido.Direccion)
        .WithMany(direc => direc.Pedido)
        .HasForeignKey(pedido => pedido.DireccionId);

        builder.Property(producto => producto.Total).IsRequired();

        builder.HasOne(pedido => pedido.MetodoPago)
        .WithMany()
        .HasForeignKey(pedido => pedido.MetodoPagoId);

        builder.HasOne(pedido => pedido.Estado)
        .WithMany()
        .HasForeignKey(pedido => pedido.EstadoId);

        builder.Property(pedido => pedido.FechaPedido).IsRequired();
   
         builder.Property(re => re.Activo)
		.IsRequired()
		.HasConversion(estado => estado!.Value, value => new Activo(value));
        
    }
}