
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Delivery.Domain.Usuarios;

namespace Delivery.Infrastructure.Configurations;

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

        builder.Property(usuario => usuario.Correo)
        .IsRequired()
        .HasMaxLength(200);

        builder.Property(usuario => usuario.Dni)
            .HasMaxLength(20);

        builder.Property(usuario => usuario.Celular)
            .HasMaxLength(20);            
        
        builder.Property(empleado => empleado.Sexo)
            .IsRequired()   
            .HasMaxLength(20);

        builder.Property(usuario => usuario.IsDefaultPassword);

        builder.Property(user => user.Password)
           .IsRequired()
           .HasMaxLength(2000);

        builder.HasIndex(usuario => usuario.Correo).IsUnique();

        builder.HasIndex(usuario => usuario.Dni).IsUnique();

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