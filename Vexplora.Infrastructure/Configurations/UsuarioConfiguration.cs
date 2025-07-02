using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Vexplora.Domain.Usuarios;
using Vexplora.Domain.Shared;

namespace Vexplora.Infrastructure.Configurations;

internal sealed class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(
        EntityTypeBuilder<Usuario> builder
        )
    {
        builder.ToTable("usuarios");
        builder.HasKey(usuario => usuario.Id);

        builder.Property(usuario => usuario.Id)
        .HasConversion(usuarioId => usuarioId!.Value, value => new UsuarioId(value));
        // .HasConversion(usuarioId => usuarioId!.Value, value => new UsuarioId(value));

        builder.Property(usuario => usuario.Email)
        .IsRequired()
        .HasMaxLength(200);

        builder.Property(usuario => usuario.NroDocumento)
            .HasMaxLength(20);

        builder.Property(usuario => usuario.RutaDocumento)
            .HasMaxLength(20);

        builder.Property(empleado => empleado.FechaCreacion)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(usuario => usuario.RecibeNotificaciones);

        builder.Property(user => user.Clave)
           .IsRequired()
           .HasMaxLength(2000);

        builder.HasIndex(usuario => usuario.Email).IsUnique();

        builder.HasIndex(usuario => usuario.NroDocumento).IsUnique();
        
        	builder.Property(parametro => parametro.Activo)
		.IsRequired()
		.HasConversion(estado => estado!.Value, value => new Activo(value));


        // builder
        //            .HasOne(user => user.Rol)
        //            .WithMany()
        //            .HasForeignKey(user => user.RolId);

        // builder
        //            .HasOne(user => user.Empleado)
        //            .WithOne(empleado => empleado.Usuario)
        //            .HasForeignKey<Empleado>(user => user.UsuarioId);

        //  builder
        //            .HasOne(e => e.Cliente)
        //            .WithOne(e => e.Usuario)
        //            .HasForeignKey<Cliente>(e => e.UsuarioId);



    }
}