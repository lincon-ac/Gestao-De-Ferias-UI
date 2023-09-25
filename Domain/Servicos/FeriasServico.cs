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

        public async Task AdicionarFerias(Ferias ferias)
        {
            var data = DateTime.UtcNow;
            ferias.DataCadastro = data;
            ferias.Ano = data.Year;
            ferias.Mes = data.Month;

            var valido = ferias.ValidarPropriedadeString(ferias.Nome, "Nome");
            if (valido)
                await _InterfaceFerias.Add(ferias);

        }

        public async Task AtualizarFerias(Ferias ferias)
        {
            var data = DateTime.UtcNow;
            ferias.DataAlteracao = data;

            if (ferias.Pago)
            {
                ferias.DataPagamento = data;
            }

            var valido = ferias.ValidarPropriedadeString(ferias.Nome, "Nome");
            if (valido)
                await _InterfaceFerias.Update(ferias);
        }

        public async Task<object> CarregaGraficos(string emailUsuario)
        {
            var feriassUsuario = await _InterfaceFerias.ListarFeriassUsuario(emailUsuario);
            var feriassAnterior = await _InterfaceFerias.ListarFeriassUsuarioNaoPagasMesesAnterior(emailUsuario);

            var feriass_naoPagasMesesAnteriores = feriassAnterior.Any() ?
                feriassAnterior.ToList().Sum(x => x.Valor) : 0;

            var feriass_pagas = feriassUsuario.Where(d => d.Pago && d.TipoFerias == Entities.Enums.EnumTipoFerias.Contas)
                .Sum(x => x.Valor);

            var feriass_pendentes = feriassUsuario.Where(d => !d.Pago && d.TipoFerias == Entities.Enums.EnumTipoFerias.Contas)
                .Sum(x => x.Valor);

            var investimentos = feriassUsuario.Where(d => d.TipoFerias == Entities.Enums.EnumTipoFerias.Investimento)
                .Sum(x => x.Valor);

            return new
            {
                sucesso = "OK",
                feriass_pagas = feriass_pagas,
                feriass_pendentes = feriass_pendentes,
                feriass_naoPagasMesesAnteriores = feriass_naoPagasMesesAnteriores,
                investimentos = investimentos
            };

        }
    }
}
