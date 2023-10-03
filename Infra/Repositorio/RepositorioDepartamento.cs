using Domain.Interfaces.IDepartamento;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

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
                    (from s in banco.Departamento
                     select s).AsNoTracking().ToListAsync();
            }
        }
    }
}
