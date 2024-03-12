using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class InsertarTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfesionalXEspecialidad",
                table: "ProfesionalXEspecialidad");

            migrationBuilder.DropIndex(
                name: "IX_ProfesionalXEspecialidad_IdPersona",
                table: "ProfesionalXEspecialidad");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PacienteXObraSocial",
                table: "PacienteXObraSocial");

            migrationBuilder.DropIndex(
                name: "IX_PacienteXObraSocial_IdPersona",
                table: "PacienteXObraSocial");

            migrationBuilder.RenameColumn(
                name: "detalles",
                table: "PacienteXObraSocial",
                newName: "Detalles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfesionalXEspecialidad",
                table: "ProfesionalXEspecialidad",
                column: "IdPersona");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PacienteXObraSocial",
                table: "PacienteXObraSocial",
                column: "IdPersona");

            migrationBuilder.CreateTable(
                name: "DiaSemana",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaSemana", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPersona = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_llegada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_salida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SemanaId = table.Column<int>(type: "int", nullable: false),
                    Duracion_consulta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Agenda_DiaSemana_SemanaId",
                        column: x => x.SemanaId,
                        principalTable: "DiaSemana",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfesionalXEspecialidad_IdEspecialidad",
                table: "ProfesionalXEspecialidad",
                column: "IdEspecialidad");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteXObraSocial_IdObraSocial",
                table: "PacienteXObraSocial",
                column: "IdObraSocial");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_SemanaId",
                table: "Agenda",
                column: "SemanaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "DiaSemana");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfesionalXEspecialidad",
                table: "ProfesionalXEspecialidad");

            migrationBuilder.DropIndex(
                name: "IX_ProfesionalXEspecialidad_IdEspecialidad",
                table: "ProfesionalXEspecialidad");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PacienteXObraSocial",
                table: "PacienteXObraSocial");

            migrationBuilder.DropIndex(
                name: "IX_PacienteXObraSocial_IdObraSocial",
                table: "PacienteXObraSocial");

            migrationBuilder.RenameColumn(
                name: "Detalles",
                table: "PacienteXObraSocial",
                newName: "detalles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfesionalXEspecialidad",
                table: "ProfesionalXEspecialidad",
                columns: new[] { "IdEspecialidad", "IdPersona" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PacienteXObraSocial",
                table: "PacienteXObraSocial",
                columns: new[] { "IdObraSocial", "IdPersona" });

            migrationBuilder.CreateIndex(
                name: "IX_ProfesionalXEspecialidad_IdPersona",
                table: "ProfesionalXEspecialidad",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteXObraSocial_IdPersona",
                table: "PacienteXObraSocial",
                column: "IdPersona");
        }
    }
}
