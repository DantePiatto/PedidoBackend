using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vexplora.Domain.Estados;

internal sealed class EstadoConfiguration : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.ToTable("estados");
        builder.HasKey(estado => estado.Id);

        builder.Property(estado => estado.Id)
            .HasConversion(estadoId => estadoId!.Value, value => new EstadoId(value));

        builder.Property(estado => estado.Nombre)
            .IsRequired()
            .HasMaxLength(25);

        builder.Property(estado => estado.Tabla)
            .IsRequired()
            .HasMaxLength(25);
    }
}