using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class MigracionObraSocial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_cobertura",
                table: "Persona");

            migrationBuilder.AddColumn<bool>(
                name: "Cobertura_medica",
                table: "Persona",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ObraSocialID",
                table: "Persona",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ObraSocial",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero_afiliado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObraSocial", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persona_ObraSocialID",
                table: "Persona",
                column: "ObraSocialID");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_ObraSocial_ObraSocialID",
                table: "Persona",
                column: "ObraSocialID",
                principalTable: "ObraSocial",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persona_ObraSocial_ObraSocialID",
                table: "Persona");

            migrationBuilder.DropTable(
                name: "ObraSocial");

            migrationBuilder.DropIndex(
                name: "IX_Persona_ObraSocialID",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "Cobertura_medica",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "ObraSocialID",
                table: "Persona");

            migrationBuilder.AddColumn<int>(
                name: "Id_cobertura",
                table: "Persona",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
