using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuarioFuncionarioFinanceiro;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class UsuarioFuncionarioFinanceiroServico : IUsuarioFuncionarioFinanceiroServico
    {

        private readonly InterfaceUsuarioFuncionarioFinanceiro _interfaceUsuarioFuncionarioFinanceiro;

        public UsuarioFuncionarioFinanceiroServico(InterfaceUsuarioFuncionarioFinanceiro interfaceUsuarioFuncionarioFinanceiro)
        {
            _interfaceUsuarioFuncionarioFinanceiro = interfaceUsuarioFuncionarioFinanceiro;
        }

        public async Task CadastrarUsuarioNoFuncionario(UsuarioFuncionarioFinanceiro usuarioFuncionarioFinanceiro)
        {
            await _interfaceUsuarioFuncionarioFinanceiro.Add(usuarioFuncionarioFinanceiro);
        }
    }
}
