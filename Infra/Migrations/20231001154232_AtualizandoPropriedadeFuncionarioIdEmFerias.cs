using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoPropriedadeFuncionarioIdEmFerias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ferias_Funcionario_funcionarioId",
                table: "Ferias");

            migrationBuilder.DropColumn(
                name: "IdFuncionario",
                table: "Ferias");

            migrationBuilder.RenameColumn(
                name: "funcionarioId",
                table: "Ferias",
                newName: "FuncionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Ferias_funcionarioId",
                table: "Ferias",
                newName: "IX_Ferias_FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ferias_Funcionario_FuncionarioId",
                table: "Ferias",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ferias_Funcionario_FuncionarioId",
                table: "Ferias");

            migrationBuilder.RenameColumn(
                name: "FuncionarioId",
                table: "Ferias",
                newName: "funcionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Ferias_FuncionarioId",
                table: "Ferias",
                newName: "IX_Ferias_funcionarioId");

            migrationBuilder.AddColumn<int>(
                name: "IdFuncionario",
                table: "Ferias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Ferias_Funcionario_funcionarioId",
                table: "Ferias",
                column: "funcionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
