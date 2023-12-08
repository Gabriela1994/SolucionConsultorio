using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class CreacionModeloProfesionalYEspecialidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Persona_PersonaID",
                table: "Paciente");

            migrationBuilder.AlterColumn<int>(
                name: "PersonaID",
                table: "Paciente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddColumn<int>(
                name: "GeneroID",
                table: "Paciente",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateTable(
                name: "Especialidad",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidad", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Profesional",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre_secundario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dni = table.Column<int>(type: "int", nullable: true),
                    Fecha_nacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Telefono = table.Column<int>(type: "int", nullable: true),
                    Celular = table.Column<int>(type: "int", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneroID = table.Column<int>(type: "int", nullable: false),
                    EspecialidadID = table.Column<int>(type: "int", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profesional_Especialidad_EspecialidadID",
                        column: x => x.EspecialidadID,
                        principalTable: "Especialidad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profesional_Genero_GeneroID",
                        column: x => x.GeneroID,
                        principalTable: "Genero",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_GeneroID",
                table: "Paciente",
                column: "GeneroID");

            migrationBuilder.CreateIndex(
                name: "IX_Profesional_EspecialidadID",
                table: "Profesional",
                column: "EspecialidadID");

            migrationBuilder.CreateIndex(
                name: "IX_Profesional_GeneroID",
                table: "Profesional",
                column: "GeneroID");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Genero_GeneroID",
                table: "Paciente");

            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Persona_PersonaID",
                table: "Paciente");

            migrationBuilder.DropTable(
                name: "Profesional");

            migrationBuilder.DropTable(
                name: "Especialidad");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_GeneroID",
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
                name: "GeneroID",
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

            migrationBuilder.AlterColumn<int>(
                name: "PersonaID",
                table: "Paciente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Persona_PersonaID",
                table: "Paciente",
                column: "PersonaID",
                principalTable: "Persona",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
