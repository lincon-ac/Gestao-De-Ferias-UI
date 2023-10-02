using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class MudancaNomeEntidadeFuncionarioFinanceiroParaFuncionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioFuncionarioFinanceiro_FuncionarioFinanceiro_IdFuncionario",
                table: "UsuarioFuncionarioFinanceiro");

            migrationBuilder.DropTable(
                name: "FuncionarioFinanceiro");

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    DiaFechamento = table.Column<int>(type: "int", nullable: false),
                    GerarCopiaFerias = table.Column<bool>(type: "bit", nullable: false),
                    MesCopia = table.Column<int>(type: "int", nullable: false),
                    AnoCopia = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioFuncionarioFinanceiro_Funcionario_IdFuncionario",
                table: "UsuarioFuncionarioFinanceiro",
                column: "IdFuncionario",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioFuncionarioFinanceiro_Funcionario_IdFuncionario",
                table: "UsuarioFuncionarioFinanceiro");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.CreateTable(
                name: "FuncionarioFinanceiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    AnoCopia = table.Column<int>(type: "int", nullable: false),
                    DiaFechamento = table.Column<int>(type: "int", nullable: false),
                    GerarCopiaFerias = table.Column<bool>(type: "bit", nullable: false),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    MesCopia = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioFinanceiro", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioFuncionarioFinanceiro_FuncionarioFinanceiro_IdFuncionario",
                table: "UsuarioFuncionarioFinanceiro",
                column: "IdFuncionario",
                principalTable: "FuncionarioFinanceiro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
