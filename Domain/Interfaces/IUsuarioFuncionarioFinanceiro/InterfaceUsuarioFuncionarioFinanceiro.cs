using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IUsuarioFuncionarioFinanceiro
{
    public interface InterfaceUsuarioFuncionarioFinanceiro : InterfaceGeneric<UsuarioFuncionarioFinanceiro>
    {
        Task<IList<UsuarioFuncionarioFinanceiro>> ListarUsuariosFuncionario(int IdFuncionario);

        Task RemoveUsuarios(List<UsuarioFuncionarioFinanceiro> usuarios);

        Task<UsuarioFuncionarioFinanceiro> ObterUsuarioPorEmail(string emailUsuario);
    }
}
