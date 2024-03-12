using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class MejorandoAgendaConDias3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Persona_ProfesionalID",
                table: "Agenda");

            migrationBuilder.RenameColumn(
                name: "ProfesionalID",
                table: "Agenda",
                newName: "PersonaID");

            migrationBuilder.RenameIndex(
                name: "IX_Agenda_ProfesionalID",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Persona_PersonaID",
                table: "Agenda");

            migrationBuilder.RenameColumn(
                name: "PersonaID",
                table: "Agenda",
                newName: "ProfesionalID");

            migrationBuilder.RenameIndex(
                name: "IX_Agenda_PersonaID",
                table: "Agenda",
                newName: "IX_Agenda_ProfesionalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Persona_ProfesionalID",
                table: "Agenda",
                column: "ProfesionalID",
                principalTable: "Persona",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
