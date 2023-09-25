using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IFuncionarioFinanceiroServico
    {
        Task AdicionarFuncionarioFinanceiro(FuncionarioFinanceiro funcionarioFinanceiro);
        Task AtualizarFuncionarioFinanceiro(FuncionarioFinanceiro funcionarioFinanceiro);
    }
}
