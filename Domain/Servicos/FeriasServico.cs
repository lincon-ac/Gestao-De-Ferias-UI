using Domain.Interfaces.IFerias;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class FeriasServico : IFeriasServico
    {

        private readonly InterfaceFerias _InterfaceFerias;
        public FeriasServico(InterfaceFerias InterfaceFerias)
        {
            _InterfaceFerias = InterfaceFerias;
        }

        public async Task AdicionarFerias(Ferias despesa)
        {
            var data = DateTime.UtcNow;
            despesa.DataCadastro = data;
            despesa.Ano = data.Year;
            despesa.Mes = data.Month;

            var valido = despesa.ValidarPropriedadeString(despesa.Nome, "Nome");
            if (valido)
                await _InterfaceFerias.Add(despesa);

        }

        public async Task AtualizarFerias(Ferias despesa)
        {
            var data = DateTime.UtcNow;
            despesa.DataAlteracao = data;

            if (despesa.Pago)
            {
                despesa.DataPagamento = data;
            }

            var valido = despesa.ValidarPropriedadeString(despesa.Nome, "Nome");
            if (valido)
                await _InterfaceFerias.Update(despesa);
        }

        public async Task<object> CarregaGraficos(string emailUsuario)
        {
            var despesasUsuario = await _InterfaceFerias.ListarFeriassUsuario(emailUsuario);
            var despesasAnterior = await _InterfaceFerias.ListarFeriassUsuarioNaoPagasMesesAnterior(emailUsuario);

            var despesas_naoPagasMesesAnteriores = despesasAnterior.Any() ?
                despesasAnterior.ToList().Sum(x => x.Valor) : 0;

            var despesas_pagas = despesasUsuario.Where(d => d.Pago && d.TipoFerias == Entities.Enums.EnumTipoFerias.Contas)
                .Sum(x => x.Valor);

            var despesas_pendentes = despesasUsuario.Where(d => !d.Pago && d.TipoFerias == Entities.Enums.EnumTipoFerias.Contas)
                .Sum(x => x.Valor);

            var investimentos = despesasUsuario.Where(d => d.TipoFerias == Entities.Enums.EnumTipoFerias.Investimento)
                .Sum(x => x.Valor);

            return new
            {
                sucesso = "OK",
                despesas_pagas = despesas_pagas,
                despesas_pendentes = despesas_pendentes,
                despesas_naoPagasMesesAnteriores = despesas_naoPagasMesesAnteriores,
                investimentos = investimentos
            };

        }
    }
}
