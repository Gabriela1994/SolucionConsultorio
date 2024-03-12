using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class ArreglarTablaSateliteTipoConsulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turno_Estado_turno_Estado_turnoID",
                table: "Turno");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estado_turno",
                table: "Estado_turno");

            migrationBuilder.RenameTable(
                name: "Estado_turno",
                newName: "EstadoTurno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstadoTurno",
                table: "EstadoTurno",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Turno_EstadoTurno_Estado_turnoID",
                table: "Turno",
                column: "Estado_turnoID",
                principalTable: "EstadoTurno",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turno_EstadoTurno_Estado_turnoID",
                table: "Turno");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstadoTurno",
                table: "EstadoTurno");

            migrationBuilder.RenameTable(
                name: "EstadoTurno",
                newName: "Estado_turno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estado_turno",
                table: "Estado_turno",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Turno_Estado_turno_Estado_turnoID",
                table: "Turno",
                column: "Estado_turnoID",
                principalTable: "Estado_turno",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
