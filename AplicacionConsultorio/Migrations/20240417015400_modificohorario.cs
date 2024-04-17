using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class modificohorario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turno_Horario_HorarioId",
                table: "Turno");

            migrationBuilder.AlterColumn<int>(
                name: "HorarioId",
                table: "Turno",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<long>(
                name: "Horario",
                table: "Turno",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_Turno_Horario_HorarioId",
                table: "Turno",
                column: "HorarioId",
                principalTable: "Horario",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turno_Horario_HorarioId",
                table: "Turno");

            migrationBuilder.DropColumn(
                name: "Horario",
                table: "Turno");

            migrationBuilder.AlterColumn<int>(
                name: "HorarioId",
                table: "Turno",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Turno_Horario_HorarioId",
                table: "Turno",
                column: "HorarioId",
                principalTable: "Horario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
