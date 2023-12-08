using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class ArreglarRolesAPersona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RolID",
                table: "Persona",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persona_RolID",
                table: "Persona",
                column: "RolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Roles_RolID",
                table: "Persona",
                column: "RolID",
                principalTable: "Roles",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Roles_RolID",
                table: "Persona");

            migrationBuilder.DropIndex(
                name: "IX_Persona_RolID",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "RolID",
                table: "Persona");
        }
    }
}
