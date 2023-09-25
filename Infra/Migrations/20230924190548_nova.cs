using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class nova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamento_FuncionarioFinanceiro_IdFuncionario",
                table: "Departamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Ferias_Departamento_IdDepartamento",
                table: "Ferias");

            migrationBuilder.DropIndex(
                name: "IX_Ferias_IdDepartamento",
                table: "Ferias");

            migrationBuilder.DropIndex(
                name: "IX_Departamento_IdFuncionario",
                table: "Departamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Ferias_IdDepartamento",
                table: "Ferias",
                column: "IdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_IdFuncionario",
                table: "Departamento",
                column: "IdFuncionario");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamento_FuncionarioFinanceiro_IdFuncionario",
                table: "Departamento",
                column: "IdFuncionario",
                principalTable: "FuncionarioFinanceiro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ferias_Departamento_IdDepartamento",
                table: "Ferias",
                column: "IdDepartamento",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
