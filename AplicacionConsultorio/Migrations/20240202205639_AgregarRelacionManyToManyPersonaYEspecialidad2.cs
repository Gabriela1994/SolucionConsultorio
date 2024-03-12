using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacionManyToManyPersonaYEspecialidad2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EspecialidadPersona_Persona_ProfesionalesID",
                table: "EspecialidadPersona");

            migrationBuilder.RenameColumn(
                name: "ProfesionalesID",
                table: "EspecialidadPersona",
                newName: "PersonasID");

            migrationBuilder.RenameIndex(
                name: "IX_EspecialidadPersona_ProfesionalesID",
                table: "EspecialidadPersona",
                newName: "IX_EspecialidadPersona_PersonasID");

            migrationBuilder.AddForeignKey(
                name: "FK_EspecialidadPersona_Persona_PersonasID",
                table: "EspecialidadPersona",
                column: "PersonasID",
                principalTable: "Persona",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EspecialidadPersona_Persona_PersonasID",
                table: "EspecialidadPersona");

            migrationBuilder.RenameColumn(
                name: "PersonasID",
                table: "EspecialidadPersona",
                newName: "ProfesionalesID");

            migrationBuilder.RenameIndex(
                name: "IX_EspecialidadPersona_PersonasID",
                table: "EspecialidadPersona",
                newName: "IX_EspecialidadPersona_ProfesionalesID");

            migrationBuilder.AddForeignKey(
                name: "FK_EspecialidadPersona_Persona_ProfesionalesID",
                table: "EspecialidadPersona",
                column: "ProfesionalesID",
                principalTable: "Persona",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
