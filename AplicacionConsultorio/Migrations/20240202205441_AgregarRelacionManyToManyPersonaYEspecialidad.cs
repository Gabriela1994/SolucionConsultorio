using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacionManyToManyPersonaYEspecialidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesional_Especialidad_EspecialidadID",
                table: "Profesional");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesional_Persona_PersonaID",
                table: "Profesional");

            migrationBuilder.DropIndex(
                name: "IX_Profesional_EspecialidadID",
                table: "Profesional");

            migrationBuilder.DropColumn(
                name: "EspecialidadID",
                table: "Profesional");

            migrationBuilder.AlterColumn<int>(
                name: "PersonaID",
                table: "Profesional",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.CreateTable(
                name: "EspecialidadPersona",
                columns: table => new
                {
                    EspecialidadesID = table.Column<int>(type: "int", nullable: false),
                    ProfesionalesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecialidadPersona", x => new { x.EspecialidadesID, x.ProfesionalesID });
                    table.ForeignKey(
                        name: "FK_EspecialidadPersona_Especialidad_EspecialidadesID",
                        column: x => x.EspecialidadesID,
                        principalTable: "Especialidad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EspecialidadPersona_Persona_ProfesionalesID",
                        column: x => x.ProfesionalesID,
                        principalTable: "Persona",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EspecialidadPersona_ProfesionalesID",
                table: "EspecialidadPersona",
                column: "ProfesionalesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesional_Persona_PersonaID",
                table: "Profesional",
                column: "PersonaID",
                principalTable: "Persona",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesional_Persona_PersonaID",
                table: "Profesional");

            migrationBuilder.DropTable(
                name: "EspecialidadPersona");

            migrationBuilder.DropColumn(
                name: "IdEspecialidad",
                table: "Profesional");

            migrationBuilder.DropColumn(
                name: "IdPersona",
                table: "Profesional");

            migrationBuilder.AlterColumn<int>(
                name: "PersonaID",
                table: "Profesional",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EspecialidadID",
                table: "Profesional",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Profesional_EspecialidadID",
                table: "Profesional",
                column: "EspecialidadID");

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
    }
}
