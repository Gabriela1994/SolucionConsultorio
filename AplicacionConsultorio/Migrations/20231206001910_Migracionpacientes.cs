using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionConsultorio.Migrations
{
    /// <inheritdoc />
    public partial class Migracionpacientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persona_ObraSocial_ObraSocialID",
                table: "Persona");

            migrationBuilder.DropIndex(
                name: "IX_Persona_ObraSocialID",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "ObraSocialID",
                table: "Persona");

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaID = table.Column<int>(type: "int", nullable: false),
                    ObraSocialID = table.Column<int>(type: "int", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paciente_ObraSocial_ObraSocialID",
                        column: x => x.ObraSocialID,
                        principalTable: "ObraSocial",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paciente_Persona_PersonaID",
                        column: x => x.PersonaID,
                        principalTable: "Persona",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_ObraSocialID",
                table: "Paciente",
                column: "ObraSocialID");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_PersonaID",
                table: "Paciente",
                column: "PersonaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.AddColumn<int>(
                name: "ObraSocialID",
                table: "Persona",
                type: "int",
                nullable: true);

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
    }
}
