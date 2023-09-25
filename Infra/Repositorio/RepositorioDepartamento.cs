using Domain.Interfaces.IDepartamento;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class RepositorioDepartamento : RepositoryGenerics<Departamento>, InterfaceDepartamento
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioDepartamento()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Departamento>> ListarDepartamentosUsuario(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    (from s in banco.FuncionarioFinanceiro
                     join c in banco.Departamento on s.Id equals c.IdFuncionario
                     join us in banco.UsuarioFuncionarioFinanceiro on s.Id equals us.IdFuncionario
                     where us.EmailUsuario.Equals(emailUsuario) && us.FuncionarioAtual
                     select c).AsNoTracking().ToListAsync();
            }
        }
    }
}
