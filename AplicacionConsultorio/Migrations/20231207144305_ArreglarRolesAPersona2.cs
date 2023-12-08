using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class ArreglarRolesAPersona2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Roles_RolID",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_RolID",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "RolID",
                table: "Paciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RolID",
                table: "Paciente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_RolID",
                table: "Paciente",
                column: "RolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Roles_RolID",
                table: "Paciente",
                column: "RolID",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
