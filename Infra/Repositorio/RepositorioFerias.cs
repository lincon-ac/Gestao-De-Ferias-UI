using Domain.Interfaces.IFerias;
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
    public class RepositorioFerias : RepositoryGenerics<Ferias>, InterfaceFerias
    {

        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioFerias()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Ferias>> ListarFeriassUsuario(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                   (from s in banco.FuncionarioFinanceiro
                    join c in banco.Departamento on s.Id equals c.IdFuncionario
                    join us in banco.UsuarioFuncionarioFinanceiro on s.Id equals us.IdFuncionario
                    join d in banco.Ferias on c.Id equals d.IdDepartamento
                    where us.EmailUsuario.Equals(emailUsuario) && s.Mes == d.Mes && s.Ano == d.Ano
                    select d).AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<Ferias>> ListarFeriassUsuarioNaoPagasMesesAnterior(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                   (from s in banco.FuncionarioFinanceiro
                    join c in banco.Departamento on s.Id equals c.IdFuncionario
                    join us in banco.UsuarioFuncionarioFinanceiro on s.Id equals us.IdFuncionario
                    join d in banco.Ferias on c.Id equals d.IdDepartamento
                    where us.EmailUsuario.Equals(emailUsuario) && d.Mes < DateTime.Now.Month && !d.Pago
                    select d).AsNoTracking().ToListAsync();
            }
        }
    }
}
