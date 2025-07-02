using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vexplora.Domain.TipoUsuarios;

internal sealed class TipoUsuarioConfiguration : IEntityTypeConfiguration<TipoUsuario>
{
    public void Configure(EntityTypeBuilder<TipoUsuario> builder)
    {
        builder.ToTable("tipos_usuario");
        builder.HasKey(tipoUsuario => tipoUsuario.Id);

        builder.Property(tipoUsuario => tipoUsuario.Id)
            .HasConversion(tipoUsuarioId => tipoUsuarioId!.Value, value => new TipoUsuarioId(value));

        builder.Property(tipoUsuario => tipoUsuario.Nombre)
            .IsRequired()
            .HasMaxLength(25);
    }
}