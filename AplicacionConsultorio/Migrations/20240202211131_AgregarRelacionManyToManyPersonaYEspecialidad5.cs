using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacionManyToManyPersonaYEspecialidad5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Profesional_ProfesionalID",
                table: "Persona");

            migrationBuilder.DropTable(
                name: "Profesional");

            migrationBuilder.DropIndex(
                name: "IX_Persona_ProfesionalID",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "ProfesionalID",
                table: "Persona");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfesionalID",
                table: "Persona",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Profesional",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesional", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persona_ProfesionalID",
                table: "Persona",
                column: "ProfesionalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Profesional_ProfesionalID",
                table: "Persona",
                column: "ProfesionalID",
                principalTable: "Profesional",
                principalColumn: "ID");
        }
    }
}
