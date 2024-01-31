using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class CrearProfesionalesYEspecialidad2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesionales_Genero_GeneroID",
                table: "Profesionales");

            migrationBuilder.DropIndex(
                name: "IX_Profesionales_GeneroID",
                table: "Profesionales");

            migrationBuilder.DropColumn(
                name: "GeneroID",
                table: "Profesionales");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeneroID",
                table: "Profesionales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profesionales_GeneroID",
                table: "Profesionales",
                column: "GeneroID");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesionales_Genero_GeneroID",
                table: "Profesionales",
                column: "GeneroID",
                principalTable: "Genero",
                principalColumn: "ID");
        }
    }
}
