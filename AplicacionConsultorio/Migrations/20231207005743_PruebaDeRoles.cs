using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class PruebaDeRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Genero_GeneroID",
                table: "Paciente");

            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Persona_PersonaID",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Dni",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Fecha_nacimiento",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Nombre_secundario",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Paciente");

            migrationBuilder.AddColumn<int>(
                name: "RolesID",
                table: "Profesional",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonaID",
                table: "Paciente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GeneroID",
                table: "Paciente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RolID",
                table: "Paciente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profesional_RolesID",
                table: "Profesional",
                column: "RolesID");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_RolID",
                table: "Paciente",
                column: "RolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Genero_GeneroID",
                table: "Paciente",
                column: "GeneroID",
                principalTable: "Genero",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Persona_PersonaID",
                table: "Paciente",
                column: "PersonaID",
                principalTable: "Persona",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Roles_RolID",
                table: "Paciente",
                column: "RolID",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profesional_Roles_RolesID",
                table: "Profesional",
                column: "RolesID",
                principalTable: "Roles",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Genero_GeneroID",
                table: "Paciente");

            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Persona_PersonaID",
                table: "Paciente");

            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Roles_RolID",
                table: "Paciente");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesional_Roles_RolesID",
                table: "Profesional");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Profesional_RolesID",
                table: "Profesional");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_RolID",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "RolesID",
                table: "Profesional");

            migrationBuilder.DropColumn(
                name: "RolID",
                table: "Paciente");

            migrationBuilder.AlterColumn<int>(
                name: "PersonaID",
                table: "Paciente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GeneroID",
                table: "Paciente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Paciente",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Celular",
                table: "Paciente",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Paciente",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Paciente",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dni",
                table: "Paciente",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_nacimiento",
                table: "Paciente",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Paciente",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre_secundario",
                table: "Paciente",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Telefono",
                table: "Paciente",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Genero_GeneroID",
                table: "Paciente",
                column: "GeneroID",
                principalTable: "Genero",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Persona_PersonaID",
                table: "Paciente",
                column: "PersonaID",
                principalTable: "Persona",
                principalColumn: "ID");
        }
    }
}
