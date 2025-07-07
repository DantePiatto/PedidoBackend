using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Delivery.Infrastructure.Migrations.AppDb
{
    /// <inheritdoc />
    public partial class initialApp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "parametros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Abreviatura = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Descripcion = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Dependencia = table.Column<int>(type: "integer", nullable: true),
                    Valor = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    Nivel = table.Column<int>(type: "integer", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parametros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_parametros_parametros_Dependencia",
                        column: x => x.Dependencia,
                        principalTable: "parametros",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "restaurantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    LogoUrl = table.Column<string>(type: "text", nullable: false),
                    TiempoEntrega = table.Column<int>(type: "integer", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Correo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    Nombres = table.Column<string>(type: "text", nullable: true),
                    Apellidos = table.Column<string>(type: "text", nullable: true),
                    Dni = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Celular = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Sexo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    IsDefaultPassword = table.Column<bool>(type: "boolean", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RestauranteId = table.Column<Guid>(type: "uuid", nullable: true),
                    CategoriaId = table.Column<Guid>(type: "uuid", nullable: true),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Precio = table.Column<double>(type: "double precision", nullable: false),
                    Imagen_Url = table.Column<string>(type: "text", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productos_categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "categorias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_productos_restaurantes_RestauranteId",
                        column: x => x.RestauranteId,
                        principalTable: "restaurantes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "direcciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: true),
                    Direc = table.Column<string>(type: "text", nullable: false),
                    Referencia = table.Column<string>(type: "text", nullable: false),
                    Latitud = table.Column<double>(type: "double precision", nullable: false),
                    Altitud = table.Column<double>(type: "double precision", nullable: false),
                    Predeterminado = table.Column<bool>(type: "boolean", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_direcciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_direcciones_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "repartidores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: true),
                    VehiculoId = table.Column<int>(type: "integer", nullable: true),
                    Placa = table.Column<string>(type: "text", nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_repartidores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_repartidores_parametros_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "parametros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_repartidores_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "usuario_roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: true),
                    RolId = table.Column<Guid>(type: "uuid", nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuario_roles_roles_RolId",
                        column: x => x.RolId,
                        principalTable: "roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_usuario_roles_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "pedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: true),
                    DireccionId = table.Column<Guid>(type: "uuid", nullable: true),
                    Total = table.Column<double>(type: "double precision", nullable: false),
                    MetodoPagoId = table.Column<int>(type: "integer", nullable: true),
                    EstadoId = table.Column<int>(type: "integer", nullable: true),
                    FechaPedido = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pedidos_direcciones_DireccionId",
                        column: x => x.DireccionId,
                        principalTable: "direcciones",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_pedidos_parametros_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "parametros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_pedidos_parametros_MetodoPagoId",
                        column: x => x.MetodoPagoId,
                        principalTable: "parametros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_pedidos_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "detalles_pedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductoId = table.Column<Guid>(type: "uuid", nullable: true),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    SubTotal = table.Column<double>(type: "double precision", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalles_pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalles_pedidos_pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "pedidos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_detalles_pedidos_productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "productos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "estados_pedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uuid", nullable: true),
                    EstadoId = table.Column<int>(type: "integer", nullable: true),
                    FechaEstado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estados_pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_estados_pedidos_parametros_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "parametros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_estados_pedidos_pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "pedidos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "opiniones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uuid", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: true),
                    Puntaje = table.Column<int>(type: "integer", nullable: true),
                    Comentario = table.Column<string>(type: "text", nullable: true),
                    TipoId = table.Column<int>(type: "integer", nullable: true),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_opiniones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_opiniones_parametros_TipoId",
                        column: x => x.TipoId,
                        principalTable: "parametros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_opiniones_pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "pedidos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_opiniones_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "pagos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uuid", nullable: true),
                    MetodoPagoId = table.Column<int>(type: "integer", nullable: true),
                    EstadoPagoId = table.Column<int>(type: "integer", nullable: true),
                    FechaPago = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pagos_parametros_EstadoPagoId",
                        column: x => x.EstadoPagoId,
                        principalTable: "parametros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_pagos_parametros_MetodoPagoId",
                        column: x => x.MetodoPagoId,
                        principalTable: "parametros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_pagos_pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "pedidos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "producto_asignados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uuid", nullable: true),
                    RepartidorId = table.Column<Guid>(type: "uuid", nullable: true),
                    FechaAsignacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto_asignados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_producto_asignados_pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "pedidos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_producto_asignados_repartidores_RepartidorId",
                        column: x => x.RepartidorId,
                        principalTable: "repartidores",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "parametros",
                columns: new[] { "Id", "Abreviatura", "Activo", "Dependencia", "Descripcion", "Nivel", "Nombre", "Valor" },
                values: new object[,]
                {
                    { 1, "oauth2", true, null, null, 0, "PROVEEDOR OAUTH2", null },
                    { 10, null, true, null, null, 0, "METODO DE PAGO", null },
                    { 20, null, true, null, null, 0, "ESTADO DE PEDIDO", null },
                    { 30, null, true, null, null, 0, "ESTADO DE PAGO", null },
                    { 40, null, true, null, null, 0, "VEHICULO", null },
                    { 50, null, true, null, null, 0, "TIPO", null },
                    { 2, null, true, 1, null, 1, "google", "1" },
                    { 3, null, true, 1, null, 1, "facebook", "2" },
                    { 4, null, true, 1, null, 1, "instagram", "3" },
                    { 11, null, true, 10, null, 1, "efectivo", "1" },
                    { 12, null, true, 10, null, 1, "tarjeta", "2" },
                    { 21, null, true, 20, null, 1, "recibido", "1" },
                    { 22, null, true, 20, null, 1, "preparando", "2" },
                    { 23, null, true, 20, null, 1, "en camino", "3" },
                    { 24, null, true, 20, null, 1, "entregado", "4" },
                    { 31, null, true, 30, null, 1, "pendiente", "1" },
                    { 32, null, true, 30, null, 1, "completado", "2" },
                    { 33, null, true, 30, null, 1, "fallido", "3" },
                    { 41, null, true, 40, null, 1, "moto", "1" },
                    { 42, null, true, 40, null, 1, "carro", "2" },
                    { 43, null, true, 40, null, 1, "bicicleta", "3" },
                    { 51, null, true, 50, null, 1, "restaurante", "1" },
                    { 52, null, true, 50, null, 1, "repartidor", "2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_detalles_pedidos_PedidoId",
                table: "detalles_pedidos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_detalles_pedidos_ProductoId",
                table: "detalles_pedidos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_direcciones_UsuarioId",
                table: "direcciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_estados_pedidos_EstadoId",
                table: "estados_pedidos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_estados_pedidos_PedidoId",
                table: "estados_pedidos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_opiniones_PedidoId",
                table: "opiniones",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_opiniones_TipoId",
                table: "opiniones",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_opiniones_UsuarioId",
                table: "opiniones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_pagos_EstadoPagoId",
                table: "pagos",
                column: "EstadoPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_pagos_MetodoPagoId",
                table: "pagos",
                column: "MetodoPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_pagos_PedidoId",
                table: "pagos",
                column: "PedidoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_parametros_Dependencia",
                table: "parametros",
                column: "Dependencia");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_DireccionId",
                table: "pedidos",
                column: "DireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_EstadoId",
                table: "pedidos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_MetodoPagoId",
                table: "pedidos",
                column: "MetodoPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_UsuarioId",
                table: "pedidos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_producto_asignados_PedidoId",
                table: "producto_asignados",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_producto_asignados_RepartidorId",
                table: "producto_asignados",
                column: "RepartidorId");

            migrationBuilder.CreateIndex(
                name: "IX_productos_CategoriaId",
                table: "productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_productos_RestauranteId",
                table: "productos",
                column: "RestauranteId");

            migrationBuilder.CreateIndex(
                name: "IX_repartidores_UsuarioId",
                table: "repartidores",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_repartidores_VehiculoId",
                table: "repartidores",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_roles_RolId",
                table: "usuario_roles",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_roles_UsuarioId",
                table: "usuario_roles",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_Correo",
                table: "usuarios",
                column: "Correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_Dni",
                table: "usuarios",
                column: "Dni",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalles_pedidos");

            migrationBuilder.DropTable(
                name: "estados_pedidos");

            migrationBuilder.DropTable(
                name: "opiniones");

            migrationBuilder.DropTable(
                name: "pagos");

            migrationBuilder.DropTable(
                name: "producto_asignados");

            migrationBuilder.DropTable(
                name: "usuario_roles");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "pedidos");

            migrationBuilder.DropTable(
                name: "repartidores");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "restaurantes");

            migrationBuilder.DropTable(
                name: "direcciones");

            migrationBuilder.DropTable(
                name: "parametros");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
