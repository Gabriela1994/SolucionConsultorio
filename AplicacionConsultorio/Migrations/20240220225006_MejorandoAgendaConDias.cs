using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class MejorandoAgendaConDias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_DiaSemana_SemanaId",
                table: "Agenda");

            migrationBuilder.DropIndex(
                name: "IX_Agenda_SemanaId",
                table: "Agenda");

            migrationBuilder.DropColumn(
                name: "SemanaId",
                table: "Agenda");

            migrationBuilder.AddColumn<int>(
                name: "AgendasID",
                table: "DiaSemana",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiaSemana_AgendasID",
                table: "DiaSemana",
                column: "AgendasID");

            migrationBuilder.AddForeignKey(
                name: "FK_DiaSemana_Agenda_AgendasID",
                table: "DiaSemana",
                column: "AgendasID",
                principalTable: "Agenda",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiaSemana_Agenda_AgendasID",
                table: "DiaSemana");

            migrationBuilder.DropIndex(
                name: "IX_DiaSemana_AgendasID",
                table: "DiaSemana");

            migrationBuilder.DropColumn(
                name: "AgendasID",
                table: "DiaSemana");

            migrationBuilder.AddColumn<int>(
                name: "SemanaId",
                table: "Agenda",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_SemanaId",
                table: "Agenda",
                column: "SemanaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_DiaSemana_SemanaId",
                table: "Agenda",
                column: "SemanaId",
                principalTable: "DiaSemana",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
