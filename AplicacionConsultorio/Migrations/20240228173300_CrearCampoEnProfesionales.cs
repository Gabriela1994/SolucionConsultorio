using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class CrearCampoEnProfesionales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "detalles",
                table: "ProfesionalXEspecialidad",
                newName: "Detalles");

            migrationBuilder.AddColumn<string>(
                name: "Matricula_profesional",
                table: "ProfesionalXEspecialidad",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Matricula_profesional",
                table: "ProfesionalXEspecialidad");

            migrationBuilder.RenameColumn(
                name: "Detalles",
                table: "ProfesionalXEspecialidad",
                newName: "detalles");
        }
    }
}
