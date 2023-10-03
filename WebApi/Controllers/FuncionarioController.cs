using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.IFuncionario;
using Entities.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FuncionarioController : ControllerBase
    {
        private readonly InterfaceFuncionario _InterfaceFuncionario;
        private readonly IFuncionarioServico _IFuncionarioServico;
        public FuncionarioController(InterfaceFuncionario InterfaceFuncionario,
            IFuncionarioServico IFuncionarioServico)
        {
            _InterfaceFuncionario = InterfaceFuncionario;
            _IFuncionarioServico = IFuncionarioServico;
        }

        [HttpGet("/api/ListaFuncionariosUsuario")]
        [Produces("application/json")]
        public async Task<object> ListaFuncionariosUsuario(string emailUsuario)
        {
            return await _InterfaceFuncionario.ListaFuncionariosUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarFuncionarioFinanceiro")]
        [Produces("application/json")]
        public async Task<Funcionario> AdicionarFuncionarioFinanceiro(FuncionarioViewModel funcionario)
        {
            Funcionario saveFuncionario = await _IFuncionarioServico.AdicionarFuncionarioFinanceiro(new Funcionario()
            {
                NomePropriedade = funcionario.NomePropriedade,
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Ano = funcionario.Ano,
                Mes = funcionario.Mes,
                Matricula = funcionario.Matricula,
                DiaFechamento = funcionario.DiaFechamento,
                GerarCopiaFerias = funcionario.GerarCopiaFerias,
                DepartamentoId = funcionario.DepartamentoId,
                Departamento = null,
                mensagem = null,
            });

            return saveFuncionario;
        }

        [HttpPut("/api/AtualizarFuncionarioFinanceiro")]
        [Produces("application/json")]
        public async Task<object> AtualizarFuncionarioFinanceiro(FuncionarioViewModel funcionario)
        {
            await _IFuncionarioServico.AtualizarFuncionarioFinanceiro(new Funcionario()
            {
                NomePropriedade = funcionario.NomePropriedade,
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Ano = funcionario.Ano,
                Mes = funcionario.Mes,
                Matricula = funcionario.Matricula,
                DiaFechamento = funcionario.DiaFechamento,
                GerarCopiaFerias = funcionario.GerarCopiaFerias,
                DepartamentoId = funcionario.DepartamentoId,
                Departamento = null,
                mensagem = null,
            });

            return Task.FromResult(funcionario);
        }


        [HttpGet("/api/ObterFuncionarioFinanceiro")]
        [Produces("application/json")]
        public async Task<object> ObterFuncionarioFinanceiro(int id)
        {
            return await _InterfaceFuncionario.GetEntityById(id);
        }


        [HttpDelete("/api/DeleteFuncionarioFinanceiro")]
        [Produces("application/json")]
        public async Task<object> DeleteFuncionarioFinanceiro(int id)
        {
            try
            {
                var funcionario = await _InterfaceFuncionario.GetEntityById(id);

                await _InterfaceFuncionario.Delete(funcionario);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
