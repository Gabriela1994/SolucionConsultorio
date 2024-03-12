using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class CambieRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Persona_PersonaID",
                table: "Agenda");

            migrationBuilder.RenameColumn(
                name: "PersonaID",
                table: "Agenda",
                newName: "ProfesionalIdPersona");

            migrationBuilder.RenameIndex(
                name: "IX_Agenda_PersonaID",
                table: "Agenda",
                newName: "IX_Agenda_ProfesionalIdPersona");

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_ProfesionalXEspecialidad_ProfesionalIdPersona",
                table: "Agenda",
                column: "ProfesionalIdPersona",
                principalTable: "ProfesionalXEspecialidad",
                principalColumn: "IdPersona",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_ProfesionalXEspecialidad_ProfesionalIdPersona",
                table: "Agenda");

            migrationBuilder.RenameColumn(
                name: "ProfesionalIdPersona",
                table: "Agenda",
                newName: "PersonaID");

            migrationBuilder.RenameIndex(
                name: "IX_Agenda_ProfesionalIdPersona",
                table: "Agenda",
                newName: "IX_Agenda_PersonaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Persona_PersonaID",
                table: "Agenda",
                column: "PersonaID",
                principalTable: "Persona",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
