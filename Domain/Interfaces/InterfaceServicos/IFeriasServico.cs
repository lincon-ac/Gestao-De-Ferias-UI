using Entities.Entidades;
using Entities.ViewModels;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IFeriasServico
    {
        Task AdicionarFerias(FeriasFuncionarioViewModel despesa);
        Task AtualizarFerias(FeriasFuncionarioViewModel despesa);
        Task<object> CarregaGraficos(string emailUsuario);
    }
}
