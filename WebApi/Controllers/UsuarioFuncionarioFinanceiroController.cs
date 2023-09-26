using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuarioFuncionarioFinanceiro;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioFuncionarioFinanceiroController : ControllerBase
    {
        private readonly InterfaceUsuarioFuncionarioFinanceiro _InterfaceUsuarioFuncionarioFinanceiro;
        private readonly IUsuarioFuncionarioFinanceiroServico _IUsuarioFuncionarioFinanceiroServico;
        private object matriculaFuncionario;

        public UsuarioFuncionarioFinanceiroController(InterfaceUsuarioFuncionarioFinanceiro InterfaceUsuarioFuncionarioFinanceiro,
            IUsuarioFuncionarioFinanceiroServico IUsuarioFuncionarioFinanceiroServico)
        {
            _InterfaceUsuarioFuncionarioFinanceiro = InterfaceUsuarioFuncionarioFinanceiro;
            _IUsuarioFuncionarioFinanceiroServico = IUsuarioFuncionarioFinanceiroServico;
        }

        [HttpGet("/api/ListarUsuariosFuncionario")]
        [Produces("application/json")]
        public async Task<object> ListaFuncionariosUsuario(int idFuncionario)
        {
            return await _InterfaceUsuarioFuncionarioFinanceiro.ListarUsuariosFuncionario(idFuncionario);
        }


        [HttpPost("/api/CadastrarUsuarioNoFuncionario")]
        [Produces("application/json")]
        public async Task<object> CadastrarUsuarioNoFuncionario(int idFuncionario, string emailUsuario)
        {
            try
            {
                await _IUsuarioFuncionarioFinanceiroServico.CadastrarUsuarioNoFuncionario(
                   new UsuarioFuncionarioFinanceiro
                   {
                       IdFuncionario = idFuncionario,
                       EmailUsuario = emailUsuario,
                       Administrador = false,
                       FuncionarioAtual = true
                   });
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);

        }

        [HttpDelete("/api/DeleteUsuarioFuncionarioFinanceiro")]
        [Produces("application/json")]
        public async Task<object> DeleteUsuarioFuncionarioFinanceiro(int id)
        {
            try
            {
                var usuarioFuncionarioFinanceiro = await _InterfaceUsuarioFuncionarioFinanceiro.GetEntityById(id);

                await _InterfaceUsuarioFuncionarioFinanceiro.Delete(usuarioFuncionarioFinanceiro);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);

        }
    }
}
