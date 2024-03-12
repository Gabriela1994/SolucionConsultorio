using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class AgregoHorarios6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HorarioId",
                table: "Turno",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hora = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turno_HorarioId",
                table: "Turno",
                column: "HorarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turno_Horario_HorarioId",
                table: "Turno",
                column: "HorarioId",
                principalTable: "Horario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turno_Horario_HorarioId",
                table: "Turno");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropIndex(
                name: "IX_Turno_HorarioId",
                table: "Turno");

            migrationBuilder.DropColumn(
                name: "HorarioId",
                table: "Turno");
        }
    }
}
