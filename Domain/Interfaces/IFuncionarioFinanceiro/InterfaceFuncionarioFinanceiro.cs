using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IFuncionarioFinanceiro
{
    public interface InterfaceFuncionarioFinanceiro : InterfaceGeneric<FuncionarioFinanceiro>
    {
        Task<IList<FuncionarioFinanceiro>> ListaFuncionariosUsuario(string emailUsuario);
    }
}
