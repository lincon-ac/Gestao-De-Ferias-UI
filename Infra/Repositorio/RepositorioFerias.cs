using Domain.Interfaces.IFerias;
using Entities.Entidades;
using Entities.ViewModels;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioFerias : RepositoryGenerics<Ferias>, InterfaceFerias
    {

        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioFerias()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Ferias>> ListarFeriasUsuario(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                   (from s in banco.Funcionario
                    join d in banco.Ferias on s.Id equals d.FuncionarioId
                    select d
                ).Include(ferias => ferias.funcionario).AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<Ferias>> ListarFeriassUsuarioNaoPagasMesesAnterior(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                   (from s in banco.Funcionario
                    join d in banco.Ferias on s.Id equals d.FuncionarioId
                    where d.Mes < DateTime.Now.Month && !d.Pago
                    select d).AsNoTracking().ToListAsync();
            }
        }
    }
}
