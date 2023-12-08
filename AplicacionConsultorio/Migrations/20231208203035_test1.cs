using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PacienteXObraSocial_IdObraSocial",
                table: "PacienteXObraSocial");

            migrationBuilder.AlterColumn<int>(
                name: "IdPersona",
                table: "PacienteXObraSocial",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdObraSocial",
                table: "PacienteXObraSocial",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PacienteXObraSocial",
                table: "PacienteXObraSocial",
                columns: new[] { "IdObraSocial", "IdPersona" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PacienteXObraSocial",
                table: "PacienteXObraSocial");

            migrationBuilder.AlterColumn<int>(
                name: "IdPersona",
                table: "PacienteXObraSocial",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdObraSocial",
                table: "PacienteXObraSocial",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteXObraSocial_IdObraSocial",
                table: "PacienteXObraSocial",
                column: "IdObraSocial");
        }
    }
}
