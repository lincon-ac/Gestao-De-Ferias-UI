using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IDepartamentoServico
    {
        Task AdicionarDepartamento(Departamento catagoria);
        Task AtualizarDepartamento(Departamento catagoria);
    }
}
