using Entities.Entidades;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IFuncionarioServico
    {
        Task<Funcionario> AdicionarFuncionarioFinanceiro(Funcionario funcionario);
        Task AtualizarFuncionarioFinanceiro(Funcionario funcionario);
    }
}
