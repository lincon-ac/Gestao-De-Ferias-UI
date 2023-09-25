using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IDepartamento
{
    public interface InterfaceDepartamento : InterfaceGeneric<Departamento>
    {
        Task<IList<Departamento>> ListarDepartamentosUsuario(string emailUsuario);
    }
}
