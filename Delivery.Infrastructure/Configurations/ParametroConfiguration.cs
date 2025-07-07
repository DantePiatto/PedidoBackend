
using Delivery.Domain.Parametros;
using Delivery.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Delivery.Infrastructure.Configurations;

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
			Parametro.Create(new ParametroId(4), "instagram", null, null, new ParametroId(1), 1, "3"),


			Parametro.Create(new ParametroId(10),"METODO DE PAGO",null,null,null,0,null),
			Parametro.Create(new ParametroId(11),"efectivo",null,null,new ParametroId(10),1,"1"),
			Parametro.Create(new ParametroId(12),"tarjeta",null,null,new ParametroId(10),1,"2"),

			Parametro.Create(new ParametroId(20),"ESTADO DE PEDIDO",null,null,null,0,null),
			Parametro.Create(new ParametroId(21),"recibido",null,null,new ParametroId(20),1,"1"),
			Parametro.Create(new ParametroId(22),"preparando",null,null,new ParametroId(20),1,"2"),
			Parametro.Create(new ParametroId(23),"en camino",null,null,new ParametroId(20),1,"3"),
			Parametro.Create(new ParametroId(24),"entregado",null,null,new ParametroId(20),1,"4"),

			Parametro.Create(new ParametroId(30),"ESTADO DE PAGO",null,null,null,0,null),
			Parametro.Create(new ParametroId(31),"pendiente",null,null,new ParametroId(30),1,"1"),
			Parametro.Create(new ParametroId(32),"completado",null,null,new ParametroId(30),1,"2"),
			Parametro.Create(new ParametroId(33),"fallido",null,null,new ParametroId(30),1,"3"),

			Parametro.Create(new ParametroId(40),"VEHICULO",null,null,null,0,null),
			Parametro.Create(new ParametroId(41),"moto",null,null,new ParametroId(40),1,"1"),
			Parametro.Create(new ParametroId(42),"carro",null,null,new ParametroId(40),1,"2"),
			Parametro.Create(new ParametroId(43),"bicicleta",null,null,new ParametroId(40),1,"3"),

			Parametro.Create(new ParametroId(50),"TIPO",null,null,null,0,null),
			Parametro.Create(new ParametroId(51),"restaurante",null,null,new ParametroId(50),1,"1"),
			Parametro.Create(new ParametroId(52),"repartidor",null,null,new ParametroId(50),1,"2")









		);

	}
}