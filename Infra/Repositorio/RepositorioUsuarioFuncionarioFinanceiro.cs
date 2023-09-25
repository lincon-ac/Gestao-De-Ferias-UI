using Domain.Interfaces.IUsuarioFuncionarioFinanceiro;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class RepositorioUsuarioFuncionarioFinanceiro : RepositoryGenerics<UsuarioFuncionarioFinanceiro>, InterfaceUsuarioFuncionarioFinanceiro
    {

        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioUsuarioFuncionarioFinanceiro()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<UsuarioFuncionarioFinanceiro>> ListarUsuariosFuncionario(int IdFuncionario)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    banco.UsuarioFuncionarioFinanceiro
                    .Where(s => s.IdFuncionario == IdFuncionario).AsNoTracking()
                    .ToListAsync();
            }
        }

        public async Task<UsuarioFuncionarioFinanceiro> ObterUsuarioPorEmail(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    banco.UsuarioFuncionarioFinanceiro.AsNoTracking().FirstOrDefaultAsync(x => x.EmailUsuario.Equals(emailUsuario));
            }
        }

        public async Task RemoveUsuarios(List<UsuarioFuncionarioFinanceiro> usuarios)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                banco.UsuarioFuncionarioFinanceiro
               .RemoveRange(usuarios);

                await banco.SaveChangesAsync();
            }
        }
    }
}
