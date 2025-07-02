
using Vexplora.Domain.Parametros;
using Vexplora.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Vexplora.Infrastructure.Configurations;

internal sealed class ParametroConfiguration : IEntityTypeConfiguration<Parametro>
{
	public void Configure(
		EntityTypeBuilder<Parametro> builder
	)
	{
		builder.ToTable("parametros");
		builder.HasKey(parametro => parametro.Id);

		builder.Property(parametro => parametro.Id)
		.HasConversion(parametroId => parametroId!.Value, value => new ParametroId(value));

		builder.Property(parametro => parametro.Nombre)
		.IsRequired()
		.HasMaxLength(50);

		builder.Property(parametro => parametro.Abreviatura)
		.HasMaxLength(10);

		builder.Property(parametro => parametro.Descripcion)
		.HasMaxLength(300);

		builder.Property(parametro => parametro.Nivel)
		.IsRequired();

		builder.Property(parametro => parametro.Activo)
		.IsRequired()
		.HasConversion(estado => estado!.Value, value => new Activo(value));

		builder.Property(parametro => parametro.Valor)
		.HasMaxLength(2);

		builder.HasOne<Parametro>()
			.WithMany()
			.HasForeignKey(parametro => parametro.Dependencia);


		builder.HasData(
			Parametro.Create(new ParametroId(1), "PROVEEDOR OAUTH2", "oauth2", null, null, 0, null),
			Parametro.Create(new ParametroId(2), "google", null, null, new ParametroId(1), 1, "1"),
			Parametro.Create(new ParametroId(3), "facebook", null, null, new ParametroId(1), 1, "2"),
			Parametro.Create(new ParametroId(4), "instagram", null, null, new ParametroId(1), 1, "3")
		);

	}
}