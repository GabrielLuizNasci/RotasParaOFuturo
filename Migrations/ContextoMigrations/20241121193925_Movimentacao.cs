using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotasParaOFuturo.Migrations
{
    /// <inheritdoc />
    public partial class Movimentacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Faltas",
                table: "Matriculas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Presenca",
                table: "Matriculas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalAulas",
                table: "Atividades",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Faltas",
                table: "Matriculas");

            migrationBuilder.DropColumn(
                name: "Presenca",
                table: "Matriculas");

            migrationBuilder.DropColumn(
                name: "TotalAulas",
                table: "Atividades");
        }
    }
}
