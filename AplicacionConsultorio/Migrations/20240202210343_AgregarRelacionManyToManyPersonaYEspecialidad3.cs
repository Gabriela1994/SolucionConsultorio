using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacionManyToManyPersonaYEspecialidad3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesional_Persona_PersonaID",
                table: "Profesional");

            migrationBuilder.DropIndex(
                name: "IX_Profesional_PersonaID",
                table: "Profesional");

            migrationBuilder.DropColumn(
                name: "IdEspecialidad",
                table: "Profesional");

            migrationBuilder.DropColumn(
                name: "IdPersona",
                table: "Profesional");

            migrationBuilder.DropColumn(
                name: "PersonaID",
                table: "Profesional");

            migrationBuilder.DropColumn(
                name: "fecha_registro",
                table: "Profesional");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Profesional",
                newName: "ID");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Profesional",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PersonaProfesional",
                columns: table => new
                {
                    PersonasID = table.Column<int>(type: "int", nullable: false),
                    ProfesionalesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaProfesional", x => new { x.PersonasID, x.ProfesionalesID });
                    table.ForeignKey(
                        name: "FK_PersonaProfesional_Persona_PersonasID",
                        column: x => x.PersonasID,
                        principalTable: "Persona",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonaProfesional_Profesional_ProfesionalesID",
                        column: x => x.ProfesionalesID,
                        principalTable: "Profesional",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonaProfesional_ProfesionalesID",
                table: "PersonaProfesional",
                column: "ProfesionalesID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonaProfesional");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Profesional");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Profesional",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "IdEspecialidad",
                table: "Profesional",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdPersona",
                table: "Profesional",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonaID",
                table: "Profesional",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_registro",
                table: "Profesional",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profesional_PersonaID",
                table: "Profesional",
                column: "PersonaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesional_Persona_PersonaID",
                table: "Profesional",
                column: "PersonaID",
                principalTable: "Persona",
                principalColumn: "ID");
        }
    }
}
