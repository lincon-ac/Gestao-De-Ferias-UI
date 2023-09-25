using Domain.Interfaces.IFuncionarioFinanceiro;
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
    public class RepositorioFuncionarioFinanceiro : RepositoryGenerics<FuncionarioFinanceiro>, InterfaceFuncionarioFinanceiro
    {

        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioFuncionarioFinanceiro()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<FuncionarioFinanceiro>> ListaFuncionariosUsuario(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                   (from s in banco.FuncionarioFinanceiro 
                    join us in banco.UsuarioFuncionarioFinanceiro on s.Id equals us.IdFuncionario                   
                    where us.EmailUsuario.Equals(emailUsuario) 
                    select s).AsNoTracking().ToListAsync();
            }
        }
    }
}
