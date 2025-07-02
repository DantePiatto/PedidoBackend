using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vexplora.Infrastructure.Migrations.AppDb
{
    /// <inheritdoc />
    public partial class initialApp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "parametros",
                columns: new[] { "Id", "Abreviatura", "Activo", "Dependencia", "Descripcion", "Nivel", "Nombre", "Valor" },
                values: new object[,]
                {
                    { 1, "oauth2", true, null, null, 0, "PROVEEDOR OAUTH2", null },
                    { 2, null, true, 1, null, 1, "google", "1" },
                    { 3, null, true, 1, null, 1, "facebook", "2" },
                    { 4, null, true, 1, null, 1, "instagram", "3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_parametros_Dependencia",
                table: "parametros",
                column: "Dependencia");

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
                name: "parametros");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
