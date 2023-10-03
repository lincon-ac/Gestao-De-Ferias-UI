using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces.IFuncionario
{
    public interface InterfaceFuncionario : InterfaceGeneric<Funcionario>
    {
        Task<Funcionario> AdicionarFuncionario(Funcionario funcionario);
        Task<IList<Funcionario>> ListaFuncionariosUsuario(string emailUsuario);
    }
}
