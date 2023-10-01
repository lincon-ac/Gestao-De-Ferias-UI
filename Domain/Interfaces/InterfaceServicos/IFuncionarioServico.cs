using Entities.Entidades;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IFuncionarioServico
    {
        Task AdicionarFuncionarioFinanceiro(Funcionario funcionario);
        Task AtualizarFuncionarioFinanceiro(Funcionario funcionario);
    }
}
