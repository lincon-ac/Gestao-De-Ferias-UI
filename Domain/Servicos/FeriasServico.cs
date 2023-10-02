using Domain.Interfaces.IFerias;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using Entities.ViewModels;

namespace Domain.Servicos
{
    public class FeriasServico : IFeriasServico
    {

        private readonly InterfaceFerias _InterfaceFerias;

        public FeriasServico(InterfaceFerias InterfaceFerias)
        {
            _InterfaceFerias = InterfaceFerias;
        }

        public async Task AdicionarFerias(FeriasFuncionarioViewModel ferias)
        {
            var data = DateTime.UtcNow;
            ferias.DataCadastro = data;
            ferias.Ano = data.Year;
            ferias.Mes = data.Month;

            await _InterfaceFerias.Add(new Ferias()
            {
                Mes = ferias.Mes,
                Ano = ferias.Ano,
                DataAlteracao = ferias.DataAlteracao,
                DataCadastro = ferias.DataCadastro,
                DataEncerramento = ferias.DataEncerramento,
                DataInicio = ferias.DataInicio,
                DataPagamento = ferias.DataPagamento,
                DataVencimento = ferias.DataVencimento,
                FeriasAntrasada = ferias.FeriasAntrasada,
                FuncionarioId = ferias.FuncionarioId,
                Pago = ferias.Pago,
                TipoFerias = ferias.TipoFerias,
                funcionario = null
            });
        }

        public async Task AtualizarFerias(FeriasFuncionarioViewModel ferias)
        {
            Ferias currentferias = await _InterfaceFerias.GetEntityById(ferias.Id);

            if (currentferias == null)
            {
                throw new Exception("Férias não encontrada");
            };

            DateTime data = DateTime.UtcNow;
            ferias.DataAlteracao = data;

            if (ferias.Pago)
            {
                ferias.DataPagamento = data;
            }

            await _InterfaceFerias.Update(new Ferias()
            {
                Id = ferias.Id,
                Mes = ferias.Mes,
                Ano = ferias.Ano,
                TipoFerias = ferias.TipoFerias,
                Pago = ferias.Pago,
                DataVencimento = ferias.DataVencimento,
                DataPagamento = ferias.DataPagamento,
                DataAlteracao = ferias.DataAlteracao,
                DataEncerramento = ferias.DataEncerramento,
                DataInicio = ferias.DataInicio,
                FeriasAntrasada = ferias.FeriasAntrasada,
                FuncionarioId = ferias.FuncionarioId,
                DataCadastro = ferias.DataCadastro,
                funcionario = null
            });
        }

        public async Task<object> CarregaGraficos(string emailUsuario)
        {
            //var despesasUsuario = await _InterfaceFerias.ListarFeriassUsuario(emailUsuario);
            //var despesasAnterior = await _InterfaceFerias.ListarFeriassUsuarioNaoPagasMesesAnterior(emailUsuario);

            //var despesas_naoPagasMesesAnteriores = despesasAnterior.Any() ?
            //    despesasAnterior.ToList().Sum(x => x.Valor) : 0;

            //var despesas_pagas = despesasUsuario.Where(d => d.Pago && d.TipoFerias == Entities.Enums.EnumTipoFerias.Contas)
            //    .Sum(x => x.Valor);

            //var despesas_pendentes = despesasUsuario.Where(d => !d.Pago && d.TipoFerias == Entities.Enums.EnumTipoFerias.Contas)
            //    .Sum(x => x.Valor);

            //var investimentos = despesasUsuario.Where(d => d.TipoFerias == Entities.Enums.EnumTipoFerias.Investimento)
            //    .Sum(x => x.Valor);

            return new
            {
                sucesso = "OK",
                //despesas_pagas = despesas_pagas,
                //despesas_pendentes = despesas_pendentes,
                //despesas_naoPagasMesesAnteriores = despesas_naoPagasMesesAnteriores,
                //investimentos = investimentos
            };

        }
    }
}
