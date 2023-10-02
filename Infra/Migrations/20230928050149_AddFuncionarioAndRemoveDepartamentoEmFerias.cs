using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddFuncionarioAndRemoveDepartamentoEmFerias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdDepartamento",
                table: "Ferias");

            migrationBuilder.CreateIndex(
                name: "IX_Ferias_IdFuncionario",
                table: "Ferias",
                column: "IdFuncionario");

            migrationBuilder.AddForeignKey(
                name: "FK_Ferias_Funcionario_IdFuncionario",
                table: "Ferias",
                column: "IdFuncionario",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ferias_Funcionario_IdFuncionario",
                table: "Ferias");

            migrationBuilder.DropIndex(
                name: "IX_Ferias_IdFuncionario",
                table: "Ferias");

            migrationBuilder.AddColumn<int>(
                name: "IdDepartamento",
                table: "Ferias",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 1);
        }
    }
}
