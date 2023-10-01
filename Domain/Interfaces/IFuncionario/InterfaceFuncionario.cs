using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces.IFuncionario
{
    public interface InterfaceFuncionario : InterfaceGeneric<Funcionario>
    {
        Task<IList<Funcionario>> ListaFuncionariosUsuario(string emailUsuario);
    }
}
