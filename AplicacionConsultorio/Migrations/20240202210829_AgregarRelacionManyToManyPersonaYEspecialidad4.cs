using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacionManyToManyPersonaYEspecialidad4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EspecialidadPersona");

            migrationBuilder.DropTable(
                name: "PersonaProfesional");

            migrationBuilder.AddColumn<int>(
                name: "ProfesionalID",
                table: "Persona",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProfesionalXEspecialidad",
                columns: table => new
                {
                    IdEspecialidad = table.Column<int>(type: "int", nullable: false),
                    IdPersona = table.Column<int>(type: "int", nullable: false),
                    detalles = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfesionalXEspecialidad", x => new { x.IdEspecialidad, x.IdPersona });
                    table.ForeignKey(
                        name: "FK_ProfesionalXEspecialidad_Especialidad_IdEspecialidad",
                        column: x => x.IdEspecialidad,
                        principalTable: "Especialidad",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ProfesionalXEspecialidad_Persona_IdPersona",
                        column: x => x.IdPersona,
                        principalTable: "Persona",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persona_ProfesionalID",
                table: "Persona",
                column: "ProfesionalID");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesionalXEspecialidad_IdPersona",
                table: "ProfesionalXEspecialidad",
                column: "IdPersona");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Profesional_ProfesionalID",
                table: "Persona",
                column: "ProfesionalID",
                principalTable: "Profesional",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Profesional_ProfesionalID",
                table: "Persona");

            migrationBuilder.DropTable(
                name: "ProfesionalXEspecialidad");

            migrationBuilder.DropIndex(
                name: "IX_Persona_ProfesionalID",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "ProfesionalID",
                table: "Persona");

            migrationBuilder.CreateTable(
                name: "EspecialidadPersona",
                columns: table => new
                {
                    EspecialidadesID = table.Column<int>(type: "int", nullable: false),
                    PersonasID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecialidadPersona", x => new { x.EspecialidadesID, x.PersonasID });
                    table.ForeignKey(
                        name: "FK_EspecialidadPersona_Especialidad_EspecialidadesID",
                        column: x => x.EspecialidadesID,
                        principalTable: "Especialidad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EspecialidadPersona_Persona_PersonasID",
                        column: x => x.PersonasID,
                        principalTable: "Persona",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_EspecialidadPersona_PersonasID",
                table: "EspecialidadPersona",
                column: "PersonasID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaProfesional_ProfesionalesID",
                table: "PersonaProfesional",
                column: "ProfesionalesID");
        }
    }
}
