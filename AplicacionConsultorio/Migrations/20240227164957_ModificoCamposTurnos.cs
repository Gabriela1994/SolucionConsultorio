using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class ModificoCamposTurnos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turno_Estado_turno_Id_estadoTurnoID",
                table: "Turno");

            migrationBuilder.DropForeignKey(
                name: "FK_Turno_PacienteXObraSocial_IdPacienteIdPersona",
                table: "Turno");

            migrationBuilder.DropForeignKey(
                name: "FK_Turno_ProfesionalXEspecialidad_IdProfesionalIdPersona",
                table: "Turno");

            migrationBuilder.DropForeignKey(
                name: "FK_Turno_Tipo_consulta_Id_tipoConsultaID",
                table: "Turno");

            migrationBuilder.RenameColumn(
                name: "Id_tipoConsultaID",
                table: "Turno",
                newName: "Tipo_consultaID");

            migrationBuilder.RenameColumn(
                name: "Id_estadoTurnoID",
                table: "Turno",
                newName: "ProfesionalIdPersona");

            migrationBuilder.RenameColumn(
                name: "IdProfesionalIdPersona",
                table: "Turno",
                newName: "PacienteIdPersona");

            migrationBuilder.RenameColumn(
                name: "IdPacienteIdPersona",
                table: "Turno",
                newName: "Estado_turnoID");

            migrationBuilder.RenameIndex(
                name: "IX_Turno_IdProfesionalIdPersona",
                table: "Turno",
                newName: "IX_Turno_PacienteIdPersona");

            migrationBuilder.RenameIndex(
                name: "IX_Turno_IdPacienteIdPersona",
                table: "Turno",
                newName: "IX_Turno_Estado_turnoID");

            migrationBuilder.RenameIndex(
                name: "IX_Turno_Id_tipoConsultaID",
                table: "Turno",
                newName: "IX_Turno_Tipo_consultaID");

            migrationBuilder.RenameIndex(
                name: "IX_Turno_Id_estadoTurnoID",
                table: "Turno",
                newName: "IX_Turno_ProfesionalIdPersona");

            migrationBuilder.AddForeignKey(
                name: "FK_Turno_Estado_turno_Estado_turnoID",
                table: "Turno",
                column: "Estado_turnoID",
                principalTable: "Estado_turno",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turno_PacienteXObraSocial_PacienteIdPersona",
                table: "Turno",
                column: "PacienteIdPersona",
                principalTable: "PacienteXObraSocial",
                principalColumn: "IdPersona",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turno_ProfesionalXEspecialidad_ProfesionalIdPersona",
                table: "Turno",
                column: "ProfesionalIdPersona",
                principalTable: "ProfesionalXEspecialidad",
                principalColumn: "IdPersona",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turno_Tipo_consulta_Tipo_consultaID",
                table: "Turno",
                column: "Tipo_consultaID",
                principalTable: "Tipo_consulta",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turno_Estado_turno_Estado_turnoID",
                table: "Turno");

            migrationBuilder.DropForeignKey(
                name: "FK_Turno_PacienteXObraSocial_PacienteIdPersona",
                table: "Turno");

            migrationBuilder.DropForeignKey(
                name: "FK_Turno_ProfesionalXEspecialidad_ProfesionalIdPersona",
                table: "Turno");

            migrationBuilder.DropForeignKey(
                name: "FK_Turno_Tipo_consulta_Tipo_consultaID",
                table: "Turno");

            migrationBuilder.RenameColumn(
                name: "Tipo_consultaID",
                table: "Turno",
                newName: "Id_tipoConsultaID");

            migrationBuilder.RenameColumn(
                name: "ProfesionalIdPersona",
                table: "Turno",
                newName: "Id_estadoTurnoID");

            migrationBuilder.RenameColumn(
                name: "PacienteIdPersona",
                table: "Turno",
                newName: "IdProfesionalIdPersona");

            migrationBuilder.RenameColumn(
                name: "Estado_turnoID",
                table: "Turno",
                newName: "IdPacienteIdPersona");

            migrationBuilder.RenameIndex(
                name: "IX_Turno_Tipo_consultaID",
                table: "Turno",
                newName: "IX_Turno_Id_tipoConsultaID");

            migrationBuilder.RenameIndex(
                name: "IX_Turno_ProfesionalIdPersona",
                table: "Turno",
                newName: "IX_Turno_Id_estadoTurnoID");

            migrationBuilder.RenameIndex(
                name: "IX_Turno_PacienteIdPersona",
                table: "Turno",
                newName: "IX_Turno_IdProfesionalIdPersona");

            migrationBuilder.RenameIndex(
                name: "IX_Turno_Estado_turnoID",
                table: "Turno",
                newName: "IX_Turno_IdPacienteIdPersona");

            migrationBuilder.AddForeignKey(
                name: "FK_Turno_Estado_turno_Id_estadoTurnoID",
                table: "Turno",
                column: "Id_estadoTurnoID",
                principalTable: "Estado_turno",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turno_PacienteXObraSocial_IdPacienteIdPersona",
                table: "Turno",
                column: "IdPacienteIdPersona",
                principalTable: "PacienteXObraSocial",
                principalColumn: "IdPersona",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turno_ProfesionalXEspecialidad_IdProfesionalIdPersona",
                table: "Turno",
                column: "IdProfesionalIdPersona",
                principalTable: "ProfesionalXEspecialidad",
                principalColumn: "IdPersona",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turno_Tipo_consulta_Id_tipoConsultaID",
                table: "Turno",
                column: "Id_tipoConsultaID",
                principalTable: "Tipo_consulta",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
