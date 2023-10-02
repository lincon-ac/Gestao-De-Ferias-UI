using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarFuncionarioEmFerias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Ferias");

            migrationBuilder.AddColumn<int>(
                name: "IdFuncionario",
                table: "Ferias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdFuncionario",
                table: "Ferias");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Ferias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
