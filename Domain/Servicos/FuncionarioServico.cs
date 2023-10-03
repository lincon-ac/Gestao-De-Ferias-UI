using Domain.Interfaces.IFuncionario;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;

namespace Domain.Servicos
{
    public class FuncionarioServico : IFuncionarioServico
    {
        private readonly InterfaceFuncionario _interfaceFuncionario;

        public FuncionarioServico(InterfaceFuncionario interfaceFuncionario)
        {
            _interfaceFuncionario = interfaceFuncionario;
        }

        public async Task<Funcionario> AdicionarFuncionarioFinanceiro(Funcionario funcionario)
        {
            var valido = funcionario.ValidarPropriedadeString(funcionario.Nome);

            if (valido)
            {
                var data = DateTime.Now;

                funcionario.DiaFechamento = 1;
                funcionario.Matricula = funcionario.Matricula;
                funcionario.Ano = data.Year;
                funcionario.Mes = data.Month;
                funcionario.GerarCopiaFerias = true;

                return await _interfaceFuncionario.AdicionarFuncionario(funcionario);
            }

            return null;
        }

        public async Task AtualizarFuncionarioFinanceiro(Funcionario funcionario)
        {
            Funcionario currentFuncionario = await _interfaceFuncionario.GetEntityById(funcionario.Id);

            if (currentFuncionario == null)
            {
                throw new Exception("FuncionarioFinanceiro não encontrado"); 
            };

            funcionario.DiaFechamento = 1;
            await _interfaceFuncionario.Update(funcionario);
        }
    }
}
