using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class MejorandoAgendaConDias2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "IdPersona",
                table: "Agenda",
                newName: "ProfesionalID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_ProfesionalID",
                table: "Agenda",
                column: "ProfesionalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_DiaSemana_Dia_semanaId",
                table: "Agenda",
                column: "Dia_semanaId",
                principalTable: "DiaSemana",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Persona_ProfesionalID",
                table: "Agenda",
                column: "ProfesionalID",
                principalTable: "Persona",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_DiaSemana_Dia_semanaId",
                table: "Agenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Persona_ProfesionalID",
                table: "Agenda");

            migrationBuilder.DropIndex(
                name: "IX_Agenda_Dia_semanaId",
                table: "Agenda");

            migrationBuilder.DropIndex(
                name: "IX_Agenda_ProfesionalID",
                table: "Agenda");

            migrationBuilder.DropColumn(
                name: "Dia_semanaId",
                table: "Agenda");

            migrationBuilder.RenameColumn(
                name: "ProfesionalID",
                table: "Agenda",
                newName: "IdPersona");

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
    }
}
