using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class CrearProfesionalesYEspecialidad3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesionales_Especialidades_EspecialidadID",
                table: "Profesionales");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesionales_Persona_PersonaID",
                table: "Profesionales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profesionales",
                table: "Profesionales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Especialidades",
                table: "Especialidades");

            migrationBuilder.RenameTable(
                name: "Profesionales",
                newName: "Profesional");

            migrationBuilder.RenameTable(
                name: "Especialidades",
                newName: "Especialidad");

            migrationBuilder.RenameIndex(
                name: "IX_Profesionales_PersonaID",
                table: "Profesional",
                newName: "IX_Profesional_PersonaID");

            migrationBuilder.RenameIndex(
                name: "IX_Profesionales_EspecialidadID",
                table: "Profesional",
                newName: "IX_Profesional_EspecialidadID");

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
                name: "FK_Profesional_Persona_PersonaID",
                table: "Profesional",
                column: "PersonaID",
                principalTable: "Persona",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesional_Especialidad_EspecialidadID",
                table: "Profesional");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesional_Persona_PersonaID",
                table: "Profesional");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profesional",
                table: "Profesional");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Especialidad",
                table: "Especialidad");

            migrationBuilder.RenameTable(
                name: "Profesional",
                newName: "Profesionales");

            migrationBuilder.RenameTable(
                name: "Especialidad",
                newName: "Especialidades");

            migrationBuilder.RenameIndex(
                name: "IX_Profesional_PersonaID",
                table: "Profesionales",
                newName: "IX_Profesionales_PersonaID");

            migrationBuilder.RenameIndex(
                name: "IX_Profesional_EspecialidadID",
                table: "Profesionales",
                newName: "IX_Profesionales_EspecialidadID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profesionales",
                table: "Profesionales",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Especialidades",
                table: "Especialidades",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesionales_Especialidades_EspecialidadID",
                table: "Profesionales",
                column: "EspecialidadID",
                principalTable: "Especialidades",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profesionales_Persona_PersonaID",
                table: "Profesionales",
                column: "PersonaID",
                principalTable: "Persona",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
