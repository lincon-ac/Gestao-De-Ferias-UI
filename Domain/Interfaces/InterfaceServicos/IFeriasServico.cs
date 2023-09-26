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
        Task AdicionarFerias(Ferias despesa);
        Task AtualizarFerias(Ferias despesa);
        Task<object> CarregaGraficos(string emailUsuario);
    }
}
