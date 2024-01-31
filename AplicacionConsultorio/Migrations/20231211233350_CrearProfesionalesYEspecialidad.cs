using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class CrearProfesionalesYEspecialidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesional_Especialidad_EspecialidadID",
                table: "Profesional");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesional_Genero_GeneroID",
                table: "Profesional");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profesional",
                table: "Profesional");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Especialidad",
                table: "Especialidad");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Profesional");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Profesional");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Profesional");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Profesional");

            migrationBuilder.DropColumn(
                name: "Dni",
                table: "Profesional");

            migrationBuilder.DropColumn(
                name: "Fecha_nacimiento",
                table: "Profesional");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Profesional");

            migrationBuilder.DropColumn(
                name: "Nombre_secundario",
                table: "Profesional");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Profesional");

            migrationBuilder.RenameTable(
                name: "Profesional",
                newName: "Profesionales");

            migrationBuilder.RenameTable(
                name: "Especialidad",
                newName: "Especialidades");

            migrationBuilder.RenameIndex(
                name: "IX_Profesional_GeneroID",
                table: "Profesionales",
                newName: "IX_Profesionales_GeneroID");

            migrationBuilder.RenameIndex(
                name: "IX_Profesional_EspecialidadID",
                table: "Profesionales",
                newName: "IX_Profesionales_EspecialidadID");

            migrationBuilder.AlterColumn<int>(
                name: "GeneroID",
                table: "Profesionales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PersonaID",
                table: "Profesionales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profesionales",
                table: "Profesionales",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Especialidades",
                table: "Especialidades",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Profesionales_PersonaID",
                table: "Profesionales",
                column: "PersonaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesionales_Especialidades_EspecialidadID",
                table: "Profesionales",
                column: "EspecialidadID",
                principalTable: "Especialidades",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profesionales_Genero_GeneroID",
                table: "Profesionales",
                column: "GeneroID",
                principalTable: "Genero",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesionales_Persona_PersonaID",
                table: "Profesionales",
                column: "PersonaID",
                principalTable: "Persona",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesionales_Especialidades_EspecialidadID",
                table: "Profesionales");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesionales_Genero_GeneroID",
                table: "Profesionales");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesionales_Persona_PersonaID",
                table: "Profesionales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profesionales",
                table: "Profesionales");

            migrationBuilder.DropIndex(
                name: "IX_Profesionales_PersonaID",
                table: "Profesionales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Especialidades",
                table: "Especialidades");

            migrationBuilder.DropColumn(
                name: "PersonaID",
                table: "Profesionales");

            migrationBuilder.RenameTable(
                name: "Profesionales",
                newName: "Profesional");

            migrationBuilder.RenameTable(
                name: "Especialidades",
                newName: "Especialidad");

            migrationBuilder.RenameIndex(
                name: "IX_Profesionales_GeneroID",
                table: "Profesional",
                newName: "IX_Profesional_GeneroID");

            migrationBuilder.RenameIndex(
                name: "IX_Profesionales_EspecialidadID",
                table: "Profesional",
                newName: "IX_Profesional_EspecialidadID");

            migrationBuilder.AlterColumn<int>(
                name: "GeneroID",
                table: "Profesional",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Profesional",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Celular",
                table: "Profesional",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Profesional",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Profesional",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dni",
                table: "Profesional",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha_nacimiento",
                table: "Profesional",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Profesional",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre_secundario",
                table: "Profesional",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Telefono",
                table: "Profesional",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profesional",
                table: "Profesional",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Especialidad",
                table: "Especialidad",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesional_Especialidad_EspecialidadID",
                table: "Profesional",
                column: "EspecialidadID",
                principalTable: "Especialidad",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profesional_Genero_GeneroID",
                table: "Profesional",
                column: "GeneroID",
                principalTable: "Genero",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
