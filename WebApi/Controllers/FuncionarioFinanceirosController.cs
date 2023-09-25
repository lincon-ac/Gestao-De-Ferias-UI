using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IFuncionarioFinanceiro;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FuncionarioFinanceirosController : ControllerBase
    {
        private readonly InterfaceFuncionarioFinanceiro _InterfaceFuncionarioFinanceiro;
        private readonly IFuncionarioFinanceiroServico _IFuncionarioFinanceiroServico;
        public FuncionarioFinanceirosController(InterfaceFuncionarioFinanceiro InterfaceFuncionarioFinanceiro,
            IFuncionarioFinanceiroServico IFuncionarioFinanceiroServico)
        {
            _InterfaceFuncionarioFinanceiro = InterfaceFuncionarioFinanceiro;
            _IFuncionarioFinanceiroServico = IFuncionarioFinanceiroServico;
        }

        [HttpGet("/api/ListaFuncionariosUsuario")]
        [Produces("application/json")]
        public async Task<object> ListaFuncionariosUsuario(string emailUsuario)
        {
            return await _InterfaceFuncionarioFinanceiro.ListaFuncionariosUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarFuncionarioFinanceiro")]
        [Produces("application/json")]
        public async Task<object> AdicionarFuncionarioFinanceiro(FuncionarioFinanceiro funcionarioFinanceiro)
        {
            await _IFuncionarioFinanceiroServico.AdicionarFuncionarioFinanceiro(funcionarioFinanceiro);

            return funcionarioFinanceiro;
        }

        [HttpPut("/api/AtualizarFuncionarioFinanceiro")]
        [Produces("application/json")]
        public async Task<object> AtualizarFuncionarioFinanceiro(FuncionarioFinanceiro funcionarioFinanceiro)
        {
            await _IFuncionarioFinanceiroServico.AtualizarFuncionarioFinanceiro(funcionarioFinanceiro);

            return Task.FromResult(funcionarioFinanceiro);
        }


        [HttpGet("/api/ObterFuncionarioFinanceiro")]
        [Produces("application/json")]
        public async Task<object> ObterFuncionarioFinanceiro(int id)
        {
            return await _InterfaceFuncionarioFinanceiro.GetEntityById(id);
        }


        [HttpDelete("/api/DeleteFuncionarioFinanceiro")]
        [Produces("application/json")]
        public async Task<object> DeleteFuncionarioFinanceiro(int id)
        {
            try
            {
                var funcionarioFinanceiro = await _InterfaceFuncionarioFinanceiro.GetEntityById(id);

                await _InterfaceFuncionarioFinanceiro.Delete(funcionarioFinanceiro);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


    }
}
