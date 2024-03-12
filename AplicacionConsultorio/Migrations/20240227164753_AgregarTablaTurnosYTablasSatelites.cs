using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTablaTurnosYTablasSatelites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estado_turno",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado_turno", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_consulta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_consulta", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Turno",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProfesionalIdPersona = table.Column<int>(type: "int", nullable: false),
                    IdPacienteIdPersona = table.Column<int>(type: "int", nullable: false),
                    Id_tipoConsultaID = table.Column<int>(type: "int", nullable: false),
                    Id_estadoTurnoID = table.Column<int>(type: "int", nullable: false),
                    Fecha_consulta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_consulta = table.Column<TimeSpan>(type: "time", nullable: false),
                    Indicaciones_paciente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turno", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Turno_Estado_turno_Id_estadoTurnoID",
                        column: x => x.Id_estadoTurnoID,
                        principalTable: "Estado_turno",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turno_PacienteXObraSocial_IdPacienteIdPersona",
                        column: x => x.IdPacienteIdPersona,
                        principalTable: "PacienteXObraSocial",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turno_ProfesionalXEspecialidad_IdProfesionalIdPersona",
                        column: x => x.IdProfesionalIdPersona,
                        principalTable: "ProfesionalXEspecialidad",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turno_Tipo_consulta_Id_tipoConsultaID",
                        column: x => x.Id_tipoConsultaID,
                        principalTable: "Tipo_consulta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turno_Id_estadoTurnoID",
                table: "Turno",
                column: "Id_estadoTurnoID");

            migrationBuilder.CreateIndex(
                name: "IX_Turno_Id_tipoConsultaID",
                table: "Turno",
                column: "Id_tipoConsultaID");

            migrationBuilder.CreateIndex(
                name: "IX_Turno_IdPacienteIdPersona",
                table: "Turno",
                column: "IdPacienteIdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Turno_IdProfesionalIdPersona",
                table: "Turno",
                column: "IdProfesionalIdPersona");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turno");

            migrationBuilder.DropTable(
                name: "Estado_turno");

            migrationBuilder.DropTable(
                name: "Tipo_consulta");
        }
    }
}
