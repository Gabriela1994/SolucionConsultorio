using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class QuitoRelacionDeSemanas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_DiaSemana_Dia_semanaId",
                table: "Agenda");

            migrationBuilder.DropIndex(
                name: "IX_Agenda_Dia_semanaId",
                table: "Agenda");

            migrationBuilder.DropColumn(
                name: "Dia_semanaId",
                table: "Agenda");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Dia_semanaId",
                table: "Agenda",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_Dia_semanaId",
                table: "Agenda",
                column: "Dia_semanaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_DiaSemana_Dia_semanaId",
                table: "Agenda",
                column: "Dia_semanaId",
                principalTable: "DiaSemana",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
