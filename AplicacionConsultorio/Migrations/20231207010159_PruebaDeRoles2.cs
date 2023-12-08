using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class PruebaDeRoles2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Genero_GeneroID",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_GeneroID",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "GeneroID",
                table: "Paciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeneroID",
                table: "Paciente",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_GeneroID",
                table: "Paciente",
                column: "GeneroID");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Genero_GeneroID",
                table: "Paciente",
                column: "GeneroID",
                principalTable: "Genero",
                principalColumn: "ID");
        }
    }
}
