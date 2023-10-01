using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddPropriedadeNavegaoFuncionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ferias_Funcionario_IdFuncionario",
                table: "Ferias");

            migrationBuilder.DropIndex(
                name: "IX_Ferias_IdFuncionario",
                table: "Ferias");

            migrationBuilder.AddColumn<int>(
                name: "funcionarioId",
                table: "Ferias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ferias_funcionarioId",
                table: "Ferias",
                column: "funcionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ferias_Funcionario_funcionarioId",
                table: "Ferias",
                column: "funcionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ferias_Funcionario_funcionarioId",
                table: "Ferias");

            migrationBuilder.DropIndex(
                name: "IX_Ferias_funcionarioId",
                table: "Ferias");

            migrationBuilder.DropColumn(
                name: "funcionarioId",
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
    }
}
