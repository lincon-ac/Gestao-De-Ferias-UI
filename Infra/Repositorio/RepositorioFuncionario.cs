using Domain.Interfaces.IFuncionario;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioFuncionario : RepositoryGenerics<Funcionario>, InterfaceFuncionario
    {

        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioFuncionario()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Funcionario>> ListaFuncionariosUsuario(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                   (from s in banco.Funcionario 
                    join us in banco.UsuarioFuncionarioFinanceiro on s.Id equals us.IdFuncionario                   
                    where us.EmailUsuario.Equals(emailUsuario) 
                    select s).AsNoTracking().ToListAsync();
            }
        }
    }
}
