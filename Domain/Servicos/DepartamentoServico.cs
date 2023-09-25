using Domain.Interfaces.IDepartamento;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class DepartamentoServico : IDepartamentoServico
    {

        private readonly InterfaceDepartamento _interfaceDepartamento;
        public DepartamentoServico(InterfaceDepartamento interfaceDepartamento)
        {
            _interfaceDepartamento = interfaceDepartamento;
        }

        public async Task AdicionarDepartamento(Departamento catagoria)
        {
            var valido = catagoria.ValidarPropriedadeString(catagoria.Nome, "Nome");
            if (valido)
                await _interfaceDepartamento.Add(catagoria);
        }

        public async Task AtualizarDepartamento(Departamento catagoria)
        {
            var valido = catagoria.ValidarPropriedadeString(catagoria.Nome, "Nome");
            if (valido)
                await _interfaceDepartamento.Update(catagoria);
        }
    }
}
