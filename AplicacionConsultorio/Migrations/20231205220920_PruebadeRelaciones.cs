using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class PruebadeRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeneroID",
                table: "Persona",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Persona_GeneroID",
                table: "Persona",
                column: "GeneroID");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Genero_GeneroID",
                table: "Persona",
                column: "GeneroID",
                principalTable: "Genero",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Genero_GeneroID",
                table: "Persona");

            migrationBuilder.DropIndex(
                name: "IX_Persona_GeneroID",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "GeneroID",
                table: "Persona");
        }
    }
}
