using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces.IFerias
{
    public interface InterfaceFerias : InterfaceGeneric<Ferias>
    {
        Task<IList<Ferias>> ListarFeriasUsuario(string emailUsuario);

        Task<IList<Ferias>> ListarFeriassUsuarioNaoPagasMesesAnterior(string emailUsuario);
    }
}
