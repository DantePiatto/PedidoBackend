

using Delivery.Domain.Abstractions;
using Delivery.Domain.Opiniones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivery.Infrastructure.Configurations;

internal sealed class OpinionConfiguration : IEntityTypeConfiguration<Opinion>
{

    public void Configure(

        EntityTypeBuilder<Opinion> builder
    )
    {


        builder.ToTable("opiniones");
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
        .HasConversion(oId => oId!.Value, value => new OpinionId(value));

        builder.HasOne(o => o.Pedido)
        .WithMany(p => p.Opinion)
        .HasForeignKey(o => o.PedidoId);

        builder.HasOne(o => o.Usuario)
        .WithMany(u => u.Opinion)
        .HasForeignKey(o => o.UsuarioId);
        



    }
}