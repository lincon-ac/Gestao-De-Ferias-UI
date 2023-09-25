using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IFeriasServico
    {
        Task AdicionarFerias(Ferias ferias);
        Task AtualizarFerias(Ferias ferias);
        Task<object> CarregaGraficos(string emailUsuario);
    }
}
