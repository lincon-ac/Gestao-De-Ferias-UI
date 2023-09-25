using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IFerias
{
    public interface InterfaceFerias : InterfaceGeneric<Ferias>
    {
        Task<IList<Ferias>> ListarFeriassUsuario(string emailUsuario);

        Task<IList<Ferias>> ListarFeriassUsuarioNaoPagasMesesAnterior(string emailUsuario);
    }
}
