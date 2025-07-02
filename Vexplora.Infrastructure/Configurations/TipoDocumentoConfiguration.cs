using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vexplora.Domain.TipoDocumentos;

internal sealed class TipoDocumentoConfiguration : IEntityTypeConfiguration<TipoDocumento>
{
    public void Configure(EntityTypeBuilder<TipoDocumento> builder)
    {
        builder.ToTable("tipos_documento");
        builder.HasKey(tipoDocumento => tipoDocumento.Id);

        builder.Property(tipoDocumento => tipoDocumento.Id)
            .HasConversion(tipoDocumentoId => tipoDocumentoId!.Value, value => new TipoDocumentoId(value));

        builder.Property(tipoDocumento => tipoDocumento.Nombre)
            .IsRequired()
            .HasMaxLength(25);
    }
}