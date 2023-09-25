using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IFuncionarioFinanceiro;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public  class FuncionarioFinanceiroServico : IFuncionarioFinanceiroServico
    {
        private readonly InterfaceFuncionarioFinanceiro _interfaceFuncionarioFinanceiro;

        public FuncionarioFinanceiroServico(InterfaceFuncionarioFinanceiro interfaceFuncionarioFinanceiro)
        {
            _interfaceFuncionarioFinanceiro = interfaceFuncionarioFinanceiro;
        }

        public async Task AdicionarFuncionarioFinanceiro(FuncionarioFinanceiro funcionarioFinanceiro)
        {
             var valido = funcionarioFinanceiro.ValidarPropriedadeString(funcionarioFinanceiro.Nome, "Nome");

            if(valido)
            {
                var data = DateTime.Now;

                funcionarioFinanceiro.DiaFechamento = 1;
                funcionarioFinanceiro.Ano = data.Year;
                funcionarioFinanceiro.Mes = data.Month;
                funcionarioFinanceiro.AnoCopia = data.Year;
                funcionarioFinanceiro.MesCopia = data.Month;
                funcionarioFinanceiro.GerarCopiaFerias = true;

                await _interfaceFuncionarioFinanceiro.Add(funcionarioFinanceiro);
            }
        }

        public async Task AtualizarFuncionarioFinanceiro(FuncionarioFinanceiro funcionarioFinanceiro)
        {
            var valido = funcionarioFinanceiro.ValidarPropriedadeString(funcionarioFinanceiro.Nome, "Nome");

            if (valido)
            {
                funcionarioFinanceiro.DiaFechamento = 1;
                await _interfaceFuncionarioFinanceiro.Update(funcionarioFinanceiro);
            }
        }
    }
}
