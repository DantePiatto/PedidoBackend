
using Delivery.Domain.UsuarioRoles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivery.Infrastructure.Configurations;

internal sealed class UsuarioRolConfoguration : IEntityTypeConfiguration<UsuarioRol>
{

    public void Configure(

        EntityTypeBuilder<UsuarioRol> builder
    )

    {

        builder.ToTable("usuario_roles");
        builder.HasKey(ro => ro.Id);

        builder.Property(ro => ro.Id)
        .HasConversion(roId => roId!.Value, value => new UsuarioRolId(value));

        builder.HasOne(ro => ro.Usuario)
        .WithMany(user => user.usuarioRols)
        .HasForeignKey(ro => ro.UsuarioId);

        builder.HasOne(ro => ro.Rol)
        .WithMany(r=>r.UsuarioRols)
        .HasForeignKey(ro => ro.RolId);
        
    }
}